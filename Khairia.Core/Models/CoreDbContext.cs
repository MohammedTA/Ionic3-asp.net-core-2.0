using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Khairia.Core.Models
{
	public class CoreDbContext : DbContext
	{
		
		public CoreDbContext(DbContextOptions options) : base(options)
		{
		}

		public virtual DbSet<ArchiveSacridetails> ArchiveSacridetails { get; set; }
		public virtual DbSet<ArchiveSacrifinames> ArchiveSacrifinames { get; set; }
		public virtual DbSet<AssetDuration> AssetDuration { get; set; }
		public virtual DbSet<Assetitems> Assetitems { get; set; }
		public virtual DbSet<Assets> Assets { get; set; }
		public virtual DbSet<AssetsOrders> AssetsOrders { get; set; }
		public virtual DbSet<Assetstypes> Assetstypes { get; set; }
		public virtual DbSet<Availableslotes> Availableslotes { get; set; }
		public virtual DbSet<Banner> Banner { get; set; }
		public virtual DbSet<CatchBonds> CatchBonds { get; set; }
		public virtual DbSet<Categories> Categories { get; set; }
		public virtual DbSet<Directdistirb> Directdistirb { get; set; }
		public virtual DbSet<Distribution> Distribution { get; set; }
		public virtual DbSet<Donationsize> Donationsize { get; set; }
		public virtual DbSet<Drivers> Drivers { get; set; }
		public virtual DbSet<Driversattendance> Driversattendance { get; set; }
		public virtual DbSet<Durations> Durations { get; set; }
		public virtual DbSet<Employees> Employees { get; set; }
		public virtual DbSet<EmpsCategries> EmpsCategries { get; set; }
		public virtual DbSet<Groups> Groups { get; set; }
		public virtual DbSet<Help1> Help1 { get; set; }
		public virtual DbSet<Help2> Help2 { get; set; }
		public virtual DbSet<Items> Items { get; set; }
		public virtual DbSet<Marks> Marks { get; set; }
		public virtual DbSet<Marquee> Marquee { get; set; }
		public virtual DbSet<Needy> Needy { get; set; }
		public virtual DbSet<Newsimages> Newsimages { get; set; }
		public virtual DbSet<Newstable> Newstable { get; set; }
		public virtual DbSet<Offdayes> Offdayes { get; set; }
		public virtual DbSet<OrderEmps> OrderEmps { get; set; }
		public virtual DbSet<Places> Places { get; set; }
		public virtual DbSet<Roles> Roles { get; set; }
		public virtual DbSet<Sacridetails> Sacridetails { get; set; }
		public virtual DbSet<Sacridetails60> Sacridetails60 { get; set; }
		public virtual DbSet<Sacrifinames> Sacrifinames { get; set; }
		public virtual DbSet<Sacrifinames6000> Sacrifinames6000 { get; set; }
		public virtual DbSet<Saidabout> Saidabout { get; set; }
		public virtual DbSet<Saidattach> Saidattach { get; set; }
		public virtual DbSet<Salaries> Salaries { get; set; }
		public virtual DbSet<Sections> Sections { get; set; }
		public virtual DbSet<SentNumbers> SentNumbers { get; set; }
		public virtual DbSet<Shipments> Shipments { get; set; }
		public virtual DbSet<Slidertbl> Slidertbl { get; set; }
		public virtual DbSet<Solts> Solts { get; set; }
		public virtual DbSet<Stratigyrates> Stratigyrates { get; set; }
		public virtual DbSet<Targets> Targets { get; set; }
		public virtual DbSet<Tasks> Tasks { get; set; }
		public virtual DbSet<Unites> Unites { get; set; }
		public virtual DbSet<Users> Users { get; set; }
		public virtual DbSet<Utilitiesprofile> Utilitiesprofile { get; set; }
		public virtual DbSet<Volunteerapp> Volunteerapp { get; set; }
		public virtual DbSet<Volunteerfields> Volunteerfields { get; set; }
		public virtual DbSet<Weekdayes> Weekdayes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:DefaultSchema", "usertest");

			modelBuilder.Entity<ArchiveSacridetails>(entity =>
			{
				entity.ToTable("archiveSacridetails", "dbo");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedNever();

				entity.Property(e => e.Time).HasMaxLength(50);

				entity.Property(e => e.Timename)
					.HasColumnName("timename")
					.HasMaxLength(50);

				entity.Property(e => e.Type).HasMaxLength(50);

				entity.Property(e => e.Typename)
					.HasColumnName("typename")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<ArchiveSacrifinames>(entity =>
			{
				entity.ToTable("archiveSacrifinames", "dbo");

				entity.Property(e => e.Id)
					.HasColumnName("id")
					.ValueGeneratedNever();

				entity.Property(e => e.Booknumber).HasMaxLength(50);

				entity.Property(e => e.Date).HasColumnType("datetime");

				entity.Property(e => e.Gender)
					.HasColumnName("gender")
					.HasMaxLength(5);

				entity.Property(e => e.Mail)
					.HasColumnName("mail")
					.HasMaxLength(50);

				entity.Property(e => e.Mobile).HasMaxLength(20);

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(200);

				entity.Property(e => e.Paytype).HasColumnName("paytype");

				entity.Property(e => e.Place)
					.HasColumnName("place")
					.HasMaxLength(50);

				entity.Property(e => e.SacrifiNumber).HasColumnName("Sacrifi_number");

				entity.Property(e => e.Time).HasColumnName("time");

				entity.Property(e => e.Year).HasColumnName("year");
			});

			modelBuilder.Entity<AssetDuration>(entity =>
			{
				entity.HasKey(e => e.Assdurid);

				entity.ToTable("AssetDuration", "dbo");

				entity.Property(e => e.Durcode).HasColumnName("durcode");

				entity.Property(e => e.Durcount).HasColumnName("durcount");

				entity.Property(e => e.Durname)
					.HasColumnName("durname")
					.HasMaxLength(50);

				entity.Property(e => e.Stat).HasColumnName("stat");
			});

			modelBuilder.Entity<Assetitems>(entity =>
			{
				entity.HasKey(e => e.Assetitemid);

				entity.ToTable("Assetitems", "dbo");

				entity.Property(e => e.Assetid).HasColumnName("assetid");

				entity.Property(e => e.Assetname)
					.HasColumnName("assetname")
					.HasMaxLength(50);

				entity.Property(e => e.Assetnumber).HasColumnName("assetnumber");

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasColumnType("ntext");
			});

			modelBuilder.Entity<Assets>(entity =>
			{
				entity.HasKey(e => e.Assetid);

				entity.ToTable("Assets", "dbo");

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(100);

				entity.Property(e => e.Approveddate)
					.HasColumnName("approveddate")
					.HasColumnType("datetime");

				entity.Property(e => e.Approvuser).HasColumnName("approvuser");

				entity.Property(e => e.Canceldate)
					.HasColumnName("canceldate")
					.HasColumnType("datetime");

				entity.Property(e => e.Canceluser).HasColumnName("canceluser");

				entity.Property(e => e.Closedate).HasColumnType("date");

				entity.Property(e => e.Day)
					.HasColumnName("day")
					.HasColumnType("date");

				entity.Property(e => e.Driver).HasColumnName("driver");

				entity.Property(e => e.Email).HasMaxLength(50);

				entity.Property(e => e.Hour).HasColumnName("hour");

				entity.Property(e => e.Lit)
					.HasColumnName("lit")
					.HasMaxLength(50);

				entity.Property(e => e.Long)
					.HasColumnName("long")
					.HasMaxLength(50);

				entity.Property(e => e.Mobile)
					.HasColumnName("mobile")
					.HasMaxLength(50);

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(50);

				entity.Property(e => e.Notes).HasColumnType("ntext");

				entity.Property(e => e.Phone)
					.HasColumnName("phone")
					.HasMaxLength(50);

				entity.Property(e => e.Recorddate).HasColumnType("datetime");

				entity.Property(e => e.Square)
					.HasColumnName("square")
					.HasMaxLength(50);

				entity.Property(e => e.Stat)
					.HasColumnName("stat")
					.HasDefaultValueSql("((1))");
			});

			modelBuilder.Entity<AssetsOrders>(entity =>
			{
				entity.HasKey(e => e.Assetorderid);

				entity.ToTable("AssetsOrders", "dbo");

				entity.Property(e => e.Assetorderid).HasColumnName("assetorderid");

				entity.Property(e => e.Address).HasMaxLength(100);

				entity.Property(e => e.Approveddate)
					.HasColumnName("approveddate")
					.HasColumnType("datetime");

				entity.Property(e => e.Asset)
					.HasColumnName("asset")
					.HasMaxLength(50);

				entity.Property(e => e.Canceldate)
					.HasColumnName("canceldate")
					.HasColumnType("datetime");

				entity.Property(e => e.Day)
					.HasColumnName("day")
					.HasColumnType("date");

				entity.Property(e => e.Driver).HasColumnName("driver");

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(50);

				entity.Property(e => e.Hallname).HasMaxLength(50);

				entity.Property(e => e.Hour)
					.HasColumnName("hour")
					.HasMaxLength(50);

				entity.Property(e => e.Lat)
					.HasColumnName("lat")
					.HasMaxLength(50);

				entity.Property(e => e.Long)
					.HasColumnName("long")
					.HasMaxLength(50);

				entity.Property(e => e.Mobile)
					.HasColumnName("mobile")
					.HasMaxLength(50);

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(50);

				entity.Property(e => e.Notes).HasColumnType("ntext");

				entity.Property(e => e.Number).HasColumnName("number");

				entity.Property(e => e.Phone)
					.HasColumnName("phone")
					.HasMaxLength(50);

				entity.Property(e => e.Recoreddate).HasColumnType("datetime");

				entity.Property(e => e.Square)
					.HasColumnName("square")
					.HasMaxLength(20);

				entity.Property(e => e.Stat)
					.HasColumnName("stat")
					.HasDefaultValueSql("((0))");
			});

			modelBuilder.Entity<Assetstypes>(entity =>
			{
				entity.HasKey(e => e.Assettype);

				entity.ToTable("Assetstypes", "dbo");

				entity.Property(e => e.Assettypename).HasMaxLength(50);
			});

			modelBuilder.Entity<Availableslotes>(entity =>
			{
				entity.HasKey(e => e.Availableid);

				entity.ToTable("Availableslotes", "dbo");

				entity.Property(e => e.Slot).HasColumnName("slot");
			});

			modelBuilder.Entity<Banner>(entity =>
			{
				entity.ToTable("banner", "db_owner");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Path)
					.HasColumnName("path")
					.HasMaxLength(100);
			});

			modelBuilder.Entity<CatchBonds>(entity =>
			{
				entity.HasKey(e => e.Bondid);

				entity.ToTable("CatchBonds", "dbo");

				entity.Property(e => e.Bonddate).HasColumnType("date");
			});

			modelBuilder.Entity<Categories>(entity =>
			{
				entity.HasKey(e => e.Catid);

				entity.ToTable("Categories", "db_owner");

				entity.Property(e => e.Catid).HasColumnName("catid");

				entity.Property(e => e.Categoryname).HasMaxLength(20);
			});

			modelBuilder.Entity<Directdistirb>(entity =>
			{
				entity.ToTable("Directdistirb", "db_owner");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Ammount).HasColumnName("ammount");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(50);

				entity.Property(e => e.Nid)
					.HasColumnName("nid")
					.HasMaxLength(10);

				entity.Property(e => e.Phone)
					.HasColumnName("phone")
					.HasMaxLength(10);
			});

			modelBuilder.Entity<Distribution>(entity =>
			{
				entity.HasKey(e => e.Reciveid);

				entity.ToTable("Distribution", "dbo");

				entity.Property(e => e.Reciveid).HasColumnName("reciveid");

				entity.Property(e => e.Ammount).HasColumnName("ammount");

				entity.Property(e => e.Details)
					.HasColumnName("details")
					.HasColumnType("ntext");

				entity.Property(e => e.Distrname).HasMaxLength(50);

				entity.Property(e => e.Distrpoint).HasMaxLength(50);

				entity.Property(e => e.Number).HasColumnName("number");

				entity.Property(e => e.Packsize)
					.HasColumnName("packsize")
					.HasMaxLength(5);

				entity.Property(e => e.Sdsd)
					.HasColumnName("sdsd")
					.HasColumnType("nchar(10)");

				entity.Property(e => e.Sdsdf)
					.HasColumnName("sdsdf")
					.HasColumnType("nchar(10)");

				entity.Property(e => e.Wewew)
					.HasColumnName("wewew")
					.HasColumnType("nchar(10)");
			});

			modelBuilder.Entity<Donationsize>(entity =>
			{
				entity.ToTable("donationsize", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Ammont).HasColumnName("ammont");

				entity.Property(e => e.Donatename)
					.HasColumnName("donatename")
					.HasMaxLength(50);

				entity.Property(e => e.Ewewew)
					.HasColumnName("ewewew")
					.HasColumnType("nchar(10)");

				entity.Property(e => e.Werewrewr)
					.HasColumnName("werewrewr")
					.HasColumnType("nchar(10)");

				entity.Property(e => e.Wewerwer)
					.HasColumnName("wewerwer")
					.HasColumnType("nchar(10)");
			});

			modelBuilder.Entity<Drivers>(entity =>
			{
				entity.HasKey(e => e.Driverid);

				entity.ToTable("Drivers", "db_owner");

				entity.Property(e => e.Driverid).HasColumnName("driverid");

				entity.Property(e => e.Category).HasColumnName("category");

				entity.Property(e => e.Drivername)
					.HasColumnName("drivername")
					.HasMaxLength(100);

				entity.Property(e => e.Mobile)
					.HasColumnName("mobile")
					.HasMaxLength(10);

				entity.Property(e => e.Type).HasColumnName("type");
			});

			modelBuilder.Entity<Driversattendance>(entity =>
			{
				entity.HasKey(e => e.Attid);

				entity.ToTable("Driversattendance", "db_owner");

				entity.Property(e => e.Attid).HasColumnName("attid");

				entity.Property(e => e.Attdate)
					.HasColumnName("attdate")
					.HasColumnType("date");

				entity.Property(e => e.Attdatetime)
					.HasColumnName("attdatetime")
					.HasColumnType("datetime");

				entity.Property(e => e.Atttime).HasColumnName("atttime");

				entity.Property(e => e.Groupid).HasColumnName("groupid");
			});

			modelBuilder.Entity<Durations>(entity =>
			{
				entity.HasKey(e => e.Durid);

				entity.ToTable("Durations", "dbo");

				entity.Property(e => e.Code).HasColumnName("code");

				entity.Property(e => e.Count).HasColumnName("count");

				entity.Property(e => e.Duration).HasMaxLength(50);
			});

			modelBuilder.Entity<Employees>(entity =>
			{
				entity.HasKey(e => e.Empid);

				entity.ToTable("Employees", "dbo");

				entity.Property(e => e.Empid).HasColumnName("empid");

				entity.Property(e => e.Empname)
					.HasColumnName("empname")
					.HasMaxLength(100);

				entity.Property(e => e.Sectionid).HasColumnName("sectionid");
			});

			modelBuilder.Entity<EmpsCategries>(entity =>
			{
				entity.HasKey(e => e.Catid);

				entity.ToTable("EmpsCategries", "db_owner");

				entity.Property(e => e.Catid).HasColumnName("catid");

				entity.Property(e => e.Catcode).HasColumnName("catcode");

				entity.Property(e => e.Catname)
					.HasColumnName("catname")
					.HasMaxLength(50);

				entity.Property(e => e.Money).HasColumnName("money");
			});

			modelBuilder.Entity<Groups>(entity =>
			{
				entity.HasKey(e => e.Groupid);

				entity.ToTable("Groups", "db_owner");

				entity.Property(e => e.Clolor).HasMaxLength(50);

				entity.Property(e => e.Groupname)
					.HasColumnName("groupname")
					.HasMaxLength(50);

				entity.Property(e => e.Mobile)
					.HasColumnName("mobile")
					.HasMaxLength(15);
			});

			modelBuilder.Entity<Help1>(entity =>
			{
				entity.HasKey(e => e.Helpid);

				entity.ToTable("Help1", "dbo");

				entity.Property(e => e.Helpid).HasColumnName("helpid");

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(50);

				entity.Property(e => e.Corp).HasColumnName("corp");

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(50);

				entity.Property(e => e.Familynumber).HasColumnName("familynumber");

				entity.Property(e => e.Food).HasColumnName("food");

				entity.Property(e => e.Idexpire)
					.HasColumnName("idexpire")
					.HasMaxLength(50);

				entity.Property(e => e.Income)
					.HasColumnName("income")
					.HasMaxLength(10);

				entity.Property(e => e.Incometype)
					.HasColumnName("incometype")
					.HasMaxLength(50);

				entity.Property(e => e.Livallaw)
					.HasColumnName("livallaw")
					.HasMaxLength(50);

				entity.Property(e => e.Livtype)
					.HasColumnName("livtype")
					.HasMaxLength(50);

				entity.Property(e => e.Mobile)
					.HasColumnName("mobile")
					.HasMaxLength(50);

				entity.Property(e => e.Money).HasColumnName("money");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(50);

				entity.Property(e => e.Nid)
					.HasColumnName("nid")
					.HasMaxLength(10);

				entity.Property(e => e.Notes)
					.HasColumnName("notes")
					.HasColumnType("ntext");

				entity.Property(e => e.Orderdate)
					.HasColumnName("orderdate")
					.HasColumnType("date");

				entity.Property(e => e.Place)
					.HasColumnName("place")
					.HasMaxLength(50);

				entity.Property(e => e.Registerme).HasColumnName("registerme");

				entity.Property(e => e.Rent)
					.HasColumnName("rent")
					.HasMaxLength(50);

				entity.Property(e => e.Statues)
					.HasColumnName("statues")
					.HasDefaultValueSql("((0))");
			});

			modelBuilder.Entity<Help2>(entity =>
			{
				entity.HasKey(e => e.Helpid);

				entity.ToTable("Help2", "dbo");

				entity.Property(e => e.Helpid).HasColumnName("helpid");

				entity.Property(e => e.Date)
					.HasColumnName("date")
					.HasColumnType("date");

				entity.Property(e => e.Helpnotes)
					.HasColumnName("helpnotes")
					.HasColumnType("ntext");

				entity.Property(e => e.Helptype)
					.HasColumnName("helptype")
					.HasMaxLength(100);

				entity.Property(e => e.Statues)
					.HasColumnName("statues")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.Things)
					.HasColumnName("things")
					.HasMaxLength(200);
			});

			modelBuilder.Entity<Items>(entity =>
			{
				entity.HasKey(e => e.Itemid);

				entity.ToTable("Items", "db_owner");

				entity.Property(e => e.Itemid).HasColumnName("itemid");

				entity.Property(e => e.Category).HasColumnName("category");

				entity.Property(e => e.Itemname)
					.HasColumnName("itemname")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Marks>(entity =>
			{
				entity.ToTable("Marks", "db_owner");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Date)
					.HasColumnName("date")
					.HasColumnType("datetime");

				entity.Property(e => e.Mark).HasColumnName("mark");
			});

			modelBuilder.Entity<Marquee>(entity =>
			{
				entity.ToTable("Marquee", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Active).HasColumnName("active");

				entity.Property(e => e.Details)
					.HasColumnName("details")
					.HasColumnType("ntext");

				entity.Property(e => e.Image)
					.HasColumnName("image")
					.HasMaxLength(50);

				entity.Property(e => e.Title)
					.HasColumnName("title")
					.HasMaxLength(100);
			});

			modelBuilder.Entity<Needy>(entity =>
			{
				entity.ToTable("needy", "db_owner");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Pername)
					.HasColumnName("pername")
					.HasMaxLength(100);

				entity.Property(e => e.Phone)
					.HasColumnName("phone")
					.HasMaxLength(10);

				entity.Property(e => e.Sendername)
					.HasColumnName("sendername")
					.HasMaxLength(50);

				entity.Property(e => e.Senderphone)
					.HasColumnName("senderphone")
					.HasMaxLength(10);

				entity.Property(e => e.Squer)
					.HasColumnName("squer")
					.HasMaxLength(100);

				entity.Property(e => e.Statues).HasColumnName("statues");
			});

			modelBuilder.Entity<Newsimages>(entity =>
			{
				entity.ToTable("Newsimages", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Imgpath)
					.HasColumnName("imgpath")
					.HasMaxLength(100);

				entity.Property(e => e.Newsid).HasColumnName("newsid");
			});

			modelBuilder.Entity<Newstable>(entity =>
			{
				entity.ToTable("Newstable", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Detail)
					.HasColumnName("detail")
					.HasColumnType("ntext");

				entity.Property(e => e.Expire)
					.HasColumnName("expire")
					.HasColumnType("date");

				entity.Property(e => e.Image)
					.HasColumnName("image")
					.HasMaxLength(100);

				entity.Property(e => e.Title)
					.HasColumnName("title")
					.HasColumnType("ntext");
			});

			modelBuilder.Entity<Offdayes>(entity =>
			{
				entity.ToTable("offdayes", "db_owner");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Frmdate)
					.HasColumnName("frmdate")
					.HasColumnType("date");

				entity.Property(e => e.Todate)
					.HasColumnName("todate")
					.HasColumnType("date");
			});

			modelBuilder.Entity<OrderEmps>(entity =>
			{
				entity.HasKey(e => e.Orderempid);

				entity.ToTable("OrderEmps", "db_owner");

				entity.Property(e => e.Orderempid).HasColumnName("orderempid");

				entity.Property(e => e.Empid).HasColumnName("empid");

				entity.Property(e => e.Orderid).HasColumnName("orderid");
			});

			modelBuilder.Entity<Places>(entity =>
			{
				entity.HasKey(e => e.Plceid);

				entity.ToTable("Places", "dbo");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Roles>(entity =>
			{
				entity.HasKey(e => e.RoleId);

				entity.ToTable("Roles", "dbo");

				entity.Property(e => e.RoleId).HasColumnName("RoleID");

				entity.Property(e => e.Rolename).HasMaxLength(50);
			});

			modelBuilder.Entity<Sacridetails>(entity =>
			{
				entity.ToTable("Sacridetails", "dbo");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Time).HasMaxLength(50);

				entity.Property(e => e.Timename)
					.HasColumnName("timename")
					.HasMaxLength(50);

				entity.Property(e => e.Type).HasMaxLength(50);

				entity.Property(e => e.Typename)
					.HasColumnName("typename")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Sacridetails60>(entity =>
			{
				entity.ToTable("Sacridetails60", "dbo");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Time).HasMaxLength(50);

				entity.Property(e => e.Timename)
					.HasColumnName("timename")
					.HasMaxLength(50);

				entity.Property(e => e.Type).HasMaxLength(50);

				entity.Property(e => e.Typename)
					.HasColumnName("typename")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Sacrifinames>(entity =>
			{
				entity.ToTable("Sacrifinames", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Booknumber).HasMaxLength(50);

				entity.Property(e => e.Date).HasColumnType("datetime");

				entity.Property(e => e.Gender)
					.HasColumnName("gender")
					.HasMaxLength(5);

				entity.Property(e => e.Mail)
					.HasColumnName("mail")
					.HasMaxLength(50);

				entity.Property(e => e.Mobile).HasMaxLength(20);

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(200);

				entity.Property(e => e.Paytype).HasColumnName("paytype");

				entity.Property(e => e.Place)
					.HasColumnName("place")
					.HasMaxLength(50);

				entity.Property(e => e.SacrifiNumber).HasColumnName("Sacrifi_number");

				entity.Property(e => e.Time).HasColumnName("time");
			});

			modelBuilder.Entity<Sacrifinames6000>(entity =>
			{
				entity.ToTable("Sacrifinames6000", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Booknumber).HasMaxLength(50);

				entity.Property(e => e.Date).HasColumnType("datetime");

				entity.Property(e => e.Gender)
					.HasColumnName("gender")
					.HasMaxLength(5);

				entity.Property(e => e.Mail)
					.HasColumnName("mail")
					.HasMaxLength(50);

				entity.Property(e => e.Mobile).HasMaxLength(20);

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(200);

				entity.Property(e => e.Place)
					.HasColumnName("place")
					.HasMaxLength(50);

				entity.Property(e => e.SacrifiNumber).HasColumnName("Sacrifi_number");

				entity.Property(e => e.Time).HasColumnName("time");
			});

			modelBuilder.Entity<Saidabout>(entity =>
			{
				entity.ToTable("Saidabout", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Sign)
					.HasColumnName("sign")
					.HasColumnType("ntext");

				entity.Property(e => e.Speech)
					.HasColumnName("speech")
					.HasColumnType("ntext");
			});

			modelBuilder.Entity<Saidattach>(entity =>
			{
				entity.HasKey(e => e.Saboutatt);

				entity.ToTable("saidattach", "dbo");

				entity.Property(e => e.Saboutatt).HasColumnName("saboutatt");

				entity.Property(e => e.Image)
					.HasColumnName("image")
					.HasMaxLength(100);

				entity.Property(e => e.Imagename)
					.HasColumnName("imagename")
					.HasMaxLength(50);

				entity.Property(e => e.Saidid).HasColumnName("saidid");
			});

			modelBuilder.Entity<Salaries>(entity =>
			{
				entity.HasKey(e => e.Salid);

				entity.ToTable("Salaries", "db_owner");

				entity.Property(e => e.Fromdate)
					.HasColumnName("fromdate")
					.HasColumnType("date");

				entity.Property(e => e.Todate).HasColumnType("date");
			});

			modelBuilder.Entity<Sections>(entity =>
			{
				entity.HasKey(e => e.Sectionid);

				entity.ToTable("Sections", "dbo");

				entity.Property(e => e.Sectionname)
					.HasColumnName("sectionname")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<SentNumbers>(entity =>
			{
				entity.ToTable("SentNumbers", "db_owner");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Date)
					.HasColumnName("date")
					.HasColumnType("date");

				entity.Property(e => e.Message)
					.HasColumnName("message")
					.HasColumnType("ntext");

				entity.Property(e => e.Number)
					.HasColumnName("number")
					.HasMaxLength(10);

				entity.Property(e => e.Type).HasColumnName("type");
			});

			modelBuilder.Entity<Shipments>(entity =>
			{
				entity.HasKey(e => e.Shipid);

				entity.ToTable("Shipments", "db_owner");

				entity.Property(e => e.Shipdate).HasColumnType("date");

				entity.Property(e => e.Shipmobile).HasMaxLength(50);

				entity.Property(e => e.Shipname).HasMaxLength(50);
			});

			modelBuilder.Entity<Slidertbl>(entity =>
			{
				entity.ToTable("Slidertbl", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Active).HasColumnName("active");

				entity.Property(e => e.Imagepath)
					.HasColumnName("imagepath")
					.HasMaxLength(100);

				entity.Property(e => e.Titile)
					.HasColumnName("titile")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Solts>(entity =>
			{
				entity.ToTable("Solts", "dbo");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Day).HasMaxLength(50);

				entity.Property(e => e.Number).HasColumnName("number");

				entity.Property(e => e.Price)
					.HasColumnName("price")
					.HasMaxLength(10);

				entity.Property(e => e.Soltname)
					.HasColumnName("soltname")
					.HasMaxLength(50);

				entity.Property(e => e.Time).HasMaxLength(50);
			});

			modelBuilder.Entity<Stratigyrates>(entity =>
			{
				entity.HasKey(e => e.Rateid);

				entity.ToTable("Stratigyrates", "dbo");

				entity.Property(e => e.Rateid).HasColumnName("rateid");

				entity.Property(e => e.Firstweek).HasColumnName("firstweek");

				entity.Property(e => e.Four).HasColumnName("four");

				entity.Property(e => e.Month).HasColumnName("month");

				entity.Property(e => e.Secondweek).HasColumnName("secondweek");

				entity.Property(e => e.Strategid).HasColumnName("strategid");

				entity.Property(e => e.Third).HasColumnName("third");

				entity.Property(e => e.Year).HasColumnName("year");
			});

			modelBuilder.Entity<Targets>(entity =>
			{
				entity.HasKey(e => e.Targitid);

				entity.ToTable("Targets", "dbo");

				entity.Property(e => e.Targitid).HasColumnName("targitid");

				entity.Property(e => e.Targetname)
					.HasColumnName("targetname")
					.HasColumnType("ntext");

				entity.Property(e => e.Targetsectionid).HasColumnName("targetsectionid");
			});

			modelBuilder.Entity<Tasks>(entity =>
			{
				entity.HasKey(e => e.Stratgyid);

				entity.ToTable("tasks", "dbo");

				entity.Property(e => e.Stratgyid).HasColumnName("stratgyid");

				entity.Property(e => e.Cost)
					.HasColumnName("cost")
					.HasMaxLength(50);

				entity.Property(e => e.Employees)
					.HasColumnName("employees")
					.HasColumnType("ntext");

				entity.Property(e => e.Empsvalue)
					.HasColumnName("empsvalue")
					.HasColumnType("ntext");

				entity.Property(e => e.Enddate)
					.HasColumnName("enddate")
					.HasMaxLength(50);

				entity.Property(e => e.Number).HasColumnName("number");

				entity.Property(e => e.Start)
					.HasColumnName("start")
					.HasMaxLength(50);

				entity.Property(e => e.Straname)
					.HasColumnName("straname")
					.HasColumnType("ntext");

				entity.Property(e => e.Supervalues)
					.HasColumnName("supervalues")
					.HasColumnType("ntext");

				entity.Property(e => e.Superviser)
					.HasColumnName("superviser")
					.HasColumnType("ntext");

				entity.Property(e => e.Targetid).HasColumnName("targetid");

				entity.Property(e => e.Unitid).HasColumnName("unitid");
			});

			modelBuilder.Entity<Unites>(entity =>
			{
				entity.HasKey(e => e.Unitid);

				entity.ToTable("Unites", "dbo");

				entity.Property(e => e.Sectionid).HasColumnName("sectionid");

				entity.Property(e => e.Unitname)
					.HasColumnName("unitname")
					.HasMaxLength(100);
			});

			modelBuilder.Entity<Users>(entity =>
			{
				entity.HasKey(e => e.UserId);

				entity.ToTable("Users", "dbo");

				entity.Property(e => e.UserId).HasColumnName("User_id");

				entity.Property(e => e.Password).HasMaxLength(50);

				entity.Property(e => e.Userfullname).HasMaxLength(50);

				entity.Property(e => e.Username).HasMaxLength(50);

				entity.Property(e => e.Userphone).HasMaxLength(50);
			});

			modelBuilder.Entity<Utilitiesprofile>(entity =>
			{
				entity.HasKey(e => e.Uprofileid);

				entity.ToTable("Utilitiesprofile", "dbo");

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(50);

				entity.Property(e => e.Rol).HasColumnName("rol");

				entity.Property(e => e.Uid).HasMaxLength(50);

				entity.Property(e => e.Upass).HasMaxLength(10);
			});

			modelBuilder.Entity<Volunteerapp>(entity =>
			{
				entity.HasKey(e => e.Appid);

				entity.ToTable("volunteerapp", "db_owner");

				entity.Property(e => e.Appid).HasColumnName("appid");

				entity.Property(e => e.Address)
					.HasColumnName("address")
					.HasMaxLength(100);

				entity.Property(e => e.Certifcates)
					.HasColumnName("certifcates")
					.HasColumnType("ntext");

				entity.Property(e => e.Date)
					.HasColumnName("date")
					.HasColumnType("date");

				entity.Property(e => e.Dayes)
					.HasColumnName("dayes")
					.HasMaxLength(200);

				entity.Property(e => e.Email)
					.HasColumnName("email")
					.HasMaxLength(50);

				entity.Property(e => e.Fields)
					.HasColumnName("fields")
					.HasColumnType("ntext");

				entity.Property(e => e.Houres)
					.HasColumnName("houres")
					.HasMaxLength(50);

				entity.Property(e => e.Mobile)
					.HasColumnName("mobile")
					.HasMaxLength(15);

				entity.Property(e => e.Name)
					.HasColumnName("name")
					.HasMaxLength(50);

				entity.Property(e => e.Natinality)
					.HasColumnName("natinality")
					.HasMaxLength(50);

				entity.Property(e => e.Nid)
					.HasColumnName("nid")
					.HasMaxLength(10);

				entity.Property(e => e.Skils)
					.HasColumnName("skils")
					.HasColumnType("ntext");

				entity.Property(e => e.Time)
					.HasColumnName("time")
					.HasMaxLength(5);

				entity.Property(e => e.Workallaw)
					.HasColumnName("workallaw")
					.HasMaxLength(10);
			});

			modelBuilder.Entity<Volunteerfields>(entity =>
			{
				entity.HasKey(e => e.Voluntid);

				entity.ToTable("Volunteerfields", "db_owner");

				entity.Property(e => e.Voluntid).HasColumnName("voluntid");

				entity.Property(e => e.Voluntname)
					.HasColumnName("voluntname")
					.HasMaxLength(100);
			});


			modelBuilder.Entity<Weekdayes>(entity =>
			{
				entity.HasKey(e => e.Name);
				entity.ToTable("Weekdayes", "db_owner");

				entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100);
				entity.Property(e => e.AName).HasColumnName("AName").HasMaxLength(100);
			});
		}
	}
}