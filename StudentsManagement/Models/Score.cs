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
        [DisplayName("ѧ��")]
        public string UserID { get; set; }

        [Required]
        [StringLength(3)]
        [DisplayName("�γ̱��")]
        public string CID { get; set; }

        [DisplayName("�ɼ�")]
        [Range(0,100,ErrorMessage ="�ɼ�������0-100֮���������")]
        public int Grade { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("����ʱ��"),
            DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime? TestTime { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
