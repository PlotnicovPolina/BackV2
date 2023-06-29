using Back.Data;
using BackV2.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackV2.Data.Repositories
{
    public class EFCoreBlockRepository : EFCoreRepository<Block, ApplicationDBContext>
    {
        public EFCoreBlockRepository (ApplicationDBContext dbContext): base(dbContext) { }

        public async Task<Block> GetBlockByUserIdAsync(int userId) => await dbContext.Blocks.FirstOrDefaultAsync(block => block.UserId == userId);

        public async Task UpdateEndLock(int id, DateTime newEndLock)
        {
            var block = await dbContext.Blocks.FindAsync(id);
            block.EndBlock = newEndLock;
            dbContext.SaveChanges();
        }
        

    }
}
