using BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface ICustomerManager
    {
        List<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int id);
        CustomerDto GetCustomerByEmail(string email);
        void AddCustomer(CustomerDto customerDto);
        void UpdateCustomer(CustomerDto customerDto);
        void DeleteCustomer(int id);
        bool ValidateCustomer(CustomerDto customerDto, string password);
    }
}
