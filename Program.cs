// Oppsett av web serveren
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Library library = new Library();

// Legg til noen placholder bøker
Book martian = new Book("Martian", "Jack Black", new DateTime(2002, 10, 10));
library.AddNewBook(martian);
Book foundation = new Book("Foundation", "Jane Doe", new DateTime(1940, 04, 05));
library.AddNewBook(foundation);

// Konfigurer endpunktene (hvilken meldinger vi responderer på og logik vi skal kjøre)
// Metode:     GET
// URI (sti):  /book
app.MapGet("/book", () =>
{
  return library.ListAvailableBooks();
});

// Metode:     POST
// URI (sti):  /
app.MapPost("/book/borrow", (BookRequest request) =>
{
  Book? book = library.BorrowBook(request.Title);

  if (book == null)
  {
    return Results.NotFound();
  }
  else
  {
    return Results.Ok(book);
  }
});

app.MapPost("/book/return", (BookRequest request) =>
{
Book? book = library.ReturnBook(request.Title);

  if (book == null)
  {
    return Results.NotFound();
  }
  else
  {
    return Results.Ok(book);
  }

});

// Start web serveren
app.Run();
