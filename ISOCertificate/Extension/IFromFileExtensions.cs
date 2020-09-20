﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ISOCertificate.Extension
{
    public static class IFromFileExtensions
    {
        public async static Task<string> SaveAsync(this IFormFile file, string root, string folder)
        {
            string path = Path.Combine(root, "images");
            string fileName = Path.Combine(folder, Guid.NewGuid().ToString() + file.FileName);

            string resultPath = Path.Combine(path, fileName);

            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        public async static Task<string> SaveWithoutFolderAsync(this IFormFile file, string root)
        {
            string path = Path.Combine(root, "images");
            string fileName = Path.Combine(Guid.NewGuid().ToString() + file.FileName);

            string resultPath = Path.Combine(path, fileName);

            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
    }
}