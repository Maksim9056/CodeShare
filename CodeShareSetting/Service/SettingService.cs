using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeShareSetting.Service
{
    public class SettingService : ISettingService
    {
        public readonly CodeShareDB _CodeShareDB;
        public SettingService(CodeShareDB codeShareDB)
        {
            _CodeShareDB = codeShareDB;
        }

        public async Task<Setting> Get(long Id_Code_Share)
        {
            try
            {
                var Seting = await _CodeShareDB.Setting.FirstOrDefaultAsync(u => u.SnippetId == Id_Code_Share);

               
                return Seting;
            }
            catch (Exception ex)
            {
                return new Setting();
            }
        }

        public async Task<Setting> Update(Setting setting)
        {
            try
            {   
                var Seting =  await _CodeShareDB.Setting.FirstOrDefaultAsync(u=>u.SnippetId == setting.SnippetId && u.SettingId == setting.SettingId);
                Seting.Prohibition = setting.Prohibition;
                Seting.Visibility_Setting = setting.Visibility_Setting;
                Seting.Block = setting.Block;
                Seting.Hide = setting.Hide;
                Seting.SettingId = setting.SettingId;
                Seting.SnippetId = setting.SnippetId;
                await _CodeShareDB.SaveChangesAsync();

                return Seting;
            }
            catch (Exception ex)
            {
                return new Setting();
            }
        }
    }
}
