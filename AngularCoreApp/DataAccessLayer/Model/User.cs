﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Model
{
   public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public AddressInfo Address { get; set; }
    }

}
