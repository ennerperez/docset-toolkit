using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toolkit.Models
{
    [Table("searchIndex")]
    public class Index
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [NotMapped]
        public long ParentId { get; set; }

        public override string ToString()
        {
            return Name ?? base.ToString();
        }
    }
}