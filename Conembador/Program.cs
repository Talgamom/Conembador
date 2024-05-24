using Conembador.Contexto;
using Microsoft.EntityFrameworkCore;
using TesteInsert;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ConembadorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Remova a segunda definição de rota padrão, pois a primeira já a cobre.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "CadastrarItem",
    pattern: "Edi/CadastrarItem", // O padrão da URL para acessar sua página
    defaults: new { controller = "Edi", action = "CadastrarItem" } // O controller e a action que devem ser invocados
);

app.MapControllerRoute(
    name: "CadastrarItem",
    pattern: "Edi/ApresentarEdi", // O padrão da URL para acessar sua página
    defaults: new { controller = "Edi", action = "ApresentarEdi" } // O controller e a action que devem ser invocados
);

app.MapRazorPages();

app.Run();
