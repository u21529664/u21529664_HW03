﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21529664_HW03.Models;
using System.IO;

namespace u21529664_HW03.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
            public ActionResult Images()
            {
                //Fetch all files in the Folder (Directory).

                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));

         

                List<FileModel> files = new List<FileModel>();

                foreach (string filePath in filePaths)
                {
                    files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
                }
                return View(files);
            }
            public FileResult DownloadFile(string fileName) 
            {
               
                  //File Path
                string path = Server.MapPath("~/Media/Images/") + fileName;

                //Read the File data into Byte Array.
               

                byte[] bytes = System.IO.File.ReadAllBytes(path);

                //send file to Download
                return File(bytes, "application/octet-stream", fileName);
            }

            public ActionResult DeleteFile(string fileName)
            {
                //Delete requires reading the files and then the allocation of a file path.
                //The file is then deleted based on the identified file path.

                string path = Server.MapPath("~/Media/Images/") + fileName;
                byte[] bytes = System.IO.File.ReadAllBytes(path);

                System.IO.File.Delete(path);

                return RedirectToAction("Images");
            }
    }
            
}
    
