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
    public class PreCheckListService : IPreCheckListService
    {
        private readonly IPreCheckListRepository _preCheckListRepository;
        private readonly IPreCheckListDetailRepository _preCheckListDetailRepository;
        private readonly IMapper _dataMapper;

        public PreCheckListService(IPreCheckListRepository preCheckListRepository,
                                  IPreCheckListDetailRepository preCheckListDetailRepository,
                                  IMapper dataMapper)
        {
            _preCheckListRepository = preCheckListRepository;
            _preCheckListDetailRepository = preCheckListDetailRepository;
            _dataMapper = dataMapper;
        }

        public async Task<IEnumerable<PreCheckList>> GetAllPreCheckListAsync()
        {
            var entities = await _preCheckListRepository.GetAllAsync();

            // Map entities to PreCheckList view models
            var result = entities.Select(entity => new PreCheckList
            {
                Id = entity.Id,
                Code = entity.Code,
                StartDateTime = entity.StartDateTime,
                ProductionOrderId = entity.ProductionOrderId,
                ProductId = entity.ProductId,
                ProductName = entity.ProductMaster?.ProductName, // Map the ProductName from the Product entity
                ShiftId = entity.ShiftId,
                FillingLine = entity.FillingLine,
                FillerUserIds = entity.FillerUserIds,
                Comments = entity.Comments,
                IsActive = entity.IsActive
            }).ToList();

            return result;
        }

        public async Task<PreCheckListAddEdit> GetPreCheckListByIdAsync(long id)
        {
            var entity = await _preCheckListRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            // Manually load the related PreCheckListDetails if not already included
            var details = await _preCheckListDetailRepository.GetAllAsync(); // Get all details from the repository
            var preCheckListDetails = details.Where(d => d.PreCheckListId == id).ToList();

            // Assign the related details to the entity
            entity.PreCheckListDetails = preCheckListDetails;

            // Map the entity to the view model
            var result = _dataMapper.Map<PreCheckListEntity, PreCheckListAddEdit>(entity);
            return result;
        }

        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _preCheckListRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"PCL" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<long> AddPreCheckListAsync(PreCheckListAddEdit model, long userId)
        {
            try
            {
                var mappedModel = _dataMapper.Map<PreCheckListEntity>(model);
                mappedModel.CreatedBy = userId;
                mappedModel.CreatedDate = DateTime.Now;
                mappedModel.ModifiedBy = userId;
                mappedModel.ModifiedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                // Save the PreCheckListEntity first to generate its ID
                await _preCheckListRepository.AddAsync(mappedModel);

                #region Details
                // Now that the PreCheckListEntity is saved, the Id is generated
                foreach (var list in model.PreCheckListDetails)
                {
                    PreCheckListDetailEntity det = new PreCheckListDetailEntity();
                    _dataMapper.Map<PreCheckListDetailAddEdit, PreCheckListDetailEntity>(list, det);

                    det.HeaderId = mappedModel.Id;  // Assign the generated Id
                    det.CreatedBy = userId;
                    det.CreatedDate = DateTime.Now;
                    det.ModifiedBy = userId;
                    det.ModifiedDate = DateTime.Now;
                    det.IsActive = true;
                    await _preCheckListDetailRepository.AddAsync(det);
                }
                #endregion

                return mappedModel.Id;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., logging)
                return await Task.Run(() => 0);
            }
        }


        public async Task<long> UpdatePreCheckListAsync(PreCheckListAddEdit model, long userId)
        {
            try
            {
                var entity = await _preCheckListRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;

                if (entity.PreCheckListDetails != null)
                {
                    foreach (var detailEntity in entity.PreCheckListDetails)
                    {
                        _preCheckListDetailRepository.DeleteEntity(detailEntity);
                    }
                }

                entity.ModifiedBy = userId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<PreCheckListAddEdit, PreCheckListEntity>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;

                #region Details
                mappedModel.PreCheckListDetails.Clear();
                foreach (var list in model.PreCheckListDetails)
                {
                    PreCheckListDetailEntity det = new PreCheckListDetailEntity();
                    _dataMapper.Map<PreCheckListDetailAddEdit, PreCheckListDetailEntity>(list, det);

                    det.HeaderId = mappedModel.Id;
                    det.CreatedBy = userId;
                    det.CreatedDate = DateTime.Now;
                    det.ModifiedBy = userId;
                    det.ModifiedDate = DateTime.Now;
                    det.IsActive = true;
                    mappedModel.PreCheckListDetails.Add(det);
                }
                #endregion

                await _preCheckListRepository.UpdateAsync(mappedModel);
                return entity.Id;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., logging)
                return await Task.Run(() => 0);
            }
        }

        public async Task DeletePreCheckListAsync(long id, long userId)
        {
            var entity = await _preCheckListRepository.GetByIdAsync(id);
            entity.ModifiedBy = userId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;
            await _preCheckListRepository.UpdateAsync(entity);
        }
    }
}
