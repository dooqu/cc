using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace callcenter.modal
{
    public class ServiceUserInfo
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "账号不能为空")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码不能为空")]
        public string PassWord { get; set; }
        public int Status { get; set; }
        public bool Function1 { get; set; }
        public bool Function2 { get; set; }
        public bool Function3 { get; set; }
        public bool Function4 { get; set; }
        public bool Function5 { get; set; }
        public bool Function6 { get; set; }
        public DateTime  CreateTime { get; set; }
        public int IsDelete { get; set; }
    }
}
