class Book
{
  public string Title { get; set; }
  public string Author { get; set; }
  public DateTime FirstPublished { get; set; }
  public Guid Id { get; set; }

  public bool IsBorrowed;

  public Book(string title, string author, DateTime firstPublished)
{
  Title = title;
  Author = author;
  FirstPublished = firstPublished;
  IsBorrowed = false;
  Id = Guid.NewGuid();
}

public void Borrow()
{
  IsBorrowed = true;
}

public void Return()
{
  IsBorrowed = false;
}
}