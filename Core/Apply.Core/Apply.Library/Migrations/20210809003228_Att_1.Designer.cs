﻿// <auto-generated />
using System;
using Apply.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apply.Library.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210809003228_Att_1")]
    partial class Att_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Apply.Library.Cards", b =>
                {
                    b.Property<long>("CodCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NotPayment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodCard");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Apply.Library.FlowClosed", b =>
                {
                    b.Property<long>("CodFlowClosed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodFlowClosed");

                    b.ToTable("FlowClosed");
                });

            modelBuilder.Entity("Apply.Library.Payment", b =>
                {
                    b.Property<long>("CodPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<long>("CodWallet")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodPayment");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Apply.Library.Usuario", b =>
                {
                    b.Property<long>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Apply.Library.Wallet", b =>
                {
                    b.Property<long>("CodWallet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CardsNavigationCodCard")
                        .HasColumnType("bigint");

                    b.Property<int>("CodCards")
                        .HasColumnType("int");

                    b.Property<int>("CodFlowClosed")
                        .HasColumnType("int");

                    b.Property<int>("CodPayment")
                        .HasColumnType("int");

                    b.Property<int>("CodUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FlowClosedNavigationCodFlowClosed")
                        .HasColumnType("bigint");

                    b.Property<long?>("PaymentNavigationCodPayment")
                        .HasColumnType("bigint");

                    b.Property<long?>("UsuarioNavigationCodUsuario")
                        .HasColumnType("bigint");

                    b.HasKey("CodWallet");

                    b.HasIndex("CardsNavigationCodCard");

                    b.HasIndex("FlowClosedNavigationCodFlowClosed");

                    b.HasIndex("PaymentNavigationCodPayment");

                    b.HasIndex("UsuarioNavigationCodUsuario");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("Apply.Library.Wallet", b =>
                {
                    b.HasOne("Apply.Library.Cards", "CardsNavigation")
                        .WithMany()
                        .HasForeignKey("CardsNavigationCodCard");

                    b.HasOne("Apply.Library.FlowClosed", "FlowClosedNavigation")
                        .WithMany()
                        .HasForeignKey("FlowClosedNavigationCodFlowClosed");

                    b.HasOne("Apply.Library.Payment", "PaymentNavigation")
                        .WithMany()
                        .HasForeignKey("PaymentNavigationCodPayment");

                    b.HasOne("Apply.Library.Usuario", "UsuarioNavigation")
                        .WithMany()
                        .HasForeignKey("UsuarioNavigationCodUsuario");

                    b.Navigation("CardsNavigation");

                    b.Navigation("FlowClosedNavigation");

                    b.Navigation("PaymentNavigation");

                    b.Navigation("UsuarioNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}