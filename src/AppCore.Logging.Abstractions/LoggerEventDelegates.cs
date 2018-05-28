﻿// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;

namespace AppCore.Logging
{
    public delegate void LoggerEventDelegate(
        ILogger logger,
        IEnumerable<ILogProperty> properties = null,
        Exception exception = null);

    public delegate void LoggerEventDelegate<in T0>(
        ILogger logger,
        T0 arg0,
        IEnumerable<ILogProperty> properties = null,
        Exception exception = null);

    public delegate void LoggerEventDelegate<in T0, in T1>(
        ILogger logger,
        T0 arg0,
        T1 arg1,
        IEnumerable<ILogProperty> properties = null,
        Exception exception = null);

    public delegate void LoggerEventDelegate<in T0, in T1, in T2>(
        ILogger logger,
        T0 arg0,
        T1 arg1,
        T2 arg2,
        IEnumerable<ILogProperty> properties = null,
        Exception exception = null);

    public delegate void LoggerEventDelegate<in T0, in T1, in T2, in T3>(
        ILogger logger,
        T0 arg0,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        IEnumerable<ILogProperty> properties = null,
        Exception exception = null);

    public delegate void LoggerEventDelegate<in T0, in T1, in T2, in T3, in T4>(
        ILogger logger,
        T0 arg0,
        T1 arg1,
        T2 arg2,
        T3 arg3,
        T4 arg4,
        IEnumerable<ILogProperty> properties = null,
        Exception exception = null);
}