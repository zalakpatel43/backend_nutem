using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PalletPackingService : IPalletPackingService
    {
        private readonly IPalletPackingRepository _palletPackingRepository;
        private readonly IPalletPackingDetailsRepository _palletPackingDetailsRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;

        public PalletPackingService(
            IPalletPackingRepository palletPackingRepository,
            IPalletPackingDetailsRepository palletPackingDetailsRepository,
            IAutoMapperGenericDataMapper dataMapper)
        {
            _palletPackingRepository = palletPackingRepository;
            _palletPackingDetailsRepository = palletPackingDetailsRepository;
            _dataMapper = dataMapper;
        }

        //public IQueryable<PalletPackingList> GetAllPalletPackingAsync()
        //{
        //    var entity = _palletPackingRepository.GetAllPalletPackingsWithProduct();
        //    return _dataMapper.Project<PalletPacking, PalletPackingList>(entity);
        //}

        public IQueryable<PalletPackingList> GetAllPalletPackingAsync()
        {
            var entity = _palletPackingRepository.GetAllPalletPackingsWithProduct();

            // Ensure the ProductName is included in the mapping
            var result = entity.Select(pp => new PalletPackingList
            {
                Id = pp.Id,
                Code = pp.Code,
                PackingDateTime = pp.PackingDateTime,
                ProductId = pp.ProductId,
                ProductName =  pp.ProductMaster.ProductName  // Ensure ProductName is mapped
            });

            return result;
        }

        public async Task<PalletPackingAddEdit> GetPalletPackingByIdAsync(long id)
        {
            var entity = await _palletPackingRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            var result = _dataMapper.Map<PalletPacking, PalletPackingAddEdit>(entity);
            return result;
        }


        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _palletPackingRepository.Get().Select(a => a.Code).Distinct().ToList().Count;
            code = $"PPC" + (ct + 1).ToString("0000000");
            return code.ToUpper();
        }

        public async Task<long> AddPalletPackingAsync(PalletPackingAddEdit model, long userId)
        {
            try
            {
                var mappedModel = _dataMapper.Map<PalletPackingAddEdit, PalletPacking>(model);
                mappedModel.CreatedBy = userId;
                mappedModel.CreatedDate = DateTime.Now;
                mappedModel.ModifiedBy = userId;
                mappedModel.ModifiedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                #region Details
                mappedModel.PalletPackingDetails.Clear();
                foreach (var list in model.PalletPackingDetails)
                {
                    try
                    {
                        var detail = _dataMapper.Map<PalletPackingDetailsAddEdit, PalletPackingDetails>(list);
                        detail.HeaderId = mappedModel.Id;
                        detail.CreatedBy = userId;
                        detail.CreatedDate = DateTime.Now;
                        detail.ModifiedBy = userId;
                        detail.ModifiedDate = DateTime.Now;
                        detail.IsActive = true;

                        mappedModel.PalletPackingDetails.Add(detail);
                    }
                    catch (Exception ex)
                    {
                        // Handle specific exception or log
                    }
                }
                #endregion

                await _palletPackingRepository.AddAsync(mappedModel);
                return mappedModel.Id;
            }
            catch (Exception ex)
            {
                // Handle exception or log
                return await Task.Run(() => 0);
            }
        }

        public async Task<long> UpdatePalletPackingAsync(PalletPackingAddEdit model, long userId)
        {
            try
            {
                var entity = await _palletPackingRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;

                // Remove existing details
                if (entity.PalletPackingDetails != null)
                {
                    foreach (var detailEntity in entity.PalletPackingDetails.ToList())
                    {
                        _palletPackingDetailsRepository.DeleteEntity(detailEntity);
                    }
                }

                // Map and update the entity
                entity.ModifiedBy = userId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<PalletPackingAddEdit, PalletPacking>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;

                // Add new details
                mappedModel.PalletPackingDetails.Clear();
                foreach (var list in model.PalletPackingDetails)
                {
                    var detail = _dataMapper.Map<PalletPackingDetailsAddEdit, PalletPackingDetails>(list);
                    detail.HeaderId = mappedModel.Id;
                    detail.CreatedBy = userId;
                    detail.CreatedDate = DateTime.Now;
                    detail.ModifiedBy = userId;
                    detail.ModifiedDate = DateTime.Now;
                    detail.IsActive = true;

                    mappedModel.PalletPackingDetails.Add(detail);
                }

                await _palletPackingRepository.UpdateAsync(mappedModel);
                return entity.Id;
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return await Task.Run(() => 0);
            }
        }

        public async Task DeletePalletPackingAsync(long id, long userId)
        {
            var entity = await _palletPackingRepository.GetByIdAsync(id);
            if (entity != null)
            {
                entity.ModifiedBy = userId;
                entity.ModifiedDate = DateTime.Now;
                entity.IsActive = false;
                await _palletPackingRepository.UpdateAsync(entity);
            }
        }

        public async Task DeletePalletPackingAsync(int id)
        {
            await _palletPackingRepository.DeleteAsync(id);
        }
    }
}
