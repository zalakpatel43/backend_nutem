using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository, IAutoMapperGenericDataMapper dataMapper)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _dataMapper = dataMapper;
        }

        public async Task<List<RolePermissionList>> GetAllRolePermissionsAsync()
        {
            var entity = _rolePermissionRepository.GetAllRolePermissionsWithRelatedInfo();
            var list = await Task.FromResult(_dataMapper.Project<RolePermissionMap, RolePermissionList>(entity).ToList());
            return list;
        }

        public async Task<RolePermissionAddEdit> GetRolePermissionByIdAsync(int id)
        {
            var entity = await _rolePermissionRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            return _dataMapper.Map<RolePermissionMap, RolePermissionAddEdit>(entity);
        }

        public async Task<int> AddRolePermissionAsync(RolePermissionAddEdit model, long userId)
        {
            try
            {
                var mappedModel = _dataMapper.Map<RolePermissionAddEdit, RolePermissionMap>(model);
                //mappedModel.CreatedBy = userId;
                //mappedModel.CreatedDate = DateTime.Now;
                //mappedModel.ModifiedBy = userId;
                //mappedModel.ModifiedDate = DateTime.Now;

                await _rolePermissionRepository.AddAsync(mappedModel);
                return mappedModel.Id;
            }
            catch (Exception ex)
            {
                // Log exception
                return await Task.FromResult(0);
            }
        }

        public async Task<int> UpdateRolePermissionAsync(RolePermissionAddEdit model, long userId)
        {
            try
            {
                var entity = await _rolePermissionRepository.GetByIdAsync(model.Id);
                if (entity == null)
                    return 0;

                //entity.ModifiedBy = userId;
                //entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<RolePermissionAddEdit, RolePermissionMap>(model, entity);

                await _rolePermissionRepository.UpdateAsync(mappedModel);
                return entity.Id;
            }
            catch (Exception ex)
            {
                // Log exception
                return await Task.FromResult(0);
            }
        }

        public async Task DeleteRolePermissionAsync(int id, long userId)
        {
            var entity = await _rolePermissionRepository.GetByIdAsync(id);
            if (entity == null)
                return;

            //entity.ModifiedBy = userId;
            //entity.ModifiedDate = DateTime.Now;
            await _rolePermissionRepository.DeleteAsync(entity.Id);
        }
    }
}
