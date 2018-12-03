using System;
using System.Collections.Generic;

namespace TBDD.Model
{
    public partial class RegisterSubject
    {
        public string RegisterId { get; set; }
        public string StudentId { get; set; }
        public string TeacherId { get; set; }
        public string SubjectId { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
    }
}
