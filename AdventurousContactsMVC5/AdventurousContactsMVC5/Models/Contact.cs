using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContactsMVC5.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
        public class Contact_Metadata
        {
            [Required(ErrorMessage = "E-mail can't be blank.")]
            [DisplayName("E-mail")]
            [StringLength(50, ErrorMessage = "E-mail can not be longer than 50 characthers.")]
            [EmailAddress(ErrorMessage = "The e-mail is not valid.")]
            public string EmailAddress { get; set; }

            [Required(ErrorMessage = "First name can't be blank.")]
            [StringLength(50, ErrorMessage = "First name must not exceed 50 characthers.")]
            [DisplayName("First name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name can't be blank.")]
            [StringLength(50, ErrorMessage = "Last name must not exceed 50 charachters.")]
            [DisplayName("Last name")]
            public string LastName { get; set; }
        }
    }
}