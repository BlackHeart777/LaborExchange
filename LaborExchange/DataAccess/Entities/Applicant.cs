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
    public class Applicant
    {
        /// <summary>
        /// Applicant id.
        /// </summary>
        [Key]
        [Index("IX_FieldIndex_Id", IsUnique = true)]
        public int Id { get; set; }

        /// <summary>
        /// Appliccant first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Appliccant second name.
        /// </summary>
        [Required]
        public string SecondName { get; set; }

        /// <summary>
        /// Appliccant birthday.
        /// </summary>
        [Required]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Appliccant address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Appliccant phone.
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Appliccant skype.
        /// </summary>
        public string Skype { get; set; }

        /// <summary>
        /// Appliccant e-mail.
        /// </summary>
        [Required]
        [Index("IX_FieldIndex_Email",IsUnique = true)]
        [MaxLength(450)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Additional information of applicant.
        /// </summary>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Experience Jobseekers.
        /// </summary>
        public string Experience { get; set; }

        /// <summary>
        /// Appliccant photo.
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Tags that are applicant is appointed.
        /// </summary>
        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Jobs that are of interest to the applicant.
        /// </summary>
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
