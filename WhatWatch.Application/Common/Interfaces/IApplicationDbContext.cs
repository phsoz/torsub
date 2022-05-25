using MongoDB.Driver;

namespace WhatWatch.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    IMongoCollection<Movie> GetCollection<Movie>(string name);
}

