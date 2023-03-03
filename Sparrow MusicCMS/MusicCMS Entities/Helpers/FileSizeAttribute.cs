using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_Entities.Helpers
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly float _maxFileSize;
        private readonly float _minFileSize;
        public FileSizeAttribute(float maxFileSize, float minFileSize)
        {
            _maxFileSize = maxFileSize;
            _minFileSize = minFileSize;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }

                if (file.Length < _minFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $" Maximum allowed file size is {String.Format("{0:0.00}", _maxFileSize * 1 / 1048576)} megabytes. \n  Minimum allowed file size is {String.Format("{0:0.00}", _minFileSize * 1 / 1048576)} megabytes. ";
        }
    }
}
