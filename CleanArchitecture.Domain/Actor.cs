using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Actor : BaseDomainModel
    {
        public Actor()
        {
            Videos = new HashSet<Video>();
        }

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
