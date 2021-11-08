using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ejeciciodoscuatro.Models;
using System.Threading.Tasks;

namespace ejeciciodoscuatro.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<foto>().Wait();
        }

        public Task <int> SavedFotoAsync(foto fot)
        {
            if (fot.IdFoto==0)
            {
                return db.InsertAsync(fot);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Recupera todas las Fotos
        /// </summary>
        /// <returns>
        /// </returns>
        public Task<List<foto>> GetFotoAsync()
        {
            return db.Table<foto>().ToListAsync();
        }
        /// <summary>
        /// Recupera fotos por Id
        /// </summary>
        /// <param name="IdFoto">Id de la foto que se requiere</param>
        /// <returns></returns>
        public Task<foto> GetFotoByIdAsync(int IdFoto)
        {
            return db.Table<foto>().Where(a => a.IdFoto == IdFoto).FirstOrDefaultAsync();
        }
    }
}
