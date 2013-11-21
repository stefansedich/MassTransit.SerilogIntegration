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

using System.Runtime.Caching;
using MassTransit.Logging;
using Serilog;
using ILogger = MassTransit.Logging.ILogger;

namespace MassTransit.SeriLogIntegration
{
    public class SerilogLogger : ILogger
    {
        private readonly Serilog.ILogger _baseLogger;
        private readonly MemoryCache _logs;

        public SerilogLogger(Serilog.ILogger baseLogger)
        {
            _baseLogger = baseLogger;
            _logs = new MemoryCache("MassTransit.SerilogIntegration");
        }

        public ILog Get(string name)
        {
            var logger = _baseLogger ?? Log.Logger;
            var log = (_logs[name] as ILog)
                      ?? (ILog)(_logs[name] = new SerilogLog(logger.ForContext("name", name)));

            return log;
        }

        public static void Use(Serilog.ILogger baseLogger)
        {
            Logger.UseLogger(new SerilogLogger(baseLogger));
        }
    }
}