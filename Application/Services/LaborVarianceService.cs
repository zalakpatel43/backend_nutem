using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LaborVarianceService : ILaborVarianceService
    {
        private readonly ILaborVarinceRepository _LaborVarinceRepository;
        private readonly ILaborVarinceDetailsRepository _LaborVarinceDetailsRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;
        private readonly IClaimAccessorService _claimAccessorService;

        public LaborVarianceService(ILaborVarinceRepository laborVarinceRepository,
            ILaborVarinceDetailsRepository laborVarinceDetailsRepository,
           IAutoMapperGenericDataMapper dataMapper,
           IClaimAccessorService claimAccessorService
            )
        {
            _LaborVarinceRepository = laborVarinceRepository;
            _LaborVarinceDetailsRepository = laborVarinceDetailsRepository;
            _dataMapper = dataMapper;
            _claimAccessorService = claimAccessorService;
        }
        public IQueryable<LaborVarianceList> GetAllLaborVarianceAsync()
        {
            var entity = _LaborVarinceRepository.GetAllLaborVarinceProduct();
            return _dataMapper.Project<LaborVariance, LaborVarianceList>(entity);

        }

        public async Task<LaborVarianceAddEdit> GetLaborVarianceByIdAsync(long id)
        {
            var entity = await _LaborVarinceRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            var result = _dataMapper.Map<LaborVariance, LaborVarianceAddEdit>(entity);
            return result;
        }


        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct =  _LaborVarinceRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"LV" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<long> AddLaborVarianceAsync(LaborVarianceAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                var mappedModel = _dataMapper.Map<LaborVarianceAddEdit, LaborVariance>(model);
                mappedModel.CreatedBy = loggedinuserId;
                mappedModel.CreatedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                #region Details
                mappedModel.LaborVarianceDetails.Clear();
                foreach (var list in model.LaborVarianceDetails)
                {
                    try
                    {
                        LaborVarianceDetails det = new LaborVarianceDetails();
                        _dataMapper.Map<LaborVarianceDetailsAddEdit, LaborVarianceDetails>(list, det);

                        det.HeaderId = mappedModel.Id;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LaborVarianceDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                #endregion

                await _LaborVarinceRepository.AddAsync(mappedModel);
                return mappedModel.Id;

            }

            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }

        }

        public async Task<long> UpdateLaborVarianceAsync(LaborVarianceAddEdit model, long userId)
        {
            try
            {
                var entity = await _LaborVarinceRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;
                if (entity.LaborVarianceDetails != null)
                {
                    foreach (var detailEntity in entity.LaborVarianceDetails)
                    {
                        _LaborVarinceDetailsRepository.DeleteEntity(detailEntity);
                    }
                }

                long loggedinuserId = _claimAccessorService.GetUserId();
                entity.ModifiedBy = loggedinuserId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<LaborVarianceAddEdit, LaborVariance>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;

                #region Details

                mappedModel.LaborVarianceDetails.Clear();
                foreach (var list in model.LaborVarianceDetails)
                {
                    try
                    {
                        LaborVarianceDetails det = new LaborVarianceDetails();
                        _dataMapper.Map<LaborVarianceDetailsAddEdit, LaborVarianceDetails>(list, det);
                        det.HeaderId = mappedModel.Id;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                        det.ModifiedBy = loggedinuserId;
                        det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        

                        mappedModel.LaborVarianceDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                #endregion

                await _LaborVarinceRepository.UpdateAsync(mappedModel);
                return entity.Id;

            }

            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }

        }


        public async Task DeleteLaborVarianceAsync(long Id, long userId)
        {
            var entity = await _LaborVarinceRepository.GetByIdAsync(Id);
            long loggedinuserId = _claimAccessorService.GetUserId();
            entity.ModifiedBy = loggedinuserId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;
            await _LaborVarinceRepository.UpdateAsync(entity);

            //  return new ResponseModel { IsSuccess = true, Message = "Deleted Successfully." };
        }
    }
}
