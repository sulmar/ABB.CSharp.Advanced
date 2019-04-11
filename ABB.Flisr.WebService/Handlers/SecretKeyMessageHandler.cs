using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ABB.Flisr.WebService.Handlers
{
    public class SecretKeyMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            if (IsValidKey(request))
            {
                response = await base.SendAsync(request, cancellationToken);
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }

            return response;
        }

        private bool IsValidKey(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("Secret-Key", out IEnumerable<string> headers))
            {
                string secretKey = headers.First();

                return secretKey == "1234";
            }
            

            return false;
        }

    }
}