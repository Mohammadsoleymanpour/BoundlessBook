﻿// <auto-generated />
using System;
using BoundlessBook.Infrastructure.Ef.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoundlessBook.Infrastructure.Migrations
{
    [DbContext(typeof(BoundlessBookContext))]
    [Migration("20231222152220_fix_email")]
    partial class fix_email
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoundlessBook.Domain.CategoryAggregate.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Categories", "dbo");
                });

            modelBuilder.Entity("BoundlessBook.Domain.CommentAggregate.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CommentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BoundlessBook.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", "order");
                });

            modelBuilder.Entity("BoundlessBook.Domain.ProductAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(110)
                        .HasColumnType("nvarchar(110)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("SecondarySubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Products", "product");
                });

            modelBuilder.Entity("BoundlessBook.Domain.RoleAggregate.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "role");
                });

            modelBuilder.Entity("BoundlessBook.Domain.SellerAggregate.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SellerStatus")
                        .HasColumnType("int");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NationalCode")
                        .IsUnique();

                    b.ToTable("Sellers", "seller");
                });

            modelBuilder.Entity("BoundlessBook.Domain.SiteEntities.Banner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BannerPosition")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("BoundlessBook.Domain.SiteEntities.Slider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("BoundlessBook.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Family")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Users", "user");
                });

            modelBuilder.Entity("BoundlessBook.Domain.CategoryAggregate.Category", b =>
                {
                    b.HasOne("BoundlessBook.Domain.CategoryAggregate.Category", null)
                        .WithMany("Child")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("BoundlessBook.Common.Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Canonical")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Categories", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("SeoData")
                        .IsRequired();
                });

            modelBuilder.Entity("BoundlessBook.Domain.OrderAggregate.Order", b =>
                {
                    b.OwnsOne("BoundlessBook.Domain.OrderAggregate.OrderAddress", "Address", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("NationalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)");

                            b1.Property<string>("PostalAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("Shire")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId")
                                .IsUnique();

                            b1.ToTable("Addresses", "order");

                            b1.WithOwner("Order")
                                .HasForeignKey("OrderId");

                            b1.Navigation("Order");
                        });

                    b.OwnsMany("BoundlessBook.Domain.OrderAggregate.OrderItem", "OrderItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("InventoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<float>("Price")
                                .HasColumnType("real");

                            b1.HasKey("Id");

                            b1.HasIndex("InventoryId");

                            b1.HasIndex("OrderId");

                            b1.ToTable("Items", "order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("BoundlessBook.Domain.OrderAggregate.ValueObjects.OrderDiscount", "OrderDiscount", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<float>("DiscountAmount")
                                .HasColumnType("real");

                            b1.Property<string>("DiscountTitle")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("BoundlessBook.Domain.SiteEntities.ShippingMethod", "ShippingMethod", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Cost")
                                .HasColumnType("int");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<string>("Title")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address");

                    b.Navigation("OrderDiscount");

                    b.Navigation("OrderItems");

                    b.Navigation("ShippingMethod");
                });

            modelBuilder.Entity("BoundlessBook.Domain.ProductAggregate.Product", b =>
                {
                    b.OwnsOne("BoundlessBook.Common.Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Canonical")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", "product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("BoundlessBook.Domain.ProductAggregate.ProductImage", "ProductImages", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ImageName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<int>("Sequence")
                                .HasColumnType("int");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Images", "product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("BoundlessBook.Domain.ProductAggregate.ProductSpecification", "ProductSpecifications", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<string>("Key")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Specifications", "product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("ProductImages");

                    b.Navigation("ProductSpecifications");

                    b.Navigation("SeoData")
                        .IsRequired();
                });

            modelBuilder.Entity("BoundlessBook.Domain.RoleAggregate.Role", b =>
                {
                    b.OwnsMany("BoundlessBook.Domain.RoleAggregate.RolePermission", "RolePermissions", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<int>("Permission")
                                .HasColumnType("int");

                            b1.HasKey("RoleId", "Id");

                            b1.ToTable("Permissions", "role");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("BoundlessBook.Domain.SellerAggregate.Seller", b =>
                {
                    b.OwnsMany("BoundlessBook.Domain.SellerAggregate.SellerInventory", "SellerInventories", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<int?>("DiscountPercent")
                                .HasColumnType("int");

                            b1.Property<bool>("IsActive")
                                .HasColumnType("bit");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<float>("Price")
                                .HasColumnType("real");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("SellerId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.HasIndex("SellerId");

                            b1.ToTable("Inventories", "seller");

                            b1.WithOwner()
                                .HasForeignKey("SellerId");
                        });

                    b.Navigation("SellerInventories");
                });

            modelBuilder.Entity("BoundlessBook.Domain.UserAggregate.User", b =>
                {
                    b.OwnsMany("BoundlessBook.Application.Users.UserToken", "UserTokens", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Device")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("HashJwtToken")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.Property<string>("HashRefreshToken")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<DateTime>("RefreshTokenExpireDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("TokenExpireDate")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Tokens", "user");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("BoundlessBook.Domain.UserAggregate.UserAddress", "UserAddresses", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<bool>("IsActive")
                                .HasColumnType("bit");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("NationalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("Shire")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Addresses", "user");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("BoundlessBook.Domain.UserAggregate.UserRole", "UserRoles", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Roles", "user");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("BoundlessBook.Domain.UserAggregate.Wallet", "Wallets", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Description")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<DateTime>("FinallyDate")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsDelete")
                                .HasColumnType("bit");

                            b1.Property<bool>("IsFinally")
                                .HasColumnType("bit");

                            b1.Property<float>("Price")
                                .HasColumnType("real");

                            b1.Property<int>("Type")
                                .HasColumnType("int");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Wallets", "user");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("UserAddresses");

                    b.Navigation("UserRoles");

                    b.Navigation("UserTokens");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("BoundlessBook.Domain.CategoryAggregate.Category", b =>
                {
                    b.Navigation("Child");
                });
#pragma warning restore 612, 618
        }
    }
}