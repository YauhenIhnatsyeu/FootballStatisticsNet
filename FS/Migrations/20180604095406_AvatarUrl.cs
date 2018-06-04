using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FS.Migrations
{
    public partial class AvatarUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("Avatar", "AspNetUsers", "AvatarUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("AvatarUrl", "AspNetUsers", "Avatar");
        }
    }
}
