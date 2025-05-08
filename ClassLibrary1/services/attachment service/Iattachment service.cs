using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.bl.services.attachment_service
{
    public interface Iattachment_service
    {
        //upload
        public string? upload(IFormFile file, string foldername);
        //delete
        bool delete(string filename,string foldername);
    }
}
