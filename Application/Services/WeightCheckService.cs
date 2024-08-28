using Application.Interfaces;
using AutoMapper;
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
    public class WeightCheckService : IWeightCheckService
    {
        private readonly IWeightCheckRepository _WeightCheckRepository;
        private readonly IWeightCheckDetailsRepository _WeightCheckDetailRepository;
        private readonly IWeightCheckSubDetailsRepository _WeightCheckSubDetailRepository;
       // private readonly IMapper _dataMapper;
        private readonly IAutoMapperGenericDataMapper _dataMapper; 
        public WeightCheckService(IWeightCheckRepository weightCheckRepository, 
            IWeightCheckDetailsRepository weightCheckDetailRepository,
            IWeightCheckSubDetailsRepository weightCheckSubDetailRepository,
           // IMapper dataMapper,
           IAutoMapperGenericDataMapper dataMapper
            )
        {
            _WeightCheckRepository = weightCheckRepository;
            _WeightCheckDetailRepository = weightCheckDetailRepository;
            _WeightCheckSubDetailRepository = weightCheckSubDetailRepository;
            _dataMapper = dataMapper;
        }
        public IQueryable<WeightCheckList> GetAllWeightCheckAsync()
        {
            // var entity = _WeightCheckRepository.Get(m => m.IsActive == true);
            var entity = _WeightCheckRepository.GetAllWeightChecksWithProduct();
            return _dataMapper.Project<WeightCheck, WeightCheckList>(entity);
            
           //  throw new NotImplementedException();
        }

        public async Task<WeightCheckAddEdit> GetWeightCheckByIdAsync(long id)
        {
            var entity = await _WeightCheckRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            var result = _dataMapper.Map<WeightCheck, WeightCheckAddEdit>(entity);
            return result;
        }


        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _WeightCheckRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"WTC" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<long> AddWeightCheckAsync(WeightCheckAddEdit model, long userId)
        {
            try
            {
                    var mappedModel = _dataMapper.Map<WeightCheckAddEdit, WeightCheck >(model);
                    mappedModel.CreatedBy = userId;
                    mappedModel.CreatedDate = DateTime.Now;
                    mappedModel.ModifiedBy = userId;
                    mappedModel.ModifiedDate = DateTime.Now;
                    mappedModel.IsActive = true;
                    mappedModel.Code = await GenerateCode();

                    #region Details
                    mappedModel.WeightCheckDetails.Clear();
                foreach (var list in model.WeightCheckDetails)
                {
                    try
                    {
                        WeightCheckDetails det = new WeightCheckDetails();
                        _dataMapper.Map<WeightCheckDetailsAddEdit, WeightCheckDetails>(list, det);

                        if (list.DoneByUserIdList != null && list.DoneByUserIdList.Count() > 0)
                        {
                            det.DoneByUserIds = string.Join(",", list.DoneByUserIdList);
                        }
                        det.HeaderId = mappedModel.Id;
                        det.CreatedBy = userId;
                        det.CreatedDate = DateTime.Now;
                        det.ModifiedBy = userId;
                        det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        foreach (var item in list.WeightCheckSubDetails)
                        {
                            WeightCheckSubDetails det1 = new WeightCheckSubDetails();
                            det1.DetailId = det.Id;
                            det1.Id = 0;
                            det1.NozzleId = item.NozzleId;
                            det1.Weight = item.Weight;
                            det1.CreatedBy = userId;
                            det1.CreatedDate = DateTime.Now;
                            det1.ModifiedBy = userId;
                            det1.ModifiedDate = DateTime.Now;
                            det1.IsActive = true;

                            det.WeightCheckSubDetails.Add(det1);
                        }

                        mappedModel.WeightCheckDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                #endregion

                await _WeightCheckRepository.AddAsync(mappedModel);
                    // await _unitOfWork.Save();
                    return mappedModel.Id;
                
            }

            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }

           // await _WeightCheckRepository.AddAsync(company);
        }

        public async Task<long> UpdateWeightCheckAsync(WeightCheckAddEdit model, long userId)
        {
            try
            {
                var entity = await _WeightCheckRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;
                if (entity.WeightCheckDetails != null)
                {
                    foreach (var detailEntity in entity.WeightCheckDetails)
                    {
                        foreach (var subDetailEntity in detailEntity.WeightCheckSubDetails)
                        {
                            _WeightCheckSubDetailRepository.DeleteEntity(subDetailEntity);
                        }

                        _WeightCheckDetailRepository.DeleteEntity(detailEntity);
                    }
                }


                entity.ModifiedBy = userId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<WeightCheckAddEdit, WeightCheck>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;
                //mappedModel.IsActive = true;

                #region Details

                mappedModel.WeightCheckDetails.Clear();
                foreach (var list in model.WeightCheckDetails)
                {
                    try
                    {
                        WeightCheckDetails det = new WeightCheckDetails();
                        _dataMapper.Map<WeightCheckDetailsAddEdit, WeightCheckDetails>(list, det);

                        if (list.DoneByUserIdList != null && list.DoneByUserIdList.Count() > 0)
                        {
                            det.DoneByUserIds = string.Join(",", list.DoneByUserIdList);
                        }
                        det.HeaderId = mappedModel.Id;
                        det.CreatedBy = userId;
                        det.CreatedDate = DateTime.Now;
                        det.ModifiedBy = userId;
                        det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        foreach (var item in list.WeightCheckSubDetails)
                        {
                            WeightCheckSubDetails det1 = new WeightCheckSubDetails();
                            det1.DetailId = det.Id;
                            det1.Id = 0;
                            det1.NozzleId = item.NozzleId;
                            det1.Weight = item.Weight;
                            det1.CreatedBy = userId;
                            det1.CreatedDate = DateTime.Now;
                            det1.ModifiedBy = userId;
                            det1.ModifiedDate = DateTime.Now;
                            det1.IsActive = true;

                            det.WeightCheckSubDetails.Add(det1);
                        }

                        mappedModel.WeightCheckDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                #endregion

                await _WeightCheckRepository.UpdateAsync(mappedModel);
                // await _unitOfWork.Save();
                return entity.Id;

            }

            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }

            // await _WeightCheckRepository.AddAsync(company);
        }
        

        public async Task DeleteWeightCheckAsync(long Id, long userId)
        {
            var entity = await _WeightCheckRepository.GetByIdAsync(Id);
            entity.ModifiedBy = userId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;
            await _WeightCheckRepository.UpdateAsync(entity);

          //  return new ResponseModel { IsSuccess = true, Message = "Deleted Successfully." };
        }

        public async Task DeleteWeightCheckAsync(int id)
        {
            await _WeightCheckRepository.DeleteAsync(id);
        }
    }
}
