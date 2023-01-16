using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using Medii_Android.Models;


namespace Medii_Android.Data
{
    public class ProgramariDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProgramariDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programari>().Wait();
            _database.CreateTableAsync<Servicii>().Wait();
            _database.CreateTableAsync<ListService>().Wait();

        }
        public Task<List<Programari>> GetShopListsAsync()
        {
            return _database.Table<Programari>().ToListAsync();
        }
        public Task<Programari> GetShopListAsync(int id)
        {
            return _database.Table<Programari>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(Programari slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(Programari slist)
        {
            return _database.DeleteAsync(slist);
        }


        public Task<int> SaveProductAsync(Servicii serviciu)
        {
            if (serviciu.ID != 0)
            {
                return _database.UpdateAsync(serviciu);
            }
            else
            {
                return _database.InsertAsync(serviciu);
            }
        }
        public Task<int> DeleteProductAsync(Servicii serviciu)
        {
            return _database.DeleteAsync(serviciu);
        }
        public Task<List<Servicii>> GetProductsAsync()
        {
            return _database.Table<Servicii>().ToListAsync();
        }

        public Task<int> SaveListProductAsync(ListService listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Servicii>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Servicii>(
            "select S.ID, S.Description from Servicii S"
            + " inner join ListService LS"
            + " on S.ID = LS.ServiciuID where LS.ProgramariID = ?",
            shoplistid);
        }

        //
        

    }
}
