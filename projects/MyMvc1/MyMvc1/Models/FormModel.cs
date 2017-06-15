using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvc1.Models
{
    public class FormModel
    {
        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Error
        {
            get;
            set;
        }

        public List<Type> Types { get; set; }
    }
}