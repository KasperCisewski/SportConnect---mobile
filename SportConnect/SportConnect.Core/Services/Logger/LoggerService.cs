using System;

namespace SportConnect.Core.Services.Logger
{
    public class LoggerService:ILoggerService
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string info, params object[] param)
        {
            throw new NotImplementedException();
        }

        public void LogError(Exception e, string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(Exception e, string message, params object[] param)
        {
            throw new NotImplementedException();
        }

        public void FlushAndReInit()
        {
            throw new NotImplementedException();
        }
    }
}
