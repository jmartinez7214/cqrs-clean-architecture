using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {

        }

        public async Task<Video> GetVideoByName(string videoName)
        {
            return await _context.Videos!.Where(x => x.Name == videoName).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _context.Videos!.Where(x => x.CreatedBy == username).ToListAsync();
        }
    }
}
