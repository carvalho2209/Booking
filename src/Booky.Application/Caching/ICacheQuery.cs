using Booky.Application.Abstractions.Messaging;

namespace Booky.Application.Caching;

public interface ICacheQuery<TResponse> : IQuery<TResponse>, ICacheQuery;

public interface ICacheQuery
{
    string CacheKey { get; }
    TimeSpan? Expiration { get; }
}