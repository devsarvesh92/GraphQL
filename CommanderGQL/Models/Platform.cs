using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Represents Platforms")]
    /// <summary>
    /// Platform
    /// </summary>
    public class Platform
    {

        /// <summary>
        /// Consturctot
        /// </summary>
        public Platform()
        {
            Commands = new List<Command>();
        }

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


        [GraphQLDescription("Valid License Key")]

        /// <summary>
        /// LicenseKey
        /// </summary>
        /// <value></value>
        public string LicenseKey { get; set; }

        /// <summary>
        /// Commands
        /// </summary>
        /// <value></value>
        public ICollection<Command> Commands { get; set; }
    }
}

