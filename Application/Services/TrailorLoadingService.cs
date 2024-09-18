using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TrailerLoadingService : ITrailerLoadingService
    {
        private readonly ITrailerLoadingRepository _trailerLoadingRepository;
        private readonly ITrailerLoadingDetailsRepository _trailerLoadingDetailsRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;
        private readonly IClaimAccessorService _claimAccessorService;

        public TrailerLoadingService(
            ITrailerLoadingRepository trailerLoadingRepository,
            ITrailerLoadingDetailsRepository trailerLoadingDetailsRepository,
            IAutoMapperGenericDataMapper dataMapper,
            IClaimAccessorService claimAccessorService
            )
        {
            _trailerLoadingRepository = trailerLoadingRepository;
            _trailerLoadingDetailsRepository = trailerLoadingDetailsRepository;
            _dataMapper = dataMapper;
            _claimAccessorService = claimAccessorService;
        }

        //public IQueryable<TrailerLoadingList> GetAllTrailerLoadingsAsync()
        //{
        //    var entity = _trailerLoadingRepository.GetAllTrailerLoadingsWithDetails();
        //    return _dataMapper.Project<TrailerLoading, TrailerLoadingList>(entity);
        //}
        public IQueryable<TrailerLoadingList> GetAllTrailerLoadingsAsync()
        {
            var entity = _trailerLoadingRepository.GetAllTrailerLoadingsWithDetails();

            // Ensure the ProductName is included in the mapping
            var result = entity.Select(pp => new TrailerLoadingList
            {
                Id = pp.Id,
                Code = pp.Code,
                TLDateTime = pp.TLDateTime,
                DoorNo = pp.DoorNo,
                TrailerNo=pp.TrailerNo,
                BOLNo = pp.BOLNo,  
                SupervisedName = pp.HeadUser.Name,
                SupervisedBy = pp.SupervisedBy,
                SupervisedOn = pp.SupervisedOn,
                

            });

            return result;
        }

        public async Task<TrailerLoadingAddEdit> GetTrailerLoadingByIdAsync(long id)
        {
            var entity = await _trailerLoadingRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            return _dataMapper.Map<TrailerLoading, TrailerLoadingAddEdit>(entity);
        }

        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _trailerLoadingRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"TLC" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<long> AddTrailerLoadingAsync(TrailerLoadingAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                var mappedModel = _dataMapper.Map<TrailerLoadingAddEdit, TrailerLoading>(model);
                mappedModel.CreatedBy = loggedinuserId;
                mappedModel.CreatedDate = DateTime.Now;
               // mappedModel.ModifiedBy = userId;
               // mappedModel.ModifiedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                #region Details
                mappedModel.TrailerLoadingDetails.Clear();
                foreach (var detail in model.TrailerLoadingDetails)
                {
                    var mappedDetail = _dataMapper.Map<TrailerLoadingDetailsAddEdit, TrailerLoadingDetails>(detail);
                    mappedDetail.HeaderId = mappedModel.Id;
                    mappedDetail.CreatedBy = loggedinuserId;
                    mappedDetail.CreatedDate = DateTime.Now;
                  //  mappedDetail.ModifiedBy = userId;
                   // mappedDetail.ModifiedDate = DateTime.Now;
                    mappedDetail.IsActive = true;
                    mappedModel.TrailerLoadingDetails.Add(mappedDetail);
                }
                #endregion

                await _trailerLoadingRepository.AddAsync(mappedModel);
                return mappedModel.Id;
            }
            catch (Exception ex)
            {
                // Log the exception
                return await Task.FromResult(0);
            }
        }

        public async Task<long> UpdateTrailerLoadingAsync(TrailerLoadingAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                var entity = await _trailerLoadingRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;

                if (entity.TrailerLoadingDetails != null)
                {
                    foreach (var detail in entity.TrailerLoadingDetails.ToList())
                    {
                        _trailerLoadingDetailsRepository.DeleteEntity(detail);
                    }
                }

                entity.ModifiedBy = loggedinuserId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<TrailerLoadingAddEdit, TrailerLoading>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;

                #region Details
                mappedModel.TrailerLoadingDetails.Clear();
                foreach (var detail in model.TrailerLoadingDetails)
                {
                    var mappedDetail = _dataMapper.Map<TrailerLoadingDetailsAddEdit, TrailerLoadingDetails>(detail);
                    mappedDetail.HeaderId = mappedModel.Id;
                    mappedDetail.CreatedBy = loggedinuserId;
                    mappedDetail.CreatedDate = DateTime.Now;
                    mappedDetail.ModifiedBy = loggedinuserId;
                    mappedDetail.ModifiedDate = DateTime.Now;
                    mappedDetail.IsActive = true;
                    mappedModel.TrailerLoadingDetails.Add(mappedDetail);
                }
                #endregion

                await _trailerLoadingRepository.UpdateAsync(mappedModel);
                return entity.Id;
            }
            catch (Exception ex)
            {
                // Log the exception
                return await Task.FromResult(0);
            }
        }

        public async Task DeleteTrailerLoadingAsync(long id, long userId)
        {
            long loggedinuserId = _claimAccessorService.GetUserId();
            var entity = await _trailerLoadingRepository.GetByIdAsync(id);
            entity.ModifiedBy = loggedinuserId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;
            await _trailerLoadingRepository.UpdateAsync(entity);
        }

        public async Task DeleteTrailerLoadingAsync(int id)
        {
            await _trailerLoadingRepository.DeleteAsync(id);
        }
    }
}
