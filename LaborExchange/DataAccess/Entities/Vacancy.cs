using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Vacancy
    {
        /// <summary>
        /// Vacancy Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// List of requirements in vacancy.
        /// </summary>
        public string ListOfRequirements { get; set; }

        /// <summary>
        /// List of duties in vacancy.
        /// </summary>
        public string ListOfDuties { get; set; }

        /// <summary>
        /// List of duties in vacancy.
        /// </summary>
        public string ListOfConditions { get; set; }

        /// <summary>
        /// Tags that are applicant is appointed.
        /// </summary>
        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Applicants that are interested is vacancy.
        /// </summary>
        public ICollection<Applicant> Applicants { get; set; }

        /// <summary>
        /// Employer that created this vacancy.
        /// </summary>
        public ICollection<Employer> Employers { get; set; }
    }
}
