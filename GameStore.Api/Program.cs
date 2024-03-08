

// const string GetGameEndPointName = "GetGame";

// List<GameDto> games =[

//     new(
//         1,
//         "Street Fighter II",
//         "Fighting",
//         19.99m,
//         new DateOnly(1992, 7, 15)
//     ),
//     new  (
//         2,
//         "Final Fantasy XIV",
//         "Roleplaying",
//         59.99m,
//         new DateOnly(2010, 9, 30)
//     ),
//     new (
//         3,
//         "FIFA 23",
//         "Sports",
//         69.99m,
//         new DateOnly(2022, 9, 27)

//     )
// ];

// // minimal api application
// //GET games
// app.MapGet("games", ()=> games);

// // Get/games/1 
// app.MapGet("games/{id}", (int id)=>{ 
//     GameDto? game =games.Find(game => game.Id == id);
//     return game is null ? Results.NotFound() : Results.Ok(game);
//     })
//     .WithName(GetGameEndPointName);

// // POST /games

// app.MapPost("games", (CreateGameDto newGame)=>
// {
//     GameDto game = new(
//         games.Count + 1,
//         newGame.Name,
//         newGame.Genre,
//         newGame.Price,
//         newGame.ReleaseDate
//     );
//     games.Add(game);

//     return Results.CreatedAtRoute(GetGameEndPointName,new {id=game.Id}, game);
// });

// //PUT /games
// app.MapPut("games/{id}",(int id, UpdateGameDto updateGame)=> 
// {
//     var index = games.FindIndex(game => game.Id ==id);
//     if(index ==-1){
//         return Results.NotFound();
//     }

//     games[index] = new GameDto(
//         id,
//         updateGame.Name,
//         updateGame.Genre,
//         updateGame.Price,
//         updateGame.ReleaseDate
//     );
//     return Results.NoContent();
// });

// // Delete / games/1
// app.MapDelete("games/{id}", (int id)=>
// {
//     games.RemoveAll(game => game.Id == id);

//     return Results.NoContent();
// });

using GameStore.Api.Data;
using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Gamestore");
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
