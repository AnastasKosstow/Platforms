using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Mediator.Abstractions;

namespace PlatformService.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<Type, Type> _handlerDetails;

        public Mediator(IServiceProvider serviceProvider, IDictionary<Type, Type> handlerDetails)
        {
            _serviceProvider = serviceProvider;
            _handlerDetails = handlerDetails;
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
        {
            var requestType = request.GetType();
            if (!_handlerDetails.ContainsKey(requestType))
            {
                throw new Exception($"No handler to handle request of type: {requestType.Name}");
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                _handlerDetails.TryGetValue(requestType, out var requestHandlerType);

                var handler = scope.ServiceProvider.GetRequiredService(requestHandlerType);

                return await
                    (Task<TResponse>)handler
                    .GetType()
                    .GetMethod("HandleAsync")
                    .Invoke(handler, new[] { request });
            }  
        }
    }
}
