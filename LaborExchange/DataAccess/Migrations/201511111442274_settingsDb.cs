namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settingsDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Address = c.String(),
                        Phone = c.String(nullable: false),
                        Skype = c.String(),
                        Email = c.String(nullable: false, maxLength: 450),
                        AdditionalInformation = c.String(),
                        Experience = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true, name: "IX_FieldIndex_Applicant_Id")
                .Index(t => t.Email, unique: true, name: "IX_FieldIndex_Applicant_Email");
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 450),
                        Applicant_Id = c.Int(),
                        Vacancy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_Id)
                .Index(t => t.Id, unique: true, name: "IX_FieldIndex_Tag_Id")
                .Index(t => t.Name, unique: true, name: "IX_FieldIndex_Tag_Name")
                .Index(t => t.Applicant_Id)
                .Index(t => t.Vacancy_Id);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListOfRequirements = c.String(nullable: false),
                        ListOfDuties = c.String(nullable: false),
                        ListOfConditions = c.String(nullable: false),
                        Employer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.Employer_Id)
                .Index(t => t.Id, unique: true, name: "IX_FieldIndex_Vacancy_Id")
                .Index(t => t.Employer_Id);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOFCompany = c.String(nullable: false),
                        FirstNameOfRepresentative = c.String(nullable: false),
                        LastNameOfRepresentative = c.String(nullable: false),
                        AddressOfCompany = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 450),
                        Phone = c.String(nullable: false),
                        Skype = c.String(),
                        KindOfActivity = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true, name: "IX_FieldIndex_Employer_Id")
                .Index(t => t.Email, unique: true, name: "IX_FieldIndex_Employer_Email");
            
            CreateTable(
                "dbo.VacancyApplicants",
                c => new
                    {
                        Vacancy_Id = c.Int(nullable: false),
                        Applicant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vacancy_Id, t.Applicant_Id })
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id, cascadeDelete: true)
                .Index(t => t.Vacancy_Id)
                .Index(t => t.Applicant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.Tags", "Vacancy_Id", "dbo.Vacancies");
            DropForeignKey("dbo.VacancyApplicants", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.VacancyApplicants", "Vacancy_Id", "dbo.Vacancies");
            DropForeignKey("dbo.Tags", "Applicant_Id", "dbo.Applicants");
            DropIndex("dbo.VacancyApplicants", new[] { "Applicant_Id" });
            DropIndex("dbo.VacancyApplicants", new[] { "Vacancy_Id" });
            DropIndex("dbo.Employers", "IX_FieldIndex_Employer_Email");
            DropIndex("dbo.Employers", "IX_FieldIndex_Employer_Id");
            DropIndex("dbo.Vacancies", new[] { "Employer_Id" });
            DropIndex("dbo.Vacancies", "IX_FieldIndex_Vacancy_Id");
            DropIndex("dbo.Tags", new[] { "Vacancy_Id" });
            DropIndex("dbo.Tags", new[] { "Applicant_Id" });
            DropIndex("dbo.Tags", "IX_FieldIndex_Tag_Name");
            DropIndex("dbo.Tags", "IX_FieldIndex_Tag_Id");
            DropIndex("dbo.Applicants", "IX_FieldIndex_Applicant_Email");
            DropIndex("dbo.Applicants", "IX_FieldIndex_Applicant_Id");
            DropTable("dbo.VacancyApplicants");
            DropTable("dbo.Employers");
            DropTable("dbo.Vacancies");
            DropTable("dbo.Tags");
            DropTable("dbo.Applicants");
        }
    }
}
