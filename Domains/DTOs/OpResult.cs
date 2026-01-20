using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.DTOs
{
    public class OpResult
    {
        public OpStatus Status { get; set; }
        public string Message { get; set; }
        public EditUserRequest EditUserRequest { get; set; }
    }
}
