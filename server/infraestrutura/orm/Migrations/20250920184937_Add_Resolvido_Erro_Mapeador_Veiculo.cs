using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstacionamento.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_Resolvido_Erro_Mapeador_Veiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Veiculos_Id",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Hospedes_HospedeId",
                table: "Veiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Tickets_TicketId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_HospedeId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_TicketId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "HospedeId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Veiculos");

            migrationBuilder.AddColumn<Guid>(
                name: "VeiculoId",
                table: "Tickets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_VeiculoId",
                table: "Tickets",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Veiculos_VeiculoId",
                table: "Tickets",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Veiculos_VeiculoId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_VeiculoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "Tickets");

            migrationBuilder.AddColumn<Guid>(
                name: "HospedeId",
                table: "Veiculos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketId",
                table: "Veiculos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_HospedeId",
                table: "Veiculos",
                column: "HospedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TicketId",
                table: "Veiculos",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Veiculos_Id",
                table: "Tickets",
                column: "Id",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Hospedes_HospedeId",
                table: "Veiculos",
                column: "HospedeId",
                principalTable: "Hospedes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Tickets_TicketId",
                table: "Veiculos",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
