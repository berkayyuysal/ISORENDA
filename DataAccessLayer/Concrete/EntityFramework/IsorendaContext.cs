using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Core.Entities.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public partial class IsorendaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("connectionDatabaseSettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AuthenticateRole> AuthenticateRoles { get; set; }
        public virtual DbSet<Authenticate> Authenticates { get; set; }
        public virtual DbSet<BasketClient> BasketClients { get; set; }
        public virtual DbSet<BasketCompany> BasketCompanies { get; set; }
        public virtual DbSet<BasketCourseMentor> BasketCourseMentors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryCourse> CategoryCourses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ClientEducationInformation> ClientEducationInformations { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CommentMentor> CommentMentors { get; set; }
        public virtual DbSet<CommentPost> CommentPosts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CourseMentorClient> CourseMentorClients { get; set; }
        public virtual DbSet<CourseMentor> CourseMentors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<DiscountCourseMentor> DiscountCourseMentors { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<FileAuthenticate> FileAuthenticates { get; set; }
        public virtual DbSet<FileClient> FileClients { get; set; }
        public virtual DbSet<FileMentor> FileMentors { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<LoginLog> LoginLogs { get; set; }
        public virtual DbSet<MentorEducationInformation> MentorEducationInformations { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ParentClient> ParentClients { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.Property(e => e.AddressId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Cities");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Towns");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Users");
            });

            modelBuilder.Entity<AuthenticateRole>(entity =>
            {
                entity.HasKey(e => e.AuthenticateRoleId);

                entity.Property(e => e.AuthenticateRoleId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Authenticate)
                    .WithMany(p => p.AuthenticateRoles)
                    .HasForeignKey(d => d.AuthenticateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthenticateRoles_Authenticates");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AuthenticateRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthenticateRoles_Roles");
            });

            modelBuilder.Entity<Authenticate>(entity =>
            {
                entity.HasKey(e => e.AuthenticateId);

                entity.Property(e => e.AuthenticateId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BasketClient>(entity =>
            {
                entity.HasKey(e => e.BasketClientId);

                entity.Property(e => e.BasketClientId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.BasketClients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketClients_Clients");
            });

            modelBuilder.Entity<BasketCompany>(entity =>
            {
                entity.HasKey(e => e.BasketCompanyId);

                entity.Property(e => e.BasketCompanyId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.BasketCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketCompanies_Companies");
            });

            modelBuilder.Entity<BasketCourseMentor>(entity =>
            {
                entity.HasKey(e => e.BasketCourseMentorId);

                entity.Property(e => e.BasketCourseMentorId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.BasketClient)
                    .WithMany(p => p.BasketCourseMentors)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketCourseMentors_BasketClients");

                entity.HasOne(d => d.BasketCompany)
                    .WithMany(p => p.BasketCourseMentors)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketCourseMentors_BasketCompanies");

                entity.HasOne(d => d.CourseMentor)
                    .WithMany(p => p.BasketCourseMentors)
                    .HasForeignKey(d => d.CourseMentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketCourseMentors_CourseMentors");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.CategoryParent)
                    .WithMany(p => p.InverseCategoryParent)
                    .HasForeignKey(d => d.CategoryParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categories_Categories");
            });

            modelBuilder.Entity<CategoryCourse>(entity =>
            {
                entity.HasKey(e => e.CategoryCourseId);

                entity.Property(e => e.CategoryCourseId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryCourses)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryCourses_Categories");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CategoryCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryCourses_Courses");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientEducationInformation>(entity =>
            {
                entity.HasKey(e => e.ClientEducationInformationId);

                entity.Property(e => e.ClientEducationInformationId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.HighSchoolName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UniversityName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientEducationInformations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientEducationInformations_Clients");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BirthDateOnIdentity).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RealBirthDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_Users");
            });

            modelBuilder.Entity<CommentMentor>(entity =>
            {
                entity.HasKey(e => e.CommentMentorId);

                entity.Property(e => e.CommentMentorId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentMentors)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentMentors_Comments");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.CommentMentors)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentMentors_Mentors");
            });

            modelBuilder.Entity<CommentPost>(entity =>
            {
                entity.HasKey(e => e.CommentPostId);

                entity.Property(e => e.CommentPostId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentPosts)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentPosts_Comments");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.CommentPosts)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentPosts_Posts");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Users");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.Property(e => e.CompanyId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Companies_Users");
            });

            modelBuilder.Entity<CourseMentorClient>(entity =>
            {
                entity.HasKey(e => e.CourseMentorClientId);

                entity.Property(e => e.CourseMentorClientId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CourseMentorClients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseMentorClients_Clients");

                entity.HasOne(d => d.CourseMentor)
                    .WithMany(p => p.CourseMentorClients)
                    .HasForeignKey(d => d.CourseMentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseMentorClients_CourseMentors");
            });

            modelBuilder.Entity<CourseMentor>(entity =>
            {
                entity.HasKey(e => e.CourseMentorId);

                entity.Property(e => e.CourseMentorId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseMentors)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseMentors_Courses");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.CourseMentors)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseMentors_Mentors");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.CourseId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DiscountCourseMentor>(entity =>
            {
                entity.HasKey(e => e.DiscountCourseMentorId);

                entity.Property(e => e.DiscountCourseMentorId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.CourseMentor)
                    .WithMany(p => p.DiscountCourseMentors)
                    .HasForeignKey(d => d.CourseMentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscountCourseMentors_CourseMentors");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountCourseMentors)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscountCourseMentors_Discounts");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.Property(e => e.DiscountId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FileAuthenticate>(entity =>
            {
                entity.HasKey(e => e.FileAuthenticateId)
                    .HasName("PK_FileAuthenticate");

                entity.Property(e => e.FileAuthenticateId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.FileAuthenticates)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileAuthenticates_Clients");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FileAuthenticates)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileAuthenticates_Files");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.FileAuthenticates)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileAuthenticates_Mentors");
            });

            modelBuilder.Entity<FileClient>(entity =>
            {
                entity.HasKey(e => e.FileClientId);

                entity.Property(e => e.FileClientId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FileClients)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileClients_Files");
            });

            modelBuilder.Entity<FileMentor>(entity =>
            {
                entity.HasKey(e => e.FileMentorId);

                entity.Property(e => e.FileMentorId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FileMentors)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileMentors_Files");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.FileId);

                entity.Property(e => e.FileId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.LikeId);

                entity.Property(e => e.LikeId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LikeDate).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Likes_Posts");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Likes_Users");
            });

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.HasKey(e => e.LoginLogId);

                entity.Property(e => e.LoginLogId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LoginDate).HasColumnType("datetime");

                entity.Property(e => e.LogoutDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoginLogs_Users");
            });

            modelBuilder.Entity<MentorEducationInformation>(entity =>
            {
                entity.HasKey(e => e.MentorEducationInformationId);

                entity.Property(e => e.MentorEducationInformationId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.HighSchoolName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UniversityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.MentorEducationInformations)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MentorEducationInformations_Mentors");
            });

            modelBuilder.Entity<Mentor>(entity =>
            {
                entity.HasKey(e => e.MentorId);

                entity.Property(e => e.MentorId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BirthDateOnIdentity).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RealBirthDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Mentors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mentors_Users");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.BasketClient)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_BasketClients");

                entity.HasOne(d => d.BasketCompany)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_BasketCompanies");
            });

            modelBuilder.Entity<ParentClient>(entity =>
            {
                entity.HasKey(e => e.ParentClientId);

                entity.Property(e => e.ParentClientId).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ParentClients)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentClients_Clients");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ParentClients)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentClients_Parents");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.ParentId);

                entity.Property(e => e.ParentId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BirthDateOnIdentity).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RealBirthDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parents_Users");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.PostContent)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Mentors");
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => e.RoleUserId);

                entity.Property(e => e.RoleUserId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUsers_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUsers_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId);

                entity.Property(e => e.TownId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength();

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
