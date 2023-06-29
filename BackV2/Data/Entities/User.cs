namespace BackV2.Data.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBlocked { get; set; }
    }
}
