using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_rdv.Migrations
{
    public partial class AddNewUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir dados na tabela Users
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "FirstName", "LastName", "Email", "PhoneNumber", "Password" },
                values: new object[,]
                {
                    { "John", "Doe", "john.doe@example.com", "1234567890", "password123" },
                    { "Jane", "Smith", "jane.smith@example.com", "0987654321", "securePass456" },
                    { "Mike", "Johnson", "mike.johnson@example.com", "1112223334", "mike2024" },
                    { "Sarah", "Brown", "sarah.brown@example.com", "5556667778", "sarah_789" },
                    { "Chris", "Davis", "chris.davis@example.com", "9998887776", "chrisD_2023" }
                }
            );

            long addressId = 1;

            for (int userId = 1; userId <= 5; userId++) 
            {
                for (int addressIndex = 1; addressIndex <= 2; addressIndex++) // 2 endereços por usuário
                {
                    // Inserir endereço
                    migrationBuilder.InsertData(
                        table: "Addresses",
                        columns: new[] { "Street", "Number", "Complement", "District", "City", "Uf", "ZipCode" },
                        values: new object[] 
                        {
                            $"Street {addressIndex} - User {userId}",
                            $"{100 + addressIndex}",
                            $"Complement {addressIndex}",
                            $"District {addressIndex}",
                            $"City {userId}",
                            "SP",
                            $"12345-00{addressIndex}"
                        }
                    );

                    // Inserir relação na tabela HasAddress
                    migrationBuilder.InsertData(
                        table: "HasAddresses",
                        columns: new[] { "UserId", "AddressId" },
                        values: new object[] { userId, addressId }
                    );

                    addressId++; // Incrementar o addressId após cada inserção de endereço
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover os dados inseridos em caso de rollback (opcional)
            migrationBuilder.Sql("DELETE FROM HasAddress");
            migrationBuilder.Sql("DELETE FROM Address");
            migrationBuilder.Sql("DELETE FROM Users");
        }
    }
}
