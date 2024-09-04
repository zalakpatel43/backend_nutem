using Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostCheckListService
    {
        Task<IEnumerable<PostCheckList>> GetAllPostCheckListAsync();
        Task<PostCheckListAddEdit> GetPostCheckListByIdAsync(long id);
        Task<long> AddPostCheckListAsync(PostCheckListAddEdit model, long user);
        Task<long> UpdatePostCheckListAsync(PostCheckListAddEdit model, long user);
        Task DeletePostCheckListAsync(long id, long user);
    }
}
