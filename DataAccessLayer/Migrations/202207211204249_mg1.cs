namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contents", name: "Writer_WriterID", newName: "WriterId");
            RenameIndex(table: "dbo.Contents", name: "IX_Writer_WriterID", newName: "IX_WriterId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Contents", name: "IX_WriterId", newName: "IX_Writer_WriterID");
            RenameColumn(table: "dbo.Contents", name: "WriterId", newName: "Writer_WriterID");
        }
    }
}
