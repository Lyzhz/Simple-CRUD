using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wingslompson.Migrations
{
    /// <inheritdoc />
    public partial class DbConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "Wings");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Wings",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wings",
                table: "Wings",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Wings",
                table: "Wings");

            migrationBuilder.RenameTable(
                name: "Wings",
                newName: "Todos");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");
        }
    }
}
