using _01.EntityLayer.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01.EntityLayer
{
    public class Blog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Blog Title Boş olamaz")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olmak zorunda")]
        [MinLength(2, ErrorMessage = "Minumum 2 karakter olmak zorunda")]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "Blog Image Boş olamaz")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olmak zorunda")]
        [MinLength(2, ErrorMessage = "Minumum 2 karakter olmak zorunda")]
        public string BlogImage { get; set; }

        [Required(ErrorMessage = "Blog Date Boş olamaz")]
        public DateTime BlogDate { get; set; }

        [Required(ErrorMessage = "Blog Content Boş olamaz")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olmak zorunda")]
        [MinLength(2, ErrorMessage = "Minumum 2 karakter olmak zorunda")]
        public string BlogContent { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public ICollection<Comments> Comments { get; set; }


    }
}
