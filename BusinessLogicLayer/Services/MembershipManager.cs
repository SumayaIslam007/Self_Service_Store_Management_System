using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class MembershipManager : IMembershipManager
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly EntityDtoTransformer _transformer;

        public MembershipManager(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
            _transformer = new EntityDtoTransformer();
        }

        public List<MembershipDto> GetAllMemberships()
        {
            List<Membership> memberships = _membershipRepository.GetAllMemberships();
            List<MembershipDto> membershipDtos = new List<MembershipDto>();
            foreach (var membership in memberships)
            {
                membershipDtos.Add(_transformer.TransformToMembershipDto(membership));
            }
            return membershipDtos;
        }

        public MembershipDto GetMembershipById(int id)
        {
            Membership membership = _membershipRepository.GetMembershipById(id);
            return _transformer.TransformToMembershipDto(membership);
        }

        public void AddMembership(MembershipDto membershipDto)
        {
            Membership membership = _transformer.TransformToMembershipEntity(membershipDto);
            _membershipRepository.AddMembership(membership);
        }

        public void UpdateMembership(MembershipDto membershipDto)
        {
            Membership membership = _transformer.TransformToMembershipEntity(membershipDto);
            _membershipRepository.UpdateMembership(membership);
        }

        public void DeleteMembership(int id)
        {
            _membershipRepository.DeleteMembership(id);
        }
    }
}
