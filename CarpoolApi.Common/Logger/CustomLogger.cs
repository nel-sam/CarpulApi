using OpenTracing;
using System.Collections.Generic;
using System.Linq;

namespace CarpoolApi.Common.Logger
{
    public class CustomLogger : ICustomLogger
    {
        private readonly ITracer _tracer;

        public CustomLogger(ITracer tracer)
        {
            _tracer = tracer;
        }

        private void WriteLog(Dictionary<string, object> data, LogLevel level)
        {
            var additionalData = new Dictionary<string, object>
            {
                { "LogLevel", level }
            };

            _tracer.ActiveSpan.Log(data.Concat(additionalData));
        }

        public void Info(Dictionary<string, object> data) => WriteLog(data, LogLevel.Information);

        public void Warning(Dictionary<string, object> data) => WriteLog(data, LogLevel.Warning);

        public void Error(Dictionary<string, object> data) => WriteLog(data, LogLevel.Error);

        public void Info(string message) => Info(new Dictionary<string, object> { { "Message", message } });

        public void Warning(string message) => Warning(new Dictionary<string, object> { { "Message", message } });

        public void Error(string message) => Error(new Dictionary<string, object> { { "Message", message } });

        public void Info(string message, Dictionary<string, object> data)
        {
            data.Add("Message", message);
            Info(data);
        }

        public void Warning(string message, Dictionary<string, object> data)
        {
            data.Add("Message", message);
            Warning(data);
        }

        public void Error(string message, Dictionary<string, object> data)
        {
            data.Add("Message", message);
            Error(data);
        }
    }
}
