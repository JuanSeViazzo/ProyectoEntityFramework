using Microsoft.EntityFrameworkCore;
using projectEf.Models;

namespace projectEf
{
    class WorksContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Work> Works { get; set; }

        public WorksContext(DbContextOptions<WorksContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Category> categoryInit = new List<Category>();
            categoryInit.Add(new Category() {CategoryId = Guid.Parse("11d14284-1d76-493f-8b12-9cd72c81cfe4"),Name = "pending activities", Weight=20});
            categoryInit.Add(new Category() {CategoryId = Guid.Parse("0af42020-57e2-4b2d-a666-a579268e75b5"),Name = "personal activities", Weight=50});




            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Categoria");
                category.HasKey(propiedad => propiedad.CategoryId);

                category.Property(propiedad => propiedad.Name).IsRequired().HasMaxLength(150);

                category.Property(p => p.Description).IsRequired(false);
                category.Property(p=> p.Weight);
                //HAS DATA, permite en Fluent API agregar datos por defecto a un modelo
                category.HasData(categoryInit);

            });

            List<Work> worksInit = new List<Work>();
            worksInit.Add(new Work() {WorkId = Guid.Parse("11d14284-1d76-493f-8b12-9cd72c81cfe4"),CategoryId = Guid.Parse("11d14284-1d76-493f-8b12-9cd72c81cfe4"), WorkPriority = Work.Priority.Medium, Title="payment of public services", CreationDate = DateTime.Now});  
            
            worksInit.Add(new Work() {WorkId = Guid.Parse("11d14284-1d76-493f-8b12-9cd72c81cf10"),CategoryId = Guid.Parse("0af42020-57e2-4b2d-a666-a579268e75b5"), WorkPriority = Work.Priority.Low, Title="finish watching a movie on netflix", CreationDate = DateTime.Now});
            modelBuilder.Entity<Work>(work =>
            {
                work.ToTable("Tarea");
                work.HasKey(work => work.WorkId);
                work.HasOne(work => work.Category).WithMany(work => work.Works).HasForeignKey(work => work.CategoryId);
                work.Property(p => p.Title).IsRequired().HasMaxLength(200);
                work.Property(p => p.Description);
                work.Property(p => p.WorkPriority);
                work.Property(p => p.CreationDate);
                //Ignore es igual a NotMapped
                work.Ignore(p=> p.Summary);
                work.HasData(worksInit);

            });

        }










   }
}
