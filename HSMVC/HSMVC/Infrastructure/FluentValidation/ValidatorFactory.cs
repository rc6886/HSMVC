using System;
using FluentValidation;
using StructureMap;

namespace HSMVC.Infrastructure.FluentValidation
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IContainer _container;

        public ValidatorFactory()
        {

        }

        public IValidator<T> GetValidator<T>()
        {
            return ObjectFactory.GetInstance<T>() as IValidator<T>;
            //return _container.GetInstance<T>() as IValidator<T>;
        }

        public IValidator GetValidator(Type type)
        {
            return ObjectFactory.GetInstance(type) as IValidator;
            //return _container.GetInstance(type) as IValidator;
        }
    }
}