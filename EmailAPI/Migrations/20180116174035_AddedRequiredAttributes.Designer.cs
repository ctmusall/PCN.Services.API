﻿// <auto-generated />
using Email.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Email.API.Migrations
{
    [DbContext(typeof(EmailContext))]
    [Migration("20180116174035_AddedRequiredAttributes")]
    partial class AddedRequiredAttributes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Email.API.Models.LoggedEmail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlindCarbonCopies");

                    b.Property<string>("Body");

                    b.Property<string>("CarbonCopy");

                    b.Property<DateTime>("DateTimeSent");

                    b.Property<string>("FromAddress")
                        .IsRequired();

                    b.Property<bool>("IsBodyHtml");

                    b.Property<string>("Priority");

                    b.Property<string>("Subject");

                    b.Property<string>("ToAddress")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LoggedEmail");
                });
#pragma warning restore 612, 618
        }
    }
}
