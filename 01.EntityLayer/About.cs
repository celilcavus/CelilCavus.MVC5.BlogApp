using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01.EntityLayer
{
    public class About
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Minumum 3 Karakter girmelisiniz.")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 Karakter girmelisiniz.")]
        [Required(ErrorMessage = "About Title Boş Olamaz")]
        public string AboutTitle { get; set; }
        [MinLength(2, ErrorMessage = "Minumum 3 Karakter girmelisiniz.")]
        [MaxLength(500, ErrorMessage = "Maksimum 500 Karakter girmelisiniz.")]
        [Required(ErrorMessage = "About Content Boş Olamaz")]
        public string AboutContent { get; set; }

        [Required(ErrorMessage ="Image Boş Olamaz.")]
        public string AboutImage { get; set; }
     
    }
}
