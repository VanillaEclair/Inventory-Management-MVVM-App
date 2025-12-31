using Mei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mei.Interfaces
{
    public interface IItemRepository
    {
        Task AddQueryAsync(AddItem item);
        Task UpdateQueryAsync(AddItem item);
        Task DeleteQueryAsync(int id);

        Task<IEnumerable<MainWindowModel>> SearchQuery(string item);

        Task<IEnumerable<MainWindowModel>> AsyncDataQuery();
        Task<IEnumerable<string>> GetCategoryAsync();
    }
}
