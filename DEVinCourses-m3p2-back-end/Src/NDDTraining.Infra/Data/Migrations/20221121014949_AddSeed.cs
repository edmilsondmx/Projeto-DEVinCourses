using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NDDTraining.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRAININGS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    TITLE = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR(400)", maxLength: 400, nullable: false),
                    TEACHER = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    DURATION = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CATEGORY = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAININGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AGE = table.Column<int>(type: "INT", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    IMAGE = table.Column<byte[]>(type: "VARBINARY(8000)", maxLength: 8000, nullable: true),
                    TOKEN = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MODULES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    TITLEMODULE = table.Column<string>(name: "TITLE_MODULE", type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    LINK = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    IMAGE = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    DESCRIPTIONMODULE = table.Column<string>(name: "DESCRIPTION_MODULE", type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    STATUSMODULE = table.Column<string>(name: "STATUS_MODULE", type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODULES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MODULES_TRAININGS_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "TRAININGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REGISTRATION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERID = table.Column<int>(name: "USER_ID", type: "INT", nullable: false),
                    TRAININGID = table.Column<int>(name: "TRAINING_ID", type: "INT", nullable: false),
                    STATUS = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    RefreshDate = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTRATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REGISTRATION_TRAININGS_TRAINING_ID",
                        column: x => x.TRAININGID,
                        principalTable: "TRAININGS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_REGISTRATION_USER_USER_ID",
                        column: x => x.USERID,
                        principalTable: "USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "COMPLETED_MODULE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MODULEID = table.Column<int>(name: "MODULE_ID", type: "INT", nullable: false),
                    REGISTRATIONID = table.Column<int>(name: "REGISTRATION_ID", type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPLETED_MODULE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMPLETED_MODULE_MODULES_MODULE_ID",
                        column: x => x.MODULEID,
                        principalTable: "MODULES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMPLETED_MODULE_REGISTRATION_REGISTRATION_ID",
                        column: x => x.REGISTRATIONID,
                        principalTable: "REGISTRATION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TRAININGS",
                columns: new[] { "ID", "ACTIVE", "CATEGORY", "DESCRIPTION", "DURATION", "TEACHER", "TITLE", "URL" },
                values: new object[,]
                {
                    { 1, true, "tecnologia", "Architecto eaque consectetur nostrum impedit earum at harum. Reiciendis suscipit soluta, ab, repellat ad, Architecto eaque consectetur nostrum impedit earum at harum. Architecto eaque consectetur nostrum impedit earum at harum., Architecto eaque consectetur nostrum impedit earum at harum.", new TimeSpan(0, 20, 0, 0, 0), "Carlos Silva", "Manutenção de Computadores", "https://certificadocursosonline.com/wp-content/uploads/2018/07/Curso-de-Manutenc%CC%A7a%CC%83o-de-Computadores.jpg" },
                    { 2, true, "idioma", "Neste curso, os alunos irão obter um conhecimento aprofundado sobre os recursos disponíveis sobre Inlges o basico.", new TimeSpan(2, 22, 0, 0, 0), "Rodrigo Rosa", "Ingles Basico", "https://setcesp.org.br/wp-content/uploads/2019/08/treinamento.jpg" },
                    { 3, true, "educacao", "Neste curso, os alunos irão obter um conhecimento aprofundado sobre os recursos disponíveis.", new TimeSpan(0, 18, 0, 0, 0), "Maria Eduarda", "Redacao", "https://setcesp.org.br/wp-content/uploads/2019/08/treinamento.jpg" }
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "ID", "AGE", "CPF", "EMAIL", "IMAGE", "NAME", "PASSWORD", "TOKEN" },
                values: new object[] { 1, 32, "39963055834", "admim@email.com", null, "Admin", "adminadmin", null });

            migrationBuilder.InsertData(
                table: "MODULES",
                columns: new[] { "ID", "DESCRIPTION_MODULE", "IMAGE", "LINK", "STATUS_MODULE", "TITLE_MODULE", "TrainingId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "vbs7jKRMuiA", "finalizado", "Módulo 1", 1 },
                    { 2, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "3CC_YtyD7Po", "disponivel", "Módulo 2", 1 },
                    { 3, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "TxxkFWty09g", "disponivel", "Módulo 3", 1 },
                    { 4, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "vbs7jKRMuiA", "finalizado", "Módulo 1", 2 },
                    { 5, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "3CC_YtyD7Po", "disponivel", "Módulo 2", 2 },
                    { 6, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "TxxkFWty09g", "disponivel", "Módulo 3", 2 },
                    { 7, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "vbs7jKRMuiA", "finalizado", "Módulo 1", 3 },
                    { 8, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "3CC_YtyD7Po", "disponivel", "Módulo 2", 3 },
                    { 9, "Lorem ipsum dolor sit amet consectetur.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjOUpolyASUyrLMSV2vqIvQQZ8_--ddMSsJF_xvxZ3tEwPPtZrc57tShVksL8y8JZ8QIk&usqp=CAU", "TxxkFWty09g", "disponivel", "Módulo 3", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMPLETED_MODULE_MODULE_ID",
                table: "COMPLETED_MODULE",
                column: "MODULE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPLETED_MODULE_REGISTRATION_ID",
                table: "COMPLETED_MODULE",
                column: "REGISTRATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MODULES_TrainingId",
                table: "MODULES",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_REGISTRATION_TRAINING_ID",
                table: "REGISTRATION",
                column: "TRAINING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REGISTRATION_USER_ID",
                table: "REGISTRATION",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPLETED_MODULE");

            migrationBuilder.DropTable(
                name: "MODULES");

            migrationBuilder.DropTable(
                name: "REGISTRATION");

            migrationBuilder.DropTable(
                name: "TRAININGS");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
