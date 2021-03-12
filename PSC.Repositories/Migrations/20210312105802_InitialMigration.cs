using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSC.Repositories.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit_Countries",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_Countries", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_Messages",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMessage = table.Column<long>(type: "bigint", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_Messages", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    IdMessage = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.IdMessage);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Countries",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Countries", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { 1L, "Afghanistan", 0 },
                    { 126L, "Netherlands", 0 },
                    { 127L, "New Zealand", 0 },
                    { 128L, "Nicaragua", 0 },
                    { 129L, "Niger", 0 },
                    { 130L, "Nigeria", 0 },
                    { 131L, "Norway", 0 },
                    { 132L, "Oman", 0 },
                    { 133L, "Pakistan", 0 },
                    { 134L, "Palau", 0 },
                    { 125L, "Nepal", 0 },
                    { 135L, "Panama", 0 },
                    { 137L, "Paraguay", 0 },
                    { 138L, "Peru", 0 },
                    { 139L, "Philippines", 0 },
                    { 140L, "Poland", 0 },
                    { 141L, "Portugal", 0 },
                    { 142L, "Qatar", 0 },
                    { 143L, "Romania", 0 },
                    { 144L, "Russia", 0 },
                    { 145L, "Rwanda", 0 },
                    { 136L, "Papua New Guinea", 0 },
                    { 124L, "Nauru", 0 },
                    { 123L, "Namibia", 0 },
                    { 122L, "Myanmar (Burma)", 0 },
                    { 101L, "Liechtenstein", 0 },
                    { 102L, "Lithuania", 0 },
                    { 103L, "Luxembourg", 0 },
                    { 104L, "Macedonia", 0 },
                    { 105L, "Madagascar", 0 },
                    { 106L, "Malawi", 0 },
                    { 107L, "Malaysia", 0 },
                    { 108L, "Maldives", 0 },
                    { 109L, "Mali", 0 },
                    { 110L, "Malta", 0 },
                    { 111L, "Marshall Islands", 0 },
                    { 112L, "Mauritania", 0 },
                    { 113L, "Mauritius", 0 },
                    { 114L, "Mexico", 0 },
                    { 115L, "Micronesia, Federated States of", 0 },
                    { 116L, "Moldova", 0 },
                    { 117L, "Monaco", 0 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { 118L, "Mongolia", 0 },
                    { 119L, "Montenegro", 0 },
                    { 120L, "Morocco", 0 },
                    { 121L, "Mozambique", 0 },
                    { 146L, "Saint Kitts and Nevis", 0 },
                    { 100L, "Libya", 0 },
                    { 147L, "Saint Lucia", 0 },
                    { 149L, "Samoa", 0 },
                    { 175L, "Thailand", 0 },
                    { 176L, "Togo", 0 },
                    { 177L, "Tonga", 0 },
                    { 178L, "Trinidad and Tobago", 0 },
                    { 179L, "Tunisia", 0 },
                    { 180L, "Turkey", 0 },
                    { 181L, "Turkmenistan", 0 },
                    { 182L, "Tuvalu", 0 },
                    { 183L, "Uganda", 0 },
                    { 174L, "Tanzania", 0 },
                    { 184L, "Ukraine", 0 },
                    { 186L, "United Kingdom", 1 },
                    { 187L, "United States of America", 1 },
                    { 188L, "Uruguay", 0 },
                    { 189L, "Uzbekistan", 0 },
                    { 190L, "Vanuatu", 0 },
                    { 191L, "Vatican City (Holy See)", 0 },
                    { 192L, "Venezuela", 0 },
                    { 193L, "Vietnam", 0 },
                    { 194L, "Yemen", 0 },
                    { 185L, "United Arab Emirates", 0 },
                    { 173L, "Tajikistan", 0 },
                    { 172L, "Taiwan", 0 },
                    { 171L, "Syria", 0 },
                    { 150L, "San Marino", 0 },
                    { 151L, "Sao Tome and Principe", 0 },
                    { 152L, "Saudi Arabia", 0 },
                    { 153L, "Senegal", 0 },
                    { 154L, "Serbia", 0 },
                    { 155L, "Seychelles", 0 },
                    { 156L, "Sierra Leone", 0 },
                    { 157L, "Singapore", 0 },
                    { 158L, "Slovakia", 0 },
                    { 159L, "Slovenia", 0 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { 160L, "Solomon Islands", 0 },
                    { 161L, "Somalia", 0 },
                    { 162L, "South Africa", 0 },
                    { 163L, "South Sudan", 0 },
                    { 164L, "Spain", 0 },
                    { 165L, "Sri Lanka", 0 },
                    { 166L, "Sudan", 0 },
                    { 167L, "Suriname", 0 },
                    { 168L, "Swaziland", 0 },
                    { 169L, "Sweden", 0 },
                    { 170L, "Switzerland", 0 },
                    { 148L, "Saint Vincent and the Grenadines", 0 },
                    { 99L, "Liberia", 0 },
                    { 98L, "Lesotho", 0 },
                    { 97L, "Lebanon", 0 },
                    { 27L, "Burkina Faso", 0 },
                    { 28L, "Burundi", 0 },
                    { 29L, "Cambodia", 0 },
                    { 30L, "Cameroon", 0 },
                    { 31L, "Canada", 0 },
                    { 32L, "Cape Verde", 0 },
                    { 33L, "Central African Republic", 0 },
                    { 34L, "Chad", 0 },
                    { 35L, "Chile", 0 },
                    { 26L, "Bulgaria", 0 },
                    { 36L, "China", 0 },
                    { 38L, "Comoros", 0 },
                    { 39L, "Congo, Republic of the", 0 },
                    { 40L, "Congo, Democratic Republic of the", 0 },
                    { 41L, "Costa Rica", 0 },
                    { 42L, "Cote d'Ivoire", 0 },
                    { 43L, "Croatia", 0 },
                    { 44L, "Cuba", 0 },
                    { 45L, "Cyprus", 0 },
                    { 46L, "Czech Republic", 0 },
                    { 37L, "Colombia", 0 },
                    { 25L, "Brunei", 0 },
                    { 24L, "Brazil", 0 },
                    { 23L, "Botswana", 0 },
                    { 2L, "Albania", 0 },
                    { 3L, "Algeria", 0 },
                    { 4L, "Andorra", 0 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { 5L, "Angola", 0 },
                    { 6L, "Antigua and Barbuda", 0 },
                    { 7L, "Argentina", 0 },
                    { 8L, "Armenia", 0 },
                    { 9L, "Australia", 0 },
                    { 10L, "Austria", 0 },
                    { 11L, "Azerbaijan", 0 },
                    { 12L, "The Bahamas", 0 },
                    { 13L, "Bahrain", 0 },
                    { 14L, "Bangladesh", 0 },
                    { 15L, "Barbados", 0 },
                    { 16L, "Belarus", 0 },
                    { 17L, "Belgium", 0 },
                    { 18L, "Belize", 0 },
                    { 19L, "Benin", 0 },
                    { 20L, "Bhutan", 0 },
                    { 21L, "Bolivia", 0 },
                    { 22L, "Bosnia and Herzegovina", 0 },
                    { 47L, "Denmark", 0 },
                    { 48L, "Djibouti", 0 },
                    { 49L, "Dominica", 0 },
                    { 50L, "Dominican Republic", 0 },
                    { 76L, "Iceland", 0 },
                    { 77L, "India", 0 },
                    { 78L, "Indonesia", 0 },
                    { 79L, "Iran", 0 },
                    { 80L, "Iraq", 0 },
                    { 81L, "Ireland", 0 },
                    { 82L, "Israel", 0 },
                    { 83L, "Italy", 0 },
                    { 84L, "Jamaica", 0 },
                    { 85L, "Japan", 0 },
                    { 86L, "Jordan", 0 },
                    { 87L, "Kazakhstan", 0 },
                    { 88L, "Kenya", 0 },
                    { 89L, "Kiribati", 0 },
                    { 90L, "Korea, North", 0 },
                    { 91L, "Korea, South", 0 },
                    { 92L, "Kosovo", 0 },
                    { 93L, "Kuwait", 0 },
                    { 94L, "Kyrgyzstan", 0 },
                    { 95L, "Laos", 0 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "Name", "Order" },
                values: new object[,]
                {
                    { 96L, "Latvia", 0 },
                    { 75L, "Hungary", 0 },
                    { 195L, "Zambia", 0 },
                    { 74L, "Honduras", 0 },
                    { 72L, "Guyana", 0 },
                    { 51L, "East Timor (Timor-Leste)", 0 },
                    { 52L, "Ecuador", 0 },
                    { 53L, "Egypt", 0 },
                    { 54L, "El Salvador", 0 },
                    { 55L, "Equatorial Guinea", 0 },
                    { 56L, "Eritrea", 0 },
                    { 57L, "Estonia", 0 },
                    { 58L, "Ethiopia", 0 },
                    { 59L, "Fiji", 0 },
                    { 60L, "Finland", 0 },
                    { 61L, "France", 0 },
                    { 62L, "Gabon", 0 },
                    { 63L, "The Gambia", 0 },
                    { 64L, "Georgia", 0 },
                    { 65L, "Germany", 0 },
                    { 66L, "Ghana", 0 },
                    { 67L, "Greece", 0 },
                    { 68L, "Grenada", 0 },
                    { 69L, "Guatemala", 0 },
                    { 70L, "Guinea", 0 },
                    { 71L, "Guinea-Bissau", 0 },
                    { 73L, "Haiti", 0 },
                    { 196L, "Zimbabwe", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit_Countries");

            migrationBuilder.DropTable(
                name: "Audit_Messages");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "tbl_Countries");
        }
    }
}
