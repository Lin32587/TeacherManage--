namespace StudentsManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Score")]
    public partial class Score
    {
        [Key]
        [StringLength(10)]
        public string SID { get; set; }

        [Required]
        [StringLength(12)]
        [DisplayName("学号")]
        public string UserID { get; set; }

        [Required]
        [StringLength(3)]
        [DisplayName("课程编号")]
        public string CID { get; set; }

        [DisplayName("学生人数")]
        [Range(0,200,ErrorMessage ="人数必须是0-200之间的整数！")]
        public int Grade { get; set; }

        [DisplayName("上课地点")]
        public string Place { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("上课时间"),
            DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime? TestTime { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
