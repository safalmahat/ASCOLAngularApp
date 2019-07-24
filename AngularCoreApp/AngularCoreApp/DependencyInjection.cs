using BusinessLogicLayer.Service;
using DataAccessLayer;
using DataAccessLayer.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCoreApp
{
    public static class DependencyInjection
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherRepo, TeacherRepo>();
            services.AddScoped<IDatabaseManager, DatabaseManager>();
        }
    }
}
