using CustomerApiWithService.Domain.Common;
using System;
using System.Linq;

namespace CustomerApiWithService.Domain.Entities
{
    public class Customer : ValuableBaseEntity
    {
        // Properties
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        // Ctors
        public Customer(string firstName, string lastName, string email, string phone)
            : this(Guid.NewGuid(), firstName, lastName, email, phone)
        {
        }

        public Customer(Guid id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;

            Validate();
        }

        // Methods
        public override bool Validate()
        {
            if (Id == Guid.Empty)
                ValidationResult.Add($"{nameof(Id)} é requerido.");

            if (String.IsNullOrEmpty(FirstName))
                ValidationResult.Add($"{nameof(FirstName)} é requerido.");

            if (String.IsNullOrEmpty(LastName))
                ValidationResult.Add($"{nameof(LastName)} é requerido.");

            if (String.IsNullOrEmpty(Email))
                ValidationResult.Add($"{nameof(Email)} é requerido.");

            if (String.IsNullOrEmpty(Phone))
                ValidationResult.Add($"{nameof(Phone)} é requerido.");

            return !ValidationResult.Any();
        }
    }
}
