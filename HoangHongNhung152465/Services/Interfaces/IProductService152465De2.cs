using HoangHongNhung152465.Dtos.Product;
using HoangHongNhung152465.Dtos;
using HoangHongNhung152465.Dtos.Certificate;

namespace HoangHongNhung152465.Services.Interfaces
{
    public interface IProductService152465De2
    {
        void CreateProduct(CreateProductDto152465De2 input);
        PageResult152465De2<ProductDto152465De2> GetAllProduct(int page, int pageSize, FilterDto filter);
        void UpdateProduct(UpdateProductDto152465De2 input);
        PageResult152465De2<CertificateDto152465De2> GetCertificate(int page, int pageSize, int storeId);
    }
}
