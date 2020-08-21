using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolBook.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IdSuperior = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bulletins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Subtitle = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogLevel = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    Msg = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    GroupMenuOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSelections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSelections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: true),
                    MenuOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMenus_MenuOptions_MenuOptionId",
                        column: x => x.MenuOptionId,
                        principalTable: "MenuOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenus_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    YearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_SchoolYears_YearId",
                        column: x => x.YearId,
                        principalTable: "SchoolYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    TypePeriodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Periods_TypePeriods_TypePeriodId",
                        column: x => x.TypePeriodId,
                        principalTable: "TypePeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    GradeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationGrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationId = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationGrades_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsClasses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Grade = table.Column<double>(nullable: false),
                    GradeSubjectId = table.Column<int>(nullable: false),
                    ClassSubjectId = table.Column<int>(nullable: true),
                    PeriodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_ClassSubjects_ClassSubjectId",
                        column: x => x.ClassSubjectId,
                        principalTable: "ClassSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_TypePeriods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "TypePeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f67df2ce-0448-42a9-be11-3c68ea78d9c1", "48d62dea-f3da-4a93-b29a-238f32b8110b", "Administrador", "ADMINISTRADOR" },
                    { "295b11cf-22e3-48b3-b6ab-538653c98c04", "5699460f-69a0-44b4-a503-bf7d71455516", "Profesor", "PROFESOR" },
                    { "8176f8e0-49bf-44bd-9655-d39b9cf7111d", "e83e495d-60b3-4f97-96b5-421ddfde7307", "Apoderado", "APODERADO" },
                    { "05ea2c83-210a-446d-971b-ecdf4f489461", "54461591-525d-4d79-b307-0e20e792ee4f", "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "Bulletins",
                columns: new[] { "Id", "Content", "Image", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, "Esto es demasiado interesante..", "https://www.elosceolastar.com/wp-content/uploads/2020/07/empty-classroom_elementary-school-middle-school-high-school.jpg", "Que tema tan interesante nos hablan hoy", "Noticia de prueba 1" },
                    { 2, "Esto es demasiado interesante..", "https://www.andree.cl/home3/images/stories/slideshow2014/foto_03.jpg", "Que tema tan interesante nos hablan hoy", "Noticia de prueba 2" },
                    { 3, "Esto es demasiado interesante..", "https://lh5.googleusercontent.com/proxy/dv9-TY9gKRTLd9zTuxrQYfx6H67fgMhCBBBjHNDZrSdv0RDqhiI3a8SBmQyHXyVVz983bM53TmXyiSU", "Que tema tan interesante nos hablan hoy", "Noticia de prueba 3" },
                    { 4, "Esto es demasiado interesante..", "https://www.sketchup.com/sites/www.sketchup.com/files/molecule_image/IMG_01_SCHOOL_SCENE_01_low-1.png", "Que tema tan interesante nos hablan hoy", "Noticia de prueba 4" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 2, "Enseñansa Media" },
                    { 1, "Enseñansa Básica" }
                });

            migrationBuilder.InsertData(
                table: "MenuOptions",
                columns: new[] { "Id", "Description", "GroupMenuOptionId", "Icon", "Order", "Url" },
                values: new object[,]
                {
                    { 17, "Horario Por Profesor", 13, null, 0, "ScheduleMaker?type=3" },
                    { 16, "Horario Por Curso", 13, null, 0, "ScheduleMaker?type=2" },
                    { 15, "Horario Por Asignatura", 13, null, 0, "ScheduleMaker?type=1" },
                    { 14, "Crear Horarios", 13, null, 0, "ScheduleMaker" },
                    { 13, "Horarios", 0, "small-icon svgcollege-005-alarm", 3, null },
                    { 11, "Credenciales", 10, null, 0, "Credentials" },
                    { 10, "Administración", 0, "small-icon svgcollege-043-test", 4, null },
                    { 9, "Accidente Escolar", 7, null, 0, "Accidents" },
                    { 12, "Cambiar Contraseña", 10, null, 0, "Password" },
                    { 7, "Alumnos", 0, "small-icon svgcollege-019-reading-book", 2, null },
                    { 6, "Atrasos", 1, null, 0, "Delays" },
                    { 5, "Asistencia", 1, null, 0, "Attendance" },
                    { 4, "Evaluaciones", 1, null, 0, "Evaluations" },
                    { 3, "Anotaciones", 1, null, 0, "Observations" },
                    { 2, "Notas", 1, null, 0, "ClassBook" },
                    { 1, "Libro de Clases", 0, "small-icon svgcollege-029-papyrus", 1, null },
                    { 8, "Ficha Alumno", 7, null, 0, "Student" }
                });

            migrationBuilder.InsertData(
                table: "SchoolYears",
                columns: new[] { "Id", "End", "Start", "Year" },
                values: new object[] { 1, new DateTime(2021, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Arturito Vidal" },
                    { 7, "Julito Videla" },
                    { 6, "Don Francisquito" },
                    { 5, "Felipito Camiroa" },
                    { 4, "Luly Love" },
                    { 2, "Luchito Jara" },
                    { 1, "Juanito Perez" },
                    { 3, "Kenita Larrain" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Historia y Geografía" },
                    { 2, "Matemáticas" },
                    { 3, "Lenguaje y Comunicaciones" },
                    { 4, "Biología" },
                    { 5, "Química" },
                    { 6, "Física" }
                });

            migrationBuilder.InsertData(
                table: "TypePeriods",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Semestral" },
                    { 2, "Trimestral" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Description", "YearId" },
                values: new object[,]
                {
                    { 1, "Septimo Básico", 1 },
                    { 2, "Octavo Básico", 1 },
                    { 3, "Primero Medio", 1 },
                    { 4, "Segundo Medio", 1 },
                    { 5, "Tercero Medio", 1 },
                    { 6, "Cuarto Medio", 1 }
                });

            migrationBuilder.InsertData(
                table: "Periods",
                columns: new[] { "Id", "Description", "End", "Order", "Start", "TypePeriodId" },
                values: new object[,]
                {
                    { 1, "Primer Semestre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Segundo Semestre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Abbreviation", "Description", "GradeId" },
                values: new object[,]
                {
                    { 1, "7A", "A", 1 },
                    { 2, "7B", "B", 1 },
                    { 3, "8A", "A", 2 },
                    { 4, "8A", "B", 2 },
                    { 5, "1A", "A", 3 },
                    { 6, "1B", "B", 3 },
                    { 7, "2A", "A", 4 },
                    { 8, "2B", "B", 4 },
                    { 9, "3A", "A", 5 },
                    { 10, "3B", "B", 5 },
                    { 11, "4A", "A", 6 },
                    { 12, "4B", "B", 6 }
                });

            migrationBuilder.InsertData(
                table: "ClassSubjects",
                columns: new[] { "Id", "ClassId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 46, 8, 4 },
                    { 45, 8, 3 },
                    { 44, 8, 2 },
                    { 43, 8, 1 },
                    { 42, 7, 6 },
                    { 41, 7, 5 },
                    { 40, 7, 4 },
                    { 39, 7, 3 },
                    { 38, 7, 2 },
                    { 47, 8, 5 },
                    { 37, 7, 1 },
                    { 35, 6, 5 },
                    { 34, 6, 4 },
                    { 33, 6, 3 },
                    { 32, 6, 2 },
                    { 31, 6, 1 },
                    { 30, 5, 6 },
                    { 29, 5, 5 },
                    { 71, 12, 5 },
                    { 27, 5, 3 },
                    { 36, 6, 6 },
                    { 26, 5, 2 },
                    { 48, 8, 6 },
                    { 50, 9, 2 },
                    { 70, 12, 4 },
                    { 69, 12, 3 },
                    { 68, 12, 2 },
                    { 67, 12, 1 },
                    { 66, 11, 6 },
                    { 65, 11, 5 },
                    { 64, 11, 4 },
                    { 63, 11, 3 },
                    { 62, 11, 2 },
                    { 49, 9, 1 },
                    { 61, 11, 1 },
                    { 59, 10, 5 },
                    { 58, 10, 4 },
                    { 57, 10, 3 },
                    { 56, 10, 2 },
                    { 55, 10, 1 },
                    { 54, 9, 6 },
                    { 53, 9, 5 },
                    { 52, 9, 4 },
                    { 51, 9, 3 },
                    { 60, 10, 6 },
                    { 25, 5, 1 },
                    { 28, 5, 4 },
                    { 72, 12, 6 },
                    { 18, 3, 6 },
                    { 15, 3, 3 },
                    { 24, 4, 6 },
                    { 14, 3, 2 },
                    { 13, 3, 1 },
                    { 12, 2, 6 },
                    { 11, 2, 5 },
                    { 10, 2, 4 },
                    { 9, 2, 3 },
                    { 8, 2, 2 },
                    { 17, 3, 5 },
                    { 7, 2, 1 },
                    { 16, 3, 4 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 },
                    { 20, 4, 2 },
                    { 21, 4, 3 },
                    { 22, 4, 4 },
                    { 23, 4, 5 },
                    { 19, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "StudentsClasses",
                columns: new[] { "Id", "ClassId", "StudentId" },
                values: new object[,]
                {
                    { 44, 2, 8 },
                    { 38, 2, 7 },
                    { 32, 2, 6 },
                    { 26, 2, 5 },
                    { 8, 2, 2 },
                    { 14, 2, 3 },
                    { 2, 2, 1 },
                    { 1, 1, 1 },
                    { 7, 1, 2 },
                    { 43, 1, 8 },
                    { 37, 1, 7 },
                    { 31, 1, 6 },
                    { 25, 1, 5 },
                    { 19, 1, 4 },
                    { 20, 2, 4 },
                    { 13, 1, 3 },
                    { 48, 6, 8 },
                    { 42, 6, 7 },
                    { 10, 4, 2 },
                    { 16, 4, 3 },
                    { 22, 4, 4 },
                    { 28, 4, 5 },
                    { 34, 4, 6 },
                    { 40, 4, 7 },
                    { 46, 4, 8 },
                    { 45, 3, 8 },
                    { 5, 5, 1 },
                    { 11, 5, 2 },
                    { 17, 5, 3 },
                    { 23, 5, 4 },
                    { 29, 5, 5 },
                    { 3, 3, 1 },
                    { 35, 5, 6 },
                    { 47, 5, 8 },
                    { 39, 3, 7 },
                    { 33, 3, 6 },
                    { 27, 3, 5 },
                    { 21, 3, 4 },
                    { 15, 3, 3 },
                    { 9, 3, 2 },
                    { 6, 6, 1 },
                    { 12, 6, 2 },
                    { 18, 6, 3 },
                    { 24, 6, 4 },
                    { 30, 6, 5 },
                    { 36, 6, 6 },
                    { 41, 5, 7 },
                    { 4, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GradeId",
                table: "Classes",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_ClassId",
                table: "ClassSubjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_SubjectId",
                table: "ClassSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationGrades_EducationId",
                table: "EducationGrades",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationGrades_GradeId",
                table: "EducationGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ClassSubjectId",
                table: "Evaluations",
                column: "ClassSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_PeriodId",
                table: "Evaluations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_YearId",
                table: "Grades",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_TypePeriodId",
                table: "Periods",
                column: "TypePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_MenuOptionId",
                table: "RoleMenus",
                column: "MenuOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_RoleId",
                table: "RoleMenus",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYears_Year",
                table: "SchoolYears",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsClasses_ClassId",
                table: "StudentsClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsClasses_StudentId",
                table: "StudentsClasses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSelections_UserId",
                table: "UserSelections",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bulletins");

            migrationBuilder.DropTable(
                name: "EducationGrades");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "RoleMenus");

            migrationBuilder.DropTable(
                name: "StudentsClasses");

            migrationBuilder.DropTable(
                name: "UserSelections");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "ClassSubjects");

            migrationBuilder.DropTable(
                name: "TypePeriods");

            migrationBuilder.DropTable(
                name: "MenuOptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "SchoolYears");
        }
    }
}
