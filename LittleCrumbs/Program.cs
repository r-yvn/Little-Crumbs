using LittleCrumbs.Components;
using LittleCrumbs.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Initialize and register Supabase Client
var url = builder.Configuration["Supabase:Url"]!;
var key = builder.Configuration["Supabase:Key"]!;
var supabase = new Supabase.Client(url, key,
    new Supabase.SupabaseOptions { AutoConnectRealtime = false });
await supabase.InitializeAsync();
builder.Services.AddSingleton(supabase);

builder.Services.AddSingleton<RecipeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();