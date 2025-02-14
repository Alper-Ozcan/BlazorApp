using BlazorServerApp.Components;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

/* builder.Services.AddHttpClient("MyClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5147");
}); */

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); 

//builder.Services.AddSingleton<MenuService>(); // MenuService'i kaydedin
builder.Services.AddHttpClient<MenuService>();

//builder.Services.AddSingleton<UserService>(); // UserService'i kaydedin
builder.Services.AddHttpClient<UserService>();

builder.Services.AddHttpClient<EventService>(); //EventService'i kaydedin

builder.Services.AddHttpClient<UserEventService>(); //UserEventService'i kaydedin

builder.Services.AddControllers(); // MVC servislerini ekleyin

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// API rotalarını ekleyin
app.MapControllers();

app.Run();
