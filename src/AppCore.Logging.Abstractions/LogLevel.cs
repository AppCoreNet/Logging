// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

namespace AppCore.Logging
{
    /// <summary>
    /// Specifies the importance of an log event.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Logs most detailed information. May contain sensitive data.
        /// </summary>
        Trace = 0,

        /// <summary>
        /// Logs that are used during development.
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Logs that track general application flow.
        /// </summary>
        Info = 2,

        /// <summary>
        /// Logs that highlight an unexpected event in the application flow.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Logs that highlight when the application flow for the current operation is aborted.
        /// </summary>
        Error = 4,

        /// <summary>
        /// Logs that highlight an un-recoverable global error in the application.
        /// </summary>
        Critical = 5
    }
}