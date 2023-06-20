using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoangHongNhung152465.Dtos.Product
{
    public class ProductDto152465De2
    {
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        public string Name { get; set; }
        public string DVT { get; set; }
        public int SoLuong { get; set; }
    }
}
