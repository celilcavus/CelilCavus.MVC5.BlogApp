using System.ComponentModel.DataAnnotations;

namespace _01.EntityLayer.CustomAttributes
{
    public class AllValidation:ValidationAttribute
    {
        public string EntityName { get; set; }
        public int MinLen { get; set; }
        public int MaxLen { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                int len = value.ToString().Length;
                if (len <= 0)
                {
                    return new ValidationResult($"{EntityName} Boş Olamaz");
                }
                else if (value.ToString().Length <= MinLen && value.ToString().Length >= MaxLen)
                {
                    return new ValidationResult($"{EntityName} En Az {MinLen} ve En Fazla {MaxLen} Karakter olmak zorunda.");
                }
                return ValidationResult.Success;
            }
            catch (System.Exception)
            {

                return ValidationResult.Success;
            }
            
        }
    }
}
