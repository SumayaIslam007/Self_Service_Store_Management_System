using System.Collections.Generic;
using BusinessLogicLayer.Dtos;

namespace BusinessLogicLayer.IServices
{
    public interface IAdminManager
    {
        List<AdminDto> GetAllAdmins();
        AdminDto GetAdminById(int id);
        AdminDto GetAdminByEmail(string email);
        void AddAdmin(AdminDto adminDto);
        void UpdateAdmin(AdminDto adminDto);
        void DeleteAdmin(int id);
        bool ValidateAdmin(AdminDto adminDto, string password);
    }
}
