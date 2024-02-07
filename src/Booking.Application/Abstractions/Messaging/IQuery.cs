using Booky.Domain.Abstractions;
using MediatR;

namespace Booky.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;