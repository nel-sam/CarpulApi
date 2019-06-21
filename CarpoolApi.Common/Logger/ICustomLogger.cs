using System.Collections.Generic;

namespace CarpoolApi.Common.Logger
{
    public interface ICustomLogger
    {
        void Info(Dictionary<string, object> data);
        void Warning(Dictionary<string, object> data);
        void Error(Dictionary<string, object> data);
        
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        
        void Info(string message, Dictionary<string, object> data);
        void Warning(string message, Dictionary<string, object> data);
        void Error(string message, Dictionary<string, object> data);
    }
}
