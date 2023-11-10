using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionProject.Models
{
    public class Institute
    {
        public Institute()
        {
            this.Campuses = new List<Campus>(); 
        }


        public int InstituteId { get; set; }
        [Required,StringLength(60),DisplayName("Institute Name")]
        public string InstituteName { get; set; } = default!;
        [Required]
        public int Established { get; set; }

        //nev

        public virtual ICollection<Campus> Campuses { get; set; }
    }

    public class Campus
    {
        public int CampusId { get; set; }
        [Required,StringLength(30),DisplayName("Principle Name")]
        public string PrincipleName { get; set; } = default!;
        [Required, StringLength(50)]
        public string Address { get; set; } = default!;
        [Required, StringLength(20)]
        public string Phone { get; set; } = default!;

        [ForeignKey("Institute")]
        [Required,DisplayName("Institute")]
        public int InstituteId { get; set; }

        public virtual Institute? Institute { get; set; }
    }

    public class InstituteDbContext : DbContext
    {
        public InstituteDbContext(DbContextOptions<InstituteDbContext> options):base(options)
        {

        }

        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Campus> Campuses { get; set; }
    }
}
