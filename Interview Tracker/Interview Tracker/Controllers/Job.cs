//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Interview_Tracker.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        public Job()
        {
            this.Interviews = new HashSet<Interview>();
        }
    
        public int JobId { get; set; }
        public string PositionTitle { get; set; }
        public string Company { get; set; }
        public string JobDescription { get; set; }
        public string ApplicationStatus { get; set; }
    
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
