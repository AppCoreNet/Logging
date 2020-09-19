AppCore .NET Logging
--------------------

[![Build Status](https://dev.azure.com/AppCoreNet/Logging/_apis/build/status/AppCoreNet.Logging%20CI?branchName=dev)](https://dev.azure.com/AppCoreNet/Logging/_build/latest?definitionId=3&branchName=dev)
![Azure DevOps tests (compact)](https://img.shields.io/azure-devops/tests/AppCoreNet/Logging/3?compact_message)
![Azure DevOps coverage (branch)](https://img.shields.io/azure-devops/coverage/AppCoreNet/Logging/3/dev)
![Nuget](https://img.shields.io/nuget/v/AppCore.Logging.Abstractions)

This repository contains abstractions and implementations for logging. It targets the .NET Framework and .NET Core.

All artifacts are licensed under the [MIT license](LICENSE). You are free to use them in open-source or commercial projects as long
as you keep the copyright notice intact when redistributing or otherwise reusing our artifacts.

## Packages

Latest development packages can be found on [MyGet](https://www.myget.org/gallery/appcorenet).

Package                                           | Description
--------------------------------------------------|------------------------------------------------------------------------------------------------------
`AppCore.Logging`                               | Provides the default implementations agnostic to the actual logging framework.
`AppCore.Logging.Abstractions`                | Contains the public API for the logging framework.
`AppCore.Logging.Serilog`                      | Integrates [Serilog](https://serilog.net/) with the logging framework.
`AppCore.Logging.Microsoft.Extensions`       | Integration of [Microsoft.Extensions.Logging](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging).

### Logging

This packages includes the default implementations. To configure logging in your application simply register the facility:

```
registry.RegisterFacility<LoggingFacility>();
```

### Abstractions

This packages includes the logging API for applications and logging providers.

### Serilog

Adds support for using Serilog.
To use Serilog simply configure the provider when registering the facility:
```
registry.RegisterFacility<LoggingFacility>()
        .AddSerilog();
```

### Microsoft.Extensions

Adds support for using the Microsoft.Extensions.Logging.
To use Microsoft Logging simply configure the provider when registering the facility:
```
registry.RegisterFacility<LoggingFacility>()
        .AddMicrosoftLogging();
```

## Contributing

Contributions, whether you file an issue, fix some bug or implement a new feature, are highly appreciated. The whole user community
will benefit from them.

Please refer to the [Contribution guide](CONTRIBUTING.md).
