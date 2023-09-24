using BookStoreV2.Models.Services;
using BookStoreV2;
using MinimalAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// my own services 
builder.Services.AddHttpClient();
//builder.Services.AddHttpClient(IBookService,BookService);
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<BookService>();
// Registrerar url basen
StaticDetails.BookApiString = builder.Configuration["ServiceUrls:BookApiString"];

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
