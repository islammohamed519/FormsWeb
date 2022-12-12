using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Models
{
    [Table("frmQuestions")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string? Qust_Title { get; set; }
        public int? IsRequired { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Question>? questions { get; set; }
        [ForeignKey("question")]
        public int ParentId { get; set; }
        public int? ControlId { get; set; }
        [ForeignKey("ControlId")]
        public ControlType? ControlType { get; set; }
        public int? FormId { get; set; }
        [ForeignKey("FormId")]
        public FrmForms? Form { get; set; }
        [NotMapped]
        public ICollection<DataSourceCtrl>? DataSourceCtrls { get; set; }
    }
}
