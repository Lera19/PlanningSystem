using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace AutoRejectionTask.ErrorHandler
{
    public class CustomErrorHandler : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            if (error is WebFaultException)
            {
                var code = ((WebFaultException)error).StatusCode;

                if (code == HttpStatusCode.BadRequest || code == HttpStatusCode.NotFound)
                {
                    status = code;
                }
            }

            fault = Message.CreateMessage(version, string.Empty, error.Message,
                                            new DataContractJsonSerializer(typeof(string)));
            fault.Properties.Add(
                HttpResponseMessageProperty.Name,
                new HttpResponseMessageProperty
                {
                    StatusCode = status
                }
            );
        }

        public bool HandleError(Exception error)
        {
            return true;
        }
    }
}