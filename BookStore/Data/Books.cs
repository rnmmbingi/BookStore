using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter Title of book.")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Title minimun lenth is 5 and maximun is 30")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Author of book.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Title minimun lenth is 5 and maximun is 30")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Title minimun lenth is 30 and maximun is 500")]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter total no. of pages.")]
        [Display(Name ="Total pages")]
        public int? TotalPages { get; set; }
        public string Language { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
