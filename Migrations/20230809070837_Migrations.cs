using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanini_Tourism.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgents",
                columns: table => new
                {
                    TravelAgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgents", x => x.TravelAgentId);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministratorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Photos_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "AdministratorId");
                });

            migrationBuilder.CreateTable(
                name: "TravelDetails",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanPrice = table.Column<int>(type: "int", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    TravelAgentsTravelAgentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelDetails", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_TravelDetails_TravelAgents_TravelAgentsTravelAgentId",
                        column: x => x.TravelAgentsTravelAgentId,
                        principalTable: "TravelAgents",
                        principalColumn: "TravelAgentId");
                });

            migrationBuilder.CreateTable(
                name: "Travelers",
                columns: table => new
                {
                    TravelerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravellerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    TravelAgentsTravelAgentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travelers", x => x.TravelerId);
                    table.ForeignKey(
                        name: "FK_Travelers_TravelAgents_TravelAgentsTravelAgentId",
                        column: x => x.TravelAgentsTravelAgentId,
                        principalTable: "TravelAgents",
                        principalColumn: "TravelAgentId");
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tradeId = table.Column<int>(type: "int", nullable: true),
                    totalprice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingDetails_TravelDetails_tradeId",
                        column: x => x.tradeId,
                        principalTable: "TravelDetails",
                        principalColumn: "PlanId");
                    table.ForeignKey(
                        name: "FK_BookingDetails_Travelers_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Travelers",
                        principalColumn: "TravelerId");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    FeedbackText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    TravelerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Travelers_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Travelers",
                        principalColumn: "TravelerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_tradeId",
                table: "BookingDetails",
                column: "tradeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_TravelerId",
                table: "BookingDetails",
                column: "TravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TravelerId",
                table: "Feedbacks",
                column: "TravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdministratorId",
                table: "Photos",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelDetails_TravelAgentsTravelAgentId",
                table: "TravelDetails",
                column: "TravelAgentsTravelAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Travelers_TravelAgentsTravelAgentId",
                table: "Travelers",
                column: "TravelAgentsTravelAgentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "TravelDetails");

            migrationBuilder.DropTable(
                name: "Travelers");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "TravelAgents");
        }
    }
}
