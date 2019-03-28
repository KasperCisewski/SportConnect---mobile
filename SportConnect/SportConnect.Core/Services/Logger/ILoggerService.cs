using System;

namespace SportConnect.Core.Services.Logger
{
    public interface ILoggerService : IDisposable
    {
        void LogInfo(string info, params object[] param);
        void LogError(Exception e, string message);
        void LogError(Exception e, string message, params object[] param);
        void FlushAndReInit();
    }
}
