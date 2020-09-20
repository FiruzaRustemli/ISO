using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Extensions
{
    public static class IFormFileExtensions
    {
        public async static Task<string> SaveAsync(this IFormFile file, string root, string folder)
        {
            var filePath = Path.Combine(root, "images");
            var fileName = Path.Combine(folder + Guid.NewGuid().ToString() + file.FileName);

            string resultPath = Path.Combine(filePath, fileName);

            using (var fileSteam = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileSteam);
            }

            return fileName;
        }

        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
    }
}
