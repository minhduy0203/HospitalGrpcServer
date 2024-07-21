using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementProject.Migrations
{
    public partial class Update_Ver4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Feedbacks_PrescriptionId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MedStaffs");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Feedbacks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "75154e9c-fc42-47c1-bf72-7796f746fd84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e9b192e9-2d54-4a23-8843-9d506ba2f6ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "758962d9-7186-4a78-897f-0200331b22a9");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_FeedbackId",
                table: "Appointments",
                column: "FeedbackId",
                unique: true,
                filter: "[FeedbackId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Feedbacks_FeedbackId",
                table: "Appointments",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Feedbacks_FeedbackId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_FeedbackId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MedStaffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "63dc5b80-0221-428a-8941-e0d78200c272");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1e9bdd79-3dca-4e42-95a9-7c4de453099c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "10da40b5-3628-4772-a071-f306c28bfdd5");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Feedbacks_PrescriptionId",
                table: "Appointments",
                column: "PrescriptionId",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }
    }
}
