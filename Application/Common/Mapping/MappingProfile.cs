using System;
using System.Linq;
using System.Reflection;
using Application.Common.Models;
using Application.EmployeeApp;
using Application.ProfileApp;
using Application.TeacherApp;
using AutoMapper;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(RespDto<>), typeof(RespDto<>));
            CreateMap<UpsertTeacherCommand, UpsertProfileCommand>();
            CreateMap<UpsertEmployeeCommand, UpsertProfileCommand>();
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => 
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}