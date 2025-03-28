﻿using LeadManagement.Application.Services.AutoMapper;
using LeadManagement.Application.UseCases.Lead.Filter;
using LeadManagement.Application.UseCases.Lead.Register;
using Microsoft.Extensions.DependencyInjection;

namespace LeadManagement.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterLeadUseCase, RegisterLeadUseCase>();
        services.AddScoped<IFilterLeadUseCase, FilterLeadUseCase>();
    }

}
