﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.dtos.Request
{
    public class UserRequest
    {
        public string UserCode { get; set; }
        public string Password { get; set; }
    }
}
