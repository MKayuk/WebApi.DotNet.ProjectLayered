using Base.Core.SeedWork;
using Base.Core.Validation;
using System;

namespace Base.Core.Aggregate
{
    public class Base : SeedWork.Entity, IAggregateRoot
    {
        public Base(Guid id, string cpf)
        {
            Id = id;
            Cpf = cpf;
        }

        public Base(string cpf)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
        }

        /// <summary>
        /// Information's reference id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Unique personal document
        /// </summary>
        public string Cpf { get; }

        public override bool IsValid()
        {
            ValidationResult = new BaseValidation()
                .Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
