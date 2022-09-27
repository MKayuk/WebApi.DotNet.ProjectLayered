using FluentValidation.Results;

namespace Base.Core.SeedWork
{
    public abstract class Entity
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
