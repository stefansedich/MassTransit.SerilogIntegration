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

namespace MassTransit
{
    using MassTransit.BusConfigurators;
    using MassTransit.SeriLogIntegration;

    using Serilog;

    /// <summary> Serilog configurator extensions. </summary>
    public static class SerilogConfiguratorExtensions
    {
        #region Public Methods and Operators

        /// <summary> Configure the Mass Transit Service Bus to use the provided Serilog. </summary>
        /// <param name="configurator"> The configurator to act on. </param>
        /// <param name="baseLogger"> The base logger. </param>
        public static void UseSerilog(this ServiceBusConfigurator configurator, ILogger baseLogger)
        {
            SerilogLogger.Use(baseLogger);
        }

        #endregion
    }
}