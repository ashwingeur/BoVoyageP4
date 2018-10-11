using BoVoyageP4.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BoVoyageP4.Validateurs
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LoginAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && value is string)
            {
                using (BoVoyageDbContext db = new BoVoyageDbContext())
                {
                    return !db.Commercials.Any(x => x.Login == value.ToString());
                }
            }
            return true;
        }
    }
}