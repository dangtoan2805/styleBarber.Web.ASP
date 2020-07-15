using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Models
{
    public class ContactVM
    {
        [StringLength(maximumLength: 30, MinimumLength = 1, ErrorMessage = "Tên từ 1 đến 30 ký tự")]
        public string FirstName { get; set; }
        [StringLength(maximumLength: 30, MinimumLength = 1, ErrorMessage = "Họ từ 1 đến 30 ký tự")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống!")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Email không được bỏ trống!")]
        public string Email { get; set; }
        public string Note { get; set; }
    }
}