using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    //This class implements the abstract HttpPostedFileBase class
    public class MemoryPostedFile: HttpPostedFileBase
    {
        private readonly byte[] bytes;
        public MemoryPostedFile(byte[] bytes, string fileName = null)
        {
            this.bytes = bytes;
            this.FileName = fileName;
            this.InputStream = new MemoryStream(bytes);
        }

        public override int ContentLength => bytes.Length;
        public override string FileName { get; }
        public override Stream InputStream { get; }
    }
}