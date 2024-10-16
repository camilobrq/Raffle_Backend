using Domain.Entities.Raflee;
using Domain.Ports.Repository;
using Infrastructura.Adapters;
using System.Data;
namespace Infrastructure.Adapters.Repository;

public class ProductRepository(IDbConnection dbConnection, IDbTransaction dbTransaction)
: ServiceRepository<Product>(dbConnection, dbTransaction), IProductRepository
{
}
