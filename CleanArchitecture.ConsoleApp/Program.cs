using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

await MultipleEntitiesQuery();
//await AddNewDirectorWithVideo();
//await AddNewActorWithVideo();
//await AddNewStreamerWithVideoId();
//await AddNewStreamerWithVideo();

Console.WriteLine("Presione cualquier tecla para terminar el proceso");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActors = await dbContext!.Videos!.Include(q => q.Actors).FirstOrDefaultAsync(q => q.Id == 1);

    //var actor = await dbContext!.Actors!.Select(q => q.Firstname).ToListAsync();

    var videoWithDirector = await dbContext!.Videos!
                            .Where(q => q.Director != null)
                            .Include(x => x.Director)
                            .Select(q =>
                                new
                                {
                                    Director_Fullname = $"{q.Director.Firstname} {q.Director.Lastname}",
                                    Movie = q.Name
                                }
                            )
                            .ToListAsync();

    foreach (var movie in videoWithDirector)
    {
        Console.WriteLine($"{movie.Movie} - {movie.Director_Fullname}");
    }
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Firstname = "Lorenzo",
        Lastname = "Basteri",
        VideoId = 1
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Firstname = "Brad",
        Lastname = "Pitt"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{
    var batmanForever = new Video
    {
        Name = "Batman Forever",
        StreamerId = 3,
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer
    {
        Name = "Pantaya"
    };

    var hungerGames = new Video
    {
        Name = "Hunger Games",
        Streamer = pantaya,
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}

async void AddNewRecords()
{
    Streamer streamer = new()
    {
        Name = "Amazon Prime",
        Url = "https://www.amazonprime.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
    {
    new Video { Name = "Mad Max", StreamerId = streamer.Id },
    new Video { Name = "Batman", StreamerId = streamer.Id },
    new Video { Name = "Crepusculo", StreamerId = streamer.Id },
    new Video { Name = "Citizen Kane", StreamerId = streamer.Id },
    };

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}