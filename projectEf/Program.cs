using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEf;
using projectEf.Models;

var builder = WebApplication.CreateBuilder(args);
//crear la base de datos
//builder.Services.AddDbContext<WorksContext>(date => 
//date.UseInMemoryDatabase("WorksDB"));
//conectar a la base con el string de coneccion.
builder.Services.AddSqlServer<WorksContext>(builder.Configuration.GetConnectionString("cnWorks"));



var app = builder.Build();

//mapeo y conecto
app.MapGet("/dbconection", ([FromServices] WorksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Data Base in Memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/works", ([FromServices] WorksContext dbContext) =>
{
    return Results.Ok(dbContext.Works.Include(p => p.Category));// condicion de filtrado .Where(p => p.WorkPriority == projectEf.Models.Work.Priority.Medium));
});


app.MapPost("/api/works", async ([FromServices] WorksContext dbContext, [FromBody] Work work) =>
{

    try
    {
        work.WorkId = Guid.NewGuid();
        work.CreationDate = DateTime.Now;
        await dbContext.AddAsync(work);

        await dbContext.SaveChangesAsync();
        // dos formas distintas await dbContext.Works.AddAsync(work);

    }
    catch (System.Exception)
    {
        return Results.Problem();
    }
    return Results.Ok();
});

app.MapPost("/api/works", async ([FromServices] WorksContext dbContext, [FromBody] Work work) =>
{

    try
    {
        work.WorkId = Guid.NewGuid();
        work.CreationDate = DateTime.Now;
        await dbContext.AddAsync(work);

        await dbContext.SaveChangesAsync();
        // dos formas distintas await dbContext.Works.AddAsync(work);

    }
    catch (System.Exception)
    {
        return Results.Problem();
    }
    return Results.Ok();
});

app.MapPut("/api/works/{idWork}", async ([FromServices] WorksContext dbContext, [FromBody] Work work,[FromRoute] Guid idWork) =>
{

    try
    {
        var actualyWork = dbContext.Works.Find(idWork);
        if (actualyWork is not null)
        {
            actualyWork.CategoryId = work.CategoryId;
            actualyWork.Title = work.Title;
            actualyWork.WorkPriority = work.WorkPriority;
            actualyWork.Description = work.Description;
            await dbContext.SaveChangesAsync();
        }

    
    }
    catch (System.Exception)
    {
        return Results.NotFound();
    }
    return Results.Ok();
});

app.MapDelete("/api/works/{idWork}", async ([FromServices] WorksContext dbContext,[FromRoute] Guid idWork)=>
{
    
        var actualyWork = dbContext.Works.Find(idWork);
        if(actualyWork is not null)
        {
            dbContext.Remove(actualyWork);
            await dbContext.SaveChangesAsync();
            return Results.Ok();
        }
    
    return Results.NotFound();


});




app.Run();

