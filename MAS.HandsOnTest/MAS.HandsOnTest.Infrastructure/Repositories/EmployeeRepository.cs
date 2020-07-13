using AutoMapper;
using MAS.HandsOnTest.Core.Entities;
using MAS.HandsOnTest.Core.Repositories;
using RestSharp;
using System.Collections.Generic;

namespace MAS.HandsOnTest.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        readonly RestClient client = new RestClient("http://masglobaltestapi.azurewebsites.net/api/");

        /// <summary>
        /// Class constructor
        /// </summary>
        public EmployeeRepository()
        {
            MappingConfiguration();
        }

        /// <summary>
        /// Configure mapping employees
        /// </summary>
        internal override void MappingConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, Models.Employee>()                    
                    .ReverseMap();
            });
            mapping = config.CreateMapper();
        }
        
        /// <summary>
        /// Retrieve employee from source data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAll()
        {
            var request = new RestRequest("Employees", Method.GET);
            var queryResult = client.Execute<IEnumerable<Models.Employee>>(request).Data;

            return mapping.Map<IEnumerable<Employee>>(queryResult);
        }        
    }
}
