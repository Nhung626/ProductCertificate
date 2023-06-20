using HoangHongNhung152465.DbContexts;
using HoangHongNhung152465.Dtos;
using HoangHongNhung152465.Dtos.Product;
using HoangHongNhung152465.Dtos.Certificate;
using HoangHongNhung152465.Entities;
using HoangHongNhung152465.Exceptions;
using HoangHongNhung152465.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace HoangHongNhung152465.Services.Implements
{
    public class ProductService152465De2 : IProductService152465De2
    {
        private readonly ApplicationDbContext152465De2 _context;
        public ProductService152465De2(ApplicationDbContext152465De2 context)
        {
            _context = context;
        }

        public void CreateProduct(CreateProductDto152465De2 input)
        {
            if (_context.Products.Any(nc => nc.Name.ToLower() == input.Name.ToLower()))
            {
                throw new UserFriendlyException152465De2($"Trùng tên hàng hoa:{input.Name}");
            }
            _context.Products.Add(new Product152465De2
            {
                ProductCode = input.ProductCode,
                Name = input.Name,
                DVT = input.DVT,
                SoLuong = input.SoLuong,
            });
            _context.SaveChanges();
        }

        public PageResult152465De2<ProductDto152465De2> GetAllProduct(int page, int pageSize, FilterDto filter)
        {
            //var query = _context.Products.AsQueryable();

            // Lọc gần đúng theo tên hoặc mã

            var query = _context.Products.Where(s => s.ProductId.ToString().Contains(filter.Keyword) || s.DVT.Contains(filter.Keyword))
                .Select(s => new ProductDto152465De2
                {
                    ProductCode = s.ProductCode,
                    Name = s.Name,
                    DVT = s.DVT,
                    SoLuong = s.SoLuong,
                });
            var totalItems = query.Count();

            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            var products = query.ToList();

            var result = new PageResult152465De2<ProductDto152465De2>
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                Items = products
            };
            return result;
        }

        public void UpdateProduct(UpdateProductDto152465De2 input)
        {
            var product = _context.Products.FirstOrDefault(s => s.ProductId == input.ProductId);
            if (product == null)
            {
                throw new UserFriendlyException152465De2($"Không tìm thấy cửa hàng có id = {input.ProductId}");
            }
            product.Name = input.Name;
            product.DVT = input.DVT;
            product.SoLuong = input.SoLuong;
            _context.SaveChanges();
        }

        public PageResult152465De2<CertificateDto152465De2> GetCertificate(int page, int pageSize, int productId)
        {
            var dateNow = DateTime.Now;
            //var maxPoint = _context.ProductCertificates.Where(s => s.ProductId == productId).Max(s => s.IntimacyLevel);
            var query = _context.ProductCertificates.Join(_context.Certificates, ss => ss.CertificateId, s => s.CertificateId,
                (productCretificate, certificate) => new
                {
                    productCretificate,
                    certificate
                })
                .OrderBy(s => s.productCretificate)
                .Where(s => s.productCretificate.ProductId == productId && s.productCretificate.DateOff < dateNow)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .Select(s => new CertificateDto152465De2
                {
                    CertificateCode = s.certificate.CertificateCode,
                    CertificateName = s.certificate.Name,
                    DateOff = s.productCretificate.DateOff
                });
            var certificateDtos = query.ToList();
            var totalItems = query.Count();
            var result = new PageResult152465De2<CertificateDto152465De2>
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                Items = certificateDtos
            };
            return result;
        }
    }
}
