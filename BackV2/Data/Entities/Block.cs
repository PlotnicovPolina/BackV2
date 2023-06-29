using System.Data;

namespace BackV2.Data.Entities
{
    public class Block:IEntity
    {
        public Block(int userId, DateTime endBlock) 
        {
            UserId = userId;
            EndBlock = endBlock;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime EndBlock { get; set; }
    }
}
