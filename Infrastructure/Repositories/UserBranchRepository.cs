using Microsoft.EntityFrameworkCore;
using Projeto_Aplicado_II_API.DTO;
using Projeto_Aplicado_II_API.Entities;
using Projeto_Aplicado_II_API.Infrastructure.Context;
using Projeto_Aplicado_II_API.Infrastructure.Interfaces;

namespace Projeto_Aplicado_II_API.Infrastructure.Repositories
{
    public class UserBranchRepository(MainDbContext db) : BaseRepository<UserBranch>(db), IUserBranchRepository
    {
        public async Task<List<UserBranchesDto>> GetUsersBranches(User user)
        {
            return await _dbSet
                .Include(ub => ub.Branch)
                    .ThenInclude(b => b!.BranchSize)
                .Where(ub => ub.UserId == user.Id && ub.Branch!.IsActive)
                .Select(ub => new UserBranchesDto
                {
                    Id = ub.Branch!.Id,
                    Name = ub.Branch.Name,
                    BranchSize = new BranchSizeDto
                    {
                        Description = ub.Branch.BranchSize!.Description
                    },
                    Street = ub.Branch.Street,
                    Number = ub.Branch.Number,
                    Neighborhood = ub.Branch.Neighborhood,
                    City = ub.Branch.City,
                    State = ub.Branch.State,
                    Country = ub.Branch.Country
                })
                .ToListAsync();
        }
    }
}
