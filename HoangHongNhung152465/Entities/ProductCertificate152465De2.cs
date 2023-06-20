using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HoangHongNhung152465.Entities
{
    [Table("ProductCertificate")]

    public class ProductCertificate152465De2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        public int ProductId { get; set; }
        public int CertificateId { get; set; }
        public DateTime DateOff { get; set; }

    }
}
