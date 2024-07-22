using System;
using System.Collections.Generic;
using Data_Access_Layer.Repository.Entities;
using AutoMapper;
using Business_Logic_Layer.Models;

namespace Business_Logic_Layer
{
	public class EmployeeBLL
	{

		private Data_Access_Layer.EmployeeDAL _DAL;
		private Mapper _EmployeeMapper;

		public EmployeeBLL()
		{
			_DAL = new Data_Access_Layer.EmployeeDAL();
			var _configEmployee = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeModel>().ReverseMap());

			_EmployeeMapper = new Mapper(_configEmployee);
		}

		public List<EmployeeModel> GetAllEmployees()
		{
			List<Employee> EmployeesFromDB = _DAL.GetAllEmployees();
			List<EmployeeModel> EmployeesModel = _EmployeeMapper.Map<List<Employee>, List<EmployeeModel>>(EmployeesFromDB);

			return EmployeesModel;
		}

		public EmployeeModel GetEmployeeById(int id)
		{
			var EmployeeEntity = _DAL.GetEmployeeById(id);

			EmployeeModel EmployeeModel = _EmployeeMapper.Map<Employee, EmployeeModel>(EmployeeEntity);

			return EmployeeModel;
		}


		public void postEmployee(EmployeeModel EmployeeModel)
		{
			Employee EmployeeEntity = _EmployeeMapper.Map<EmployeeModel, Employee>(EmployeeModel);
			_DAL.postEmployee(EmployeeEntity);
		}

	}
}
