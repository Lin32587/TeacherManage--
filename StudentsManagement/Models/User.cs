namespace StudentsManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Score = new HashSet<Score>();
        }

        [DisplayName("ѧ��")]
        [Required(ErrorMessage ="ѧ�Ų���Ϊ��")]
        [StringLength(12,MinimumLength=10,
            ErrorMessage ="ѧ�ű���ʮλ�ַ�")]
        public string UserID { get; set; }

        [Required(ErrorMessage ="��������Ϊ��")]
        [DisplayName("����")]
        public string UserName { get; set; }

        [DisplayName("�༶")]
        public string SClass { get; set; }

        [Required(ErrorMessage ="���벻��Ϊ��")]
        public string Pwd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Score { get; set; }
    }
}
