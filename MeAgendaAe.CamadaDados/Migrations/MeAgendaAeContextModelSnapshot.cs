﻿// <auto-generated />
using System;
using MeAgendaAe.CamadaDados.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeAgendaAe.CamadaDados.Migrations
{
    [DbContext(typeof(MeAgendaAeContext))]
    partial class MeAgendaAeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbAgendamentos", b =>
                {
                    b.Property<long>("IdAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.Property<long>("IdEmpresa")
                        .HasColumnType("bigint");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAgendamento");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("TbAgendamentos");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbCidades", b =>
                {
                    b.Property<long>("IdCidades")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCidades");

                    b.ToTable("TbCidades");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbConfiguracoes", b =>
                {
                    b.Property<int>("IdConfiguracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.HasKey("IdConfiguracao");

                    b.ToTable("TbConfiguracoes");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbEmpresas", b =>
                {
                    b.Property<long>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<long>("IdCidade")
                        .HasColumnType("bigint");

                    b.Property<long>("IdEstado")
                        .HasColumnType("bigint");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpresa");

                    b.HasIndex("IdCidade");

                    b.HasIndex("IdEstado");

                    b.ToTable("TbEmpresas");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbEstados", b =>
                {
                    b.Property<long>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstado");

                    b.ToTable("TbEstados");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbFormasPagamentos", b =>
                {
                    b.Property<int>("IdFormasPagamentos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoFormaPagamento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFormasPagamentos");

                    b.ToTable("TbFormasPagamentos");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbPagamentos", b =>
                {
                    b.Property<long>("IdPagamentos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdFormaPagamento")
                        .HasColumnType("int");

                    b.Property<int>("Parcelas")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPagamentos");

                    b.HasIndex("IdFormaPagamento");

                    b.ToTable("TbPagamentos");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbUsuarios", b =>
                {
                    b.Property<long>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdCidade")
                        .HasColumnType("bigint");

                    b.Property<long>("IdEstado")
                        .HasColumnType("bigint");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UltimoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdCidade");

                    b.HasIndex("IdEstado");

                    b.ToTable("TbUsuarios");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbAgendamentos", b =>
                {
                    b.HasOne("MeAgendaAe.CamadaDados.Tabelas.TbEmpresas", "TbEmpresas")
                        .WithMany("TbAgendamentos")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TbEmpresas");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbEmpresas", b =>
                {
                    b.HasOne("MeAgendaAe.CamadaDados.Tabelas.TbCidades", "TbCidades")
                        .WithMany("TbEmpresas")
                        .HasForeignKey("IdCidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeAgendaAe.CamadaDados.Tabelas.TbEstados", "TbEstados")
                        .WithMany("TbEmpresas")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TbCidades");

                    b.Navigation("TbEstados");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbPagamentos", b =>
                {
                    b.HasOne("MeAgendaAe.CamadaDados.Tabelas.TbFormasPagamentos", "TbFormasPagamentos")
                        .WithMany("TbPagamentos")
                        .HasForeignKey("IdFormaPagamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TbFormasPagamentos");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbUsuarios", b =>
                {
                    b.HasOne("MeAgendaAe.CamadaDados.Tabelas.TbCidades", "TbCidades")
                        .WithMany("TbUsuarios")
                        .HasForeignKey("IdCidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeAgendaAe.CamadaDados.Tabelas.TbEstados", "TbEstados")
                        .WithMany("TbUsuarios")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TbCidades");

                    b.Navigation("TbEstados");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbCidades", b =>
                {
                    b.Navigation("TbEmpresas");

                    b.Navigation("TbUsuarios");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbEmpresas", b =>
                {
                    b.Navigation("TbAgendamentos");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbEstados", b =>
                {
                    b.Navigation("TbEmpresas");

                    b.Navigation("TbUsuarios");
                });

            modelBuilder.Entity("MeAgendaAe.CamadaDados.Tabelas.TbFormasPagamentos", b =>
                {
                    b.Navigation("TbPagamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
