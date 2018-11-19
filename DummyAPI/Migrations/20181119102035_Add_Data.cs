using Microsoft.EntityFrameworkCore.Migrations;

namespace DummyAPI.Migrations
{
    public partial class Add_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Authors", "Name", new[] { "Kim", "Tom", "Sam" });
            migrationBuilder.InsertData("Blogs", "Url", new[] { "https://kims.blog.com", "https://toms.blog.com", "https://sams.blog.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
