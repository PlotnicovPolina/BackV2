using Back.Data;
using Back.Data.Entities;
using BackV2.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackV2.Data.Repositories
{
    public class EFCoreRaceRepository : EFCoreRepository<Race, ApplicationDBContext>
    {
        public EFCoreRaceRepository(ApplicationDBContext dBContext): base(dBContext) { }

    }
}
