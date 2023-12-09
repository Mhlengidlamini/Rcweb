using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rc_tutors.Migrations
{
    /// <inheritdoc />
    public partial class azasetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a7d1d7a-deff-4acb-ae7b-12d4a3dcffed", "AQAAAAEAACcQAAAAEN/34LshrW4McKzz5mTjTrqKT6OHw/Git4GzRkZ0IwMhwaLJn7TxdAR/UK8ep0OCAA==", "3cfd644d-518a-4574-984a-15ece3b8e5eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "student-user-id-1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17642357-f299-4757-8c92-a9d878576874", "AQAAAAEAACcQAAAAEPFoPmLZ2RRN00Xyq2Mm+giAAx9UMlmyOU+VFlThI61kRAu19/Nb1cuX5bIfOkefOQ==", "489df3c7-fedb-41a6-b411-e2b02c4f3e30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "student-user-id-2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7ffcefb-9037-4770-9eae-691dd2b07046", "AQAAAAEAACcQAAAAEKHUWQ59GAkOE/LmSlOPcoQGv0slwCG5xcOWDSZdwEZPQBmHgGaArgH8oyJkxF40Ww==", "1f7fde48-0006-4486-a2a2-d2119635fa80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "tutor-user-id-1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4bad88a-651a-4fc1-890d-7ab79fdc7b93", "AQAAAAEAACcQAAAAEF5QLNMH6DVoFtvIrXXRZ4Iupu29PTW6KfEwCkGIP9P2duEAOgEjIm4CHDn+IrmuSg==", "c22a455e-4363-47a1-9b27-db33e210af35" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77d6508c-dff2-4a39-a835-4fc3d57dca3b", "AQAAAAEAACcQAAAAEOKKNyAAYpiuAcsl+EbuZvm/Xv/76Ooy29Dt4zOs887c7/8kbOI5tAAzd1iaVjCY0A==", "b0bf717f-3077-445d-bf9b-5fb9e69dff51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "student-user-id-1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecb8b995-0d47-4704-89c3-5a702ebc9ca1", "AQAAAAEAACcQAAAAENxi95SkhX8xu/fHO4Hfh4qk31WWbri6hoh6fF9CmrVdwRjrDXFXzf6btDciUalvgg==", "5c3adb4f-f4d6-438f-ad7c-0690d17297f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "student-user-id-2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eac53332-8764-4824-8422-dc27a26df079", "AQAAAAEAACcQAAAAEH8o5CtDU9cuFpcONatvOK4dLd2uNFdYKEZ0I9Aihdi952Au8zyRjFQV/tplUYfkHw==", "9507a709-508a-4f66-ae7b-34ad3772d644" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "tutor-user-id-1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c476e3b-afa0-4766-987f-01f11ba14b03", "AQAAAAEAACcQAAAAELuppBM+WKJ77VXkYP4IGrp5ZAH+yAoI0CnPBDdOBMclo93M8nuVxcxer6TcHfEpNw==", "b765a222-f9ef-4d10-bfa6-63ece87df6c5" });
        }
    }
}
