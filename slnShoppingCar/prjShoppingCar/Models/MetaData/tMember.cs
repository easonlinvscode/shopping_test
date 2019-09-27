using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjShoppingCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(tMember_metadata))]
    public partial class tMember
    {
        private class tMember_metadata
        {
            
            public int fId { get; set; }

            [DisplayName("帳號")]
            [Required]
            public string fUserId { get; set; }

            [DisplayName("密碼")]
            [Required]
            public string fPwd { get; set; }

            [DisplayName("姓名")]
            [Required]
            public string fName { get; set; }

            [DisplayName("信箱")]
            [Required]
            public string fEmail { get; set; }

            [DisplayName("手機")]
            [Required]
            public string fTel { get; set; }

            [DisplayName("性別")]

            public string fSex { get; set; }

            [DisplayName("生日")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy/MM/dd}")]
            public Nullable<System.DateTime> fBirthday { get; set; }

            [DisplayName("地址")]
            [Required]
            public string fUAddress { get; set; }
        }
        
    }
}
