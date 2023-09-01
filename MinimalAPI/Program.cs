
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Context;
using MinimalAPI.Interfaces;
using MinimalAPI.Models;
using MinimalAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository<Book>, BookRepository>();

builder.Services.AddDbContext<DataContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("Minimal-Connection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Get All Books

app.MapGet("/books", async (IBookRepository<Book> repo) =>
{
    try
    {
        var book = await repo.GetAll();
        return Results.Ok(book);
    }
    catch (Exception)
    {
        return Results.StatusCode(500);
    }
});

//Get Book By ID
app.MapGet("/books/{id}", async (IBookRepository<Book> repo, int id) =>
    {
        var book = await repo.GetBookById(id);
        try
        {
            if (book == null)
            {
                return Results.NotFound("Book with this ID does not exist in the database.");
            }
            return Results.Ok(book);
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });
//Add Book
app.MapPost("/book", async (IBookRepository<Book> repo, Book newBook) =>
{
    try
    {
        await repo.AddBook(newBook);
        if (newBook == null)
        {
            return Results.StatusCode(404);
        }
        return Results.Created($"/books/{newBook.BookId}", newBook);
    }
    catch (Exception)
    {

        return Results.StatusCode(500);
    }
   
});
//Update Book
app.MapPut("/book/{id}", async (IBookRepository<Book> repo, int id, Book bookToUpdate) =>
{
    try
    {
        if (id != bookToUpdate.BookId)
        {
            return Results.StatusCode(400);
        }
        var response = await repo.UpdateBook(bookToUpdate);
        if (response == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(bookToUpdate);
    }
    catch (Exception)
    {
        return Results.StatusCode(500);
    }
   
});
// Delete Book
app.MapDelete("/book/{id}", async (IBookRepository<Book> repo, int id) =>
{
    try
    {
        var bookToDelete = await repo.DeleteBook(id);
        if (bookToDelete == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(bookToDelete);
    }
    catch (Exception)
    {

        return Results.StatusCode(500);
    }
  
});
app.MapGet("/bookSearch/{string}", async (IBookRepository<Book> repo,string keyWord) =>
{
    try
    {      
        var tempList = await repo.SearchForBook(keyWord);
        if (tempList == null)
        {
            return Results.StatusCode(404);
        }
        return Results.Ok(tempList);
    }
    catch (Exception)
    {
        return Results.StatusCode(500);
    }
});
app.Run();


