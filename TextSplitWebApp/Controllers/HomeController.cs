using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TextSplitWebApp.Models;

namespace TextSplitWebApp.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            return View(db.Sentences.ToList());
        }

        [HttpGet]
        public ActionResult UploadBook()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult UploadBook(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                string path = "~/Files/" + fileName;
                upload.SaveAs(Server.MapPath(path));
                //string file_type = "application/octet-stream";
                byte[] mas = System.IO.File.ReadAllBytes("D:\\OneDrive\\Gonchar\\C#2005\\TextSplitWebApp\\TextSplitWebApp\\Files\\NewSampleEndlishTextDoc.txt");
                //FileStream fs = new FileStream(path, FileMode.Open);
                string fileContent = Encoding.UTF8.GetString(mas, 0, mas.Length);
                BookFile b = new BookFile();
                b.BookFileContent = fileContent;
                return View("UploadPage", b);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UploadPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPage(string product, string action)
        {
            if (action == "toUpload")
            {
                return View();
            }
            else if (action == "toExit")
            {
                return RedirectToAction("Index");
            }
            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult UploadFileSelect(string product, string action)
        {
            if (action == "uploadEnglish")
            {
                return RedirectToAction("UploadBook");
            }
            else if (action == "toExit")
            {
                return RedirectToAction("Index");
            }
            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult MyAction(string product, string action)
        {
            if (action == "toUpload")
            {
                return GetFile();
            }
            else if (action == "toReturn")
            {
                return RedirectToAction("Index"); 
            }
            return Redirect("Index");
        }

        public FilePathResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/sampleEndlishTextDoc.txt");
            // Тип файла - content-type
            string file_type = "application/octet-stream";
            // Имя файла - необязательно
            string file_name = "sampleEndlishTextDoc.txt";
            return File(file_path, file_type, file_name);
        }

        public FileResult GetBytes()
        {
            string path = Server.MapPath("~/Files/sampleEndlishTextDoc.txt");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/octet-stream";
            string file_name = "sampleEndlishTextDoc.txt";
            return File(mas, file_type, file_name);
        }

        public FileResult GetStream()
        {
            string path = Server.MapPath("~/Files/sampleEndlishTextDoc.txt");
            // Объект Stream
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "application/octet-stream";
            string file_name = "sampleEndlishTextDoc.txt";
            return File(fs, file_type, file_name);
        }

        public ActionResult GetSentence(int id = 0)
        {
            if (id == 0)
                return View();

            Sentence s = db.Sentences.Find(id);            
            return View(s);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}