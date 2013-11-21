// Copyright 2013 CaptiveAire Systems
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using MassTransit.Logging;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace MassTransit.SeriLogIntegration
{
    public class SerilogLog : ILog
    {
        public const string ObjectLogTemplate = "{@obj}";
        private readonly ILogger _logger;

        public SerilogLog(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            _logger = logger;
        }

        public bool IsDebugEnabled
        {
            get { return _logger.IsEnabled(LogEventLevel.Debug); }
        }

        public bool IsErrorEnabled
        {
            get { return _logger.IsEnabled(LogEventLevel.Error); }
        }

        public bool IsFatalEnabled
        {
            get { return _logger.IsEnabled(LogEventLevel.Fatal); }
        }

        public bool IsInfoEnabled
        {
            get { return _logger.IsEnabled(LogEventLevel.Information); }
        }

        public bool IsWarnEnabled
        {
            get { return _logger.IsEnabled(LogEventLevel.Warning); }
        }

        public void Debug(object obj)
        {
            WriteSerilog(LogEventLevel.Debug, obj);
        }

        public void Debug(object obj, Exception exception)
        {
            WriteSerilog(LogEventLevel.Debug, exception, obj);
        }

        public void Debug(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Debug, messageProvider);
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Debug, format, args);
        }

        public void DebugFormat(string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Debug, format, args);
        }

        public void Error(object obj)
        {
            WriteSerilog(LogEventLevel.Error, obj);
        }

        public void Error(object obj, Exception exception)
        {
            WriteSerilog(LogEventLevel.Error, exception, obj);
        }

        public void Error(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Error, messageProvider);
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Error, format, args);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Error, format, args);
        }

        public void Fatal(object obj)
        {
            WriteSerilog(LogEventLevel.Fatal, obj);
        }

        public void Fatal(object obj, Exception exception)
        {
            WriteSerilog(LogEventLevel.Fatal, exception, obj);
        }

        public void Fatal(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Fatal, messageProvider);
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Fatal, format, args);
        }

        public void FatalFormat(string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Fatal, format, args);
        }

        public void Info(object obj)
        {
            WriteSerilog(LogEventLevel.Information, obj);
        }

        public void Info(object obj, Exception exception)
        {
            WriteSerilog(LogEventLevel.Information, exception, obj);
        }

        public void Info(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Information, messageProvider);
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Information, format, args);
        }

        public void InfoFormat(string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Information, format, args);
        }

        public void Log(LogLevel level, object obj)
        {
            WriteSerilog(GetSerilogLevel(level), obj);
        }

        public void Log(LogLevel level, object obj, Exception exception)
        {
            WriteSerilog(GetSerilogLevel(level), exception, obj);
        }

        public void Log(LogLevel level, LogOutputProvider messageProvider)
        {
            WriteSerilog(GetSerilogLevel(level), messageProvider);
        }

        public void LogFormat(LogLevel level,
            IFormatProvider formatProvider,
            string format,
            params object[] args)
        {
            WriteSerilog(GetSerilogLevel(level), format, args);
        }

        public void LogFormat(LogLevel level, string format, params object[] args)
        {
            WriteSerilog(GetSerilogLevel(level), format, args);
        }

        public void Warn(object obj)
        {
            WriteSerilog(LogEventLevel.Warning, obj);
        }

        public void Warn(object obj, Exception exception)
        {
            WriteSerilog(LogEventLevel.Warning, exception, obj);
        }

        public void Warn(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Warning, messageProvider);
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Warning, format, args);
        }

        public void WarnFormat(string format, params object[] args)
        {
            WriteSerilog(LogEventLevel.Warning, format, args);
        }

        private LogEventLevel GetSerilogLevel(LogLevel level)
        {
            if (level == LogLevel.Fatal)
            {
                return LogEventLevel.Fatal;
            }
            if (level == LogLevel.Error)
            {
                return LogEventLevel.Error;
            }
            if (level == LogLevel.Warn)
            {
                return LogEventLevel.Warning;
            }
            if (level == LogLevel.Info)
            {
                return LogEventLevel.Information;
            }
            if (level == LogLevel.Debug)
            {
                return LogEventLevel.Debug;
            }
            if (level == LogLevel.All)
            {
                return LogEventLevel.Verbose;
            }

            return LogEventLevel.Information;
        }

        private void WriteSerilog(LogEventLevel level, object obj)
        {
            _logger.Write(level, ObjectLogTemplate, obj);
        }

        private void WriteSerilog(LogEventLevel level, Exception exception, object obj)
        {
            _logger.Write(level, exception, ObjectLogTemplate, obj);
        }

        private void WriteSerilog(LogEventLevel level, string messageTemplate, object[] objects)
        {
            _logger.Write(level, messageTemplate, objects);
        }

        private void WriteSerilog(LogEventLevel level, LogOutputProvider logOutputProvider)
        {
            if (_logger.IsEnabled(level))
            {
                _logger.Write(level, ObjectLogTemplate, logOutputProvider());
            }
        }   
    }
}