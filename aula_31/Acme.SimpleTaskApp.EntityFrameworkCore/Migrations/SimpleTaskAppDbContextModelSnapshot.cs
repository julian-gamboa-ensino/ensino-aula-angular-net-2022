using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Acme.SimpleTaskApp.EntityFrameworkCore;

namespace Acme.SimpleTaskApp.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(SimpleTaskAppDbContext))]
    partial class SimpleTaskAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acme.SimpleTaskApp.People.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.HasKey("Id");

                    b.ToTable("AppPersons");
                });

            modelBuilder.Entity("Acme.SimpleTaskApp.Tasks.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AssignedPersonId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 65536);

                    b.Property<byte>("State");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("AssignedPersonId");

                    b.ToTable("AppTasks");
                });

            modelBuilder.Entity("Acme.SimpleTaskApp.Tasks.Task", b =>
                {
                    b.HasOne("Acme.SimpleTaskApp.People.Person", "AssignedPerson")
                        .WithMany()
                        .HasForeignKey("AssignedPersonId");
                });
        }
    }
}
