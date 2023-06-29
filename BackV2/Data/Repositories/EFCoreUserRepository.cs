
using Back.Data;
using BackV2.Data.Entities;

namespace BackV2.Data.Repositories
{
    public class EFCoreUserRepository:EFCoreRepository<User,ApplicationDBContext>
    {
        public EFCoreUserRepository(ApplicationDBContext dBContext) : base(dBContext) { }

        public async Task UpdateIsBlocked(int id, bool isBlocked)
        {
            var user = await dbContext.Users.FindAsync(id);
            user.IsBlocked = isBlocked;
            dbContext.SaveChanges();
        }
    }
}
