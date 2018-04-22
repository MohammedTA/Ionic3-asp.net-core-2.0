using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Khairia.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "db_owner");

            migrationBuilder.CreateTable(
                name: "banner",
                schema: "db_owner",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    path = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "db_owner",
                columns: table => new
                {
                    catid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoryname = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.catid);
                });

            migrationBuilder.CreateTable(
                name: "Directdistirb",
                schema: "db_owner",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ammount = table.Column<int>(nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    nid = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directdistirb", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                schema: "db_owner",
                columns: table => new
                {
                    driverid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    category = table.Column<int>(nullable: true),
                    drivername = table.Column<string>(maxLength: 100, nullable: true),
                    Groupid = table.Column<int>(nullable: true),
                    mobile = table.Column<string>(maxLength: 10, nullable: true),
                    type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.driverid);
                });

            migrationBuilder.CreateTable(
                name: "Driversattendance",
                schema: "db_owner",
                columns: table => new
                {
                    attid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    attdate = table.Column<DateTime>(type: "date", nullable: true),
                    attdatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    atttime = table.Column<TimeSpan>(nullable: true),
                    groupid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driversattendance", x => x.attid);
                });

            migrationBuilder.CreateTable(
                name: "EmpsCategries",
                schema: "db_owner",
                columns: table => new
                {
                    catid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    catcode = table.Column<int>(nullable: true),
                    catname = table.Column<string>(maxLength: 50, nullable: true),
                    money = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpsCategries", x => x.catid);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "db_owner",
                columns: table => new
                {
                    Groupid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clolor = table.Column<string>(maxLength: 50, nullable: true),
                    groupname = table.Column<string>(maxLength: 50, nullable: true),
                    mobile = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Groupid);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                schema: "db_owner",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    mark = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "needy",
                schema: "db_owner",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pername = table.Column<string>(maxLength: 100, nullable: true),
                    phone = table.Column<string>(maxLength: 10, nullable: true),
                    sendername = table.Column<string>(maxLength: 50, nullable: true),
                    senderphone = table.Column<string>(maxLength: 10, nullable: true),
                    squer = table.Column<string>(maxLength: 100, nullable: true),
                    statues = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_needy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "offdayes",
                schema: "db_owner",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    frmdate = table.Column<DateTime>(type: "date", nullable: true),
                    todate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offdayes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrderEmps",
                schema: "db_owner",
                columns: table => new
                {
                    orderempid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    empid = table.Column<short>(nullable: true),
                    orderid = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEmps", x => x.orderempid);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                schema: "db_owner",
                columns: table => new
                {
                    Salid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fromdate = table.Column<DateTime>(type: "date", nullable: true),
                    Satues = table.Column<int>(nullable: true),
                    Todate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Salid);
                });

            migrationBuilder.CreateTable(
                name: "SentNumbers",
                schema: "db_owner",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    message = table.Column<string>(type: "ntext", nullable: true),
                    number = table.Column<string>(maxLength: 10, nullable: true),
                    type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentNumbers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                schema: "db_owner",
                columns: table => new
                {
                    Shipid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Shipdate = table.Column<DateTime>(type: "date", nullable: true),
                    Shipmobile = table.Column<string>(maxLength: 50, nullable: true),
                    Shipname = table.Column<string>(maxLength: 50, nullable: true),
                    Shipnumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Shipid);
                });

            migrationBuilder.CreateTable(
                name: "volunteerapp",
                schema: "db_owner",
                columns: table => new
                {
                    appid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    certifcates = table.Column<string>(type: "ntext", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    dayes = table.Column<string>(maxLength: 200, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    fields = table.Column<string>(type: "ntext", nullable: true),
                    houres = table.Column<string>(maxLength: 50, nullable: true),
                    mobile = table.Column<string>(maxLength: 15, nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    natinality = table.Column<string>(maxLength: 50, nullable: true),
                    nid = table.Column<string>(maxLength: 10, nullable: true),
                    skils = table.Column<string>(type: "ntext", nullable: true),
                    time = table.Column<string>(maxLength: 5, nullable: true),
                    workallaw = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volunteerapp", x => x.appid);
                });

            migrationBuilder.CreateTable(
                name: "Volunteerfields",
                schema: "db_owner",
                columns: table => new
                {
                    voluntid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    voluntname = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteerfields", x => x.voluntid);
                });

            migrationBuilder.CreateTable(
                name: "Weekdayes",
                schema: "db_owner",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    AName = table.Column<string>(maxLength: 100, nullable: true),
                    State = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekdayes", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "archiveSacridetails",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Number = table.Column<long>(nullable: true),
                    Sacrid = table.Column<int>(nullable: true),
                    Soltid = table.Column<int>(nullable: true),
                    Time = table.Column<string>(maxLength: 50, nullable: true),
                    timename = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    typename = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archiveSacridetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "archiveSacrifinames",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Booknumber = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    gender = table.Column<string>(maxLength: 5, nullable: true),
                    mail = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    name = table.Column<string>(maxLength: 200, nullable: true),
                    paytype = table.Column<int>(nullable: true),
                    place = table.Column<string>(maxLength: 50, nullable: true),
                    Sacrifi_number = table.Column<int>(nullable: true),
                    Statues = table.Column<int>(nullable: true),
                    time = table.Column<TimeSpan>(nullable: true),
                    year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archiveSacrifinames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AssetDuration",
                schema: "dbo",
                columns: table => new
                {
                    Assdurid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    durcode = table.Column<int>(nullable: true),
                    durcount = table.Column<int>(nullable: true),
                    durname = table.Column<string>(maxLength: 50, nullable: true),
                    stat = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDuration", x => x.Assdurid);
                });

            migrationBuilder.CreateTable(
                name: "Assetitems",
                schema: "dbo",
                columns: table => new
                {
                    Assetitemid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assetid = table.Column<short>(nullable: true),
                    assetname = table.Column<string>(maxLength: 50, nullable: true),
                    assetnumber = table.Column<int>(nullable: true),
                    notes = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assetitems", x => x.Assetitemid);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                schema: "dbo",
                columns: table => new
                {
                    Assetid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    approveddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    approvuser = table.Column<short>(nullable: true),
                    Assetdetails = table.Column<short>(nullable: true),
                    Assettype = table.Column<int>(nullable: true),
                    canceldate = table.Column<DateTime>(type: "datetime", nullable: true),
                    canceluser = table.Column<short>(nullable: true),
                    Closed = table.Column<short>(nullable: true),
                    Closedate = table.Column<DateTime>(type: "date", nullable: true),
                    day = table.Column<DateTime>(type: "date", nullable: true),
                    driver = table.Column<short>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    hour = table.Column<int>(nullable: true),
                    lit = table.Column<string>(maxLength: 50, nullable: true),
                    @long = table.Column<string>(name: "long", maxLength: 50, nullable: true),
                    mobile = table.Column<string>(maxLength: 50, nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    Recorddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    square = table.Column<string>(maxLength: 50, nullable: true),
                    stat = table.Column<int>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Assetid);
                });

            migrationBuilder.CreateTable(
                name: "AssetsOrders",
                schema: "dbo",
                columns: table => new
                {
                    assetorderid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    approveddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    asset = table.Column<string>(maxLength: 50, nullable: true),
                    canceldate = table.Column<DateTime>(type: "datetime", nullable: true),
                    day = table.Column<DateTime>(type: "date", nullable: true),
                    driver = table.Column<short>(nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    Hallname = table.Column<string>(maxLength: 50, nullable: true),
                    hour = table.Column<string>(maxLength: 50, nullable: true),
                    lat = table.Column<string>(maxLength: 50, nullable: true),
                    @long = table.Column<string>(name: "long", maxLength: 50, nullable: true),
                    mobile = table.Column<string>(maxLength: 50, nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "ntext", nullable: true),
                    number = table.Column<int>(nullable: true),
                    phone = table.Column<string>(maxLength: 50, nullable: true),
                    Recoreddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    square = table.Column<string>(maxLength: 20, nullable: true),
                    stat = table.Column<int>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsOrders", x => x.assetorderid);
                });

            migrationBuilder.CreateTable(
                name: "Assetstypes",
                schema: "dbo",
                columns: table => new
                {
                    Assettype = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Assettypename = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assetstypes", x => x.Assettype);
                });

            migrationBuilder.CreateTable(
                name: "Availableslotes",
                schema: "dbo",
                columns: table => new
                {
                    Availableid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availablenumber = table.Column<int>(nullable: true),
                    slot = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availableslotes", x => x.Availableid);
                });

            migrationBuilder.CreateTable(
                name: "CatchBonds",
                schema: "dbo",
                columns: table => new
                {
                    Bondid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bonddate = table.Column<DateTime>(type: "date", nullable: true),
                    Sacrid = table.Column<int>(nullable: true),
                    Userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchBonds", x => x.Bondid);
                });

            migrationBuilder.CreateTable(
                name: "Distribution",
                schema: "dbo",
                columns: table => new
                {
                    reciveid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ammount = table.Column<int>(nullable: true),
                    details = table.Column<string>(type: "ntext", nullable: true),
                    Distrname = table.Column<string>(maxLength: 50, nullable: true),
                    Distrpoint = table.Column<string>(maxLength: 50, nullable: true),
                    number = table.Column<double>(nullable: true),
                    packsize = table.Column<string>(maxLength: 5, nullable: true),
                    sdsd = table.Column<string>(type: "nchar(10)", nullable: true),
                    sdsdf = table.Column<string>(type: "nchar(10)", nullable: true),
                    wewew = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribution", x => x.reciveid);
                });

            migrationBuilder.CreateTable(
                name: "donationsize",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ammont = table.Column<int>(nullable: true),
                    donatename = table.Column<string>(maxLength: 50, nullable: true),
                    ewewew = table.Column<string>(type: "nchar(10)", nullable: true),
                    werewrewr = table.Column<string>(type: "nchar(10)", nullable: true),
                    wewerwer = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donationsize", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Durations",
                schema: "dbo",
                columns: table => new
                {
                    Durid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<int>(nullable: true),
                    count = table.Column<int>(nullable: true),
                    Duration = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durations", x => x.Durid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "dbo",
                columns: table => new
                {
                    empid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    empname = table.Column<string>(maxLength: 100, nullable: true),
                    sectionid = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empid);
                });

            migrationBuilder.CreateTable(
                name: "Help1",
                schema: "dbo",
                columns: table => new
                {
                    helpid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    corp = table.Column<int>(nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    familynumber = table.Column<int>(nullable: true),
                    food = table.Column<int>(nullable: true),
                    idexpire = table.Column<string>(maxLength: 50, nullable: true),
                    income = table.Column<string>(maxLength: 10, nullable: true),
                    incometype = table.Column<string>(maxLength: 50, nullable: true),
                    livallaw = table.Column<string>(maxLength: 50, nullable: true),
                    livtype = table.Column<string>(maxLength: 50, nullable: true),
                    mobile = table.Column<string>(maxLength: 50, nullable: true),
                    money = table.Column<int>(nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    nid = table.Column<string>(maxLength: 10, nullable: true),
                    notes = table.Column<string>(type: "ntext", nullable: true),
                    orderdate = table.Column<DateTime>(type: "date", nullable: true),
                    place = table.Column<string>(maxLength: 50, nullable: true),
                    registerme = table.Column<int>(nullable: true),
                    rent = table.Column<string>(maxLength: 50, nullable: true),
                    statues = table.Column<int>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Help1", x => x.helpid);
                });

            migrationBuilder.CreateTable(
                name: "Help2",
                schema: "dbo",
                columns: table => new
                {
                    helpid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    helpnotes = table.Column<string>(type: "ntext", nullable: true),
                    helptype = table.Column<string>(maxLength: 100, nullable: true),
                    Recid = table.Column<int>(nullable: true),
                    statues = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    things = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Help2", x => x.helpid);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "dbo",
                columns: table => new
                {
                    itemid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    category = table.Column<short>(nullable: true),
                    itemname = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemid);
                });

            migrationBuilder.CreateTable(
                name: "Marquee",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    active = table.Column<int>(nullable: true),
                    details = table.Column<string>(type: "ntext", nullable: true),
                    image = table.Column<string>(maxLength: 50, nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marquee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Newsimages",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    imgpath = table.Column<string>(maxLength: 100, nullable: true),
                    newsid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsimages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Newstable",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<int>(nullable: true),
                    detail = table.Column<string>(type: "ntext", nullable: true),
                    expire = table.Column<DateTime>(type: "date", nullable: true),
                    image = table.Column<string>(maxLength: 100, nullable: true),
                    title = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newstable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                schema: "dbo",
                columns: table => new
                {
                    Plceid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Plceid);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rolename = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Sacridetails",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<long>(nullable: true),
                    Sacrid = table.Column<int>(nullable: true),
                    Soltid = table.Column<int>(nullable: true),
                    Time = table.Column<string>(maxLength: 50, nullable: true),
                    timename = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    typename = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacridetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sacridetails60",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<long>(nullable: true),
                    Sacrid = table.Column<int>(nullable: true),
                    Soltid = table.Column<int>(nullable: true),
                    Time = table.Column<string>(maxLength: 50, nullable: true),
                    timename = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    typename = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacridetails60", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sacrifinames",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Booknumber = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    gender = table.Column<string>(maxLength: 5, nullable: true),
                    mail = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    name = table.Column<string>(maxLength: 200, nullable: true),
                    paytype = table.Column<int>(nullable: true),
                    place = table.Column<string>(maxLength: 50, nullable: true),
                    Sacrifi_number = table.Column<int>(nullable: true),
                    Statues = table.Column<int>(nullable: true),
                    time = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacrifinames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sacrifinames6000",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Booknumber = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    gender = table.Column<string>(maxLength: 5, nullable: true),
                    mail = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    name = table.Column<string>(maxLength: 200, nullable: true),
                    place = table.Column<string>(maxLength: 50, nullable: true),
                    Sacrifi_number = table.Column<int>(nullable: true),
                    Statues = table.Column<int>(nullable: true),
                    time = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacrifinames6000", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Saidabout",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sign = table.Column<string>(type: "ntext", nullable: true),
                    speech = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saidabout", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "saidattach",
                schema: "dbo",
                columns: table => new
                {
                    saboutatt = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    image = table.Column<string>(maxLength: 100, nullable: true),
                    imagename = table.Column<string>(maxLength: 50, nullable: true),
                    saidid = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saidattach", x => x.saboutatt);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                schema: "dbo",
                columns: table => new
                {
                    Sectionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sectionname = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Sectionid);
                });

            migrationBuilder.CreateTable(
                name: "Slidertbl",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    active = table.Column<short>(nullable: true),
                    imagepath = table.Column<string>(maxLength: 100, nullable: true),
                    titile = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slidertbl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Solts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<string>(maxLength: 50, nullable: true),
                    number = table.Column<int>(nullable: true),
                    price = table.Column<string>(maxLength: 10, nullable: true),
                    soltname = table.Column<string>(maxLength: 50, nullable: true),
                    Time = table.Column<string>(maxLength: 50, nullable: true),
                    Total = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Stratigyrates",
                schema: "dbo",
                columns: table => new
                {
                    rateid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstweek = table.Column<int>(nullable: true),
                    four = table.Column<int>(nullable: true),
                    month = table.Column<int>(nullable: true),
                    secondweek = table.Column<int>(nullable: true),
                    strategid = table.Column<short>(nullable: true),
                    third = table.Column<int>(nullable: true),
                    year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stratigyrates", x => x.rateid);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                schema: "dbo",
                columns: table => new
                {
                    targitid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    targetname = table.Column<string>(type: "ntext", nullable: true),
                    targetsectionid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.targitid);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                schema: "dbo",
                columns: table => new
                {
                    stratgyid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cost = table.Column<string>(maxLength: 50, nullable: true),
                    employees = table.Column<string>(type: "ntext", nullable: true),
                    empsvalue = table.Column<string>(type: "ntext", nullable: true),
                    enddate = table.Column<string>(maxLength: 50, nullable: true),
                    number = table.Column<int>(nullable: true),
                    start = table.Column<string>(maxLength: 50, nullable: true),
                    straname = table.Column<string>(type: "ntext", nullable: true),
                    supervalues = table.Column<string>(type: "ntext", nullable: true),
                    superviser = table.Column<string>(type: "ntext", nullable: true),
                    targetid = table.Column<short>(nullable: true),
                    unitid = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.stratgyid);
                });

            migrationBuilder.CreateTable(
                name: "Unites",
                schema: "dbo",
                columns: table => new
                {
                    Unitid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sectionid = table.Column<short>(nullable: true),
                    unitname = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unites", x => x.Unitid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    Roleid = table.Column<int>(nullable: true),
                    Userfullname = table.Column<string>(maxLength: 50, nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Userphone = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Utilitiesprofile",
                schema: "dbo",
                columns: table => new
                {
                    Uprofileid = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    rol = table.Column<int>(nullable: true),
                    Uid = table.Column<string>(maxLength: 50, nullable: true),
                    Upass = table.Column<string>(maxLength: 10, nullable: true),
                    Urecid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilitiesprofile", x => x.Uprofileid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banner",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Directdistirb",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Drivers",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Driversattendance",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "EmpsCategries",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Marks",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "needy",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "offdayes",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "OrderEmps",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Salaries",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "SentNumbers",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Shipments",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "volunteerapp",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Volunteerfields",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "Weekdayes",
                schema: "db_owner");

            migrationBuilder.DropTable(
                name: "archiveSacridetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "archiveSacrifinames",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetDuration",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Assetitems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Assets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetsOrders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Assetstypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Availableslotes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CatchBonds",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Distribution",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "donationsize",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Durations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Help1",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Help2",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Marquee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Newsimages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Newstable",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Places",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sacridetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sacridetails60",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sacrifinames",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sacrifinames6000",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Saidabout",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "saidattach",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Slidertbl",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Solts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Stratigyrates",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Targets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tasks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Unites",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Utilitiesprofile",
                schema: "dbo");
        }
    }
}
