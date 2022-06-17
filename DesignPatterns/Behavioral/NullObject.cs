using System;

namespace DesignPatterns.Behavioral
{
    public interface ILog
    {
        // maximum # of elements in the log
        int RecordLimit { get; }

        // number of elements already in the log
        int RecordCount { get; set; }

        // expected to increment RecordCount
        void LogInfo(string message);
    }

    public class SomeAccount
    {
        private ILog log;

        public SomeAccount(ILog log)
        {
            this.log = log;
        }

        public void SomeOperation()
        {
            int c = log.RecordCount;
            log.LogInfo("Performing an operation");
            if (c + 1 != log.RecordCount)
                throw new Exception();
            if (log.RecordCount >= log.RecordLimit)
                throw new Exception();
        }
    }

    public class NullLog : ILog
    {
        public int RecordLimit { get; } = Int32.MaxValue;
        public int RecordCount { get; set; } = Int32.MinValue;
        public void LogInfo(string message)
        {
            ++RecordCount;
        }
    }
}
