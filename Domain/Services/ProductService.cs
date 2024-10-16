using Domain.Entities.Raflee;
using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.Ports;
using Notes.Domain.Services.Base;

namespace Domain.Services;
[DomainService]

public class ProductService(IUnitOfWork _unitOfWork)
{
    public async Task<bool> AddProduct(Product product)
    {
        try
        {
            var result = await _unitOfWork.ProductRepository.AddAsync(product);
            _unitOfWork.SaveChanges();
            return result;
        }
        catch (Exception e)
        {
            _unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<Product>> GetAllProductByIdUser(Product product)
    {
        try
        {
            var result = await _unitOfWork.ProductRepository.GetAllFilterAsync(product);
            _unitOfWork.SaveChanges();
            return result;
        }
        catch (Exception e)
        {
            _unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        try
        {
            var result = await _unitOfWork.ProductRepository.UpdateAsync(product);
            _unitOfWork.SaveChanges();
            return result;
        }
        catch (Exception e)
        {
            _unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeleteProductById(Guid id)
    {
        try
        {
            var result = await _unitOfWork.ProductRepository.DeleteAsync(id);
            _unitOfWork.SaveChanges();
            return result;
        }
        catch (Exception e)
        {
            _unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }

}
