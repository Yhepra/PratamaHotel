using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PratamaHotel.Migrations
{
    public partial class addModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    idCardNumber = table.Column<string>(type: "text", nullable: true),
                    phoneNumber = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(767)", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<string>(type: "text", nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    numberOfRooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(767)", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    guestid = table.Column<int>(type: "int", nullable: true),
                    checkInDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    checkOutDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    numberOfRoom = table.Column<int>(type: "int", nullable: false),
                    billEstimate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.code);
                    table.ForeignKey(
                        name: "FK_Reservations_Guests_guestid",
                        column: x => x.guestid,
                        principalTable: "Guests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(767)", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    roleid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_roleid",
                        column: x => x.roleid,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    idRoom = table.Column<string>(type: "varchar(767)", nullable: false),
                    roomTypeid = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.idRoom);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_roomTypeid",
                        column: x => x.roomTypeid,
                        principalTable: "RoomTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckIns",
                columns: table => new
                {
                    idCheckin = table.Column<string>(type: "varchar(767)", nullable: false),
                    reservationcode = table.Column<string>(type: "varchar(767)", nullable: true),
                    roomNumber = table.Column<string>(type: "text", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    additionalCosts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIns", x => x.idCheckin);
                    table.ForeignKey(
                        name: "FK_CheckIns_Reservations_reservationcode",
                        column: x => x.reservationcode,
                        principalTable: "Reservations",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckOuts",
                columns: table => new
                {
                    idCheckOut = table.Column<string>(type: "varchar(767)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    reservationcode = table.Column<string>(type: "varchar(767)", nullable: true),
                    fine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOuts", x => x.idCheckOut);
                    table.ForeignKey(
                        name: "FK_CheckOuts_Reservations_reservationcode",
                        column: x => x.reservationcode,
                        principalTable: "Reservations",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_reservationcode",
                table: "CheckIns",
                column: "reservationcode");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_reservationcode",
                table: "CheckOuts",
                column: "reservationcode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_roleid",
                table: "Employees",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_guestid",
                table: "Reservations",
                column: "guestid");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_roomTypeid",
                table: "Rooms",
                column: "roomTypeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckIns");

            migrationBuilder.DropTable(
                name: "CheckOuts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
