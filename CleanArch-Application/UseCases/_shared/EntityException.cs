using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Application.UseCases._shared
{
    public class EntityException: Exception
    {
        public override string Message { get; }

        public EntityException(string message) {
            Message = message;
        }

    }
}
