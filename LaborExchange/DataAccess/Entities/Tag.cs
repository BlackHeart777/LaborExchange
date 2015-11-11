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
    /// <summary>
    /// Tag is a skill employer.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Tag Id.
        /// </summary>
        [Key]
        [Index("IX_FieldIndex_Tag_Id", IsUnique = true)]
        public int Id { get; set; }

        /// <summary>
        /// Tage name.
        /// </summary>
        [Required]
        [Index("IX_FieldIndex_Tag_Name", IsUnique = true)]
        public string Name { get; set; }
    }
}
