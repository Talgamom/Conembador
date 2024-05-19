using TesteInsert;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Remova a segunda defini��o de rota padr�o, pois a primeira j� a cobre.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "Teste001",
    pattern: "Teste01/Teste001", // O padr�o da URL para acessar sua p�gina
    defaults: new { controller = "Teste", action = "Teste001" } // O controller e a action que devem ser invocados
);


app.Run();