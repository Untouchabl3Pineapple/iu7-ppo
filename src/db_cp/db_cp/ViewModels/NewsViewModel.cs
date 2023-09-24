using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using db_cp.Models;

namespace db_cp.ViewModels
{
    public class NewsViewModel
    {
        [Required(ErrorMessage = "News not specified")]
        public string Content { get; set; }

        public IEnumerable<News> allNews { get; set; }
    }
}
