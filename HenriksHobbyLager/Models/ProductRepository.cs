﻿using HenriksHobbyLager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
namespace HenriksHobbyLager.Models
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly string _connectionString = "Data Source=database/HenriksHobbyLager.db;Version=3;";  //Flytta ut denna

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(Func<Product, bool> predicate)
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
                        var product = new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetFloat(2),
                            Stock = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            Category = reader.IsDBNull(4) ? null : reader.GetString(4),
                            DateCreated = reader.GetDateTime(5).ToString("yyyy-MM-dd HH:mm:ss"),
                            DateUpdated = reader.GetDateTime(6).ToString("yyyy-MM-dd HH:mm:ss")
                        };
                        if (predicate(product))
                        {
                            yield return product;
                        }
                    }
                }
            }
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}