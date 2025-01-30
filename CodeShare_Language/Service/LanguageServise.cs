using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeShare_Language.Service
{
    public class LanguageServise : ILanguage
    {
        public CodeShareDB db;

        public LanguageServise(CodeShareDB codeShareDB ) 
        {
            db = codeShareDB;



        }


        public async Task<Language> CreateAsync(Language language)
        {
            try
            {
                await db.Language.AddAsync(language);

              await  db.SaveChangesAsync();

                return language;
            }
            catch(Exception ex ) 
            {
                return new  Language();
            }


        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var Language = await db.Language.FirstOrDefaultAsync(u =>u.Id_Programming_language ==id);
                db.Language.Remove(Language);

                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Language>> GetAllAsync()
        {
            try
            {
                var Language = await db.Language.ToListAsync();


                return Language;
            }
            catch (Exception ex)
            {
                return new List<Language>();
            }
        }

        public async Task<Language> GetByIdAsync(long id)
        {
            try
            {
                var Language = await db.Language.FirstOrDefaultAsync(u => u.Id_Programming_language == id);


                return Language;
            }
            catch (Exception ex)
            {
                return new Language();
            }
        }

        public async Task<Language> UpdateAsync(Language language)
        {
            try
            {
                var Language = await db.Language.FirstOrDefaultAsync(u => u.Id_Programming_language == language.Id_Programming_language);

                db.Language.Update(Language);

                   await  db.SaveChangesAsync();
                return Language;
            }
            catch (Exception ex)
            {
                return new Language();
            }
        }
    }
}
