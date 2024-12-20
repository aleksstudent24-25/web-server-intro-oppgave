// Oppsett av web serveren
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Library library = new Library();

// Jeg la til en adminKey som så blir kopiert av en bruker som nå har admin rettigheter
// til å endre lånestatus på bøker som de vil igjennom /changestatus
AdminVerification adminKey = new AdminVerification(Guid.NewGuid());
User user = new User(adminKey.VerificationId);

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

// app.MapGet("/adminaccess", () =>
// {
//   return adminKey.VerificationId;
// });

// Metode:     POST
// URI (sti):  /
app.MapPost("/book/borrow", (BookRequest request) =>
{
  Book? book = library.BorrowBook(request.Id);

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
  Book? book = library.ReturnBook(request.Id);

  if (book == null)
  {
    return Results.NotFound();
  }
  else
  {
    return Results.Ok(book);
  }

});

app.MapPost("/book/changestatus", (BookRequest request) =>
{
  if (user.Id == adminKey.VerificationId)
  {
    Book? book = library.ChangeBookStatus(request.Id);
    if (book == null) return Results.NotFound();
    else return Results.Ok(book);
  }
  else
    return Results.NotFound();
});

// Start web serveren
app.Run();
