namespace WebApi2TestApp1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FuJenClassroomModel : DbContext
    {
        public FuJenClassroomModel()
            : base("name=FuJenClassroomModels")
        {
        }

        public virtual DbSet<ClassRooms> ClassRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
