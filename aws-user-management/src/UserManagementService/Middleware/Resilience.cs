using Polly;
using System;
using System.Net.Http;

namespace Middleware.Resilience
{
    class CircuitBreakerPolicyMaker
    {
        static IAsyncPolicy GetCircuitBreakerPolicy()
        {
            return Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }
    }
}