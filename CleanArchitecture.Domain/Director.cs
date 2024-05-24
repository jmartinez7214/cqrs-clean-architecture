using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Director : BaseDomainModel
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int VideoId { get; set; }

        public virtual Video? Video { get; set; }
    }
}
