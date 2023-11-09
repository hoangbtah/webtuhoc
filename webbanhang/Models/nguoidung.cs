namespace webbanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("nguoidung")]
    public partial class nguoidung
    {
        [Key]
        [DisplayName("Mã người dùng")]
        [Required(ErrorMessage = "{0} không được để trổng")]
       
        public int manguoidung { get; set; }

        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(250, ErrorMessage = "{0} không được được quá 250 kí tự")]
        public string hoten { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(250, ErrorMessage = "{0} không được được quá 250 kí tự")]
        public string matkhau { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(250, ErrorMessage = "{0} không được được quá 250 kí tự")]
        public string email { get; set; }
    }
}
