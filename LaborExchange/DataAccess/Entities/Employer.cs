using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Employer
    {
        /// <summary>
        /// Employer Id.
        /// </summary>
        [Key]
        [Index("IX_FieldIndex_Employer_Id", IsUnique = true)]
        public int Id { get; set; }

        /// <summary>
        /// Name of company employer.
        /// </summary>
        [Required]
        public string NameOFCompany { get; set; }

        /// <summary>
        /// First name of representative.
        /// </summary>
        [Required]
        public string FirstNameOfRepresentative { get; set; }

        /// <summary>
        /// Last name of representative.
        /// </summary>
        [Required]
        public string LastNameOfRepresentative { get; set; }

        /// <summary>
        /// Address of company.
        /// </summary>
        [Required]
        public string AddressOfCompany { get; set; }

        /// <summary>
        /// E-mail of representative.
        /// </summary>
        [Required]
        [Index("IX_FieldIndex_Employer_Email", IsUnique = true)]
        [MaxLength(450)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Phone of representative.
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Skype of representative.
        /// </summary>
        public string Skype { get; set; }

        /// <summary>
        /// Kind of activity of company.
        /// </summary>
        public string KindOfActivity { get; set; }

        /// <summary>
        /// Vacancies that are employer of created.
        /// </summary>
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
