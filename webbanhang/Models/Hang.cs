namespace webbanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Hang")]
    public partial class Hang
    {
        [Key]
        [DisplayName("Mã hàng")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(10, ErrorMessage = "{0} không được được quá 10 kí tự")]
        public string MaHang { get; set; }

        [DisplayName("Mã nhà cung cấp")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(10, ErrorMessage = "{0} không được được quá 10 kí tự")]
        public string MaNCC { get; set; }

        [DisplayName("Tên hàng")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(250, ErrorMessage = "{0} không được được quá 250 kí tự")]
        public string TenHang { get; set; }

        [DisplayName("Giá")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        
        public decimal? Gia { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        
        public decimal LuongCo { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(500, ErrorMessage = "{0} không được được quá 500 kí tự")]
        public string MoTa { get; set; }
        [DisplayName("Chiết khấu")]
        public decimal? ChietKhau { get; set; }
        [DisplayName("Hình ảnh")]
        [StringLength(100)]
        public string HinhAnh { get; set; }

        public virtual Nha_CC Nha_CC { get; set; }
    }
}
