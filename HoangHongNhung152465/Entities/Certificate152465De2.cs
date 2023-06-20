using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HoangHongNhung152465.Entities
{
    [Table("Certificate")]
    public class Certificate152465De2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CertificateId { get; set; }
        [Required]
        public int CertificateCode { get; set; }

        public string Name { get; set; }
        [Required]
        public string DVC { get; set; }

    }
}
