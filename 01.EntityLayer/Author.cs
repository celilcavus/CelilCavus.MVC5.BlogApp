using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01.EntityLayer
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Yazar ismi olmak zorundadir")]
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }

        [Required(ErrorMessage = "Yazar Hakkında ismi olmak zorundadir")]
        public string AuthorAbout { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
