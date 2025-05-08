using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.services.attachment_service
{
    public class attachment_service : Iattachment_service
    {
        List<string>allowextention=new List<string>() { ".png",".jpg",".jepg"};
       const int maxsize = 2_097_152;
        public bool delete(string filename,string foldername)

        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", foldername, filename);
            if(!File.Exists(filepath))return false;
        else
            {
                File.Delete(filepath);
                return true;
            }
           
        }

        public string? upload(IFormFile file, string foldername)
        {
            //check extention
            var extention = Path.GetExtension(file.FileName);
            if (!allowextention.Contains(extention)) {
                return null;
            }
            //check size
            if(file.Length==0||file.Length>maxsize) {
            return null;
            }
            //get folder path
            var folderpath=Path.Combine( Directory.GetCurrentDirectory(),"wwwroot\\files",foldername);
            //make attachment unique--guid
            var filename = $"{Guid.NewGuid()}_{file.FileName}";
            //get file path
            var filepath= Path.Combine(folderpath,filename);
            //create file stream to copy file(unmanaged)
         using   FileStream f = new FileStream(filepath, FileMode.Create);
            //use stream to copy file
            file.CopyTo(f);
            //return file name to store in database
            return filename;

        }
    }
}
