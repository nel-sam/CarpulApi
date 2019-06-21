using CarpoolApi.Common.Logger;
using System.Collections.Generic;

namespace UnitTests.Mocks
{
    public class MockLogger : ICustomLogger
    {
        public void Error(Dictionary<string, object> data)
        {
            // Do nothing since we don't need logs from tests
        }

        public void Error(string message)
        {
            // Do nothing since we don't need logs from tests
        }

        public void Error(string message, Dictionary<string, object> data)
        {
            // Do nothing since we don't need logs from tests
        }

        public void Info(Dictionary<string, object> data)
        {
            // Do nothing since we don't need logs from tests
        }

        public void Info(string message)
        {
            // Do nothing since we don't need logs from tests
        }

        public void Info(string message, Dictionary<string, object> data)
        {
            // Do nothing since we don't need logs from tests
        }

        public void Warning(Dictionary<string, object> data)
        {
            // Do nothing since we don't need logs from tests
        }

        public void Warning(string message)
        {
            // Do nothing since we don't need logs from tests
        }

        public void Warning(string message, Dictionary<string, object> data)
        {
            // Do nothing since we don't need logs from tests
        }
    }
}
