using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AirlineManagement.Models;

namespace AirlineManagement.Models
{
    public partial class NeondbContext : DbContext
    {
        public NeondbContext()
        {
        }

        public NeondbContext(DbContextOptions<NeondbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }

        public virtual DbSet<Flight> Flights { get; set; }

        public virtual DbSet<Passenger> Passengers { get; set; }

        public virtual DbSet<Staff> Staff { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.AirlineId).HasName("airlines_pkey");

                entity.ToTable("airlines");

                entity.Property(e => e.AirlineId)
                    .ValueGeneratedNever()
                    .HasColumnName("airline_id");
                entity.Property(e => e.AirlineName)
                    .HasMaxLength(255)
                    .HasColumnName("airline_name");
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(15)
                    .HasColumnName("contact_number");
                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightId).HasName("flights_pkey");

                entity.ToTable("flights");

                entity.Property(e => e.FlightId)
                    .ValueGeneratedNever()
                    .HasColumnName("flight_id");
                entity.Property(e => e.AirlineId).HasColumnName("airline_id");
                entity.Property(e => e.ArrivalTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("arrival_time");
                entity.Property(e => e.DepartureTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("departure_time");
                entity.Property(e => e.Destination)
                    .HasMaxLength(255)
                    .HasColumnName("destination");
                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(20)
                    .HasColumnName("flight_number");
                entity.Property(e => e.Origin)
                    .HasMaxLength(255)
                    .HasColumnName("origin");

                entity.HasOne(d => d.Airline).WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("flights_airline_id_fkey");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.PassengerId).HasName("passengers_pkey");

                entity.ToTable("passengers");

                entity.Property(e => e.PassengerId)
                    .ValueGeneratedNever()
                    .HasColumnName("passenger_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Nationality)
                    .HasMaxLength(255)
                    .HasColumnName("nationality");
                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(20)
                    .HasColumnName("passport_number");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffId).HasName("staff_pkey");

                entity.ToTable("staff");

                entity.Property(e => e.StaffId)
                    .ValueGeneratedNever()
                    .HasColumnName("staff_id");
                entity.Property(e => e.AirlineId).HasColumnName("airline_id");
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(15)
                    .HasColumnName("contact_number");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");

                entity.HasOne(d => d.Airline).WithMany(p => p.Staff)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("staff_airline_id_fkey");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketId).HasName("tickets_pkey");

                entity.ToTable("tickets");

                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("ticket_id");
                entity.Property(e => e.FlightId).HasColumnName("flight_id");
                entity.Property(e => e.PassengerId).HasColumnName("passenger_id");
                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");
                entity.Property(e => e.SeatNumber)
                    .HasMaxLength(10)
                    .HasColumnName("seat_number");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.HasOne(d => d.Flight).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("tickets_flight_id_fkey");

                entity.HasOne(d => d.Passenger).WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PassengerId)
                    .HasConstraintName("tickets_passenger_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
