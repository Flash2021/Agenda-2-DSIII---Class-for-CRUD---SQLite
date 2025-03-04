using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelper(string road)
        {
            _connection = new SQLiteAsyncConnection(road);
            _connection.CreateTableAsync<Produto>().Wait();
        }

        public Task Insert(Produto x) { 
        
        return _connection.InsertAsync(x);
        }

        public Task<List<Produto>> update(Produto x) {

            String SQL = "UPDATE Produto SET Descricao=?, Quantidade =?, Preco=? WHERE Id=?";

            return _connection.QueryAsync<Produto>(
                SQL, x.Descricao, x.Quantidade, x.Preco, x.Id
                
                );

        }

        public Task<int> Delete(int id) { 
        
       return _connection.Table<Produto>().DeleteAsync(i => i.Id ==id);

        }

        public Task<List<Produto>> GetAll() {

        return _connection.Table<Produto>().ToListAsync();
        
        }

        public Task<List<Produto>> Search(string s) {

            String SQL = "SELECT * Produto WHERE Descricao LIKE '%'" + s +"'%'";

            return _connection.QueryAsync<Produto>(SQL);
                
                
    
    }

    }
}
