using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReservationSystem.API.Models;

public partial class ReservationSystemContext : DbContext
{
    public ReservationSystemContext()
    {
    }

    public ReservationSystemContext(DbContextOptions<ReservationSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AvailableDesksForCurrentDate> AvailableDesksForCurrentDates { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Corporation> Corporations { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Desk> Desks { get; set; }

    public virtual DbSet<DeskMonitorDetail> DeskMonitorDetails { get; set; }

    public virtual DbSet<DeskReservation> DeskReservations { get; set; }

    public virtual DbSet<DeskReservation1> DeskReservations1 { get; set; }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<Hub> Hubs { get; set; }

    public virtual DbSet<MeetingRoom> MeetingRooms { get; set; }

    public virtual DbSet<MeetingRoomDetail> MeetingRoomDetails { get; set; }

    public virtual DbSet<MeetingRoomReservation> MeetingRoomReservations { get; set; }

    public virtual DbSet<MeetingRoomReservation1> MeetingRoomReservations1 { get; set; }

    public virtual DbSet<Monitor> Monitors { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<ParkingLevel> ParkingLevels { get; set; }

    public virtual DbSet<ParkingReservation> ParkingReservations { get; set; }

    public virtual DbSet<ParkingReservation1> ParkingReservations1 { get; set; }

    public virtual DbSet<ParkingSpot> ParkingSpots { get; set; }

    public virtual DbSet<ParkingSpotDetail> ParkingSpotDetails { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationDetail> ReservationDetails { get; set; }

    public virtual DbSet<ReservationType> ReservationTypes { get; set; }

    public virtual DbSet<ReservationsPerUser> ReservationsPerUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tv> Tvs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersRole> UsersRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=reservation-system;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvailableDesksForCurrentDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("available_desks_for_current_date");

            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Department)
                .HasColumnType("character varying")
                .HasColumnName("department");
            entity.Property(e => e.Floormap)
                .HasMaxLength(255)
                .HasColumnName("floormap");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buildings");

            entity.ToTable("buildings");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_company");

            entity.ToTable("companies");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Corporationid).HasColumnName("corporationid");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.Corporation).WithMany(p => p.Companies)
                .HasForeignKey(d => d.Corporationid)
                .HasConstraintName("fk_corporation");
        });

        modelBuilder.Entity<Corporation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_corporation_id");

            entity.ToTable("corporations");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_department");

