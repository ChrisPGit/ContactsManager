using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsManager.API.Migrations
{
    public partial class RelationshipNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactCompanyRelationships",
                columns: table => new
                {
                    ContactCompanyIds = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCompanyRelationships", x => x.ContactCompanyIds);
                    table.ForeignKey(
                        name: "FK_ContactCompanyRelationships_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContactCompanyRelationships_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactCompanyRelationships_CompanyId",
                table: "ContactCompanyRelationships",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactCompanyRelationships_ContactId",
                table: "ContactCompanyRelationships",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCompanyRelationships");
        }
    }
}
