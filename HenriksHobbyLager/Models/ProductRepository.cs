using HenriksHobbyLager.Interfaces;
using Microsoft.Data.Sqlite;
namespace HenriksHobbyLager.Models
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        //Metoder för att hantera CRUD-operationer
        public void Add(Product entity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                        INSERT INTO Lager (name, price, stock, category)
                        VALUES ($name, $price, $stock, $category)
                    ";
                command.Parameters.AddWithValue("$name", entity.Name);
                command.Parameters.AddWithValue("$price", entity.Price != 0 ? (object)entity.Price : DBNull.Value);
                command.Parameters.AddWithValue("$stock", entity.Stock ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("$category", entity.Category ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                        DELETE FROM Lager
                        WHERE id = $id
                    ";
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {


                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                        SELECT id, name, price, stock, category, dateCreated, dateUpdated
                        FROM Lager
                    ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetFloat(2),
                            Stock = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            Category = reader.IsDBNull(4) ? null : reader.GetString(4),
                            DateCreated = reader.GetDateTime(5).ToString("yyyy-MM-dd HH:mm:ss"),
                            DateUpdated = reader.GetDateTime(6).ToString("yyyy-MM-dd HH:mm:ss")
                        };
                    }
                }
            }
        }


        public Product GetById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                        SELECT id, name, price, stock, category, dateCreated, dateUpdated
                        FROM Lager
                        WHERE id = $id
                    ";
                command.Parameters.AddWithValue("$id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetFloat(2),
                            Stock = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            Category = reader.IsDBNull(4) ? null : reader.GetString(4),
                            DateCreated = reader.GetDateTime(5).ToString("yyyy-MM-dd HH:mm:ss"),
                            DateUpdated = reader.GetDateTime(6).ToString("yyyy-MM-dd HH:mm:ss")
                        };
                    }
                }
            }
            return null;
        }

        public IEnumerable<Product> Search(Func<Product, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public void Update(Product entity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                        UPDATE Lager
                        SET name = $name, price = $price, stock = $stock, category = $category
                        WHERE id = $id
                    ";
                command.Parameters.AddWithValue("$name", entity.Name);
                command.Parameters.AddWithValue("$price", entity.Price != 0 ? (object)entity.Price : DBNull.Value);
                command.Parameters.AddWithValue("$stock", entity.Stock ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("$category", entity.Category ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("$id", entity.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}