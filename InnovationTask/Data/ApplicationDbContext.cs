using InnovationTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnovationTask.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PhoneNumbers> phoneNumbers { get; set; }
        public DbSet<PhoneMessage> phoneMessages { get; set; }
     
    }
  
}