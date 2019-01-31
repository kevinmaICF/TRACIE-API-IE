using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRACIEAPIIE.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: true),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IE_ascDirUser",
                columns: table => new
                {
                    DirUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    DirID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_ascDirUser", x => x.DirUserID);
                });

            migrationBuilder.CreateTable(
                name: "IE_ascDirUserAdmin",
                columns: table => new
                {
                    DirUserAdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    DirID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_ascDirUserAdmin", x => x.DirUserAdminID);
                });

            migrationBuilder.CreateTable(
                name: "IE_ascDirUserNotification",
                columns: table => new
                {
                    DirUserNotificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    DirID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_ascDirUserNotification", x => x.DirUserNotificationID);
                });

            migrationBuilder.CreateTable(
                name: "IE_ascDirUserUnsubscribe",
                columns: table => new
                {
                    DirUserUnsubscribeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    DirID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_ascDirUserUnsubscribe", x => x.DirUserUnsubscribeeID);
                });

            migrationBuilder.CreateTable(
                name: "IE_ascMBFilePost",
                columns: table => new
                {
                    FilePostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileIDNum = table.Column<int>(nullable: false),
                    PostID = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_ascMBFilePost", x => x.FilePostID);
                });

            migrationBuilder.CreateTable(
                name: "IE_ascThreadUserNotification",
                columns: table => new
                {
                    ThreadUserNotificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ThreadID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_ascThreadUserNotification", x => x.ThreadUserNotificationID);
                });

            migrationBuilder.CreateTable(
                name: "IE_ascThreadUserUnsubscribe",
                columns: table => new
                {
                    ThreadUserUnsubscribe = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ThreadID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_ascThreadUserUnsubscribe", x => x.ThreadUserUnsubscribe);
                });

            migrationBuilder.CreateTable(
                name: "IE_luEventType",
                columns: table => new
                {
                    EventTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTypeText = table.Column<string>(type: "varchar(50)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_luEventType", x => x.EventTypeID);
                });

            migrationBuilder.CreateTable(
                name: "IE_luMBType",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_luMBType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "IE_luNotificationTemplate",
                columns: table => new
                {
                    NotificationTemplateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TemplateText = table.Column<string>(type: "varchar(8000)", nullable: true),
                    TemplateSubject = table.Column<string>(nullable: true),
                    TemplateTitle = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_luNotificationTemplate", x => x.NotificationTemplateID);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblEvent",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTypeID = table.Column<int>(nullable: true),
                    EventTitle = table.Column<string>(nullable: true),
                    EventVar1 = table.Column<string>(nullable: true),
                    EventVar2 = table.Column<string>(nullable: true),
                    StatusID = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblEvent", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblLogEvent",
                columns: table => new
                {
                    EventRecID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTypeID = table.Column<int>(nullable: true),
                    EventDesc = table.Column<string>(nullable: true),
                    EventTitle = table.Column<string>(nullable: true),
                    DirID = table.Column<int>(nullable: true),
                    ThreadID = table.Column<int>(nullable: true),
                    FileID = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    ServerID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblLogEvent", x => x.EventRecID);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblMBDir",
                columns: table => new
                {
                    DirID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "varchar(300)", nullable: true),
                    TextShort = table.Column<string>(type: "varchar(300)", nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    TypeID = table.Column<int>(nullable: true),
                    StatusID = table.Column<int>(nullable: true),
                    Path = table.Column<string>(type: "varchar(100)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    Ord = table.Column<int>(nullable: true),
                    Description = table.Column<string>(type: "varchar(3500)", nullable: true),
                    DateLatest = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sticky = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblMBDir", x => x.DirID);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblMBFile",
                columns: table => new
                {
                    FileIDNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileID = table.Column<string>(type: "varchar(128)", nullable: true),
                    Text = table.Column<string>(type: "varchar(250)", nullable: true),
                    FileName = table.Column<string>(type: "varchar(250)", nullable: true),
                    FileSize = table.Column<int>(nullable: true),
                    FileMimeType = table.Column<string>(type: "varchar(100)", nullable: true),
                    FileTypeID = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    FileExtension = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblMBFile", x => x.FileIDNum);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblNotification",
                columns: table => new
                {
                    NotificationRecID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NotificationAddress = table.Column<string>(type: "varchar(500)", nullable: true),
                    NotificationMessage = table.Column<string>(type: "varchar(2000)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(nullable: true),
                    NotificationSubject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblNotification", x => x.NotificationRecID);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblNotificationQueue",
                columns: table => new
                {
                    NotificationQueueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NotificationTemplateID = table.Column<int>(nullable: true),
                    EventTypeID = table.Column<int>(nullable: true),
                    ThreadID = table.Column<int>(nullable: true),
                    DirID = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    StatusID = table.Column<int>(nullable: true),
                    DateSent = table.Column<DateTime>(type: "datetime", nullable: true),
                    ParentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblNotificationQueue", x => x.NotificationQueueID);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblPendingRejectedUser",
                columns: table => new
                {
                    PendRejID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblPendingRejectedUser", x => x.PendRejID);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblUserContactInformation",
                columns: table => new
                {
                    UserContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserFirstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserLastName = table.Column<string>(type: "varchar(50)", nullable: true),
                    UId = table.Column<string>(type: "varchar(128)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserPrefTitle = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserPhone1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserPhone1Ext = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserPhone2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserPhone2Ext = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserStreet1 = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserStreet2 = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserCity = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserState = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserZIP = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserOrg = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserTitle = table.Column<string>(type: "varchar(300)", nullable: true),
                    UserEmail1 = table.Column<string>(type: "varchar(255)", nullable: true),
                    UserEmail2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    UserDisciplineOrProfession = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Listerv = table.Column<bool>(nullable: true),
                    IEAccess = table.Column<bool>(nullable: true),
                    APIKey = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Email1Verified = table.Column<int>(nullable: true),
                    Email2Verified = table.Column<int>(nullable: true),
                    DateLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    NewsletterSubEmail1 = table.Column<bool>(nullable: true),
                    NewsletterSubEmail2 = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblUserContactInformation", x => x.UserContactID);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblUserContactInformationUnregistered",
                columns: table => new
                {
                    UserUnregisteredID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserFirstName = table.Column<string>(type: "varchar(150)", nullable: true),
                    UserLastName = table.Column<string>(type: "varchar(150)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserPrefTitle = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserPhone1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserPhone1Ext = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserPhone2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserPhone2Ext = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserStreet1 = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserStreet2 = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserCity = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserState = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserZIP = table.Column<string>(type: "varchar(10)", nullable: true),
                    UserOrg = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserTitle = table.Column<string>(type: "varchar(300)", nullable: true),
                    UserEmail1 = table.Column<string>(type: "varchar(255)", nullable: true),
                    UserEmail2 = table.Column<string>(type: "varchar(255)", nullable: true),
                    UserDisciplineOrProfession = table.Column<string>(type: "varchar(1000)", nullable: true),
                    NewsletterSubEmail1 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblUserContactInformationUnregistered", x => x.UserUnregisteredID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 450, nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 450, nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.UniqueConstraint("AK_AspNetUserTokens_LoginProvider_Name_UserId", x => new { x.LoginProvider, x.Name, x.UserId });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblMBThread",
                columns: table => new
                {
                    ThreadID = table.Column<int>(nullable: false),
                    DirID = table.Column<int>(nullable: true),
                    Text = table.Column<string>(type: "varchar(300)", nullable: true),
                    Title = table.Column<string>(type: "varchar(300)", nullable: true),
                    StatusID = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostCount = table.Column<int>(nullable: true),
                    FileCount = table.Column<int>(nullable: true),
                    TypeID = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    DateLatest = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "varchar(3500)", nullable: true),
                    Sticky = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblMBThread", x => x.ThreadID);
                    table.ForeignKey(
                        name: "FK_IE_tblMBThread_IE_tblMBDir_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "IE_tblMBDir",
                        principalColumn: "DirID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IE_ascThreadUser",
                columns: table => new
                {
                    ThreadUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ThreadID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_ascThreadUser", x => x.ThreadUserID);
                    table.ForeignKey(
                        name: "FK_IE_ascThreadUser_IE_tblMBThread_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "IE_tblMBThread",
                        principalColumn: "ThreadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IE_tblMBPost",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ThreadID = table.Column<int>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    Text = table.Column<string>(type: "varchar(350)", nullable: true),
                    Title = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    StatusID = table.Column<int>(nullable: true),
                    TypeID = table.Column<int>(nullable: true),
                    Ord = table.Column<int>(nullable: true),
                    DateLatest = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sticky = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IE_tblMBPost", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_IE_tblMBPost_IE_tblMBThread_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "IE_tblMBThread",
                        principalColumn: "ThreadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IE_ascThreadUser_ThreadID",
                table: "IE_ascThreadUser",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_IE_tblMBPost_ThreadID",
                table: "IE_tblMBPost",
                column: "ThreadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "IE_ascDirUser");

            migrationBuilder.DropTable(
                name: "IE_ascDirUserAdmin");

            migrationBuilder.DropTable(
                name: "IE_ascDirUserNotification");

            migrationBuilder.DropTable(
                name: "IE_ascDirUserUnsubscribe");

            migrationBuilder.DropTable(
                name: "IE_ascMBFilePost");

            migrationBuilder.DropTable(
                name: "IE_ascThreadUser");

            migrationBuilder.DropTable(
                name: "IE_ascThreadUserNotification");

            migrationBuilder.DropTable(
                name: "IE_ascThreadUserUnsubscribe");

            migrationBuilder.DropTable(
                name: "IE_luEventType");

            migrationBuilder.DropTable(
                name: "IE_luMBType");

            migrationBuilder.DropTable(
                name: "IE_luNotificationTemplate");

            migrationBuilder.DropTable(
                name: "IE_tblEvent");

            migrationBuilder.DropTable(
                name: "IE_tblLogEvent");

            migrationBuilder.DropTable(
                name: "IE_tblMBFile");

            migrationBuilder.DropTable(
                name: "IE_tblMBPost");

            migrationBuilder.DropTable(
                name: "IE_tblNotification");

            migrationBuilder.DropTable(
                name: "IE_tblNotificationQueue");

            migrationBuilder.DropTable(
                name: "IE_tblPendingRejectedUser");

            migrationBuilder.DropTable(
                name: "IE_tblUserContactInformation");

            migrationBuilder.DropTable(
                name: "IE_tblUserContactInformationUnregistered");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "IE_tblMBThread");

            migrationBuilder.DropTable(
                name: "IE_tblMBDir");
        }
    }
}
