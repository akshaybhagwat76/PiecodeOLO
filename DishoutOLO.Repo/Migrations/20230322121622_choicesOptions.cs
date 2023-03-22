using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishoutOLO.Repo.Migrations
{
    /// <inheritdoc />
    public partial class choicesOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
 

        

          

            migrationBuilder.AddColumn<int>(
                name: "MayonnaiseOption",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "extraCheeseOption",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "extraChickenOption",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropColumn(
                name: "MayonnaiseOption",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "extraCheeseOption",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "extraChickenOption",
                table: "Items");
              
          
        }
    }
}
