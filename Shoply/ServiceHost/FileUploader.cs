using _0_Framework.Application;
using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file,string path)
        {
            if (file == null) return "";

            var Directorypath = $"{webHostEnvironment.WebRootPath}//Upload//{path}";
            if(!Directory.Exists(Directorypath))
                Directory.CreateDirectory(Directorypath);
            var Filename = $"{DateTime.Now.ToFileName()}-{file.FileName}";

            var picturePath = $"{Directorypath}//{Filename}";

            using (var output=File.Create(picturePath))
            {
                file.CopyTo(output);
            }
            return $"{path}/{Filename}";
        }
    }
}
