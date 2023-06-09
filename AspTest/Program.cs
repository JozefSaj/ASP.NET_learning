using AspTest.Models;
using AspTest.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<JsonFileProductService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    //endpoints.MapGet("/products", (context) =>
    //{
    //    var products = app.Services.GetRequiredService<JsonFileProductService>().GetProducts();
    //    Console.WriteLine(products);
    //    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
    //    context.Response.ContentType = "application/json";
    //    return context.Response.WriteAsJsonAsync(json);
    //});
});

app.MapRazorPages();

app.Run();



