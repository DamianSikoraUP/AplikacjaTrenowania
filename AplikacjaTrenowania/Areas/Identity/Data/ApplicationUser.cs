using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikacjaTrenowania.Models;
using Microsoft.AspNetCore.Identity;

namespace AplikacjaTrenowania.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public List<Trening> Treningi { get; set; } = [];

}

