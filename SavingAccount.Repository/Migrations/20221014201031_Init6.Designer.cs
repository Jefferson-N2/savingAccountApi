﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SavingAccount.Repository.Config.Persistence;

namespace SavingAccount.Repository.Migrations
{
    [DbContext(typeof(AccountDBContext))]
    [Migration("20221014201031_Init6")]
    partial class Init6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SavingAccount.Entity.Model.AccountModel", b =>
                {
                    b.Property<string>("ACCOUNT_NUMBER")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ACCOUNT_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_ACCOUNT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ID_CLIENT")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ACCOUNT_NUMBER");

                    b.HasIndex("ID_CLIENT");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("SavingAccount.Entity.Model.BalanceModel", b =>
                {
                    b.Property<int>("ID_Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ACCOUNT_NUMBER")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CREDIT_VALUE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DEBIT_VALUE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ID_CLIENT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<decimal>("TOTAL_VALUE")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Balance");

                    b.HasIndex("ACCOUNT_NUMBER");

                    b.ToTable("Balance");
                });

            modelBuilder.Entity("SavingAccount.Entity.Model.ClientModel", b =>
                {
                    b.Property<string>("ID_CLIENT")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CEATION_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("NAME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_CLIENT");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("SavingAccount.Entity.Model.AccountModel", b =>
                {
                    b.HasOne("SavingAccount.Entity.Model.ClientModel", "CLIENT")
                        .WithMany("ACCOUNT_LIST")
                        .HasForeignKey("ID_CLIENT")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CLIENT");
                });

            modelBuilder.Entity("SavingAccount.Entity.Model.BalanceModel", b =>
                {
                    b.HasOne("SavingAccount.Entity.Model.AccountModel", "ACCOUNT")
                        .WithMany("BALANCE_LIST")
                        .HasForeignKey("ACCOUNT_NUMBER")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ACCOUNT");
                });

            modelBuilder.Entity("SavingAccount.Entity.Model.AccountModel", b =>
                {
                    b.Navigation("BALANCE_LIST");
                });

            modelBuilder.Entity("SavingAccount.Entity.Model.ClientModel", b =>
                {
                    b.Navigation("ACCOUNT_LIST");
                });
#pragma warning restore 612, 618
        }
    }
}
