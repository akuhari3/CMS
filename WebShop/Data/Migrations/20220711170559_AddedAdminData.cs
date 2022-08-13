using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;
using WebShop.Models;

#nullable disable

namespace WebShop.Data.Migrations
{
    public partial class AddedAdminData : Migration
    {
        const string _superAdminUserGuid = "7b47dc87-1825-490f-a189-a1454fd9c330";
        const string _superAdminRoleGuid = "c8234246-b0c3-441c-89bf-01be30f67ad6";

        const string _adminUserGuid = "4d408004-b790-4430-8597-3eaae25def26";
        const string _adminRoleGuid = "1e5b4c50-000d-4cb6-87c9-ac222c5debb9";

        const string _operaterUserGuid = "0d420177-4e37-498b-ae47-40aba321bf4e";
        const string _operaterRoleGuid = "bf6ec1ae-4b25-486d-ae3f-14100fc5e6f9";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher1 = new PasswordHasher<ApplicationUser>();
            var hasher2 = new PasswordHasher<ApplicationUser>();
            var hasher3 = new PasswordHasher<ApplicationUser>();
            var passwordHashedSA = hasher1.HashPassword(null, "Superadmin12345");
            var passwordHashedA = hasher2.HashPassword(null, "Admin12345");
            var passwordHashedO = hasher3.HashPassword(null, "Operater12345");

            StringBuilder sbsa = new StringBuilder();
            sbsa.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, NormalizedEmail, PasswordHash, SecurityStamp, FirstName, LastName, TimeZone, Active, Avatar)");
            sbsa.AppendLine("VALUES(");
            sbsa.AppendLine($"'{_superAdminUserGuid}'");
            sbsa.AppendLine(", 'superadmin@admin.com'");
            sbsa.AppendLine(", 'SUPERADMIN@ADMIN.COM'");
            sbsa.AppendLine(", 'superadmin@admin.com'");
            sbsa.AppendLine(", 0");
            sbsa.AppendLine(", 0");
            sbsa.AppendLine(", 0");
            sbsa.AppendLine(", 0");
            sbsa.AppendLine(", 0");
            sbsa.AppendLine(", 'SUPERADMIN@ADMIN.COM'");
            sbsa.AppendLine($", '{passwordHashedSA}'");
            sbsa.AppendLine(", ''");
            sbsa.AppendLine(", 'SuperAdmin'");
            sbsa.AppendLine(", 'SuperAdmin'");
            sbsa.AppendLine(", 1");
            sbsa.AppendLine(", 1");
            sbsa.AppendLine(", null");
            sbsa.AppendLine(")");

            // insert korisnika
            migrationBuilder.Sql(sbsa.ToString());
            // insert rola
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES('{_superAdminRoleGuid}', 'SuperAdmin', 'SUPERADMIN')");
            // insert rola za korisnika
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ('{_superAdminUserGuid}', '{_superAdminRoleGuid}')");

            StringBuilder sba = new StringBuilder();
            sba.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, NormalizedEmail, PasswordHash, SecurityStamp, FirstName, LastName, TimeZone, Active, Avatar)");
            sba.AppendLine("VALUES(");
            sba.AppendLine($"'{_adminUserGuid}'");
            sba.AppendLine(", 'admin@admin.com'");
            sba.AppendLine(", 'ADMIN@ADMIN.COM'");
            sba.AppendLine(", 'admin@admin.com'");
            sba.AppendLine(", 0");
            sba.AppendLine(", 0");
            sba.AppendLine(", 0");
            sba.AppendLine(", 0");
            sba.AppendLine(", 0");
            sba.AppendLine(", 'ADMIN@ADMIN.COM'");
            sba.AppendLine($", '{passwordHashedA}'");
            sba.AppendLine(", ''");
            sba.AppendLine(", 'Admin'");
            sba.AppendLine(", 'Admin'");
            sba.AppendLine(", 1");
            sba.AppendLine(", 1");
            sba.AppendLine(", null");
            sba.AppendLine(")");

            // insert korisnika
            migrationBuilder.Sql(sba.ToString());
            // insert rola
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES('{_adminRoleGuid}', 'Admin', 'ADMIN')");
            // insert rola za korisnika
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ('{_adminUserGuid}', '{_adminRoleGuid}')");

            StringBuilder sbo = new StringBuilder();
            sbo.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, NormalizedEmail, PasswordHash, SecurityStamp, FirstName, LastName, TimeZone, Active, Avatar)");
            sbo.AppendLine("VALUES(");
            sbo.AppendLine($"'{_operaterUserGuid}'");
            sbo.AppendLine(", 'operater@admin.com'");
            sbo.AppendLine(", 'OPERATER@ADMIN.COM'");
            sbo.AppendLine(", 'operater@admin.com'");
            sbo.AppendLine(", 0");
            sbo.AppendLine(", 0");
            sbo.AppendLine(", 0");
            sbo.AppendLine(", 0");
            sbo.AppendLine(", 0");
            sbo.AppendLine(", 'OPERATER@ADMIN.COM'");
            sbo.AppendLine($", '{passwordHashedO}'");
            sbo.AppendLine(", ''");
            sbo.AppendLine(", 'Operater'");
            sbo.AppendLine(", 'Operater'");
            sbo.AppendLine(", 1");
            sbo.AppendLine(", 1");
            sbo.AppendLine(", null");
            sbo.AppendLine(")");

            // insert korisnika
            migrationBuilder.Sql(sbo.ToString());
            // insert rola
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES('{_operaterRoleGuid}', 'Operater', 'OPERATER')");
            // insert rola za korisnika
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ('{_operaterUserGuid}', '{_operaterRoleGuid}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{_superAdminUserGuid}' AND RoleId = '{_superAdminRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id='{_superAdminRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id='{_superAdminUserGuid}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{_adminUserGuid}' AND RoleId = '{_adminRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id='{_adminRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id='{_adminUserGuid}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{_operaterUserGuid}' AND RoleId = '{_operaterRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id='{_operaterRoleGuid}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id='{_operaterUserGuid}'");
        }
    }
}
