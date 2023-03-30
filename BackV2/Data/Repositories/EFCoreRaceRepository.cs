using Back.Data;
using Back.Data.Entities;

namespace BackV2.Data.Repositories
{
    public class EFCoreRaceRepository : EFCoreRepository<Race, ApplicationDBContext>
    {
        public EFCoreRaceRepository(ApplicationDBContext dBContext): base(dBContext) { }
    }
}
