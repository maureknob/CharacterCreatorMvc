using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CharacterCreatorMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCharacters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Characters(Id, Name,Description,HealthPoints,Damage,Image,CharacterTypeId) " +
                "VALUES('7e32da05-b5c7-4460-a854-43ed6e87d9ce','Conan','Warrior',10,10,'warrior.jpg','d70ed593-9d8c-4453-8fc3-df6221d152d7')");

            mb.Sql("INSERT INTO Characters(Id, Name,Description,HealthPoints,Damage,Image,CharacterTypeId) " +
                "VALUES('8f500ee6-6b75-4404-9e89-d3944fdcf5b2','Magus','Mage',5,10,'mage.jpg','c4ffa9fd-11f0-47cd-84b5-1af2302b8451')");

            mb.Sql("INSERT INTO Characters(Id, Name,Description,HealthPoints,Damage,Image,CharacterTypeId) " +
                "VALUES('de652203-bec2-4567-a354-468716bbb3d1','Groo','Barbarian',12,8,'barbarian.jpg','2dd2e18b-ddc7-4132-a859-d722a04d755c')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Characters");
        }
    }
}
