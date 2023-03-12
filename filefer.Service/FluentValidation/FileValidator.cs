using filefer.Entity.Models;
using FluentValidation;

namespace filefer.Service.FluentValidation
{
    public class FileValidator: AbstractValidator<UploadedFileViewModel>
    {
        public FileValidator()
        {
            RuleFor(x => x.File).NotEmpty();
            RuleFor(x => x.File.Length.ToString()).MaximumLength(52428800);
        }
    }
}
