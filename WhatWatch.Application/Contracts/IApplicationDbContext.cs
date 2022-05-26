using MongoDB.Driver;

namespace WhatWatch.Application.Contracts;

public interface IApplicationDbContext
{
    IMongoDatabase DbContext { get; }
}

