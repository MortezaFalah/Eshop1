using Domain.Eshop.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IUserRoleRepository
    {
        public void InsertAsync(List<int> roleid, int userid);

        public void UpdateAsync(List<int> roleid, int userid);

        public Task<List<int>> GetUserRoleIdsAsync(int userid);

        Task  SaveAsync();
    }
}
