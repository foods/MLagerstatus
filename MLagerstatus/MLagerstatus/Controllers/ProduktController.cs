using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLagerstatus.Interfaces.Factories.Views;

namespace MLagerstatus.Controllers
{
    public class ProduktController : Controller
    {
        private readonly IProduktViewFactory _produktViewFactory;
        public ProduktController(IProduktViewFactory produktViewFactory)
        {
            _produktViewFactory = produktViewFactory;
        }

        public async Task<IActionResult> Index()
        {
            var produktIndexView = await _produktViewFactory.Build();
            return View(produktIndexView);
        }

        public async Task<IActionResult> Details(string produkt)
        {
            var produktDetailsView = await _produktViewFactory.Build(produkt);
            return View(produktDetailsView);
        }
    }
}
