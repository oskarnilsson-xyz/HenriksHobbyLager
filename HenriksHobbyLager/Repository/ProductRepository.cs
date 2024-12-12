using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using Microsoft.Data.Sqlite;
namespace HenriksHobbyLager.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //Initiera SQLite File Databas och skapa en trigger för att uppdatera dateUpdated
        //Denna kan inte användas av andra repos!!!
        public void InitDatabase(string connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS Lager (
                        id INTEGER NOT NULL UNIQUE,
                        name TEXT NOT NULL UNIQUE,
                        price NUMERIC NOT NULL DEFAULT 0,
                        stock INTEGER NOT NULL DEFAULT 0,
                        category TEXT NOT NULL DEFAULT 'misc',
                        dateCreated TEXT NOT NULL DEFAULT (DATE('now')),
                        dateUpdated TEXT NOT NULL DEFAULT (DATE('now')),
                        PRIMARY KEY(id AUTOINCREMENT)
                    );

                    CREATE TRIGGER IF NOT EXISTS update_dateUpdated
                    AFTER UPDATE ON Lager
                    FOR EACH ROW
                    WHEN OLD.name != NEW.name OR OLD.price != NEW.price OR OLD.stock != NEW.stock OR OLD.category != NEW.category
                    BEGIN
                        UPDATE Lager
                        SET dateUpdated = DATE('now')
                        WHERE id = OLD.id;
                    END;
                ";
                command.ExecuteNonQuery(); //TODO: Kolla date för att få klockslag också
            }


            if (File.Exists(new SqliteConnectionStringBuilder(connectionString).DataSource)) //Omvandra conectionsString till en path
            {
                Console.WriteLine("Databas hittad!");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Databas saknas och gick inte att skapa, kontakta admin.");
                Console.WriteLine("Tryck på en tangent för att avsluta...");
                Console.ReadKey();
                Environment.Exit(1);
            }

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
                command.Parameters.AddWithValue("$price", entity.Price != 0 ? entity.Price : DBNull.Value);
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
                            Stock = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                            Category = reader.IsDBNull(4) ? null : reader.GetString(4),
                            DateCreated = reader.GetDateTime(5).ToString("yyyy-MM-dd"),
                            DateUpdated = reader.GetDateTime(6).ToString("yyyy-MM-dd")
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
                            Stock = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                            Category = reader.IsDBNull(4) ? null : reader.GetString(4),
                            DateCreated = reader.GetDateTime(5).ToString("yyyy-MM-dd HH:mm:ss"),
                            DateUpdated = reader.GetDateTime(6).ToString("yyyy-MM-dd HH:mm:ss")
                        };
                    }
                    else
                    {
                        return null;
                    }
                }

            }
        }

        public IEnumerable<Product> Search(Func<Product, bool> predicate)  //kolla mer på hur detta funkar
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
                command.Parameters.AddWithValue("$price", entity.Price != 0 ? entity.Price : DBNull.Value);
                command.Parameters.AddWithValue("$stock", entity.Stock ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("$category", entity.Category ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("$id", entity.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}