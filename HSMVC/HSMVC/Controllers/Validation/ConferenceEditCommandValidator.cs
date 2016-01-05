using System;
using FluentValidation;
using FluentValidation.Results;
using HSMVC.Controllers.Commands;
using HSMVC.DataAccess;
using StructureMap;

namespace HSMVC.Controllers.Validation
{
    public class ConferenceEditCommandValidator : AbstractValidator<ConferenceEditCommand>
    {
        public ConferenceEditCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(RequiredMessage("Name"));
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage(RequiredMessage("StartDate"))
                .Must(IsAValidDate).WithMessage(NotAValidDateMessage("StartDate"));
            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage(RequiredMessage("EndDate"))
                .Must(IsAValidDate).WithMessage(NotAValidDateMessage("EndDate"));
            RuleFor(x => x.Cost).NotNull().WithMessage(RequiredMessage("Cost"));

            Custom(conference => DoesConferenceNameAlreadyExist(conference.Name)
                ? new ValidationFailure("Name", "The conference name already exists.")
                : null);
        }

        private static string RequiredMessage(string propertyName)
        {
            return string.Format("{0} is a required field.", propertyName);
        }

        private static string NotAValidDateMessage(string propertyName)
        {
            return string.Format("{0} is not a valid date.", propertyName);
        }

        private static bool IsAValidDate(DateTime? date)
        {
            return !date.Equals(default(DateTime));
        }

        private static bool DoesConferenceNameAlreadyExist(string nameToCheck)
        {
            if (string.IsNullOrEmpty(nameToCheck))
                return false;

            var conference = ObjectFactory.GetInstance<IConferenceRepository>()
                .FindByName(nameToCheck);

            return conference != null;
        }
    }
}