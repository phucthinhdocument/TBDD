using System;
using System.Collections.Generic;

namespace TBDD.Model
{
    public partial class AttendanceRollCall
    {
        public string Id { get; set; }
        public string RegisterId { get; set; }
        public string DateCheck { get; set; }
        public string CheckAttendance { get; set; }
    }
}
