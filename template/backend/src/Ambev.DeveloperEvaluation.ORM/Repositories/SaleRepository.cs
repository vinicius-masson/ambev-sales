using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Implementation of IProductRepository using Entity Framework Core
        /// </summary>
        public SaleRepository(DefaultContext context)
        {
            _context = context;   
        }

        /// <summary>
        /// Creates a new sale in the repository
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync();
            return sale;
        }

        /// <summary>
        /// Deletes a sale from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id);
            if (sale == null)
                return false;

            _context.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Retrieves all sales
        /// </summary>
        /// <param name="sale">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public IQueryable<Sale?> GetAll(CancellationToken cancellationToken = default)
        {
            return _context.Sales.Include(s => s.Products).AsQueryable();
        }

        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="productid">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Retrieves a sale by an product id
        /// </summary>
        /// <param name="productid">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetByProductIdAsync(Guid productid, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products
                .Include(p => p.Sale)
                .FirstOrDefaultAsync(p => p.Id == productid);

            return product?.Sale;
        }

        /// <summary>
        /// Updates a sale from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="sale">The entity sale that is modified</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The entity sale</returns>
        public async Task<Sale?> UpdateAsync(Sale sale, Guid id, CancellationToken cancellationToken = default)
        {
            _context.Update(sale);

            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }
    }
}
