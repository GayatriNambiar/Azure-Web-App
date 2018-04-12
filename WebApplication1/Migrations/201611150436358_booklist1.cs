namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booklist1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Minerva_BookList", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Minerva_BookList", "Photo");
        }
    }
}
