using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IMembershipRepository
    {
        List<Membership> GetAllMemberships();
        Membership GetMembershipById(int id);
        void AddMembership(Membership membership);
        void UpdateMembership(Membership membership);
        void DeleteMembership(int id);
    }
}
