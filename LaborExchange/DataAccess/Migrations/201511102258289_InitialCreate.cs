namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        Skype = c.String(),
                        Email = c.String(),
                        AdditionalInformation = c.String(),
                        Experience = c.String(),
                        Photo = c.String(),
                        Vacancy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_Id)
                .Index(t => t.Vacancy_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Applicant_Id = c.Int(),
                        Vacancy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_Id)
                .Index(t => t.Applicant_Id)
                .Index(t => t.Vacancy_Id);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOFCompany = c.String(),
                        FirstNameOfRepresentative = c.String(),
                        LastNameOfRepresentative = c.String(),
                        AddressOfCompany = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Skype = c.String(),
                        KindOfActivity = c.String(),
                        Vacancy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_Id)
                .Index(t => t.Vacancy_Id);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListOfRequirements = c.String(),
                        ListOfDuties = c.String(),
                        ListOfConditions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Vacancy_Id", "dbo.Vacancies");
            DropForeignKey("dbo.Employers", "Vacancy_Id", "dbo.Vacancies");
            DropForeignKey("dbo.Applicants", "Vacancy_Id", "dbo.Vacancies");
            DropForeignKey("dbo.Tags", "Applicant_Id", "dbo.Applicants");
            DropIndex("dbo.Employers", new[] { "Vacancy_Id" });
            DropIndex("dbo.Tags", new[] { "Vacancy_Id" });
            DropIndex("dbo.Tags", new[] { "Applicant_Id" });
            DropIndex("dbo.Applicants", new[] { "Vacancy_Id" });
            DropTable("dbo.Vacancies");
            DropTable("dbo.Employers");
            DropTable("dbo.Tags");
            DropTable("dbo.Applicants");
        }
    }
}
