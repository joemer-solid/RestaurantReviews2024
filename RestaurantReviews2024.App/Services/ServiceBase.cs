using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews2024.App.Services
{
    public abstract class ServiceBase
    {
        public ServiceBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected HttpClient HttpClient { get; }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(HttpRequestException ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.NotFound;
            if (ex != null && ex.StatusCode != null)
            {
                statusCode = (HttpStatusCode)ex.StatusCode;
            }

            if (statusCode.Equals(400))
            {
                return new ApiResponse<Guid>() { Message = "Validation errors have occured.", Success = false };
            }
            else if (statusCode.Equals(404))
            {
                return new ApiResponse<Guid>() { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new ApiResponse<Guid>() { Message = "Something went wrong, please try again.", Success = false };
            }
        }
    }
}
