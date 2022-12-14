// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ChessDbContext))]
    [Migration("20221213153601_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BlackELO")
                        .HasColumnType("integer");

                    b.Property<int>("BlackRatingDiff")
                        .HasColumnType("integer");

                    b.Property<Guid?>("BlackUserId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndGameTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GameMoves")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartGameTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("TimeControl")
                        .HasColumnType("time without time zone");

                    b.Property<int>("WhiteELO")
                        .HasColumnType("integer");

                    b.Property<int>("WhiteRatingDiff")
                        .HasColumnType("integer");

                    b.Property<Guid?>("WhiteUserId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BlackUserId");

                    b.HasIndex("WhiteUserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Biography")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<int>("ELO")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Privilege")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Game", b =>
                {
                    b.HasOne("Domain.Models.User", "BlackUser")
                        .WithMany("BlackGames")
                        .HasForeignKey("BlackUserId")
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "WhiteUser")
                        .WithMany("WhiteGames")
                        .HasForeignKey("WhiteUserId")
                        .IsRequired();

                    b.Navigation("BlackUser");

                    b.Navigation("WhiteUser");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("BlackGames");

                    b.Navigation("WhiteGames");
                });
#pragma warning restore 612, 618
        }
    }
}
