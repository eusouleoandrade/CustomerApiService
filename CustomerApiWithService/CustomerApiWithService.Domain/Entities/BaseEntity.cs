using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApiWithService.Domain
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; protected set; }

        [NotMapped]
        public bool Valid { get; protected set; }

        [NotMapped]
        public bool Invalid => !Valid;

        [NotMapped]
        public IEnumerable<string> ValidationResult { get; private set; }


    }
}
