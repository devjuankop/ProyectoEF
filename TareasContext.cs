namespace proyectoEF;
using Microsoft.EntityFrameworkCore;
using proyectoEF.Models;

public class TareasContext: DbContext{
    public DbSet<Categoria> Categorias {get;set;}

    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaID = Guid.Parse("97edcd52-e5c2-44ce-b112-16c4bb570538"), Nombre = "Actividades pendientes", Peso=30});
        categoriasInit.Add(new Categoria() { CategoriaID = Guid.Parse("97edcd52-e5c2-44ce-b112-16c4bb570535"), Nombre = "Actividades personales", Peso=50});

        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaID);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p=> p.Descripcion).IsRequired(false);

            categoria.Property(p=> p.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() { TareaID = Guid.Parse("97edcd52-e5c2-44ce-b112-16c4bb570533"), CategoriaID = Guid.Parse("97edcd52-e5c2-44ce-b112-16c4bb570538"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea() { TareaID = Guid.Parse("97edcd52-e5c2-44ce-b112-16c4bb570530"), CategoriaID = Guid.Parse("97edcd52-e5c2-44ce-b112-16c4bb570535"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula en netflix", FechaCreacion = DateTime.Now});

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaID);

            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaID);

            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);

            tarea.Property(p=> p.Descripcion).IsRequired(false);

            tarea.Property(p=> p.PrioridadTarea);

            tarea.Property(p=> p.FechaCreacion);

            tarea.Ignore(p=> p.Resumen);

            tarea.HasData(tareasInit);

        });
    }
}