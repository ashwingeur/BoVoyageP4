using BoVoyageP4.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BoVoyageP4.Validateurs
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && value is string)
            {
                using (BoVoyageDbContext db = new BoVoyageDbContext())
                {
                    return !db.Clients.Any(x => x.Email == value.ToString());
                }
            }
            return true;
        }
    }
}