// <auto-generated />
using System;
using Chinook.DataStore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chinook.DataStore.SqlServer.Migrations
{
    [DbContext(typeof(ChinookContext))]
    [Migration("20220131032220_ShippingRate")]
    partial class ShippingRate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"), 1L, 1);

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.HasKey("AlbumId");

                    b.HasIndex(new[] { "ArtistId" }, "IFK_AlbumArtistId");

                    b.ToTable("Album", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Company")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Country")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("SupportRepId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex(new[] { "SupportRepId" }, "IFK_CustomerSupportRepId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.CustomerShippingRate", b =>
                {
                    b.Property<int>("CustomerShippingRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerShippingRateId"), 1L, 1);

                    b.Property<string>("Carrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeliveryDateGuaranteed")
                        .HasColumnType("bit");

                    b.Property<int>("DeliveryDays")
                        .HasColumnType("int");

                    b.Property<string>("EasyPostRateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstDeliveryDays")
                        .HasColumnType("int");

                    b.Property<string>("ListCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RateCost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RetailCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RetailRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipmentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("CustomerShippingRateId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("CustomerShippingRate", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EmployeeId");

                    b.HasIndex(new[] { "ReportsTo" }, "IFK_EmployeeReportsTo");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"), 1L, 1);

                    b.Property<string>("BillingAddress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("BillingCity")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("BillingCountry")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("BillingPostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BillingState")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric(10,2)");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.HasIndex("WarehouseId");

                    b.HasIndex(new[] { "CustomerId" }, "IFK_InvoiceCustomerId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.InvoiceLine", b =>
                {
                    b.Property<int>("InvoiceLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceLineId"), 1L, 1);

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("InvoiceLineId");

                    b.HasIndex(new[] { "InvoiceId" }, "IFK_InvoiceLineInvoiceId");

                    b.HasIndex(new[] { "TrackId" }, "IFK_InvoiceLineTrackId");

                    b.ToTable("InvoiceLine", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.MediaType", b =>
                {
                    b.Property<int>("MediaTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaTypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("MediaTypeId");

                    b.ToTable("MediaType", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Parcel", b =>
                {
                    b.Property<Guid>("ParcelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("ParcelId");

                    b.HasIndex("TrackId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Parcel");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlist", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"), 1L, 1);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("Bytes")
                        .HasColumnType("int");

                    b.Property<string>("Composer")
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Milliseconds")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("TrackId");

                    b.HasIndex(new[] { "AlbumId" }, "IFK_TrackAlbumId");

                    b.HasIndex(new[] { "GenreId" }, "IFK_TrackGenreId");

                    b.HasIndex(new[] { "MediaTypeId" }, "IFK_TrackMediaTypeId");

                    b.ToTable("Track", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("SupportRepId")
                        .HasColumnType("int");

                    b.HasKey("WarehouseId");

                    b.HasIndex(new[] { "SupportRepId" }, "IFK_WarehouseSupportRepId");

                    b.ToTable("Warehouse", (string)null);
                });

            modelBuilder.Entity("PlaylistTrack", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "TrackId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("PlaylistId", "TrackId"), false);

                    b.HasIndex(new[] { "TrackId" }, "IFK_PlaylistTrackTrackId");

                    b.ToTable("PlaylistTrack", (string)null);
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Album", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .IsRequired()
                        .HasConstraintName("FK_AlbumArtistId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Customer", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Employee", "SupportRep")
                        .WithMany("Customers")
                        .HasForeignKey("SupportRepId")
                        .HasConstraintName("FK_CustomerSupportRepId");

                    b.Navigation("SupportRep");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.CustomerShippingRate", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Customer", "Customer")
                        .WithMany("ShippingRates")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Chinook.DataStore.SqlServer.Warehouse", null)
                        .WithMany("CustomerShippingRates")
                        .HasForeignKey("WarehouseId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Employee", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Employee", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsTo")
                        .HasConstraintName("FK_EmployeeReportsTo");

                    b.Navigation("ReportsToNavigation");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Invoice", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_InvoiceCustomerId");

                    b.HasOne("Chinook.DataStore.SqlServer.Warehouse", null)
                        .WithMany("Invoices")
                        .HasForeignKey("WarehouseId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.InvoiceLine", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Invoice", "Invoice")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("InvoiceId")
                        .IsRequired()
                        .HasConstraintName("FK_InvoiceLineInvoiceId");

                    b.HasOne("Chinook.DataStore.SqlServer.Track", "Track")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("TrackId")
                        .IsRequired()
                        .HasConstraintName("FK_InvoiceLineTrackId");

                    b.Navigation("Invoice");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Parcel", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chinook.DataStore.SqlServer.Warehouse", null)
                        .WithMany("Parcels")
                        .HasForeignKey("WarehouseId");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Track", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .HasConstraintName("FK_TrackAlbumId");

                    b.HasOne("Chinook.DataStore.SqlServer.Genre", "Genre")
                        .WithMany("Tracks")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_TrackGenreId");

                    b.HasOne("Chinook.DataStore.SqlServer.MediaType", "MediaType")
                        .WithMany("Tracks")
                        .HasForeignKey("MediaTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_TrackMediaTypeId");

                    b.Navigation("Album");

                    b.Navigation("Genre");

                    b.Navigation("MediaType");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Warehouse", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Employee", "SupportRep")
                        .WithMany("Warehouses")
                        .HasForeignKey("SupportRepId");

                    b.Navigation("SupportRep");
                });

            modelBuilder.Entity("PlaylistTrack", b =>
                {
                    b.HasOne("Chinook.DataStore.SqlServer.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .IsRequired()
                        .HasConstraintName("FK_PlaylistTrackPlaylistId");

                    b.HasOne("Chinook.DataStore.SqlServer.Track", null)
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .IsRequired()
                        .HasConstraintName("FK_PlaylistTrackTrackId");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Artist", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Customer", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("ShippingRates");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Employee", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("InverseReportsToNavigation");

                    b.Navigation("Warehouses");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Genre", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Invoice", b =>
                {
                    b.Navigation("InvoiceLines");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.MediaType", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Track", b =>
                {
                    b.Navigation("InvoiceLines");
                });

            modelBuilder.Entity("Chinook.DataStore.SqlServer.Warehouse", b =>
                {
                    b.Navigation("CustomerShippingRates");

                    b.Navigation("Invoices");

                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
