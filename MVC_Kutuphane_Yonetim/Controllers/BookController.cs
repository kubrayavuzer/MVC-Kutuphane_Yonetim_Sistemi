using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using MVC_Kutuphane_Yonetim.Entities;
using MVC_Kutuphane_Yonetim.Models;


namespace MVC_Kutuphane_Yonetim.Controllers
{
    public class BookController : Controller
    {

        static List<BookEntity> _books = new List<BookEntity>()
        {
        new BookEntity{Id =1, Title = "Aden", Details = "Farklı bir gezegenden dünya gezegenine ulaşan bir hikaye Aeden. Oradaki tüm mükemmelliğin karşıtlığı dünya gezegeni. Okudukça yaşadığımız gezegene, topraklara üçüncü bir göz ile bakıp durumun ciddiyetini anlayabilme fırsatı veriyor bizlere Azra Kohen. ", Edit = "ss", IsDone = true },
        new BookEntity{Id =2, Title = "Tarih Boyunca Kent", Details = "Ütopyaların merkezinde hep bir kent tasarımı bulunmasına şaşırmalı mıyız? Kentin aracılık ettiği süreçler, yerine getirdiği işlevler ve insan hayatı üzerindeki etkileri düşünüldüğünde bu hiç şaşırtıcı değil. Elbette kent sadece maddi yapılardan ibaret değildir. Fiziksel bir bütünlüğe ve somutluğa sahip en büyük toplumsal birim olmasının yanı sıra, kent geniş bir toplumsal ilişkiler ağının hem yaratıcısı hem de düğüm noktasıdır. ", Edit = "fff" },
        new BookEntity{Id =3, Title = "Sana Gül Bahçesi Vadetmedim", Details = "Sana Gül Bahçesi Vadetmedim, deliliği, resmi tanımıyla akıl hastalığını anlatıyor: Deborah kimlik kavramını yitirip içine kapanmış, zengin düşlemi ve mizah duygusuyla yarattığı kendi düşsel dünyasına sığınmıştır. İki dünyanın çatışmaya başlaması, Deborah’ın akıl hastanesine \"düşme\"sine neden olur. Böylece hastaneleri, doktorları vb. kurumlarıyla toplumun \"kurtarma operasyonu\" başlayacaktır.", Edit = "rrr" }
        };

        static List<AuthorEntity> _authors = new List<AuthorEntity>()
        {
            new AuthorEntity{ Id = 1, Name = "Azra Kohen"},
            new AuthorEntity{ Id = 2, Name = "Joanne Greenberg"},
            new AuthorEntity{ Id = 3, Name = "Lewis Mumford"},

        };

        public IActionResult List()

        {

            var viewModel = _books.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel
            {
                Id= x.Id,
                Title = x.Title,
                Details = x.Details,
                Edit = x.Edit,
                Create = x.Create,
                IsDone = x.IsDone,
               

            }).ToList();

           return View(viewModel);
        }
        [HttpGet]
        public IActionResult CompleteTask(int id)
        {

            var task = _books.Find(x => x.Id == id);

            task.IsDone = !task.IsDone;

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Authors= _authors;

            return View();
        }

        [HttpPost]
        public IActionResult Add(BookAddViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                // ViewBag.Authors'ı tekrar dolduruyoruz
                ViewBag.Authors = _authors;
                return View(formData);
            }

            int maxId = _books.Max(x => x.Id);

            var newBook = new BookEntity()
            {
                Id = maxId + 1,
                Title = formData.Title,
                Details = formData.Details,
                // Yeni alanları ekleyelim
                AuthorId = formData.AuthorId,
                NumberOfPages = formData.NumberOfPages,
            };

            _books.Add(newBook); // Listeye eklemeyi unutmayalım

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var task = _books.Find(x =>x.Id == id);
            var viewModel = new BookEditViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Details = task.Details,
                AuthorId = task.AuthorId,
            };

            ViewBag.Authors = _authors;

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult Edit(BookEditViewModel formData)
        {
            if (!ModelState.IsValid)
            { return View(formData); }

            var task = _books.Find(x => x.Id == formData.Id);

            task.Title = formData.Title;
            task.Details = formData.Details;
            task.AuthorId = formData.AuthorId;
            task.NumberOfPages = formData.NumberOfPages;

            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult CancelBook(int id)
        {
            var task = _books.Find(x =>x.Id == id);

            _books.Remove(task); //veri tamamen silindi --> HARD DELETE

            task.IsDeleted = true; //SOFT DELETE --> veri hala duruyor. listelerken gözükmeyecek 

            return RedirectToAction("List");
        }

    }
}
