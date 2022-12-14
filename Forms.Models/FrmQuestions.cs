// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Forms.Models
{
    public partial class FrmQuestions
    {
        public FrmQuestions()
        {
            DataSourceCtrl = new HashSet<DataSourceCtrl>();
            FrmAnswers = new HashSet<FrmAnswers>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Question { get; set; }
        public bool? IsRequired { get; set; }
        public int? ControlId { get; set; }
        public int? FormsId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ControlType Control { get; set; }
        public virtual FrmForms Forms { get; set; }
        public virtual ICollection<DataSourceCtrl> DataSourceCtrl { get; set; }
        public virtual ICollection<FrmAnswers> FrmAnswers { get; set; }
    }
}