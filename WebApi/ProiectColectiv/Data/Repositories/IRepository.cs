﻿using ProiectColectiv.Data;

namespace ProiectColectiv.Data.Repositories;

public interface IRepository<T, G> where T : EntityBase where G : class
{
    T GetById(int id);
    IEnumerable<T> GetAll(string userName);
    void Add(G entity);
    void Update(T entity);
    void Delete(int id);
}