using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using ProductManagement_.Components;
using ProductManagement_.Features.Auth;
using ProductManagement_.Features.Data;
using ProductManagement_.Features.Respositories.Implementations;
using ProductManagement_.Features.Respositories.Interface;
using ProductManagement_.Features.Services.Implementations;
using ProductManagement_.Features.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException("Connection string not found.")));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ Only ONE AddAuthentication call — remove the duplicate bare AddAuthentication()
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/login";
    });

builder.Services.AddAuthorization(); // ✅ use AddAuthorization not AddAuthorizationCore

// ── Auth ──────────────────────────────────────────────────────────────────
builder.Services.AddScoped<AuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
    sp => sp.GetRequiredService<AuthStateProvider>());
builder.Services.AddCascadingAuthenticationState();

// ── Repositories ──────────────────────────────────────────────────────────
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

// ── Services ──────────────────────────────────────────────────────────────
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();   // ✅ needed for static assets
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();