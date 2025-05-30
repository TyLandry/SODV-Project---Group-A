using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public bool IsRented { get; set; }

    public Book(string name, string serialNumber)
    {
        Name = name;
        SerialNumber = serialNumber;
        IsRented = false;
    }

    public bool CheckAvailability()
    {
        return !IsRented;
    }

    public bool RentBook()
    {
        if (CheckAvailability())
        {
            IsRented = true;
            return true;
        }
        return false;
    }

    public bool ReturnBook()
    {
        if (!CheckAvailability())
        {
            IsRented = false;
            return true;
        }
        return false;
    }

    public string ShowInfo()
    {
        string status = IsRented ? "Rented" : "Available";
        return $"Book: {Name}, Serial: {SerialNumber}, Status: {status}";
    }
}

public class Reader
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }

    public Reader(string name)
    {
        Name = name;
        Books = new List<Book>();
    }

    public bool RentBook(Book book)
    {
        if (Books.Count < 2 && book.RentBook())
        {
            Books.Add(book);
            return true;
        }
        return false;
    }

    public bool ReturnBook(Book book)
    {
        if (Books.Contains(book) && book.ReturnBook())
        {
            Books.Remove(book);
            return true;
        }
        return false;
    }

    public string ShowInfo()
    {
        string booksStr = Books.Any()
            ? string.Join(", ", Books.Select(b => $"{b.Name} (Serial: {b.SerialNumber})"))
            : "None";
        return $"Reader: {Name}, Books rented: {booksStr}";
    }
}

public class Bookstore
{
    private List<Book> Books { get; set; }
    private List<Reader> Readers { get; set; }

    public Bookstore()
    {
        Books = new List<Book>();
        Readers = new List<Reader>();
    }

    public bool AddReader(string readerName)
    {
        if (!Readers.Any(r => r.Name == readerName))
        {
            Readers.Add(new Reader(readerName));
            return true;
        }
        return false;
    }

    public bool RemoveReader(string readerName)
    {
        var reader = Readers.FirstOrDefault(r => r.Name == readerName);
        if (reader != null)
        {
            if (!reader.Books.Any())
            {
                Readers.Remove(reader);
                return true;
            }
            return false;
        }
        return false;
    }

    public bool AddBook(string bookName, string serialNumber)
    {
        if (!Books.Any(b => b.Name == bookName && b.SerialNumber == serialNumber))
        {
            Books.Add(new Book(bookName, serialNumber));
            return true;
        }
        return false;
    }

    public bool RemoveBook(string bookName, string serialNumber)
    {
        var book = Books.FirstOrDefault(b => b.Name == bookName && b.SerialNumber == serialNumber);
        if (book != null && book.CheckAvailability())
        {
            Books.Remove(book);
            return true;
        }
        return false;
    }

    public bool RentBook(string readerName, string bookName, string serialNumber)
    {
        var reader = Readers.FirstOrDefault(r => r.Name == readerName);
        var book = Books.FirstOrDefault(b => b.Name == bookName && b.SerialNumber == serialNumber);
        if (reader != null && book != null)
        {
            return reader.RentBook(book);
        }
        return false;
    }

    public bool ReturnBook(string readerName, string bookName, string serialNumber)
    {
        var reader = Readers.FirstOrDefault(r => r.Name == readerName);
        var book = Books.FirstOrDefault(b => b.Name == bookName && b.SerialNumber == serialNumber);
        if (reader != null && book != null)
        {
            return reader.ReturnBook(book);
        }
        return false;
    }

    public List<string> ShowAllBooks()
    {
        return Books.Select(b => b.ShowInfo()).ToList();
    }

    public List<string> ShowAllReaders()
    {
        return Readers.Select(r => r.ShowInfo()).ToList();
    }
}