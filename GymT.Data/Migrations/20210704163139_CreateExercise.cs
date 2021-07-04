using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymT.Data.Migrations
{
    public partial class CreateExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    EquipmentId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Accounts_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseEquipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "ExerciseEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMove",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Instructions = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DefaultAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultRepetitions = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantityType = table.Column<int>(type: "INTEGER", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMove", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseMove_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMoveUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExerciseMoveId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Repetitions = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMoveUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseMoveUser_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseMoveUser_ExerciseMove_ExerciseMoveId",
                        column: x => x.ExerciseMoveId,
                        principalTable: "ExerciseMove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMove_ExerciseId",
                table: "ExerciseMove",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMoveUser_AccountId",
                table: "ExerciseMoveUser",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMoveUser_ExerciseMoveId",
                table: "ExerciseMoveUser",
                column: "ExerciseMoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_AuthorId",
                table: "Exercises",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_EquipmentId",
                table: "Exercises",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMoveUser");

            migrationBuilder.DropTable(
                name: "ExerciseMove");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseEquipment");
        }
    }
}
