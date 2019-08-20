﻿using System.Configuration;
using Microsoft.EntityFrameworkCore;
using TelemetryDependencies.Models;

namespace Telemetry.App
{
    public class TelemetryContext : DbContext
    {
        /// <summary>
        ///     Gets or sets the motors.
        /// </summary>
        public DbSet<Motor> Motors { get; set; }

        public DbSet<MPPT> MPPTs { get; set; }


        /// <summary>
        ///     Gets or sets the errors.
        /// </summary>
        public DbSet<Error> Errors { get; set; }

        public DbSet<Debug> Debugs { get; set; }

        public DbSet<Gps> GPSs { get; set; }

        /// <summary>
        ///     Gets or sets the battery management system #1.
        /// </summary>
        public DbSet<Bms> BatteryManagementSystems { get; set; }

        public DbSet<Routenote> Routenotes { get; set; }
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        ///     The on configuring.
        /// </summary>
        /// <param name="optionsBuilder">
        ///     The options builder.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}