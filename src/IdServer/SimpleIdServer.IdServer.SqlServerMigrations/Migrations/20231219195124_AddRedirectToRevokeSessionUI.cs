﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleIdServer.IdServer.SqlServerMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddRedirectToRevokeSessionUI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RedirectToRevokeSessionUI",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedirectToRevokeSessionUI",
                table: "Clients");
        }
    }
}
