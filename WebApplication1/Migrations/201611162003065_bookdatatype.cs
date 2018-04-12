namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookdatatype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Minerva_BookList", "BookCover", c => c.Binary());
            DropColumn("dbo.Minerva_BookList", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Minerva_BookList", "Photo", c => c.Binary());
            DropColumn("dbo.Minerva_BookList", "BookCover");
        }
    }
}
