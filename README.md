Logging
-------

[![Build status](https://ci.appveyor.com/api/projects/status/gj231hvwaan835o5/branch/dev?svg=true)](https://ci.appveyor.com/project/AppCoreNet/logging/branch/dev)

This repository includes projects containing abstractions and implementations for various logging frameworks.

## Packages

Package                                | Description
---------------------------------------|-----------------------------------------------------------------------------
`AppCore.Logging.Abstractions`         | Provides the public API of the logging framework.
`AppCore.Logging`                      | Provides default implementations, agnostic of the actual logging framework.
`AppCore.Logging.Serilog`              | Serilog based implementation.
`AppCore.Logging.Microsoft.Extensions` | Microsoft.Extensions.Logging based implementation.
