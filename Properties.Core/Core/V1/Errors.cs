using Microsoft.Extensions.Logging;
using Properties.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Core.Core.V1
{
    public class Errors<T>
    {
        private readonly ILogger _logger;

        public Errors(ILogger<T> logger)
        {
            _logger = logger;
        }
        public ResponseService<U> Error<U>(Exception ex, string serviceName, U content)
        {
            string innerException = string.IsNullOrEmpty(ex.InnerException.Message) ? string.Empty : ex.InnerException.Message;

            _logger.LogError(ex, $"Service: {serviceName}, Message: {ex.Message} {innerException})? ");
            return new ResponseService<U>(true, $"Exception: {ex.Message} Inner Exception: {ex.InnerException.Message}", System.Net.HttpStatusCode.InternalServerError, content);
        }

    }

}
