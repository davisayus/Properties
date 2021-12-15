using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Core.Core.V1.Utilities
{
    public static class ImagesUtility
    {

        public static async Task<string> UploadLocal(IFormFile imageFile, string rootPath)
        {
            var fileName = Path.Combine(rootPath, "PropertyImages", imageFile.FileName);
            try
            {
                await imageFile.CopyToAsync(new FileStream(fileName, FileMode.Create));
                return fileName;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
