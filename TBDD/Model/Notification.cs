using System;
using System.Collections.Generic;

namespace TBDD.Model
{
    public partial class Notification
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SubjectId { get; set; }
        public string TeacherId { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
