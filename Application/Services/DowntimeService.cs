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
    public class DowntimeTrackingService : IDowntimeTrackingService
    {
        private readonly IDowntimeTrackingRepository _downtimeTrackingRepository;
        private readonly IDowntimeTrackingDetailsRepository _downtimeTrackingDetailsRepository;
        private readonly IMapper _dataMapper;

        public DowntimeTrackingService(IDowntimeTrackingRepository downtimeTrackingRepository,
                                       IDowntimeTrackingDetailsRepository downtimeTrackingDetailsRepository,
                                       IMapper dataMapper)
        {
            _downtimeTrackingRepository = downtimeTrackingRepository;
            _downtimeTrackingDetailsRepository = downtimeTrackingDetailsRepository;
            _dataMapper = dataMapper;
        }

        public async Task<IEnumerable<DowntimeTrackingList>> GetAllDowntimeTrackingsAsync()
        {
            var entities = await _downtimeTrackingRepository.GetAllAsync();
            return _dataMapper.Map<IEnumerable<DowntimeTracking>, IEnumerable<DowntimeTrackingList>>(entities);
        }

        public async Task<DowntimeTrackingAddEdit> GetDowntimeTrackingByIdAsync(long id)
        {
            var entity = await _downtimeTrackingRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            var details = await _downtimeTrackingDetailsRepository.GetAllAsync();
            entity.DownTimeTrackingDetails = details.Where(d => d.HeaderId == id).ToList();

            return _dataMapper.Map<DowntimeTracking, DowntimeTrackingAddEdit>(entity);
        }

        private async Task<string> GenerateCode()
        {
            string code = "";
            var count = _downtimeTrackingRepository.Get().Select(a => a.Code).Distinct().Count();
            code = $"DTC" + (count + 1).ToString("0000000");
            return code.ToUpper();
        }

        public async Task<long> AddDowntimeTrackingAsync(DowntimeTrackingAddEdit model, long userId)
        {
            try
            {
                var mappedModel = _dataMapper.Map<DowntimeTracking>(model);
                mappedModel.CreatedBy = userId;
                mappedModel.CreatedDate = DateTime.Now;
                mappedModel.ModifiedBy = userId;
                mappedModel.ModifiedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                mappedModel.DownTimeTrackingDetails.Clear();
                foreach (var detail in model.DowntimeTrackingDetails)
                {
                    var det = _dataMapper.Map<DowntimeTrackingDetailsAddEdit, DowntimeTrackingDetails>(detail);
                    det.HeaderId = mappedModel.Id;
                    det.CreatedBy = userId;
                    det.CreatedDate = DateTime.Now;
                    det.ModifiedBy = userId;
                    det.ModifiedDate = DateTime.Now;
                    det.IsActive = true;
                    mappedModel.DownTimeTrackingDetails.Add(det);
                }

                await _downtimeTrackingRepository.AddAsync(mappedModel);
                return mappedModel.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<long> UpdateDowntimeTrackingAsync(DowntimeTrackingAddEdit model, long userId)
        {
            try
            {
                var entity = await _downtimeTrackingRepository.GetByIdAsync(model.Id);
                if (entity == null) return 0;

                string code = entity.Code;
                bool isActive = entity.IsActive;

                if (entity.DownTimeTrackingDetails != null)
                {
                    foreach (var detailEntity in entity.DownTimeTrackingDetails)
                    {
                        _downtimeTrackingDetailsRepository.DeleteEntity(detailEntity);
                    }
                }

                entity.ModifiedBy = userId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<DowntimeTrackingAddEdit, DowntimeTracking>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;

                mappedModel.DownTimeTrackingDetails.Clear();
                foreach (var detail in model.DowntimeTrackingDetails)
                {
                    var det = _dataMapper.Map<DowntimeTrackingDetailsAddEdit, DowntimeTrackingDetails>(detail);
                    det.HeaderId = mappedModel.Id;
                    det.CreatedBy = userId;
                    det.CreatedDate = DateTime.Now;
                    det.ModifiedBy = userId;
                    det.ModifiedDate = DateTime.Now;
                    det.IsActive = true;
                    mappedModel.DownTimeTrackingDetails.Add(det);
                }

                await _downtimeTrackingRepository.UpdateAsync(mappedModel);
                return entity.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task DeleteDowntimeTrackingAsync(long id, long userId)
        {
            var entity = await _downtimeTrackingRepository.GetByIdAsync(id);
            if (entity == null) return;

            entity.ModifiedBy = userId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;

            await _downtimeTrackingRepository.UpdateAsync(entity);
        }
    }
}
