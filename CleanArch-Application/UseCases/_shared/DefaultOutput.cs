using CleanArch_Domain._shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Application.UseCases._shared
{
    public class DefaultOutput<O>
    {
        public bool Success { get; set; }

        public string Message { get; set; }
        public O? Result { get;  set; }

        public IEnumerable<Notification>? Notifications { get; set; }
    }
}
