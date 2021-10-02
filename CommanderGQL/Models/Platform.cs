using System.ComponentModel.DataAnnotations;

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
    }
}

