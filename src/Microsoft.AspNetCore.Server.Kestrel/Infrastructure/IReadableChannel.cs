﻿using System.Runtime.CompilerServices;

namespace Microsoft.AspNetCore.Server.Kestrel.Infrastructure
{
    // TODO: Make this usable without the awaitable, split that into a struct
    public interface IReadableChannel : ICriticalNotifyCompletion
    {
        // Make it awaitable
        bool IsCompleted { get; }
        void GetResult();
        IReadableChannel GetAwaiter();

        bool Completed { get; }

        MemoryPoolSpan BeginRead();
        void EndRead(MemoryPoolIterator consumed, MemoryPoolIterator examined);

        void CompleteReading();
    }
}