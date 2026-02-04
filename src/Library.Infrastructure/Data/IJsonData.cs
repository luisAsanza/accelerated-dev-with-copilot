using System.Collections.Generic;
using System.Threading.Tasks;
using Library.ApplicationCore.Entities;

namespace Library.Infrastructure.Data;

public interface IJsonData
{
    List<Author>? Authors { get; set; }
    List<Book>? Books { get; set; }
    List<BookItem>? BookItems { get; set; }
    List<Patron>? Patrons { get; set; }
    List<Loan>? Loans { get; set; }

    Task EnsureDataLoaded();
    Task LoadData();
    Task SaveLoans(IEnumerable<Loan> loans);
    Task SavePatrons(IEnumerable<Patron> patrons);

    List<Patron> GetPopulatedPatrons(IEnumerable<Patron> patrons);
    Patron GetPopulatedPatron(Patron p);
    Loan GetPopulatedLoan(Loan l);
    BookItem GetPopulatedBookItem(BookItem bi);
    Book GetPopulatedBook(Book b);
}
