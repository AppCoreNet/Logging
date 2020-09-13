// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;

namespace AppCore.Logging
{
    /// <summary>
    /// Logger event delegate.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> where the event should be logged.</param>
    /// <param name="properties">An <see cref="IEnumerable{T}"/> of additional properties to log.</param>
    /// <param name="exception">The <see cref="Exception"/> to log.</param>
    public delegate void LoggerEventDelegate(
        ILogger logger,
        Exception exception = null,
        params LogProperty[] properties);

    /// <summary>
    /// Logger event delegate.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> where the event should be logged.</param>
    /// <param name="arg0">The first log property.</param>
    /// <param name="properties">An <see cref="IEnumerable{T}"/> of additional properties to log.</param>
    /// <param name="exception">The <see cref="Exception"/> to log.</param>
    public delegate void LoggerEventDelegate<in T0>(
        ILogger logger,
        T0 arg0,
        Exception exception = null,
        params LogProperty[] properties);

    /// <summary>
    /// Logger event delegate.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> where the event should be logged.</param>
    /// <param name="arg0">The first log property.</param>
    /// <param name="arg1">The second property.</param>
    /// <param name="properties">An <see cref="IEnumerable{T}"/> of additional properties to log.</param>
    /// <param name="exception">The <see cref="Exception"/> to log.</param>
    public delegate void LoggerEventDelegate<in T0, in T1>(
        ILogger logger,
        T0 arg0,
        T1 arg1,
        Exception exception = null,
        params LogProperty[] properties);

    /// <summary>
    /// Logger event delegate.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> where the event should be logged.</param>
    /// <param name="arg0">The first log property.</param>
    /// <param name="arg1">The second property.</param>
    /// <param name="arg2">The third property.</param>
    /// <param name="properties">An <see cref="IEnumerable{T}"/> of additional properties to log.</param>
    /// <param name="exception">The <see cref="Exception"/> to log.</param>
    public delegate void LoggerEventDelegate<in T0, in T1, in T2>(
        ILogger logger,
        T0 arg0,
        T1 arg1,
        T2 arg2,
        Exception exception = null,
        params LogProperty[] properties);

    /// <summary>
    /// Logger event delegate.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> where the event should be logged.</param>
    /// <param name="arg0">The first log property.</param>
    /// <param name="arg1">The second property.</param>
    /// <param name="arg2">The third property.</param>
    /// <param name="arg3">The fourth property.</param>
    /// <param name="properties">An <see cref="IEnumerable{T}"/> of additional properties to log.</param>
    /// <param name="exception">The <see cref="Exception"/> to log.</param>
    public delegate void LoggerEventDelegate<in T0, in T1, in T2, in T3>(
        ILogger logger,
        T0 arg0,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        Exception exception = null,
        params LogProperty[] properties);

    /// <summary>
    /// Logger event delegate.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> where the event should be logged.</param>
    /// <param name="arg0">The first log property.</param>
    /// <param name="arg1">The second property.</param>
    /// <param name="arg2">The third property.</param>
    /// <param name="arg3">The fourth property.</param>
    /// <param name="arg4">The fifth property.</param>
    /// <param name="properties">An <see cref="IEnumerable{T}"/> of additional properties to log.</param>
    /// <param name="exception">The <see cref="Exception"/> to log.</param>
    public delegate void LoggerEventDelegate<in T0, in T1, in T2, in T3, in T4>(
        ILogger logger,
        T0 arg0,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        Exception exception = null,
        params LogProperty[] properties);
}