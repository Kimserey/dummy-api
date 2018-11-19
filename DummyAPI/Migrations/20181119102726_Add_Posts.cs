using Microsoft.EntityFrameworkCore.Migrations;

namespace DummyAPI.Migrations
{
    public partial class Add_Posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Posts (AuthorId, BlogId, Title, Content)
                VALUES (1, 1, 'Just Photoshop out the dog', 'There is too much white space I have printed it out, but the animated gif is not moving could you rotate the picture to show the other side of the room?'); 
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Posts (AuthorId, BlogId, Title, Content)
                VALUES (1, 1, 'Just Photoshop out the dog', 'There is too much white space I have printed it out, but the animated gif is not moving could you rotate the picture to show the other side of the room?'); 
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Posts (AuthorId, BlogId, Title, Content)
                VALUES (2, 2, 'Just Photoshop out the dog', 'There is too much white space I have printed it out, but the animated gif is not moving could you rotate the picture to show the other side of the room?'); 
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Posts (AuthorId, BlogId, Title, Content)
                VALUES (3, 3, 'Just Photoshop out the dog', 'There is too much white space I have printed it out, but the animated gif is not moving could you rotate the picture to show the other side of the room?'); 
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
