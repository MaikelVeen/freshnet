using System;

namespace Freshnet.Diagnostics
{
    public interface ILogger
    {
        void Info(string message);

        void Info(string message, params object[] args);

        void Debug(string message);

        void Debug(string message, params object[] args);

        void Error(Exception ex);

        void Error(string message, params object[] args);

        void Error(Exception ex, string message, params object[] args);
    }
}