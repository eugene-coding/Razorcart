using Microsoft.EntityFrameworkCore;

using Razorcart.Data;
using Razorcart.Data.Models;
using Razorcart.Services;

namespace Razorcart.Areas.Admin.Services.Settings;

public class SettingService : Service, ISettingService
{
    private const string ItemsPerPageKey = "itemsPerPage";

    public SettingService(Context context) : base(context)
    {
    }

    public async Task<int> GetItemsPerPageAsync()
    {
        var pagination = await GetAsync(Code.Config, ItemsPerPageKey);

        if (int.TryParse(pagination, out int result))
        {
            return result;
        }

        return default;
    }

    public async Task SetItemsPerPageAsync(int pagination)
    {
        await SetAsync(Code.Config, ItemsPerPageKey, pagination.ToString());
    }

    private async Task<string> GetAsync(Code code, string key)
    {
        var result = await Context.Settings
            .Where(s => s.Area == Area.Admin && s.Code == code && s.Key == key)
            .Select(s => s.Value)
            .SingleOrDefaultAsync();

        return result ?? string.Empty;
    }

    private async Task SetAsync(Code code, string key, string value)
    {
        var setting = await Context.Settings
            .Where(s => s.Area == Area.Admin && s.Code == code && s.Key == key)
            .SingleOrDefaultAsync();

        if (setting is not null)
        {
            setting.Value = value;
        }
        else
        {
            setting = new Setting
            {
                Area = Area.Admin,
                Code = code,
                Key = key,
                Value = value
            };

            Context.Settings.Add(setting);
        }

        await Context.SaveChangesAsync();
    }
}
