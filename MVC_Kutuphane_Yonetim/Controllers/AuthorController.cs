using Microsoft.AspNetCore.Mvc;
using MVC_Kutuphane_Yonetim.Entities;
using MVC_Kutuphane_Yonetim.Models;

namespace MVC_Kutuphane_Yonetim.Controllers
{
    public class AuthorController : Controller
    {
        static List<AuthorEntity> _authors = new List<AuthorEntity>()
        {
        new AuthorEntity{Id =1, Name = "Azra", LastName = "Kohen",  Details = "Özge Azra Kohen (d. 1979, İzmir), Türk yazar. İlk kitabı olan Fi Akilah mahlası ile yayımlandıktan sonra, ikinci ve üçüncü kitabı Çi ile Pi Akilah Azra Kohen adıyla yayımlandı.  ", Edit = "ss", IsDone = true },
        new AuthorEntity{Id =2, Name = "Lewis", LastName = "Mumford",  Details = "Lewis Mumford(18 Ekim 1895, New York - 26 Ocak 1990, New York), Amerikalı yazar; felsefe, kültür ve mimarlık tarihçisi ve eleştirmeni. Özellikle kentler ve kent mimarisi üzerine yazdığı eserlerle anılır. 1961 yılında yayımlanan Tarih boyunca Kent adlı çalışması en önemli eserlerinden biri olarak kabul edilir.",  Edit = "fff" },
        new AuthorEntity{Id =3, Name = "Joanne", LastName = "Greenberg", Details = "Joanne Greenberg 1932 yılında Amerika'da dünyaya geldi, çalışmalarının bir kısmını Hannah Green mahlası altında yayınlayan Amerikalı bir yazardır. Colorado Maden Okulu'nda antropoloji profesörü ve gönüllü Acil Tıp Teknisyeniydi.",  Edit = "rrr" }
        };

        static List<BookEntity> _books = new List<BookEntity>()
        {
            new BookEntity{ Id =1, Title = "Aden"},
            new BookEntity{ Id =2, Title = "Tarih Boyunca Kent" },
            new BookEntity{ Id=3, Title="Sana Gül Bahçesi Vadetmedim"}
        };

        public IActionResult Author()
        {
            var viewModel = _authors.Where(x => x.IsDeleted == false).Select(x => new AuthorViewModel
            {
                Id = x.Id,
                Name=x.Name,
                LastName=x.LastName,
                Details = x.Details,
                Edit = x.Edit,
                IsDone = x.IsDone,


            }).ToList();

            return View(viewModel); 
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Books = _books;

            return View();
        }

        [HttpPost]
        public IActionResult Add(AuthorAddViewModel formData)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Book = _books;
                return View(formData); //Model doğru olmazsa Add bölümünü tekrar açar
            }

            int maxId = _authors.Max(x => x.Id);
            var newAuthor = new AuthorEntity
            {
                Id = maxId +1,
                Name = formData.Name,
                LastName = formData.LastName,
                Details = formData.Details,
            };


            _authors.Add(newAuthor);

            return RedirectToAction("Author");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var task = _authors.Find(x  => x.Id == id);

            var viewModel = new AuthorEditViewModel()
            {
                Id = task.Id,
                Name = task.Name,
                LastName = task.LastName,
                Details = task.Details,
                BookId = task.BookId,
            };
            ViewBag.Book = _books;
            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Edit(AuthorEditViewModel formData)
        {
            if (!ModelState.IsValid)
            { return View(formData); }

            var task = _authors.Find(x => x.Id == formData.Id);

            task.Name = formData.Name;
            task.LastName = formData.LastName;
            task.Details = formData.Details;
            task.BookId = formData.BookId;

            return RedirectToAction("Author");
        }



        public IActionResult CancelAuthor(int id)
        {
            var task = _authors.Find(x  => x.Id == id);
            

            task.IsDeleted = true;

            return RedirectToAction("Author");
        }
    }
}
