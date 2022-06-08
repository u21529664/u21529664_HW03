using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace u21529664_HW03.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Index(HttpPostedFileBase Upload) //INSIDE HOME
        {
            if (Upload != null &&  Upload.ContentLength > 0)
            {
                var OptionSelection = Request["File"];//radio button selection
                var fileName = Path.GetFileName(Upload.FileName);//get file name

              

                if (OptionSelection == "Document")
                {
                     // store the file inside ~/Media/Files folder

                    var path = Path.Combine(Server.MapPath("~/Media/Files"), fileName);

                    

                    Upload.SaveAs(path);
                

                }
                else if (OptionSelection == "Images")
                {

                    // store the file inside ~/Media/Images folder

                    var path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);

                    
                    Upload.SaveAs(path);


                }
                else if (OptionSelection == "Videos") 
                { 
                    //store the file inside ~/Media/Videos folder
                    var path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);

                    Upload.SaveAs(path);

                }

            }
            
            // redirect back to the index action to show the form once again

            return RedirectToAction("Index");

        }
         

    }

}
    
