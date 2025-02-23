﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace catalog.Migrations
{
    /// <inheritdoc />
    public partial class addcurtains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curtains",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matherial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    height = table.Column<double>(type: "float", nullable: false),
                    width = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtains", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Curtains",
                columns: new[] { "id", "ImageUrl", "color", "description", "height", "matherial", "name", "price", "width" },
                values: new object[,]
                {
                    { new Guid("1711fe2a-ac4a-4389-8dbe-53346c740e73"), "https://storage.yandexcloud.net/web-cterx/76584172-fb7e-11ec-80d9-002590843481_1.jpg", "Бежевый", "Портьера велюр Марсель — это элегантные шторы из высококачественного велюра, идеально подходящие для создания уютной атмосферы в вашем доме. Шторы прекрасно блокируют свет и сохраняют тепло.", 150.0, "Велюр", "Портьера велюр Марсель", 3000.0, 260.0 },
                    { new Guid("1bc4b603-9bab-48f8-ae07-306a76b48486"), "https://storage.yandexcloud.net/web-cterx/delfa_shtora_gura_fango_548_060_interior.jpg", "Зеленый", "Шторы Dubley — это стильное решение для вашего интерьера. Они прекрасно смотрятся в любом помещении и создают атмосферу уюта и комфорта.", 150.0, "Хлопок", "Шторы Dubley", 2800.0, 250.0 },
                    { new Guid("bd67c318-6d87-4e3f-a7d4-891355b9b3df"), "https://storage.yandexcloud.net/web-cterx/delfa_shtora_gura_azul_548_015_interior.jpg", "Бежевый", "Шторы Neula сочетают в себе современный дизайн и высокую функциональность. Эти бежевые шторы добавят стильный акцент вашему интерьеру, блокируя яркий свет.", 160.0, "Лен", "Шторы Neula", 3500.0, 270.0 },
                    { new Guid("d4480c59-27b3-4768-84e8-f6435044bd31"), "https://storage.yandexcloud.net/web-cterx/delfa_shtori_dubley_verde_546_080_interior.jpg", "Кофе с молоком", "Элегантные шторы Gura в цвете кофе с молоком — идеальное решение для тех, кто ценит тепло и уют в интерьере.", 150.0, "Вискоза", "Шторы Gura", 3000.0, 260.0 },
                    { new Guid("e4f36911-7599-477b-9bbc-486799363468"), "https://storage.yandexcloud.net/web-cterx/delfa_shtora_neula_gris_549_070_interior.jpg", "Серый", "Шторы Gura привнесут утонченность и стиль в ваш дом. Они идеально подойдут для гостиной или спальни.", 140.0, "Полиэстер", "Шторы Gura", 3200.0, 270.0 },
                    { new Guid("ecc57235-3fe1-4a36-abea-dc95f2f5d3a8"), "https://storage.yandexcloud.net/web-cterx/delfa_shtora_neula_beige_interior.jpg", "Серый", "Эти серые шторы Neula обеспечивают отличную изоляцию от света и шума, а также добавляют элегантность в любое помещение.", 160.0, "Вискоза", "Шторы Neula", 4000.0, 280.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curtains");
        }
    }
}
