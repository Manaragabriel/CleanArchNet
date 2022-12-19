using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Domain._shared
{
    public  class Notification
    {
        public string Key { get; set; }
        public string[] Message { get; set; }

        public Notification(string Key, string[] Message)
        {
            this.Key = Key;
            this.Message = Message;
        }
    }
}
