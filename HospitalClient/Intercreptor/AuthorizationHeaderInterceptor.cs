using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalClient.Intercreptor
{
    public class AuthorizationHeaderInterceptor : Interceptor
    {
        IHttpContextAccessor httpContextAccessor;
        public AuthorizationHeaderInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var claim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Token");
            if (claim != null)
            {
                string token = claim.Value;
                var headers = new Metadata();
                headers.Add("authorization", $"bearer {token}");
                var newOptions = context.Options.WithHeaders(headers);
                var newContext = new ClientInterceptorContext<TRequest, TResponse>(
              context.Method,
              context.Host,
              newOptions);
                return base.AsyncUnaryCall(request, newContext, continuation);
            }

            return base.AsyncUnaryCall(request, context, continuation);
        }
    }
}
