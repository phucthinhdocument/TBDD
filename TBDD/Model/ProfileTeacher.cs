﻿using System;
using System.Collections.Generic;

namespace TBDD.Model
{
    public partial class ProfileTeacher
    {
        public string ProfileId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DepartmentId { get; set; }
        public string Specialize { get; set; }
    }
}
