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
    using System.Runtime.Caching;

    using MassTransit.Logging;

    public class SerilogLogger : ILogger
    {
        #region Fields

        private readonly Serilog.ILogger _baseLogger;

        private readonly MemoryCache _logs;

        #endregion

        #region Constructors and Destructors

        public SerilogLogger(Serilog.ILogger baseLogger)
        {
            this._baseLogger = baseLogger;
            this._logs = new MemoryCache("MassTransit.SerilogIntegration");
        }

        #endregion

        #region Public Methods and Operators

        public static void Use(Serilog.ILogger baseLogger)
        {
            Logger.UseLogger(new SerilogLogger(baseLogger));
        }

        public ILog Get(string name)
        {
            ILog log = (this._logs[name] as ILog) ?? (ILog)(this._logs[name] = new SerilogLog(this._baseLogger.ForContext("name", name)));

            return log;
        }

        #endregion
    }
}