using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EntityLayer
{
    public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanici Adi Boş Olamaz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Adi Boş Olamaz")]
        public string Password { get; set; }
        public int RoleId { get; set; }

        public AdminRole Role { get; set; }
    }
    public class AdminRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Role Boş Olamaz")]
        public string RoleName { get; set; }

        public ICollection<Admin> Admins { get; set; }

    }
}
