using ColorsViewer.Models;
using ColorsViewer.Services.Contracts;
using System.Linq;
using System.Web.Mvc;
using ColorsViewer.Extensions;

namespace ColorsViewer.Controllers
{
    public class ColorsController : Controller
    {
        public ColorsController(IColorsService colorsService)
        {
            ColorsService = colorsService;
        }

        private IColorsService ColorsService { get; }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetColors(int colorsNumber, bool descendingOrder)
        {
            return PartialView("_Colors", ColorsService
                .GetColors(colorsNumber)
                .Select(arg =>
                new ColorModel { Id = arg.Id, Name = arg.Name, ColorCode = arg.ColorCode })
                .SortByItemId(descendingOrder));
        }
    }
}