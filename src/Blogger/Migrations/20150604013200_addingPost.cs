using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Blogger.Migrations
{
    public partial class addingPost : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    PosterEmail = table.Column(type: "nvarchar(max)", nullable: true),
                    PosterId = table.Column(type: "int", nullable: false),
                    Text = table.Column(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column(type: "datetime2", nullable: false),
                    Title = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Post");
        }
    }
}
