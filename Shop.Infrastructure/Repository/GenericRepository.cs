using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices.Infrastructure;
using Shop.Domain.Entities;
using Shop.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly ShopDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ShopDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _db.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            //await _dbSet.Where(_=>_.Id == id).ExecuteDeleteAsync(cancellationToken);  

            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id)!;
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _db.SaveChangesAsync(cancellationToken);
            }
            
           

        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)!;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
           
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                var tt =await _db.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {

                    throw;
            }
            
            
        }
    }
}
