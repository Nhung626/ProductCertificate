using System.ComponentModel.DataAnnotations;

namespace HoangHongNhung152465.Dtos.Product

{
    public class CreateProductDto152465De2
    {
        public int ProductCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DVT { get; set; }
        [Required]
        public int SoLuong { get; set; }
    }   
}
