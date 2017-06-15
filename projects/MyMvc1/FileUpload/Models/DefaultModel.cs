using FileUpload.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUpload.Models
{
    public class DefaultModel
    {
        public string ActionMessage { get; set; }
        public int ActionCode { get; set; }
        public Page PageInfo { get; set; }
        public TblFiles UpFile { get; set; }
        public List<TblFiles> Files { get; set; }

        public DefaultModel()
        {
            ActionMessage = "";
            ActionCode = 0;
            PageInfo = new Page();
            UpFile = new TblFiles();
            Files = new List<TblFiles>();
        }
    }
}