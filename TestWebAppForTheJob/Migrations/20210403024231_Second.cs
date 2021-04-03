using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebAppForTheJob.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Founders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Founders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
