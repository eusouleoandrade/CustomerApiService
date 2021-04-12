using System.Collections.Generic;
using System.Linq;

namespace CustomerApiWithService.Application.Services
{
    public abstract class ValuableBaseService
    {
        // Fields
        protected List<string> _validationResult;

        // Properties
        public bool Valid => !ValidationResult.Any();

        public bool Invalid => !Valid;

        public List<string> ValidationResult => _validationResult;

        // Ctors
        public ValuableBaseService()
        {
            _validationResult = new List<string>();
        }
    }
}
