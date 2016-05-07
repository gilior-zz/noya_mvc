using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSite
{
    public class Message
    {

        [Display(Name = "SenderName", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "FieldIsRequired")]
        public string SenderName { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),ErrorMessageResourceName= "FieldIsRequired")]

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Content", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "FieldIsRequired")]
        public string Content { get; set; }

        [Display(Name = "Notifications", ResourceType = typeof(Resources.Resources))]
        public bool Notifications { get; set; }

        public  bool OKMsg { get; set; }
    }
}