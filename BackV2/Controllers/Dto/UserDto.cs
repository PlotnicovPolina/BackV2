namespace BackV2.Controllers.Dto
{
    public class UserDto : IDto
    {
        public string Name { get; set; }
        public bool IsBlocked { get; set; }
    }
}
