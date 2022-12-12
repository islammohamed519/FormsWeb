using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forms.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CotrlType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cssClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleEn = table.Column<string>(name: "Title_En", type: "nvarchar(max)", nullable: false),
                    TitleAr = table.Column<string>(name: "Title_Ar", type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(name: "Description_En", type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(name: "Description_Ar", type: "nvarchar(max)", nullable: false),
                    RequiresLogin = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrmQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QustTitle = table.Column<string>(name: "Qust_Title", type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ControlId = table.Column<int>(type: "int", nullable: true),
                    FormId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrmQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrmQuestions_ControlType_ControlId",
                        column: x => x.ControlId,
                        principalTable: "ControlType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FrmQuestions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FrmQuestions_FrmQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FrmQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataSourceCtrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    DataSourceId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSourceCtrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSourceCtrl_DataSource_DataSourceId",
                        column: x => x.DataSourceId,
                        principalTable: "DataSource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataSourceCtrl_FrmQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FrmQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FrmAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    TextAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrmAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrmAnswers_FrmQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FrmQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSourceCtrl_DataSourceId",
                table: "DataSourceCtrl",
                column: "DataSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSourceCtrl_QuestionId",
                table: "DataSourceCtrl",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FrmAnswers_QuestionId",
                table: "FrmAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FrmQuestions_ControlId",
                table: "FrmQuestions",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_FrmQuestions_FormId",
                table: "FrmQuestions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FrmQuestions_QuestionId",
                table: "FrmQuestions",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSourceCtrl");

            migrationBuilder.DropTable(
                name: "FrmAnswers");

            migrationBuilder.DropTable(
                name: "DataSource");

            migrationBuilder.DropTable(
                name: "FrmQuestions");

            migrationBuilder.DropTable(
                name: "ControlType");

            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
