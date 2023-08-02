using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _01.EntityLayer
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Kategori Adı boş olamaz.")]
        public string CategoryName { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
