using System.Diagnostics;
using BackV2.Data.Repositories;
using BackV2.InternalService.Interface;
using BackV2.Services.Interface;
using BackV2.BackV2Exception;
using Microsoft.AspNetCore.Identity;

namespace BackV2.InternalService
{
    internal class BlockService : IBlockService
    {
        private readonly EFCoreBlockRepository _blockRepository;
        private readonly IUserService _userService;
        private int _executionCount = 0;

        public BlockService(IUserService userService, EFCoreBlockRepository blockRepository )
        {
            _userService = userService;
            _blockRepository = blockRepository;
        }

        public async Task DoWork()
        {
            _executionCount++;
            var now = DateTime.UtcNow;

            try
            {
                var blockList = await _blockRepository.GetAllAsync();
                if (blockList == null)
                {
                    Debug.WriteLine("error");
                }

                foreach (var block in blockList)
                {
                    if (now < block.EndBlock)
                    {
                        await _userService.Unlock(block.UserId);
                        Debug.WriteLine($"Time: {now} || Unlock user ({block.UserId}) with endLock {block.EndBlock}");
                    }
                }

                Debug.WriteLine(
                    $"Scoped Processing Service is working. Count: {_executionCount}");

                throw new BaseException("Govno");
                    
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
