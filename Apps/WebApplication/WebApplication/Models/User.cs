using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace WebApplication.Models
{
    public class User : IdentityUser
    {
        [JsonIgnore]
        [NotMapped]
        public const string AdminRole = "Admin";
        
        public DateTime BirthDate { get; set; }
    }
}