using Back.Data.Entities;

namespace BackV2.Controllers.Dto
{
    public class RaceDto : IDto
    {
        public string Name { get; set; }
        public int Lifespan { get; set; }
        public int SizeId { get; set; }
    }
}
