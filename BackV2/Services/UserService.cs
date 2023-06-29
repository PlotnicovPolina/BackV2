using BackV2.Data.Entities;
using BackV2.Data.Repositories;
using BackV2.Services.Interface;

namespace BackV2.Services
{
    public class UserService : IUserService
    {
        private readonly EFCoreUserRepository _userRepository;
        private readonly EFCoreBlockRepository _blockRepository;

        public UserService(EFCoreUserRepository userRepository, EFCoreBlockRepository blockRepository)
        {
            _userRepository = userRepository;
            _blockRepository = blockRepository;
        }

        public async Task<string> Block(int userId, DateTime endLock)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
                return "User doesn't exist";
            var now = DateTime.Now;
            if (user.IsBlocked == true)
            {
                var block = await _blockRepository.GetBlockByUserIdAsync(userId);
                if (block == null)
                    return "error";
                int compare = endLock.CompareTo(block.EndBlock);
                if (compare > 0)
                {
                    await _blockRepository.UpdateEndLock(block.Id, endLock);
                }
                return "success";

            }   
            else
            {
                await _userRepository.UpdateIsBlocked(user.Id, true);
                var block = new Block(userId, endLock);
                await _blockRepository.AddAsync(block);
                await _blockRepository.SaveAsync();
                return "success";
            }
        }

        public async Task Unlock(int blockId)
        {
            var block = await _blockRepository.GetAsync(blockId);
            if (block == null)
                Console.WriteLine("Block doesn't exist");
            await _userRepository.UpdateIsBlocked(block.UserId, false);
            await _blockRepository.DeleteAsync(blockId);
            await _blockRepository.SaveAsync();
        }
    }
}
