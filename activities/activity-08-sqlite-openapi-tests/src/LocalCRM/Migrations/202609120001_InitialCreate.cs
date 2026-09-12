using LocalCRM.Data; using Microsoft.EntityFrameworkCore.Infrastructure; using Microsoft.EntityFrameworkCore.Migrations;
namespace LocalCRM.Migrations;
[DbContext(typeof(CrmDbContext)), Migration("202609120001_InitialCreate")]
public sealed class InitialCreate : Migration
{
 protected override void Up(MigrationBuilder m)=>m.CreateTable(name:"Contacts",columns:t=>new{Id=t.Column<int>(type:"INTEGER",nullable:false).Annotation("Sqlite:Autoincrement",true),Name=t.Column<string>(type:"TEXT",maxLength:80,nullable:false),Email=t.Column<string>(type:"TEXT",maxLength:160,nullable:false),Stage=t.Column<string>(type:"TEXT",maxLength:20,nullable:false),CreatedAt=t.Column<DateTimeOffset>(type:"TEXT",nullable:false)},constraints:t=>t.PrimaryKey("PK_Contacts",x=>x.Id));
 protected override void Down(MigrationBuilder m)=>m.DropTable("Contacts");
}
