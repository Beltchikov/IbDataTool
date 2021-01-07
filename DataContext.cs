﻿using IbDataTool.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IbDataTool
{
    /// <summary>
    /// DataContext
    /// </summary>
    public class DataContext : DbContext
    {
        private static DataContext _dataContext;
        private static readonly object lockObject = new object();

        public static DataContext Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (_dataContext == null)
                    {
                        _dataContext = new DataContext();
                    }
                    return _dataContext;
                }
            }
        }

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.Instance["ConnectionString"]);
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IncomeStatement>().HasKey(p => new { p.Symbol, p.Date });
            modelBuilder.Entity<BalanceSheet>().HasKey(p => new { p.Symbol, p.Date });
            modelBuilder.Entity<CashFlowStatement>().HasKey(p => new { p.Symbol, p.Date });
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<DataTransfer> DataTransfer { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<IncomeStatement> IncomeStatements { get; set; }
        public DbSet<BalanceSheet> BalanceSheets { get; set; }
        public DbSet<CashFlowStatement> CashFlowStatements { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<NotResolved> NotResolved { get; set; }
    }
}
