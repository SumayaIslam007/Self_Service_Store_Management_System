using BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface IMembershipManager
    {
        List<MembershipDto> GetAllMemberships();
        MembershipDto GetMembershipById(int id);
        void AddMembership(MembershipDto membershipDto);
        void UpdateMembership(MembershipDto membershipDto);
        void DeleteMembership(int id);
    }
}
