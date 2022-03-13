using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Clients"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/Clients", async (AppDbContext dbContext) => await dbContext.Clients.ToListAsync());

app.MapGet("/Clients/{id}", async (int id, AppDbContext dbContext) => await dbContext.Clients.FirstOrDefaultAsync(app => app.Id == id));

app.MapPost("/Clients/{id}", async (Client client, AppDbContext dbContext) =>
{
    dbContext.Clients.Add(client);
    await dbContext.SaveChangesAsync();

    return client;
});

app.MapPut("/Clients/{id}", async (int id, Client client, AppDbContext dbContext) =>
{
    client.Id = id;
    dbContext.Entry(client).State = EntityState.Modified;
    await dbContext.SaveChangesAsync();
   
    return client;
});


app.MapDelete("/Clients/{id}", async (int id, AppDbContext dbContext) =>
{

    var client = await dbContext.Clients.FirstOrDefaultAsync(client => client.Id == id);

    if(client != null)
    {
        dbContext.Clients.Remove(client);
        await dbContext.SaveChangesAsync();
    }
    return;
});


app.UseSwaggerUI();

app.Run();
