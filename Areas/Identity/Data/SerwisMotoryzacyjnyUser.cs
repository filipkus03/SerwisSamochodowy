using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SerwisMotoryzacyjny.Areas.Identity.Data;

public class SerwisMotoryzacyjnyUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? Role { get; set; }


}

