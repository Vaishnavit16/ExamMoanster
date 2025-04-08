using Infras.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Classes
{
    public class GenRepo<T> : IGeneric<T> where T : class
    {
        DbContext cc;
        public GenRepo(DbContext cc)
        {
            this.cc = cc;
        }

        public async Task Create(T rec)
        {
            await this.cc.Set<T>().AddAsync(rec);
            await this.cc.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var rec = await this.cc.Set<T>().FindAsync(id);
            this.cc.Set<T>().Remove(rec);
            this.cc.SaveChanges();
        }

        public async Task<T> Get(long id)
        {
            return await this.cc.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await this.cc.Set<T>().ToListAsync();
        }

        public async Task Update(T rec)
        {
            this.cc.Entry(rec).State = EntityState.Modified;
            await this.cc.SaveChangesAsync();
        }
    }
}