            entity.ToTable("departments");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.Company).WithMany(p => p.Departments)
                .HasForeignKey(d => d.Companyid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_company");
        });

        modelBuilder.Entity<Desk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_desk");

            entity.ToTable("desks");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Floorid).HasColumnName("floorid");
            entity.Property(e => e.Officeid).HasColumnName("officeid");

            entity.HasOne(d => d.Floor).WithMany(p => p.Desks)
                .HasForeignKey(d => d.Floorid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_floor");

            entity.HasOne(d => d.Office).WithMany(p => p.Desks)
                .HasForeignKey(d => d.Officeid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_office");
        });

        modelBuilder.Entity<DeskMonitorDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("desk_monitor_details");

            entity.Property(e => e.DeskId).HasColumnName("desk_id");
            entity.Property(e => e.Heightadjustable).HasColumnName("heightadjustable");
            entity.Property(e => e.Manufacturer)
                .HasColumnType("character varying")
                .HasColumnName("manufacturer");
            entity.Property(e => e.Model)
                .HasColumnType("character varying")
                .HasColumnName("model");
            entity.Property(e => e.MonitorId).HasColumnName("monitor_id");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<DeskReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_dr");

            entity.ToTable("desk_reservations");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Deskid).HasColumnName("deskid");
            entity.Property(e => e.Reservationid).HasColumnName("reservationid");

            entity.HasOne(d => d.Desk).WithMany(p => p.DeskReservations)
                .HasForeignKey(d => d.Deskid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_desks");

            entity.HasOne(d => d.Reservation).WithMany(p => p.DeskReservations)
                .HasForeignKey(d => d.Reservationid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_deskr");
        });

        modelBuilder.Entity<DeskReservation1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("desk_reservation");

            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.Companyname)
                .HasColumnType("character varying")
                .HasColumnName("companyname");
            entity.Property(e => e.Numberofreservations).HasColumnName("numberofreservations");
            entity.Property(e => e.Reservationday).HasColumnName("reservationday");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<Floor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_floors");

            entity.ToTable("floors");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Buildingid).HasColumnName("buildingid");
            entity.Property(e => e.Floormap)
                .HasMaxLength(255)
                .HasColumnName("floormap");
            entity.Property(e => e.Number).HasColumnName("number");

            entity.HasOne(d => d.Building).WithMany(p => p.Floors)
                .HasForeignKey(d => d.Buildingid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_building");
        });

        modelBuilder.Entity<Hub>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_hub");

            entity.ToTable("hubs");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Deskid).HasColumnName("deskid");
            entity.Property(e => e.Manufacturer)
                .HasColumnType("character varying")
                .HasColumnName("manufacturer");
            entity.Property(e => e.Model)
                .HasColumnType("character varying")
                .HasColumnName("model");
            entity.Property(e => e.Numberofcports).HasColumnName("numberofcports");
            entity.Property(e => e.Numberofusbports).HasColumnName("numberofusbports");
            entity.Property(e => e.Power).HasColumnName("power");

            entity.HasOne(d => d.Desk).WithMany(p => p.Hubs)
                .HasForeignKey(d => d.Deskid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_desk");
        });

        modelBuilder.Entity<MeetingRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_mr");

            entity.ToTable("meeting_rooms");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Floorid).HasColumnName("floorid");

            entity.HasOne(d => d.Floor).WithMany(p => p.MeetingRooms)
                .HasForeignKey(d => d.Floorid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_floor");
        });

        modelBuilder.Entity<MeetingRoomDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("meeting_room_details");

            entity.Property(e => e.BuildingAddress)
                .HasMaxLength(255)
                .HasColumnName("building_address");
            entity.Property(e => e.BuildingId).HasColumnName("building_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.FloorId).HasColumnName("floor_id");
            entity.Property(e => e.FloorNumber).HasColumnName("floor_number");
            entity.Property(e => e.MeetingRoomId).HasColumnName("meeting_room_id");
        });

        modelBuilder.Entity<MeetingRoomReservation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("meeting_room_reservation");

            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Meetingroomid).HasColumnName("meetingroomid");
            entity.Property(e => e.Reservationid).HasColumnName("reservationid");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Reservation).WithMany()
                .HasForeignKey(d => d.Reservationid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("meeting_room_reservation_reservationid_fkey");
        });

        modelBuilder.Entity<MeetingRoomReservation1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("meeting_room_reservations");

            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Reservationday).HasColumnName("reservationday");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Monitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_monitor");

            entity.ToTable("monitor");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Deskid).HasColumnName("deskid");
            entity.Property(e => e.Heightadjustable).HasColumnName("heightadjustable");
            entity.Property(e => e.Manufacturer)
                .HasColumnType("character varying")
                .HasColumnName("manufacturer");
            entity.Property(e => e.Model)
                .HasColumnType("character varying")
                .HasColumnName("model");
            entity.Property(e => e.Size).HasColumnName("size");

            entity.HasOne(d => d.Desk).WithMany(p => p.Monitors)
                .HasForeignKey(d => d.Deskid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_desk");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_office");

            entity.ToTable("offices");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.Deparmentid).HasColumnName("deparmentid");

            entity.HasOne(d => d.Deparment).WithMany(p => p.Offices)
                .HasForeignKey(d => d.Deparmentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_department");
        });

        modelBuilder.Entity<ParkingLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_pl");

            entity.ToTable("parking_levels");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Buildingid).HasColumnName("buildingid");
            entity.Property(e => e.Level).HasColumnName("level");

            entity.HasOne(d => d.Building).WithMany(p => p.ParkingLevels)
                .HasForeignKey(d => d.Buildingid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_buildings");
        });

        modelBuilder.Entity<ParkingReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_pr");

            entity.ToTable("parking_reservations");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Parkingspotid).HasColumnName("parkingspotid");
            entity.Property(e => e.Reservationid).HasColumnName("reservationid");

            entity.HasOne(d => d.Parkingspot).WithMany(p => p.ParkingReservations)
                .HasForeignKey(d => d.Parkingspotid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rps");

            entity.HasOne(d => d.Reservation).WithMany(p => p.ParkingReservations)
                .HasForeignKey(d => d.Reservationid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rpr");
        });

        modelBuilder.Entity<ParkingReservation1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("parking_reservation");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Reservationday).HasColumnName("reservationday");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<ParkingSpot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_ps");

            entity.ToTable("parking_spots");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.Parkinglevelid).HasColumnName("parkinglevelid");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.Parkinglevel).WithMany(p => p.ParkingSpots)
                .HasForeignKey(d => d.Parkinglevelid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_ps");
        });

        modelBuilder.Entity<ParkingSpotDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("parking_spot_details");

            entity.Property(e => e.BuildingAddress)
                .HasMaxLength(255)
                .HasColumnName("building_address");
            entity.Property(e => e.BuildingId).HasColumnName("building_id");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.ParkingLevel).HasColumnName("parking_level");
            entity.Property(e => e.ParkingLevelId).HasColumnName("parking_level_id");
            entity.Property(e => e.ParkingSpotId).HasColumnName("parking_spot_id");
            entity.Property(e => e.Width).HasColumnName("width");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_reservation");

            entity.ToTable("reservations");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Reservationday).HasColumnName("reservationday");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_users");
        });

        modelBuilder.Entity<ReservationDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("reservation_details");

            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.MeetingRoomId).HasColumnName("meeting_room_id");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.Reservationday).HasColumnName("reservationday");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<ReservationType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("reservation_types");

            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Reservationday).HasColumnName("reservationday");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<ReservationsPerUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("reservations_per_user");

            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.TotalReservations).HasColumnName("total_reservations");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_roles");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tvs");

            entity.ToTable("tvs");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(255)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Meetingroomid).HasColumnName("meetingroomid");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.Serialnumber).HasColumnName("serialnumber");
            entity.Property(e => e.Size).HasColumnName("size");

            entity.HasOne(d => d.Meetingroom).WithMany(p => p.Tvs)
                .HasForeignKey(d => d.Meetingroomid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_mr");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("fk_roles");
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("users_roles");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
