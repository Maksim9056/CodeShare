using CodeShare_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShare_Library.Abstractions
{
    public interface ILanguage
    {
        /// <summary>
        /// Создать новый язык программирования.
        /// </summary>
        Task<Language> CreateAsync(Language language);

        /// <summary>
        /// Получить язык программирования по Id.
        /// </summary>
        Task<Language> GetByIdAsync(long id);

        /// <summary>
        /// Получить все языки программирования.
        /// </summary>
        Task<List<Language>> GetAllAsync();

        /// <summary>
        /// Обновить данные о языке программирования.
        /// </summary>
        Task<Language> UpdateAsync(Language language);

        /// <summary>
        /// Удалить язык программирования по Id.
        /// </summary>
        Task<bool> DeleteAsync(long id);




    }
}
