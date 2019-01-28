using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TRACIE_API_AC.Models;

namespace TRACIE_API_IE.Models
{
    public class TracieIEContext : DbContext
    {
        public TracieIEContext(DbContextOptions<TracieIEContext> options)
        : base(options)
        { }
        public DbSet<IE_ascDirUser> AC_ascRequestFieldsRepresent { get; set; }
        public DbSet<IE_ascDirUserAdmin> AC_ascRequestItem { get; set; }


    }
}