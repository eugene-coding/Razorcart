namespace Razorcart.Areas.Admin.Services.Settings;

public interface ISettingService
{
    Task<int> GetItemsPerPageAsync();
    Task SetItemsPerPageAsync(int pagination);
    Task<int> GetLanguageIdAsync();
}
