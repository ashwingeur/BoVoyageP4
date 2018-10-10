using BoVoyageP4.Data;
using BoVoyageP4.Outils;
using System.Web.Mvc;

namespace BoVoyageP4.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BoVoyageDbContext db = new BoVoyageDbContext();

        protected void Display(string text, MessageType type = MessageType.SUCCESS)
        {
            var m = new Message(type, text);
            TempData["MESSAGE"] = m;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                this.db.Dispose();
        }
    }
}