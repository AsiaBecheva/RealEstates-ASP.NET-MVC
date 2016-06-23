namespace RealEstates.Web.Controllers
{
    using RealEstates.Data.Common.Repositories;
    using RealEstates.Data.Models;
    using System.Web.Mvc;

    public class FileController : Controller
    {
        private IRepository<File> files;

        public FileController(IRepository<File> files)
        {
            this.files = files;
        }

        public ActionResult Index(int id)
        {
            var fileToRetrieve = files.GetById(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}