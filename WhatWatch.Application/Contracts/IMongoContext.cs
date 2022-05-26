using MongoDB.Driver;

namespace WhatWatch.Application.Contracts
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
