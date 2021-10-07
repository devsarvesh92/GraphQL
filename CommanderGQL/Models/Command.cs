using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{

    /// <summary>
    /// Command
    /// </summary>
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        /// <summary>
        /// HowTo
        /// </summary>
        /// <value></value>
        public string HowTo { get; set; }

        [Required]
        /// <summary>
        /// CommandLine
        /// </summary>
        /// <value></value>
        public string CommandLine { get; set; }

        [Required]
        /// <summary>
        /// PlatformId
        /// </summary>
        /// <value></value>
        public int PlatformId { get; set; }

        /// <summary>
        /// Platform
        /// </summary>
        /// <value></value>
        public Platform Platform { get; set; }

    }
}