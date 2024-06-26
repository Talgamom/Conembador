using Conembador.Contexto;
using Microsoft.EntityFrameworkCore;

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

// Remova a segunda defini��o de rota padr�o, pois a primeira j� a cobre.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "CadastrarItem",
    pattern: "Item/CadastrarItem", // O padr�o da URL para acessar sua p�gina
    defaults: new { controller = "Item", action = "CadastrarItem" } // O controller e a action que devem ser invocados
);

app.MapControllerRoute(
    name: "CadastrarItem",
    pattern: "Edi/ApresentarEdi", // O padr�o da URL para acessar sua p�gina
    defaults: new { controller = "Edi", action = "ApresentarEdi" } // O controller e a action que devem ser invocados
);

app.MapRazorPages();

app.Run();
