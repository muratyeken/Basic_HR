﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Application.Extensions
{
    public class PictureFileExtension:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;

            if (file != null)
            {

                var extension = Path.GetExtension(file.FileName).ToLower();

                string[] extensions = { ".jpg", ".jpeg", ".png" };

                bool result = extensions.Any(x => x.EndsWith(extension));

                if (!result)
                {
                    return new ValidationResult("Format Exception.You must upload png,jpeg,jpg");
                }
            }

            return ValidationResult.Success;
        }
    }
}
