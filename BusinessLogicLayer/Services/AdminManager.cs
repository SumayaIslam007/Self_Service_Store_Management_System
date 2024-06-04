using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class AdminManager : IAdminManager
    {
        private readonly AdminRepository _adminRepository;
        private readonly EntityDtoTransformer _transformer;

        public AdminManager()
        {
            _adminRepository = new AdminRepository();
            _transformer = new EntityDtoTransformer();
        }

        public List<AdminDto> GetAllAdmins()
        {
            List<Admin> admins = _adminRepository.GetAllAdmins();
            List<AdminDto> adminDtos = new List<AdminDto>();
            foreach (var admin in admins)
            {
                adminDtos.Add(_transformer.TransformToAdminDto(admin));
            }
            return adminDtos;
        }

        public AdminDto GetAdminById(int id)
        {
            Admin admin = _adminRepository.GetAdminById(id);
            return _transformer.TransformToAdminDto(admin);
        }
        public AdminDto GetAdminByEmail(string email)
        {
            Admin admin = _adminRepository.GetAdminByEmail(email);
            return _transformer.TransformToAdminDto(admin);
        }

        public void AddAdmin(AdminDto adminDto)
        {
            Admin admin = _transformer.TransformToAdminEntity(adminDto);
            _adminRepository.AddAdmin(admin);
        }

        public void UpdateAdmin(AdminDto adminDto)
        {
            Admin admin = _transformer.TransformToAdminEntity(adminDto);
            _adminRepository.UpdateAdmin(admin);
        }

        public void DeleteAdmin(int id)
        {
            _adminRepository.DeleteAdmin(id);
        }

        public bool ValidateAdmin(AdminDto adminDto, string password)
        {
            if (adminDto != null && adminDto.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
