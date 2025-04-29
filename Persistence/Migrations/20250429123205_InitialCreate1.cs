using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HelpResources",
                keyColumn: "Id",
                keyValue: new Guid("0c462c4a-eb76-41d2-bb59-5f8a1e244e37"));

            migrationBuilder.DeleteData(
                table: "HelpResources",
                keyColumn: "Id",
                keyValue: new Guid("60a9e26d-b04a-4211-945f-6cb6c5fac9d4"));

            migrationBuilder.DeleteData(
                table: "HelpResources",
                keyColumn: "Id",
                keyValue: new Guid("65480d18-b9d3-454f-9c0a-9bbda833049f"));

            migrationBuilder.InsertData(
                table: "HelpResources",
                columns: new[] { "Id", "Category", "Content", "Title" },
                values: new object[,]
                {
                    { new Guid("07c5b09e-0540-4e0c-9b94-8f92656e511f"), "Stress Relief", "Practice being present in the moment, focus on your breathing...", "Mindfulness Exercises" },
                    { new Guid("4865dede-d889-45ef-a265-cba802b34715"), "Mental Health Resources", "If your mood swings affect daily life or relationships...", "When to Seek Professional Help" },
                    { new Guid("e00da092-aab3-4fe0-94b4-c4530b084641"), "Anger Management", "Recognize your triggers, practice deep breathing, count to 10 before reacting...", "Coping with Anger" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HelpResources",
                keyColumn: "Id",
                keyValue: new Guid("07c5b09e-0540-4e0c-9b94-8f92656e511f"));

            migrationBuilder.DeleteData(
                table: "HelpResources",
                keyColumn: "Id",
                keyValue: new Guid("4865dede-d889-45ef-a265-cba802b34715"));

            migrationBuilder.DeleteData(
                table: "HelpResources",
                keyColumn: "Id",
                keyValue: new Guid("e00da092-aab3-4fe0-94b4-c4530b084641"));

            migrationBuilder.InsertData(
                table: "HelpResources",
                columns: new[] { "Id", "Category", "Content", "Title" },
                values: new object[,]
                {
                    { new Guid("0c462c4a-eb76-41d2-bb59-5f8a1e244e37"), "Anger Management", "Recognize your triggers, practice deep breathing, count to 10 before reacting...", "Coping with Anger" },
                    { new Guid("60a9e26d-b04a-4211-945f-6cb6c5fac9d4"), "Stress Relief", "Practice being present in the moment, focus on your breathing...", "Mindfulness Exercises" },
                    { new Guid("65480d18-b9d3-454f-9c0a-9bbda833049f"), "Mental Health Resources", "If your mood swings affect daily life or relationships...", "When to Seek Professional Help" }
                });
        }
    }
}
