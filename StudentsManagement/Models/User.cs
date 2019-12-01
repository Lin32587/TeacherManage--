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

        [DisplayName("学号")]
        [Required(ErrorMessage ="学号不能为空")]
        [StringLength(12,MinimumLength=10,
            ErrorMessage ="学号必须十位字符")]
        public string UserID { get; set; }

        [Required(ErrorMessage ="姓名不能为空")]
        [DisplayName("姓名")]
        public string UserName { get; set; }

        [DisplayName("班级")]
        public string SClass { get; set; }

        [Required(ErrorMessage ="密码不能为空")]
        public string Pwd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score> Score { get; set; }
    }
}
