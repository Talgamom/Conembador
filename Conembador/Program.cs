using TesteInsert;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
    name: "Teste001",
    pattern: "Teste01/Teste001", // O padrão da URL para acessar sua página
    defaults: new { controller = "Teste", action = "Teste001" } // O controller e a action que devem ser invocados
);

app.MapControllerRoute(
    name: "Teste001",
    pattern: "Teste01/ApresentarEdi", // O padrão da URL para acessar sua página
    defaults: new { controller = "Teste", action = "ApresentarEdi" } // O controller e a action que devem ser invocados
);
/*
app.MapControllerRoute(
    name: "Teste001",
    pattern: "Teste01/ApresentarEdi", // O padrão da URL para acessar sua página
    defaults: new { controller = "Teste", action = "ApresentarEdi" } // O controller e a action que devem ser invocados
);
*/

app.MapRazorPages();

app.Run();
