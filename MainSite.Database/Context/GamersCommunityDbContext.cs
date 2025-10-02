﻿using System;
using System.Collections.Generic;
using MainSite.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MainSite.Database.Context;

public partial class GamersCommunityDbContext : DbContext
{
    public GamersCommunityDbContext(DbContextOptions<GamersCommunityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banned> Banneds { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventsUsersInterest> EventsUsersInterests { get; set; }

    public virtual DbSet<EventsUsersStatus> EventsUsersStatuses { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<FriendRequestStatus> FriendRequestStatuses { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameType> GameTypes { get; set; }

    public virtual DbSet<Locale> Locales { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<RankRight> RankRights { get; set; }

    public virtual DbSet<Right> Rights { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banned>(entity =>
        {
            entity.ToTable("Banned");

            entity.Property(e => e.BeginDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Entitled).HasMaxLength(255);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdModoNavigation).WithMany(p => p.BannedIdModoNavigations)
                .HasForeignKey(d => d.IdModo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banned_Modo");

            entity.HasOne(d => d.IdUserBanNavigation).WithMany(p => p.BannedIdUserBanNavigations)
                .HasForeignKey(d => d.IdUserBan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banned_Users");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_City");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasColumnType("numeric(10, 0)");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Countries");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Country");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.BeginDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PlaceName).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_City");
        });

        modelBuilder.Entity<EventsUsersInterest>(entity =>
        {
            entity.ToTable("EventsUsersInterest");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdEventNavigation).WithMany(p => p.EventsUsersInterests)
                .HasForeignKey(d => d.IdEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventsUsersInterest_Events");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.EventsUsersInterests)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventsUsersInterest_EventsTypeStatusUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.EventsUsersInterests)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventsUsersInterest_Users");
        });

        modelBuilder.Entity<EventsUsersStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Id");

            entity.ToTable("EventsUsersStatus");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Entitled).HasMaxLength(150);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.ToTable("Friend");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdFriendAsking).ValueGeneratedOnAdd();
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdFriendAskingNavigation).WithMany(p => p.FriendIdFriendAskingNavigations)
                .HasForeignKey(d => d.IdFriendAsking)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friend_UsersAsking");

            entity.HasOne(d => d.IdFriendReceiveNavigation).WithMany(p => p.FriendIdFriendReceiveNavigations)
                .HasForeignKey(d => d.IdFriendReceive)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Friend_UsersReceive");

            entity.HasOne(d => d.IdRequestFriendStatusNavigation).WithMany(p => p.Friends)
                .HasForeignKey(d => d.IdRequestFriendStatus)
                .HasConstraintName("FK_Friend_FriendRequestStatus");
        });

        modelBuilder.Entity<FriendRequestStatus>(entity =>
        {
            entity.ToTable("FriendRequestStatus");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Entitled).HasMaxLength(150);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Picture).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UrlValue).HasMaxLength(255);

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Games_GameType");
        });

        modelBuilder.Entity<GameType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GameType");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Entitled).HasMaxLength(255);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Locale>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Entitled).HasMaxLength(150);
            entity.Property(e => e.Lcid).HasMaxLength(50);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Message");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Message1)
                .HasColumnType("text")
                .HasColumnName("Message");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdReceiverNavigation).WithMany(p => p.MessageIdReceiverNavigations)
                .HasForeignKey(d => d.IdReceiver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Receiver");

            entity.HasOne(d => d.IdSenderNavigation).WithMany(p => p.MessageIdSenderNavigations)
                .HasForeignKey(d => d.IdSender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Sender");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Rank");

            entity.Property(e => e.Color)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Entitled).HasMaxLength(150);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<RankRight>(entity =>
        {
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdRankNavigation).WithMany(p => p.RankRights)
                .HasForeignKey(d => d.IdRank)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RankRights_Ranks");

            entity.HasOne(d => d.IdRightNavigation).WithMany(p => p.RankRights)
                .HasForeignKey(d => d.IdRight)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RankRights_Rights");
        });

        modelBuilder.Entity<Right>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Right");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Entitled).HasMaxLength(150);
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Uusers");

            entity.HasIndex(e => e.Mail, "IX_Users").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasDefaultValue("http://bariserv.net:3000/bfg/avatars/default.png");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.Hashcode).HasColumnType("numeric(4, 0)");
            entity.Property(e => e.LastConnection).HasColumnType("datetime");
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.Mail).HasMaxLength(255);
            entity.Property(e => e.MailHash)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.ModificationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NumAddress).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Pseudo).HasMaxLength(255);

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("FK_Users_City");

            entity.HasOne(d => d.IdLocaleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdLocale)
                .HasConstraintName("FK_Users_Locales");

            entity.HasOne(d => d.IdRankNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRank)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Ranks");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
