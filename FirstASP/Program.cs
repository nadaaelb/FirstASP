using FirstASP.Data;
using FirstASP.Models;
using FirstASP.MyIdentity;
using FirstASP.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IGameData, GameData>();
//builder.Services.AddDbContext<GamesDbContext>(opt => opt.UseSqlite("somedatabase.db"));
builder.Services.AddDbContext<GamesDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("GamesConnectionString")));
builder.Services.AddIdentity<SiteUser, IdentityRole>( // use the User/Identity class
    options => { 
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

        options.User.RequireUniqueEmail = true;
    }
    ).AddEntityFrameworkStores<GamesDbContext>(); //use DbContextClass

var app = builder.Build();
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<GamesDbContext>();
//context.Database.EnsureDeleted();// if exists, delete
context.Database.EnsureCreated(); //if the database doesnt exist, then create the database
//SeedData.SeedDatabase(context); //only call for testing purposes

//middleware pipeline ...
//app.UseDefaultFiles();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); //show all details for all 
}
else
{
    app.UseExceptionHandler("/Games/Error");//show friendly page
    app.UseStatusCodePagesWithRedirects("/Games/Error");
}

app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();


// localhost:5087/Display/1
app.MapControllerRoute(
    name: "anotherroute",
    pattern: "Display/{id}",
    defaults: new { controller = "GameReview", action = "Show" }
    );

//localhost:5087/home/index/7
///app.MapDefaultControllerRoute();
app.MapControllerRoute(
name: "default",
//change Start back to index if it does not work
pattern: "{controller=Games}/{action=Start}/{id?}"
);

//app.MapControllerRoute(
//    name: "catchall",
//    pattern: "{*whatever}",
//    defaults: new { controller = "GameReview", action = "Index" }
//    );



app.Run();

