﻿using Microsoft.EntityFrameworkCore;
namespace GameStore.Api.Data;

public static class DataExtentions
{
    public static async void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }
}
