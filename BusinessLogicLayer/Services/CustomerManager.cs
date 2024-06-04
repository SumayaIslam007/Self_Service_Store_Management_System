using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class CustomerManager : ICustomerManager
    {
        private readonly CustomerRepository _customerRepository;
        private readonly EntityDtoTransformer _transformer;

        public CustomerManager()
        {
            _customerRepository = new CustomerRepository();
            _transformer = new EntityDtoTransformer();
        }

        public List<CustomerDto> GetAllCustomers()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers();
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                customerDtos.Add(_transformer.TransformToCustomerDto(customer));
            }
            return customerDtos;
        }

        public CustomerDto GetCustomerById(int id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            return _transformer.TransformToCustomerDto(customer);
        }
        public CustomerDto GetCustomerByEmail(string email)
        {
            Customer customer = _customerRepository.GetCustomerByEmail(email);
            return _transformer.TransformToCustomerDto(customer);
        }

        public void AddCustomer(CustomerDto customerDto)
        {
            Customer customer = _transformer.TransformToCustomerEntity(customerDto);
            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            Customer customer = _transformer.TransformToCustomerEntity(customerDto);
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public bool ValidateCustomer(CustomerDto customerDto, string password)
        {
            if(customerDto != null && customerDto.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
