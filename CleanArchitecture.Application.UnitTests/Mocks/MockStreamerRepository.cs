using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var streamers = fixture.CreateMany<Streamer>().ToList();

            streamers.Add(fixture.Build<Streamer>()
                .With(t => t.Id, 8001)
                .Without(t => t.Videos)
                .Create()
            );

            streamerDbContextFake.Streamers!.AddRange(streamers);
            streamerDbContextFake.SaveChanges();
        }
    }
}
