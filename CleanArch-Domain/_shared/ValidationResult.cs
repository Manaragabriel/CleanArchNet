using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Domain._shared
{
    public class ValidationResult<O>
    {
        public bool Success { get; set; }
        public O? Data { get; set; }

        public ValidationResult(bool success, O?  data)
        {
            Success = success;
            Data = data;
        }
    }
}
