using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))        //error for true argument
            {
                throw new System.Exception("it is not a validator class");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);            //find validator typye
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];               //equate type in generic of base type to entity type
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);       //Validate all arguments in entity type's type
            foreach (var entity in entities)
            {
                Validationtool.Validate(validator, entity);
            }
        }
    }
}
