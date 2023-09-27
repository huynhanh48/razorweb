using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Bogus;
using MigrationsExample.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace MigrationsExample.Migrations
{
    /// <inheritdoc />
    public partial class innitdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.ID);
                });
                var fruit = new[] { "conten1", "conten2", "conten3", "conten4", "conten5" };
                Randomizer.Seed = new Random(8675309);
                var FakeArticle  = new Faker<Article>();
                FakeArticle.RuleFor(a=> a.Title,f => f.Lorem.Sentence(5,5));
                FakeArticle.RuleFor(a=>a.PublishDate,f => f.Date.Between(new DateTime(2021,1,1),new DateTime(2021,5,5)));
                FakeArticle.RuleFor(a=>a.Content,f =>f.PickRandom(fruit));
                FakeArticle.Generate();
                for(int i =0;i<150;i++)
                {
                    migrationBuilder.InsertData(
                    table:"article",
                    columns: new[] {"Title","PublishDate","Content"},
                    values:
                    new object[]
                    {
                    FakeArticle.Generate().Title,
                    FakeArticle.Generate().PublishDate,
                    FakeArticle.Generate().Content,
                    }
                    );
                }
              
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article");
        }
    }
}
