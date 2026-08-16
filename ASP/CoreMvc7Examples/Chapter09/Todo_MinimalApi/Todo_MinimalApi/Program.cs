using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

//DI Container
builder.Services.AddDbContext<TodoContext>(opt=>opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "Hi. This is Minimal APIs!");

//GET讀取
app.MapGet("/todoitems", async (TodoContext ctx)=> { 
    app.Logger.LogWarning(1234, "收到GET請求方法");
    await ctx.Todos.ToListAsync();
});

app.MapGet("/todoitems/complete", async (TodoContext ctx)=> await ctx.Todos.Where(i=>i.IsComplete).ToListAsync());
app.MapGet("/todoitems/{id}", async (int id, TodoContext ctx)=> 
    await  ctx.Todos.FindAsync(id) is Todo todo ? Results.Ok(todo) : Results.NotFound());

//POST新增
app.MapPost("/todoitems", async (Todo todo, TodoContext ctx) => 
{
    //System.Text.Json
    var options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin,  UnicodeRanges.CjkUnifiedIdeographs, UnicodeRanges.CjkUnifiedIdeographsExtensionA),
        WriteIndented = true
    };
    string json = JsonSerializer.Serialize(todo, options);

    //string json = Newtonsoft.Json.JsonConvert.SerializeObject(todo);

    app.Logger.LogWarning(12345, $"收到POST請求方法, Todo: {json}");

    ctx.Todos.Add(todo);
    await ctx.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

//PUT修改
app.MapPut("/todoitems/{id}", async (int id, Todo todo, TodoContext ctx) => 
{
    string json = Newtonsoft.Json.JsonConvert.SerializeObject(todo);
    app.Logger.LogWarning(12345, $"收到PUT請求方法, Todo: {json}");

    var todoItem = await ctx.Todos.FindAsync(id);

    if (todoItem is null) return Results.NotFound();

    todoItem.Name= todo.Name;
    todoItem.IsComplete = todo.IsComplete;

    await ctx.SaveChangesAsync();

    return Results.NoContent();
});

//DELETE刪除
app.MapDelete("/todoitems/{id}", async (int id, TodoContext ctx) => 
{
    app.Logger.LogWarning(12345, $"收到DELETE請求方法, id: {id}");

    if (await ctx.Todos.FindAsync(id) is Todo todo)
    {
        ctx.Todos.Remove(todo);
        await ctx.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});



app.Run();
