﻿namespace tkdevcli.Io
{
    internal record TelemetryEvent
    {
        public DateTime Time { get; init; } = DateTime.UtcNow;
        public string Message { get; init; } = default!;
    }

    internal record TelemetryHeadlineEvent : TelemetryEvent
    {

    }

    internal record TelemetryInfoEvent : TelemetryEvent
    {

    }

    internal record TelemetryTraceEvent : TelemetryEvent
    {

    }

    internal record TelemetryWarningEvent : TelemetryEvent
    {

    }

    internal record TelemetryErrorEvent : TelemetryEvent
    {
        public Exception Exception { get; init; } = default!;
    }

    internal record TelemetryDependencyEvent : TelemetryEvent
    {
        public string Dependency { get; init; }
        public string RequestId { get; init; }
    }
}
