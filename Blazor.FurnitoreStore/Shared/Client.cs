using Blazor.FurnitoreStore.Shared.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitoreStore.Shared
{
    public  class Client
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="First Name in required")]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name in required")]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string LastName { get; set; }

        
        public DateTime BirthDate { get; set; }

        [DateValid]
        public DateTime  CreationDate { get; set; }

        [RegularExpression(@"\d{3}(-\d{9}){1}", ErrorMessage ="The phone number is invalid")] 
        public string Phone { get; set; }

        public string Address { get; set; }

        [EmailAddress (ErrorMessage ="Email format incorrect")]
        public string  Email { get; set; }

        [Range (0, 20,ErrorMessage = "The age  must be between 0 an 20")]
        [Required (ErrorMessage ="The age is required")]
        public int?  Age  { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string  Password { get; set; }

        
        [Compare("Password",ErrorMessage ="The password y re-password not macth")]
        public string  RePassword { get; set; }


        [CreditCard (ErrorMessage ="The credit card number is invalid")]
        public string CreditCard { get; set; }

    }
}
