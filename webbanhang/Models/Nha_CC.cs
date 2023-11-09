namespace webbanhang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    public partial class Nha_CC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nha_CC()
        {
            Hangs = new HashSet<Hang>();
        }

        [Key]
        [StringLength(10, ErrorMessage = "{0} không được vượt quá 10 kí tự")]
        [DisplayName("Mã nhà cung cấp")]
        [Required(ErrorMessage ="{0} không được để trổng")]
        public string MaNCC { get; set; }

        [DisplayName("Tên nhà cung cấp")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(50, ErrorMessage = "{0} không được được quá 50 kí tự")]
        public string TenNCC { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(50, ErrorMessage = "{0} không được được quá 50 kí tự")]
        public string DiaChi { get; set; }

        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(50, ErrorMessage = "{0} không được được quá 10 kí tự")]
        public string DienThoai { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} không được để trổng")]
        [StringLength(50, ErrorMessage = "{0} không được được quá 50 kí tự")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hang> Hangs { get; set; }
    }
}
