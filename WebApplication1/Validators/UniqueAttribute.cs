using System.ComponentModel.DataAnnotations;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        TantaMVCContext db;
        public UniqueAttribute(TantaMVCContext _db)
        {
            db = _db;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            var name = value as string;
            var courseObj = validationContext.ObjectInstance as Course;

            if (courseObj?.Num != null)
            {
                bool exists = db.Courses.Any(e => e.Name == name && e.Num != courseObj.Num);
                if (exists)
                    return new ValidationResult("Name must be Unique");
            }
            else 
            {
                bool exists = db.Courses.Any(e => e.Name == name);
                if (exists)
                    return new ValidationResult("Name must be Unique");
            }

            return ValidationResult.Success;
        }
    }
}
