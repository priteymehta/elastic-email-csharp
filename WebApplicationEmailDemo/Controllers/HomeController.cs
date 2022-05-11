using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace WebApplicationEmailDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var fileStream = new FileStream(Server.MapPath("~/Content/invoice.html"), FileMode.Open, FileAccess.Read);
                var Renderer = new IronPdf.HtmlToPdf();
                var PDF = Renderer.RenderHTMLFileAsPdf(Server.MapPath("~/Content/invoice.html"));
                string datetimestamp = "~/Content/" + DateTime.Now.ToString() + ".pdf";
                PDF.SaveAs(datetimestamp);

            }
            catch (Exception ex)
            {

                throw;
            }
           
           

            return View();
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


      
    }
}