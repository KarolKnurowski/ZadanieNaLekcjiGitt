using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZadanieNaLekcjiGit.tabele;

namespace ZadanieNaLekcjiGit
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection _database;
        public DataBase(string db)
        {
            _database = new SQLiteAsyncConnection(db);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Score>().Wait();
            _database.CreateTableAsync<Subject>().Wait();
        }

        public Task<int> DodajUsera(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<User>> WezUsera()
        {
            return _database.QueryAsync<User>("SELECT * FROM User");
        }

    }
}
