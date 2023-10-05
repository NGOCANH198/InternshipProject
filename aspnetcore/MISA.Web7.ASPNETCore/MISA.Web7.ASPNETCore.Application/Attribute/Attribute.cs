using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web7.ASPNETCore.Application
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidDateTime : ValidationAttribute
    {   
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                
                if (date < DateTime.Now)
                {
                    return true; 
                }
            }

            return false; 
        }
    }
}
