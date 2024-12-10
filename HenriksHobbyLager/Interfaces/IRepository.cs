﻿namespace HenriksHobbyLager.Interfaces
{
    using System;
    using System.Collections.Generic;


    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> Search(Func<T, bool> predicate);
    }
}