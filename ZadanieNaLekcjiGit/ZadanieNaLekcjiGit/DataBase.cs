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
       
        public Task<List<User>> WezUseraFiltr(string login, string password)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Login=? AND Password=?", login, password);
        }
        public async Task<bool> CzyLoginJuzIstnieje(string login)
        {
            var existingUser = await _database.Table<User>().FirstOrDefaultAsync(u => u.Login == login);
            return existingUser != null;
        }

        public async Task<int> StworzUzytkownika(User user)
        {
            if (await CzyLoginJuzIstnieje(user.Login))
            {
               
                return -1;
            }

            return await _database.InsertAsync(user);
        }
        public async Task<User> ZalogujUzytkownika(string login, string haslo)
        {
            return await _database.Table<User>().FirstOrDefaultAsync(u => u.Login == login && u.Password == haslo);
        }

        public Task<List<User>> WezUsera()
        {
            return _database.QueryAsync<User>("SELECT * FROM User");
        }
        public Task<List<Subject>> WezOcenyy()
        {
            return _database.QueryAsync<Subject>("SELECT * FROM Subject");
        }

        public Task<List<Score>> WezOceny()
        {
            return _database.QueryAsync<Score>("SELECT * FROM Score");
        }

        public Task<int> InsertSubject(Subject subject)
        {
            return _database.InsertAsync(subject);
        }

        public Task<int> InsertScore(Score score)
        {
            return _database.InsertAsync(score);
        }

        public Task<List<Score>> WezOceny(int user_id, int subject_id, string period)
        {
            return _database.QueryAsync<Score>("SELECT * FROM Score WHERE User_id=? AND Subject_id=? AND Period=?", user_id, subject_id, period);
        }
        public Task<Subject> WezOcenyyBySubjectName(string subjectName)
        {
            return _database.Table<Subject>().FirstOrDefaultAsync(s => s.Name == subjectName);
        }

    }
}
