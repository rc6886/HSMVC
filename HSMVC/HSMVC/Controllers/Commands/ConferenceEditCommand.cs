using System;
using FluentValidation.Attributes;
using HSMVC.Controllers.Validation;

namespace HSMVC.Controllers.Commands
{
    //[Validator(typeof(ConferenceEditCommandValidator))]
    public class ConferenceEditCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HashTag { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Cost { get; set; }
    }
}