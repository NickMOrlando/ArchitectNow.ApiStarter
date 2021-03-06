﻿using System.Reflection;
using Microsoft.AspNetCore.Builder;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors.Security;

namespace ArchitectNow.ApiStarter.Api.Configuration
{
    public static class SwaggerExtensions
    {
        public static void ConfigureSwagger(this IApplicationBuilder app, Assembly assembly)
        {
            var swaggerUiOwinSettings = new SwaggerUiSettings
            {
                DefaultPropertyNameHandling = PropertyNameHandling.CamelCase,
                Title = "ArchitectNow.ApiStarter",
                SwaggerRoute = "/api/docs/v1/swagger.json",
                SwaggerUiRoute = "/api/docs",
                UseJsonEditor = true, //Set to false if you want to manually type in the Json
                FlattenInheritanceHierarchy = true,
                IsAspNetCore = true
            };

            swaggerUiOwinSettings.DocumentProcessors.Add(new SecurityDefinitionAppender("Authorization",
                new SwaggerSecurityScheme
                {
                    Type = SwaggerSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = SwaggerSecurityApiKeyLocation.Header
                })
            );

            app.UseSwaggerUi(assembly, swaggerUiOwinSettings);
        }
    }
}