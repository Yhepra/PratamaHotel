﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PratamaHotel.Data;

namespace PratamaHotel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220402185309_updatemodel")]
    partial class updatemodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("PratamaHotel.Models.CheckIn", b =>
                {
                    b.Property<string>("idCheckin")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("additionalCosts")
                        .HasColumnType("int");

                    b.Property<string>("notes")
                        .HasColumnType("text");

                    b.Property<string>("reservationcode")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("roomNumber")
                        .HasColumnType("text");

                    b.HasKey("idCheckin");

                    b.HasIndex("reservationcode");

                    b.ToTable("CheckIns");
                });

            modelBuilder.Entity("PratamaHotel.Models.CheckOut", b =>
                {
                    b.Property<string>("idCheckOut")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime");

                    b.Property<int>("fine")
                        .HasColumnType("int");

                    b.Property<string>("reservationcode")
                        .HasColumnType("varchar(767)");

                    b.HasKey("idCheckOut");

                    b.HasIndex("reservationcode");

                    b.ToTable("CheckOuts");
                });

            modelBuilder.Entity("PratamaHotel.Models.Employee", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<int?>("roleid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roleid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PratamaHotel.Models.Guest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("idCardNumber")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("PratamaHotel.Models.Reservation", b =>
                {
                    b.Property<string>("code")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("billEstimate")
                        .HasColumnType("int");

                    b.Property<DateTime>("checkInDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("checkOutDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("guestid")
                        .HasColumnType("int");

                    b.Property<int>("numberOfRoom")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime");

                    b.HasKey("code");

                    b.HasIndex("guestid");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("PratamaHotel.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PratamaHotel.Models.Room", b =>
                {
                    b.Property<string>("idRoom")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("roomTypeid")
                        .HasColumnType("varchar(767)");

                    b.HasKey("idRoom");

                    b.HasIndex("roomTypeid");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PratamaHotel.Models.RoomType", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("numberOfRooms")
                        .HasColumnType("int");

                    b.Property<string>("price")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("PratamaHotel.Models.CheckIn", b =>
                {
                    b.HasOne("PratamaHotel.Models.Reservation", "reservation")
                        .WithMany()
                        .HasForeignKey("reservationcode");

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("PratamaHotel.Models.CheckOut", b =>
                {
                    b.HasOne("PratamaHotel.Models.Reservation", "reservation")
                        .WithMany()
                        .HasForeignKey("reservationcode");

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("PratamaHotel.Models.Employee", b =>
                {
                    b.HasOne("PratamaHotel.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleid");

                    b.Navigation("role");
                });

            modelBuilder.Entity("PratamaHotel.Models.Reservation", b =>
                {
                    b.HasOne("PratamaHotel.Models.Guest", "guest")
                        .WithMany()
                        .HasForeignKey("guestid");

                    b.Navigation("guest");
                });

            modelBuilder.Entity("PratamaHotel.Models.Room", b =>
                {
                    b.HasOne("PratamaHotel.Models.RoomType", "roomType")
                        .WithMany()
                        .HasForeignKey("roomTypeid");

                    b.Navigation("roomType");
                });
#pragma warning restore 612, 618
        }
    }
}
