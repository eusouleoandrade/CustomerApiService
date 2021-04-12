using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CustomerApiWithService.Domain.Common
{
    public abstract class ValuableBaseEntity
    {
        // Properties
        public virtual Guid Id { get; protected set; }

        [NotMapped]
        public bool Valid => !ValidationResult.Any();

        [NotMapped]
        public bool Invalid => !Valid;

        [NotMapped]
        public IList<string> ValidationResult { get; protected set; }

        // Ctors
        public ValuableBaseEntity()
        {
            ValidationResult = new List<string>();
        }

        // Methods
        public abstract bool Validate();
    }
}
