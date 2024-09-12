using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Infrastructure.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository,
            IRoleRepository roleRepository,
            IPermissionRepository permissionRepository,
            IAutoMapperGenericDataMapper dataMapper
            )
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
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

        public async Task<int> AddRolePermissionAsync(RoleAddEdit model, long userId)
        {
            try
            {
                var mappedModel = _dataMapper.Map<RoleAddEdit, Role>(model);
                mappedModel.CreatedBy = userId;
               // mappedModel.CreatedDate = DateTime.Now;
                mappedModel.ModifiedBy = userId;
                // mappedModel.ModifiedDate = DateTime.Now;

              //  var listPermission1 = _permissionRepository.GetSingle(m => m.Code == "PER_DASHBOARD" && (long)m.PermissionTypeId == PermissionTypeStruct.PermissionTypeConstant.List);
                

                    foreach (var permission in model.Permissions)
                {
                    // List permission
                    if (permission.IsList)
                    {
                        Permission listPermission = _permissionRepository.Get(m => m.Code == permission.Code && m.PermissionTypeId == PermissionTypeStruct.PermissionTypeConstant.List).FirstOrDefault();
                        if (listPermission != null)
                        {
                            mappedModel.RolePermissions.Add(new RolePermissionMap
                            {
                                PermissionId = Convert.ToInt32(listPermission.Id)
                            });
                        }
                    }

                    // Add Permission
                    if (permission.IsAdd)
                    {
                        Permission addPermission = _permissionRepository.Get(m => m.Code == permission.Code && m.PermissionTypeId == PermissionTypeStruct.PermissionTypeConstant.Add).FirstOrDefault();
                        if (addPermission != null)
                        {
                            mappedModel.RolePermissions.Add(new RolePermissionMap
                            {
                              //  PermissionId = addPermission.Id
                            });
                        }
                    }

                    // Edit Permission
                    if (permission.IsEdit)
                    {
                        Permission editPermission = _permissionRepository.Get(m => m.Code == permission.Code && m.PermissionTypeId == PermissionTypeStruct.PermissionTypeConstant.Edit).FirstOrDefault();
                        if (editPermission != null)
                        {
                            mappedModel.RolePermissions.Add(new RolePermissionMap
                            {
                              //  PermissionId = editPermission.Id
                            });
                        }
                    }

                    if (permission.IsDelete)
                    {
                        Permission editPermission = _permissionRepository.Get(m => m.Code == permission.Code && m.PermissionTypeId == PermissionTypeStruct.PermissionTypeConstant.Delete).FirstOrDefault();
                        if (editPermission != null)
                        {
                            mappedModel.RolePermissions.Add(new RolePermissionMap
                            {
                                PermissionId = editPermission.Id
                            });
                        }
                    }

                    // Export Permission
                    //if (permission.IsExport)
                    //{
                    //    PermissionEntity exportPermission = _permissionRepository.Get(m => m.Code == permission.Code && m.PermissionTypeId == Constants.PermissionTypeConstant.Export).FirstOrDefault();
                    //    if (exportPermission != null)
                    //    {
                    //        entity.RolePermissions.Add(new RolePermissionEntity
                    //        {
                    //            PermissionId = exportPermission.Id
                    //        });
                    //    }
                    //}
                }

                mappedModel.IsActive = true;


                await _roleRepository.AddAsync(mappedModel);
                return Convert.ToInt32(mappedModel.Id);
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
