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

namespace MassTransit.SeriLogIntegration
{
    using System;

    using MassTransit.Logging;

    using Serilog.Events;

    using ILogger = Serilog.ILogger;

    public class SerilogLog : ILog
    {
        #region Constants

        public const string ObjectLogTemplate = "{@obj}";

        #endregion

        #region Fields

        private readonly ILogger _logger;

        #endregion

        #region Constructors and Destructors

        /// <summary> Create a new SerilogLog logger instance. </summary>
        public SerilogLog(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this._logger = logger;
        }

        #endregion

        #region Public Properties

        public bool IsDebugEnabled
        {
            get
            {
                return this._logger.IsEnabled(LogEventLevel.Debug);
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return this._logger.IsEnabled(LogEventLevel.Error);
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return this._logger.IsEnabled(LogEventLevel.Fatal);
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return this._logger.IsEnabled(LogEventLevel.Information);
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return this._logger.IsEnabled(LogEventLevel.Warning);
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Debug(object obj)
        {
            this.WriteSerilog(LogEventLevel.Debug, obj);
        }

        public void Debug(object obj, Exception exception)
        {
            this.WriteSerilog(LogEventLevel.Debug, exception, obj);
        }

        public void Debug(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Debug, messageProvider);
        }

        public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Debug, format, args);
        }

        public void DebugFormat(string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Debug, format, args);
        }

        public void Error(object obj)
        {
            this.WriteSerilog(LogEventLevel.Error, obj);
        }

        public void Error(object obj, Exception exception)
        {
            this.WriteSerilog(LogEventLevel.Error, exception, obj);
        }

        public void Error(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Error, messageProvider);
        }

        public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Error, format, args);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Error, format, args);
        }

        public void Fatal(object obj)
        {
            this.WriteSerilog(LogEventLevel.Fatal, obj);
        }

        public void Fatal(object obj, Exception exception)
        {
            this.WriteSerilog(LogEventLevel.Fatal, exception, obj);
        }

        public void Fatal(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Fatal, messageProvider);
        }

        public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Fatal, format, args);
        }

        public void FatalFormat(string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Fatal, format, args);
        }

        public void Info(object obj)
        {
            this.WriteSerilog(LogEventLevel.Information, obj);
        }

        public void Info(object obj, Exception exception)
        {
            this.WriteSerilog(LogEventLevel.Information, exception, obj);
        }

        public void Info(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Information, messageProvider);
        }

        public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Information, format, args);
        }

        public void InfoFormat(string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Information, format, args);
        }

        public void Log(LogLevel level, object obj)
        {
            this.WriteSerilog(this.GetSerilogLevel(level), obj);
        }

        public void Log(LogLevel level, object obj, Exception exception)
        {
            this.WriteSerilog(this.GetSerilogLevel(level), exception, obj);
        }

        public void Log(LogLevel level, LogOutputProvider messageProvider)
        {
            WriteSerilog(this.GetSerilogLevel(level), messageProvider);
        }

        public void LogFormat(LogLevel level,
                              IFormatProvider formatProvider,
                              string format,
                              params object[] args)
        {
            WriteSerilog(this.GetSerilogLevel(level), format, args);
        }

        public void LogFormat(LogLevel level, string format, params object[] args)
        {
            WriteSerilog(this.GetSerilogLevel(level), format, args);
        }

        public void Warn(object obj)
        {
            WriteSerilog(LogEventLevel.Warning, obj);
        }

        public void Warn(object obj, Exception exception)
        {
            this.WriteSerilog(LogEventLevel.Warning, exception, obj);
        }

        public void Warn(LogOutputProvider messageProvider)
        {
            WriteSerilog(LogEventLevel.Warning, messageProvider);
        }

        public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Warning, format, args);
        }

        public void WarnFormat(string format, params object[] args)
        {
            this.WriteSerilog(LogEventLevel.Warning, format, args);
        }

        #endregion

        #region Methods

        private LogEventLevel GetSerilogLevel(LogLevel level)
        {
            if (level == LogLevel.Fatal)
            {
                return LogEventLevel.Fatal;
            }
            else if (level == LogLevel.Error)
            {
                return LogEventLevel.Error;
            }
            else if (level == LogLevel.Warn)
            {
                return LogEventLevel.Warning;
            }
            else if (level == LogLevel.Info)
            {
                return LogEventLevel.Information;
            }
            else if (level == LogLevel.Debug)
            {
                return LogEventLevel.Debug;
            }
            else if (level == LogLevel.All)
            {
                return LogEventLevel.Verbose;
            }

            return LogEventLevel.Information;
        }

        private void WriteSerilog(LogEventLevel level, object obj)
        {
            this._logger.Write(level, ObjectLogTemplate, obj);
        }

        private void WriteSerilog(LogEventLevel level, Exception exception, object obj)
        {
            this._logger.Write(level, exception, ObjectLogTemplate, obj);
        }

        private void WriteSerilog(LogEventLevel level, string messageTemplate, object[] objects)
        {
            this._logger.Write(level, messageTemplate, objects);
        }

        private void WriteSerilog(LogEventLevel level, LogOutputProvider logOutputProvider)
        {
            if (this._logger.IsEnabled(level))
            {
                this._logger.Write(level, ObjectLogTemplate, logOutputProvider());
            }
        }

        #endregion
    }
}