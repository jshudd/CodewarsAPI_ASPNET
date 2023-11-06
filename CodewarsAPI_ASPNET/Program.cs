using CodewarsAPI_ASPNET;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IApiRepo, ApiRepo>();
builder.Services.AddTransient<ICsvRepo, CsvRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Suggested by ChatGPT to fix fileName being null; ignore green squigglies, still works
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "ViewGroup",
        pattern: "User/ViewGroup/{fileName}",
        defaults: new { controller = "User", action = "ViewGroup" }
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();

