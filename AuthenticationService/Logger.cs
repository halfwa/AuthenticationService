﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AuthenticationService
{
    public class Logger : ILogger
    {
        private readonly ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();

        private string logDirectory { get; set; }

        public Logger()
        {
            logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";
            Directory.CreateDirectory(logDirectory);
        }

        public void WriteEvent(string eventMessage)
        {
            lock_.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter(logDirectory + "events.txt", append: true))
                {
                    writer.WriteLine(eventMessage);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }

        }

        public void WriteError(string errorMessage)
        {
            lock_.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter(logDirectory + "errors.txt", append: true))
                {
                    writer.WriteLine(errorMessage);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }

        }
    }

    public interface ILogger
    {
        void WriteEvent(string eventMessage);
        void WriteError(string errorMessage);
    }
}
