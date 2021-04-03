using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWebAppForTheJob.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders");

            migrationBuilder.DropIndex(
                name: "IX_Founders_ClientId",
                table: "Founders");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Founders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "Founders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Founders_ClientId1",
                table: "Founders",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_ClientId1",
                table: "Founders",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_ClientId1",
                table: "Founders");

            migrationBuilder.DropIndex(
                name: "IX_Founders_ClientId1",
                table: "Founders");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Founders");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Founders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Founders_ClientId",
                table: "Founders",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
