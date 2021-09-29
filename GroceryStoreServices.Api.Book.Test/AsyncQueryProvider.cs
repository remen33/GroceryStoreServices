﻿using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Book.Test
{
    public class AsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        public readonly IQueryProvider _inner;
        public AsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner; 
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new AsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new AsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
        {
            var result = typeof(TResult).GetGenericArguments()[0];
            var executeResult = typeof(IQueryProvider).GetMethod(
                name: nameof(IQueryProvider.Execute),
                genericParameterCount: 1,
                types: new[] { typeof(Expression) }
                ).MakeGenericMethod(result)
                .Invoke(this, new[] { expression});
            return (TResult)typeof(Task).GetMethod(nameof(Task.FromResult))?
                 .MakeGenericMethod(result).Invoke(null, new[] { executeResult});
        }
    }
}
