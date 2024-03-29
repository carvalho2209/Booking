﻿using Booky.Domain.Abstractions;
using MediatR;

namespace Booky.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;