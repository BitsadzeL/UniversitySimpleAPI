using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University.Models.Entities
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public float Salary {  get; set; }
    }
}
