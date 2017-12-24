using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace admin.Core
{
    public class LoginModel
    {

        [Required(ErrorMessage = "账号不能为空")]
        public string LoginName { set; get; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { set; get; }
    }
}