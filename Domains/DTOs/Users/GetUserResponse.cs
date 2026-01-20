using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.DTOs.Users
{
    public class GetUserResponse
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
