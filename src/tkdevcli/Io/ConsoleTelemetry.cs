﻿using Crayon;

namespace tkdevcli.Io
{
    internal class ConsoleTelemetry : ITelemetry
    {
        private readonly Action<string> _writeMessage;

        public ConsoleTelemetry() : this(Console.WriteLine)
        {
        }

        public ConsoleTelemetry(Action<string> writeMessage)
        {
            _writeMessage = writeMessage;
        }

        public void Event(TelemetryEvent evt)
        {
            var time = evt.Time.ToString("yyyy-MM-dd HH:mm:ss.fff");

            var line = $"[{time}] {Colourise(evt)(Message(evt))}";

            _writeMessage(line);
        }

        private string Message(TelemetryEvent evt) => evt switch
        {
            TelemetryErrorEvent error => string.IsNullOrEmpty(error.Exception?.Message) ? error.Message : error.Exception?.Message,
            TelemetryDependencyEvent dep => $"[{dep.Dependency}] [{dep.RequestId}] {dep.Message}",
            _ => evt.Message,
        };

        private Func<string, string> Colourise(TelemetryEvent evt)
            => evt switch
            {
                TelemetryErrorEvent error => Output.Bright.Red,
                TelemetryTraceEvent trace => Output.Dim().White,
                TelemetryDependencyEvent dep => Output.Dim().White,
                TelemetryWarningEvent warn => Output.Bright.Yellow,
                TelemetryHeadlineEvent head => Output.Bright.Cyan,
                _ => Output.Bright.White,
            };
    }
}