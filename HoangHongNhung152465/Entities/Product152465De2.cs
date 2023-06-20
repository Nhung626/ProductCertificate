using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HoangHongNhung152465.Entities
{
    [Table("Product")]
    public class Product152465De2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ProductCode { get; set; }

        public string DVT { get; set; }
        public int SoLuong { get; set; }
    }
}
