using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupportWaveAPI.Models
{
    public class Book : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }


        // Implement custom validation logic for the model
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            // Ensure PublishedDate is not in the future
            if (PublishedDate > DateTime.Now)
            {
                result.Add(new ValidationResult("The published date cannot be in the future", new[] {nameof(PublishedDate)}) );
            }

            return result;

        }
    }
}
