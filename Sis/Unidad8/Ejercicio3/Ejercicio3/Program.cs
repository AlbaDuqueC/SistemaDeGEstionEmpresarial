using Data.Repositories.repositoriosdepartamento;
using Data.Repositories.repositoriospersona;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCase;
using Domain.UseCase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registro de dependencias
builder.Services.AddScoped<IPersonaRepositoryUseCase, PersonaRepositoryUseCase>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepositoryAzure>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepositoryAzure>();
builder.Services.AddScoped<IDepartamentoRepositoryUseCase, DepartamentoRepositoryUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
