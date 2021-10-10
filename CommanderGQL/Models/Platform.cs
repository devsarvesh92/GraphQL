using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace CommanderGQL.Models
{

    /// <summary>
    /// Platform
    /// </summary>
    public class Platform
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <value></value>
        [Key]
        public int Id { get; set; }


        [GraphQLDescription("Name of Platform")]
        /// <summary>
        /// Name
        /// </summary>
        /// <value></value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// LicenseKey
        /// </summary>
        /// <value></value>
        public string LicenseKey { get; set; }

        /// <summary>
        /// Commands
        /// </summary>
        /// <value></value>
        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}

