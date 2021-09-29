using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryStoreServices.Api.Book.Test
{
    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        public readonly IEnumerator<T> _enumerator;
        public T Current => _enumerator.Current;

        public AsyncEnumerator(IEnumerator<T> enumerator) => this._enumerator = enumerator ?? throw new ArgumentException();

        public async ValueTask DisposeAsync()
        {
            await Task.CompletedTask;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.FromResult(_enumerator.MoveNext());
        }
    }
}
