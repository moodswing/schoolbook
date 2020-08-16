﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolBook.Models;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolBook.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationGrade> EducationGrades { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<MenuOption> MenuOptions { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentsClasses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TypePeriod> TypePeriods { get; set; }
        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<Log> Logs { get; set; }

        public static ILogger<ApplicationDbContext> Logger { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitialSeed(modelBuilder);
        }

        private static void InitialSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolYear>().HasIndex(e => e.Year).IsUnique();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "f67df2ce-0448-42a9-be11-3c68ea78d9c1", Name = "Administrador", NormalizedName = "Administrador".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "295b11cf-22e3-48b3-b6ab-538653c98c04", Name = "Profesor", NormalizedName = "Profesor".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "8176f8e0-49bf-44bd-9655-d39b9cf7111d", Name = "Apoderado", NormalizedName = "Apoderado".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "05ea2c83-210a-446d-971b-ecdf4f489461", Name = "Supervisor", NormalizedName = "Supervisor".ToUpper() });

            modelBuilder.Entity<TypePeriod>().HasData(new TypePeriod { Id = 1, Description = "Semestral" });
            modelBuilder.Entity<TypePeriod>().HasData(new TypePeriod { Id = 2, Description = "Trimestral" });

            modelBuilder.Entity<SchoolYear>().HasData(new SchoolYear { Id = 1, Year = 2020, Start = new DateTime(2020, 3, 1), End = new DateTime(2021, 1, 30) });

            modelBuilder.Entity<Period>().HasData(new Period { Id = 1, Description = "Primer Semestre", TypePeriodId = 1, Order = 1 });
            modelBuilder.Entity<Period>().HasData(new Period { Id = 2, Description = "Segundo Semestre", TypePeriodId = 1, Order = 2 });

            modelBuilder.Entity<Education>().HasData(new Education { Id = 1, Description = "Enseñansa Básica" });
            modelBuilder.Entity<Education>().HasData(new Education { Id = 2, Description = "Enseñansa Media" });

            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 1, Description = "Septimo Básico", YearId = 1 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 2, Description = "Octavo Básico", YearId = 1 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 3, Description = "Primero Medio", YearId = 1 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 4, Description = "Segundo Medio", YearId = 1 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 5, Description = "Tercero Medio", YearId = 1 });
            modelBuilder.Entity<Grade>().HasData(new Grade { Id = 6, Description = "Cuarto Medio", YearId = 1 });

            modelBuilder.Entity<Class>().HasData(new Class { Id = 1, Description = "Septimo Básico A", Abbreviation = "7A", GradeId = 1 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 2, Description = "Septimo Básico B", Abbreviation = "7B", GradeId = 1 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 3, Description = "Octavo Básico A", Abbreviation = "8A", GradeId = 2 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 4, Description = "Octavo Básico B", Abbreviation = "8A", GradeId = 2 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 5, Description = "Primero Medio A", Abbreviation = "1A", GradeId = 3 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 6, Description = "Primero Medio B", Abbreviation = "1B", GradeId = 3 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 7, Description = "Segundo Medio A", Abbreviation = "2A", GradeId = 4 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 8, Description = "Segundo Medio B", Abbreviation = "2B", GradeId = 4 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 9, Description = "Tercero Medio A", Abbreviation = "3A", GradeId = 5 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 10, Description = "Tercero Medio B", Abbreviation = "3B", GradeId = 5 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 11, Description = "Cuarto Medio A", Abbreviation = "4A", GradeId = 6 });
            modelBuilder.Entity<Class>().HasData(new Class { Id = 12, Description = "Cuarto Medio B", Abbreviation = "4B", GradeId = 6 });

            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 1, Description = "Historia y Geografía" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 2, Description = "Matemáticas" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 3, Description = "Lenguaje y Comunicaciones" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 4, Description = "Biología" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 5, Description = "Química" });
            modelBuilder.Entity<Subject>().HasData(new Subject { Id = 6, Description = "Física" });

            var counter = 1;
            for (var i = 1; i <= 12; i++) // classes
                for (var j = 1; j <= 6; j++) // subjects
                {
                    modelBuilder.Entity<ClassSubject>().HasData(new ClassSubject { Id = counter, ClassId = i, SubjectId = j });
                    counter++;
                }

            modelBuilder.Entity<Student>().HasData(new Student { Id = 1, Name = "Juanito Perez" });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 2, Name = "Luchito Jara" });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 3, Name = "Kenita Larrain" });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 4, Name = "Luly Love" });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 5, Name = "Felipito Camiroa" });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 6, Name = "Don Francisquito" });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 7, Name = "Julito Videla" });
            modelBuilder.Entity<Student>().HasData(new Student { Id = 8, Name = "Arturito Vidal" });

            counter = 1;
            for (var i = 1; i <= 8; i++) // students
                for (var j = 1; j <= 6; j++) // classes
                {
                    modelBuilder.Entity<StudentClass>().HasData(new StudentClass { Id = counter, StudentId = i, ClassId = j }); ;
                    counter++;
                }

            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 1, Description = "Libro de Clases", Icon = "small-icon svgcollege-029-papyrus", Order = 1 });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 2, Description = "Notas", GroupMenuOptionId = 1, Url = "ClassBook" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 3, Description = "Anotaciones", GroupMenuOptionId = 1, Url = "Observations" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 4, Description = "Evaluaciones", GroupMenuOptionId = 1, Url = "Evaluations" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 5, Description = "Asistencia", GroupMenuOptionId = 1, Url = "Attendance" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 6, Description = "Atrasos", GroupMenuOptionId = 1, Url = "Delays" });

            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 7, Description = "Alumnos", Icon = "small-icon svgcollege-019-reading-book", Order = 2 });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 8, Description = "Ficha Alumno", GroupMenuOptionId = 7, Url = "Student" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 9, Description = "Accidente Escolar", GroupMenuOptionId = 7, Url = "Accidents" });

            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 10, Description = "Administración", Icon = "small-icon svgcollege-043-test", Order = 4 });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 11, Description = "Credenciales", GroupMenuOptionId = 10, Url = "Credentials" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 12, Description = "Cambiar Contraseña", GroupMenuOptionId = 10, Url = "Password" });

            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 13, Description = "Horarios", Icon = "small-icon svgcollege-005-alarm", Order = 3 });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 14, Description = "Crear Horarios", GroupMenuOptionId = 13, Url = "ScheduleMaker" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 15, Description = "Horario Por Asignatura", GroupMenuOptionId = 13, Url = "ScheduleMaker?type=1" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 16, Description = "Horario Por Curso", GroupMenuOptionId = 13, Url = "ScheduleMaker?type=2" });
            modelBuilder.Entity<MenuOption>().HasData(new MenuOption { Id = 17, Description = "Horario Por Profesor", GroupMenuOptionId = 13, Url = "ScheduleMaker?type=3" });

            modelBuilder.Entity<Bulletin>().HasData(new Bulletin { Id = 1, Title = "Noticia de prueba 1", Subtitle = "Que tema tan interesante nos hablan hoy", Content = "Esto es demasiado interesante..", Image = "https://www.elosceolastar.com/wp-content/uploads/2020/07/empty-classroom_elementary-school-middle-school-high-school.jpg" });
            modelBuilder.Entity<Bulletin>().HasData(new Bulletin { Id = 2, Title = "Noticia de prueba 2", Subtitle = "Que tema tan interesante nos hablan hoy", Content = "Esto es demasiado interesante..", Image = "https://www.andree.cl/home3/images/stories/slideshow2014/foto_03.jpg" });
            modelBuilder.Entity<Bulletin>().HasData(new Bulletin { Id = 3, Title = "Noticia de prueba 3", Subtitle = "Que tema tan interesante nos hablan hoy", Content = "Esto es demasiado interesante..", Image = "https://lh5.googleusercontent.com/proxy/dv9-TY9gKRTLd9zTuxrQYfx6H67fgMhCBBBjHNDZrSdv0RDqhiI3a8SBmQyHXyVVz983bM53TmXyiSU" });
            modelBuilder.Entity<Bulletin>().HasData(new Bulletin { Id = 4, Title = "Noticia de prueba 4", Subtitle = "Que tema tan interesante nos hablan hoy", Content = "Esto es demasiado interesante..", Image = "https://www.sketchup.com/sites/www.sketchup.com/files/molecule_image/IMG_01_SCHOOL_SCENE_01_low-1.png" });
        }

        public static async Task SeedUsersAsync(UserManager<User> userManager, ApplicationDbContext dbContext, ILogger<ApplicationDbContext> logger)
        {
            Logger = logger;

            var managerId = Guid.NewGuid().ToString();

            dbContext.Users.RemoveRange(dbContext.Users);
            //dbContext.SaveChanges();

            await AddUserAndRoleAsync("nic@sclbk.com", "Nicolas Rivera", "Supervisor", userManager, dbContext, managerId);
            await AddUserAndRoleAsync("rob@sclbk.com", "Robinson Aravena", "Administrador", userManager, dbContext);
            await AddUserAndRoleAsync("nat@sclbk.com", "Nathalie Barra", "Profesor", userManager, dbContext);
            await AddUserAndRoleAsync("jon@sclbk.com", "Jonathan Rocha", "Apoderado", userManager, dbContext);

            foreach (var role in dbContext.Roles)
                foreach (var option in dbContext.MenuOptions)
                {
                    var rolMenu = new RoleMenu
                    {
                        MenuOptionId = option.Id,
                        RoleId = role.Id
                    };

                    dbContext.RoleMenus.Add(rolMenu);
                }

            foreach (var education in dbContext.Educations)
                foreach (var grade in dbContext.Grades)
                {
                    var educationGrade = new EducationGrade
                    {
                        EducationId = education.Id,
                        GradeId = grade.Id
                    };

                    dbContext.EducationGrades.Add(educationGrade);
                }

            dbContext.SaveChanges();
        }

        public static async Task AddUserAndRoleAsync(string email, string userName, string role, UserManager<User> userManager, ApplicationDbContext dbContext, string managerId = "")
        {
            var findByEmail = userManager.FindByEmailAsync(email);
            if (findByEmail.Result == null)
            {
                User user = new User
                {
                    UserName = userName,
                    Email = email,
                    IdSuperior = managerId,
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "1234567").Result;

                if (result.Succeeded)
                {
                    Logger.LogInformation("Usuario " + userName + " registrado con éxito.");

                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, email));
                    userManager.AddToRoleAsync(user, role).Wait();
                }
            }
            else
            {
                var user = dbContext.Users.FirstOrDefault(e => e.Email.Equals(email));
                var claims = await userManager.GetClaimsAsync(user);

                if (!userManager.IsInRoleAsync(user, role).Result)
                    userManager.AddToRoleAsync(user, role).Wait();

                if (claims.Any(c => c.Type.Equals(ClaimTypes.Email)))
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, email));
            }
        }
    }
}