using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Blogger.Migrations
{
    public partial class minPostSlugDatetimeOffset : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "TimeStamp",
                table: "Post",
                type: "datetimeoffset",
                nullable: false);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "TimeStamp",
                table: "Post",
                type: "datetime2",
                nullable: false);
        }
    }
}
