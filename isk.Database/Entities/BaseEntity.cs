using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isk.Database.Entities
{
    public class BaseEntity : IId
    {
        /// <summary>
        /// Unique ID of this entity. Will be auto-filled in upon creation
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Auto filled in on creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Auto filled in on creation
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Auto filled in on modification
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Auto filled in on modification
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Auto filled in on deletion
        /// </summary>
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// Auto filled in on deletion
        /// </summary>
        public string DeletedBy { get; set; }
    }
}