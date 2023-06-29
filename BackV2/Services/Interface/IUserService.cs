namespace BackV2.Services.Interface
{
    public interface IUserService
    {
        Task<string> Block(int userId, DateTime endLock);
        Task Unlock(int userId);
    }
}
