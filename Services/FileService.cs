using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Services
{
    public class FileService
    {
        IWebHostEnvironment _kit;

        public FileService(IWebHostEnvironment e)
        {
            _kit = e;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            string folderName = "Photo";

            if(file == null)
            {
                return string.Empty;
            }

            var location = Path.Combine(_kit.WebRootPath, folderName);

            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }

            var fileName = file.FileName;

            var fileLocation = Path.Combine(location, fileName);

            using (var Photo = new FileStream(fileLocation, FileMode.Create)) {
                await file.CopyToAsync(Photo);
            }

            string full = fileLocation;

            return Path.Combine("/" + folderName + "/", fileName);
        }
    }
}
