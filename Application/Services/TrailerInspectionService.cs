using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    public class TrailerInspectionService : ITrailerInspectionService
    {
        private readonly ITrailerInspectionRepository _TrailerInspectionRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;
        private readonly IClaimAccessorService _claimAccessorService;
        public TrailerInspectionService(ITrailerInspectionRepository trailerInspectionRepository,
           IAutoMapperGenericDataMapper dataMapper, IClaimAccessorService claimAccessorService  
            )
        {
            _TrailerInspectionRepository = trailerInspectionRepository;
            _dataMapper = dataMapper;
            _claimAccessorService = claimAccessorService;
        }

        public IQueryable<TrailerInspectionList> GetAllTrailerInspectionAsync()
        {
            var entity = _TrailerInspectionRepository.GetAllTrailerInspectionWithVehicleTypeName();
            return _dataMapper.Project<TrailerInspection, TrailerInspectionList>(entity);
        }

        public async Task<TrailerInspectionAddEdit> GetTrailerInspectionByIdAsync(long id)
        {
            var entity = await _TrailerInspectionRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            var result = _dataMapper.Map<TrailerInspection, TrailerInspectionAddEdit>(entity);
            return result;
        }

        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _TrailerInspectionRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"TI" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<long> AddTrailerInspectionAsync(TrailerInspectionAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                var mappedModel = _dataMapper.Map<TrailerInspectionAddEdit, TrailerInspection>(model);
                mappedModel.CreatedBy = loggedinuserId;
                mappedModel.CreatedDate = DateTime.Now;
              //  mappedModel.ModifiedBy = userId;
              //  mappedModel.ModifiedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                await _TrailerInspectionRepository.AddAsync(mappedModel);
                return mappedModel.Id;

            }

            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }

        }

        public async Task<long> UpdateTrailerInspectionAsync(TrailerInspectionAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                var entity = await _TrailerInspectionRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;

                entity.ModifiedBy = loggedinuserId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<TrailerInspectionAddEdit, TrailerInspection>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;

                await _TrailerInspectionRepository.UpdateAsync(mappedModel);
                return entity.Id;
            }

            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }

        }

        public async Task DeleteTrailerInspectionAsync(long Id, long userId)
        {
            long loggedinuserId = _claimAccessorService.GetUserId();
            var entity = await _TrailerInspectionRepository.GetByIdAsync(Id);
            entity.ModifiedBy = loggedinuserId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;
            await _TrailerInspectionRepository.UpdateAsync(entity);

            //  return new ResponseModel { IsSuccess = true, Message = "Deleted Successfully." };
        }
    }
}

