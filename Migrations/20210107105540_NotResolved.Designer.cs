﻿// <auto-generated />
using System;
using IbDataTool;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IbDataTool.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210107105540_NotResolved")]
    partial class NotResolved
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("IbDataTool.Model.BalanceSheet", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AcceptedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AccountPayables")
                        .HasColumnType("float");

                    b.Property<double>("AccumulatedOtherComprehensiveIncomeLoss")
                        .HasColumnType("float");

                    b.Property<double>("CashAndCashEquivalents")
                        .HasColumnType("float");

                    b.Property<double>("CashAndShortTermInvestments")
                        .HasColumnType("float");

                    b.Property<double>("CommonStock")
                        .HasColumnType("float");

                    b.Property<double>("DeferredRevenue")
                        .HasColumnType("float");

                    b.Property<double>("DeferredRevenueNonCurrent")
                        .HasColumnType("float");

                    b.Property<double>("DeferredTaxLiabilitiesNonCurrent")
                        .HasColumnType("float");

                    b.Property<string>("FillingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Goodwill")
                        .HasColumnType("float");

                    b.Property<double>("GoodwillAndIntangibleAssets")
                        .HasColumnType("float");

                    b.Property<double>("IntangibleAssets")
                        .HasColumnType("float");

                    b.Property<double>("Inventory")
                        .HasColumnType("float");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LongTermDebt")
                        .HasColumnType("float");

                    b.Property<double>("LongTermInvestments")
                        .HasColumnType("float");

                    b.Property<double>("NetDebt")
                        .HasColumnType("float");

                    b.Property<double>("NetReceivables")
                        .HasColumnType("float");

                    b.Property<double>("OtherAssets")
                        .HasColumnType("float");

                    b.Property<double>("OtherCurrentAssets")
                        .HasColumnType("float");

                    b.Property<double>("OtherCurrentLiabilities")
                        .HasColumnType("float");

                    b.Property<double>("OtherLiabilities")
                        .HasColumnType("float");

                    b.Property<double>("OtherNonCurrentAssets")
                        .HasColumnType("float");

                    b.Property<double>("OtherNonCurrentLiabilities")
                        .HasColumnType("float");

                    b.Property<double>("OthertotalStockholdersEquity")
                        .HasColumnType("float");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PropertyPlantEquipmentNet")
                        .HasColumnType("float");

                    b.Property<double>("RetainedEarnings")
                        .HasColumnType("float");

                    b.Property<double>("ShortTermDebt")
                        .HasColumnType("float");

                    b.Property<double>("ShortTermInvestments")
                        .HasColumnType("float");

                    b.Property<double>("TaxAssets")
                        .HasColumnType("float");

                    b.Property<double>("TaxPayables")
                        .HasColumnType("float");

                    b.Property<double>("TotalAssets")
                        .HasColumnType("float");

                    b.Property<double>("TotalCurrentAssets")
                        .HasColumnType("float");

                    b.Property<double>("TotalCurrentLiabilities")
                        .HasColumnType("float");

                    b.Property<double>("TotalDebt")
                        .HasColumnType("float");

                    b.Property<double>("TotalInvestments")
                        .HasColumnType("float");

                    b.Property<double>("TotalLiabilities")
                        .HasColumnType("float");

                    b.Property<double>("TotalLiabilitiesAndStockholdersEquity")
                        .HasColumnType("float");

                    b.Property<double>("TotalNonCurrentAssets")
                        .HasColumnType("float");

                    b.Property<double>("TotalNonCurrentLiabilities")
                        .HasColumnType("float");

                    b.Property<double>("TotalStockholdersEquity")
                        .HasColumnType("float");

                    b.HasKey("Symbol", "Date");

                    b.ToTable("BalanceSheets");
                });

            modelBuilder.Entity("IbDataTool.Model.Batch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataTransferId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("IbDataTool.Model.CashFlowStatement", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AcceptedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AccountsPayables")
                        .HasColumnType("float");

                    b.Property<double>("AccountsReceivables")
                        .HasColumnType("float");

                    b.Property<double>("AcquisitionsNet")
                        .HasColumnType("float");

                    b.Property<double>("CapitalExpenditure")
                        .HasColumnType("float");

                    b.Property<double>("CashAtBeginningOfPeriod")
                        .HasColumnType("float");

                    b.Property<double>("CashAtEndOfPeriod")
                        .HasColumnType("float");

                    b.Property<double>("ChangeInWorkingCapital")
                        .HasColumnType("float");

                    b.Property<double>("CommonStockIssued")
                        .HasColumnType("float");

                    b.Property<double>("CommonStockRepurchased")
                        .HasColumnType("float");

                    b.Property<double>("DebtRepayment")
                        .HasColumnType("float");

                    b.Property<double>("DeferredIncomeTax")
                        .HasColumnType("float");

                    b.Property<double>("DepreciationAndAmortization")
                        .HasColumnType("float");

                    b.Property<double>("DividendsPaid")
                        .HasColumnType("float");

                    b.Property<double>("EffectOfForexChangesOnCash")
                        .HasColumnType("float");

                    b.Property<string>("FillingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FreeCashFlow")
                        .HasColumnType("float");

                    b.Property<double>("Inventory")
                        .HasColumnType("float");

                    b.Property<double>("InvestmentsInPropertyPlantAndEquipment")
                        .HasColumnType("float");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NetCashProvidedByOperatingActivities")
                        .HasColumnType("float");

                    b.Property<double>("NetCashUsedForInvestingActivites")
                        .HasColumnType("float");

                    b.Property<double>("NetCashUsedProvidedByFinancingActivities")
                        .HasColumnType("float");

                    b.Property<double>("NetChangeInCash")
                        .HasColumnType("float");

                    b.Property<double>("NetIncome")
                        .HasColumnType("float");

                    b.Property<double>("OperatingCashFlow")
                        .HasColumnType("float");

                    b.Property<double>("OtherFinancingActivites")
                        .HasColumnType("float");

                    b.Property<double>("OtherInvestingActivites")
                        .HasColumnType("float");

                    b.Property<double>("OtherNonCashItems")
                        .HasColumnType("float");

                    b.Property<double>("OtherWorkingCapital")
                        .HasColumnType("float");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PurchasesOfInvestments")
                        .HasColumnType("float");

                    b.Property<double>("SalesMaturitiesOfInvestments")
                        .HasColumnType("float");

                    b.Property<double>("StockBasedCompensation")
                        .HasColumnType("float");

                    b.HasKey("Symbol", "Date");

                    b.ToTable("CashFlowStatements");
                });

            modelBuilder.Entity("IbDataTool.Model.Contract", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exchange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Symbol");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("IbDataTool.Model.DataTransfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DataTransfer");
                });

            modelBuilder.Entity("IbDataTool.Model.IncomeStatement", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AcceptedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CostAndExpenses")
                        .HasColumnType("float");

                    b.Property<double>("CostOfRevenue")
                        .HasColumnType("float");

                    b.Property<double>("DepreciationAndAmortization")
                        .HasColumnType("float");

                    b.Property<double>("Ebitda")
                        .HasColumnType("float");

                    b.Property<double>("Ebitdaratio")
                        .HasColumnType("float");

                    b.Property<double>("Eps")
                        .HasColumnType("float");

                    b.Property<double>("Epsdiluted")
                        .HasColumnType("float");

                    b.Property<string>("FillingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GeneralAndAdministrativeExpenses")
                        .HasColumnType("float");

                    b.Property<double>("GrossProfit")
                        .HasColumnType("float");

                    b.Property<double>("GrossProfitRatio")
                        .HasColumnType("float");

                    b.Property<double>("IncomeBeforeTax")
                        .HasColumnType("float");

                    b.Property<double>("IncomeBeforeTaxRatio")
                        .HasColumnType("float");

                    b.Property<double>("IncomeTaxExpense")
                        .HasColumnType("float");

                    b.Property<double>("InterestExpense")
                        .HasColumnType("float");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NetIncome")
                        .HasColumnType("float");

                    b.Property<double>("NetIncomeRatio")
                        .HasColumnType("float");

                    b.Property<double>("OperatingExpenses")
                        .HasColumnType("float");

                    b.Property<double>("OperatingIncome")
                        .HasColumnType("float");

                    b.Property<double>("OperatingIncomeRatio")
                        .HasColumnType("float");

                    b.Property<double>("OtherExpenses")
                        .HasColumnType("float");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ResearchAndDevelopmentExpenses")
                        .HasColumnType("float");

                    b.Property<double>("Revenue")
                        .HasColumnType("float");

                    b.Property<double>("SellingAndMarketingExpenses")
                        .HasColumnType("float");

                    b.Property<double>("TotalOtherIncomeExpensesNet")
                        .HasColumnType("float");

                    b.Property<double>("WeightedAverageShsOut")
                        .HasColumnType("float");

                    b.Property<double>("WeightedAverageShsOutDil")
                        .HasColumnType("float");

                    b.HasKey("Symbol", "Date");

                    b.ToTable("IncomeStatements");
                });

            modelBuilder.Entity("IbDataTool.Model.NotResolved", b =>
                {
                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Company");

                    b.ToTable("NotResolved");
                });

            modelBuilder.Entity("IbDataTool.Model.Stock", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Exchange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Symbol");

                    b.ToTable("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
