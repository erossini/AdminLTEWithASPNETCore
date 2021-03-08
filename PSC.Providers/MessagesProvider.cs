using PSC.Domain;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Providers
{
    public class MessagesProvider
    {
        private PSCContext _db;

        public MessagesProvider(PSCContext dbContext)
        {
            _db = dbContext;
        }

        public IEnumerable<Message> GetValues()
        {
            return _db.Messages;
        }

        public async Task<Message> GetAsync(long id)
        {
            return await _db.Messages.FindAsync(id);
        }

        public async Task<long> InsertAsync(Message value)
        {
            await _db.AddAsync(value);
            await _db.SaveChangesAsync();
            return value.IdMessage;
        }

        public async Task ReplaceAsync(int id, Message value)
        {
            _db.Update(value);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _db.Messages.FindAsync(id);
            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<long> DeleteMultipleAsync(long[] ids)
        {
            long c = 0;
            foreach (long id in ids)
            {
                c += await DeleteAsync(id) ? 1 : 0;
            }
            return c;
        }
    }
}
