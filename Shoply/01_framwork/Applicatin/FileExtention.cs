using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Applicatin
{
    public class FileExtention : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _Extention;

        public FileExtention(params string[] extention)
        {
            _Extention = extention;
        }
        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;

            var extention = Path.GetExtension(file.FileName);
            return _Extention.Contains(extention);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-fileExtention", ErrorMessage);
        }
    }
}
