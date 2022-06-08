using Microsoft.Extensions.FileProviders;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PhysicalFileProvider fileProvider = new(Path.Combine(Directory.GetCurrentDirectory(),
    "StaticFiles/"));

app.UseStaticFiles(new StaticFileOptions {FileProvider = fileProvider, RequestPath = "/static-files"});
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
