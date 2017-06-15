using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.DAL.Entity;

namespace WeiBo.Models
{
    public class DefaultModel
    {
        public Page PageInfo { get; set; }
        public List<TblMessage> MessageList { get; set; }
        public string Message { get; set; }
        public DefaultModel()
        {
            PageInfo = new Page();
            MessageList = new List<TblMessage>();
            Message = "";
        }
    }
}