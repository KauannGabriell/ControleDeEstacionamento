using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstacionamento.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_Resolvido_Mapeamento_Vaga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                table: "Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Veiculos_VeiculoId",
                table: "Vagas");

            migrationBuilder.AlterColumn<Guid>(
                name: "VeiculoId",
                table: "Vagas",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "EstacionamentoId",
                table: "Vagas",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                table: "Vagas",
                column: "EstacionamentoId",
                principalTable: "Estacionamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Veiculos_VeiculoId",
                table: "Vagas",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                table: "Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Veiculos_VeiculoId",
                table: "Vagas");

            migrationBuilder.AlterColumn<Guid>(
                name: "VeiculoId",
                table: "Vagas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EstacionamentoId",
                table: "Vagas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                table: "Vagas",
                column: "EstacionamentoId",
                principalTable: "Estacionamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Veiculos_VeiculoId",
                table: "Vagas",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
