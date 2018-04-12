using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MinervaBookViewModel
    {
        [DataType(DataType.Text)]
        public string BookName { get; set; }

        [DataType(DataType.Text)]
        public string AuthorName { get; set; }

        [DataType(DataType.Currency)]
        public string Price { get; set; }

        public HttpPostedFileBase BookCover { get; set; }
    }
}