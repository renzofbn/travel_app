using System;
using System.Collections.Generic;
using System.Text;

namespace TRAVEL01.Tables
{
    public class RegUserTable
    {
        public Guid UserId {  get; set; } 
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int CantidadAdultos { get; set; }
        public int CantidadNinos { get; set; }
        public string Fecha { get; set; }

    }
}
