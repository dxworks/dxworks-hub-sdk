﻿using DxWorks.Hub.Sdk.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DxWorks.Hub.Sdk;

public static class DxWorksHubSdkExtensions
{
    public static IServiceCollection AddDxWorksHubSdk(this IServiceCollection services,
        Action<DxWorksHubSdkOptions>? configureOptionsAction = null)
    {
        services.AddOptions<DxWorksHubSdkOptions>()
            .Configure(options => { configureOptionsAction?.Invoke(options); });
        services.TryAddSingleton<IScriptBeeClient, ScriptBeeClient>();

        return services;
    }
}
