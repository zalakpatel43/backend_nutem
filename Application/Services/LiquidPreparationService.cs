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
    public class LiquidPreparationService : ILiquidPreparationService
    {
        private readonly ILiquidPreparationRepository _liquidPreparationRepository;
        private readonly ILiquidPreparationAdjustmentDetailsRepository _liquidPreparationAdjustmentDetailsRepository;
        private readonly ILiquidPreparationChecklistDetailsRepository _liquidPreparationChecklistDetailsRepository;
        private readonly ILiquidPreparationInstructionDetailsRepository _liquidPreparationInstructionDetailsRepository;
        private readonly ILiquidPreparationSpecificationDetailsRepository _liquidPreparationSpecificationDetailsRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;
        private readonly IClaimAccessorService _claimAccessorService;

        public LiquidPreparationService(ILiquidPreparationRepository liquidPreparationRepository,
            ILiquidPreparationAdjustmentDetailsRepository liquidPreparationAdjustmentDetailsRepository,
            ILiquidPreparationChecklistDetailsRepository liquidPreparationChecklistDetailsRepository,
            ILiquidPreparationInstructionDetailsRepository liquidPreparationInstructionDetailsRepository,
            ILiquidPreparationSpecificationDetailsRepository liquidPreparationSpecificationDetailsRepository
            , IAutoMapperGenericDataMapper dataMapper,
            IClaimAccessorService claimAccessorService)
        {
            _liquidPreparationRepository = liquidPreparationRepository;
            _liquidPreparationAdjustmentDetailsRepository = liquidPreparationAdjustmentDetailsRepository;
            _liquidPreparationChecklistDetailsRepository = liquidPreparationChecklistDetailsRepository;
            _liquidPreparationInstructionDetailsRepository = liquidPreparationInstructionDetailsRepository;
            _liquidPreparationSpecificationDetailsRepository = liquidPreparationSpecificationDetailsRepository;
            _dataMapper = dataMapper;
            _claimAccessorService = claimAccessorService;
        }

        public IQueryable<LiquidPreparationList> GetAllLiquidPreparationAsync()
        {
            var entity = _liquidPreparationRepository.GetAllLiquidPreparationWithShift();
            return _dataMapper.Project<LiquidPreparation, LiquidPreparationList>(entity);
        }

        public async Task<LiquidPreparationAddEdit> GetLiquidPreparationByIdAsync(long id)
        {
            var entity = await _liquidPreparationRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            var result = _dataMapper.Map<LiquidPreparation, LiquidPreparationAddEdit>(entity);
            return result;
        }

        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _liquidPreparationRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"LP" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<long> AddLiquidPreparationAsync(LiquidPreparationAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                if (model.AnalysisDoneByList != null && model.AnalysisDoneByList.Count() > 0)
                {
                    model.AnalysisDoneByIds = string.Join(",", model.AnalysisDoneByList);
                }
                var mappedModel = _dataMapper.Map<LiquidPreparationAddEdit, LiquidPreparation>(model);
                mappedModel.CreatedBy = loggedinuserId;
                mappedModel.CreatedDate = DateTime.Now;
              //  mappedModel.ModifiedBy = userId;
               // mappedModel.ModifiedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                #region InstructionDetails
                mappedModel.LiquidPreparationInstructionDetails.Clear();
                foreach (var list in model.liquidPreparationInstructionDetails)
                {
                    try
                    {
                        LiquidPreparationInstructionDetails det = new LiquidPreparationInstructionDetails();
                        _dataMapper.Map<LiquidPreparationInstructionDetailsAddEdit, LiquidPreparationInstructionDetails>(list, det);

                        if (list.DoneByList != null && list.DoneByList.Count() > 0)
                        {
                            det.DoneByIds = string.Join(",", list.DoneByList);
                        }
                        det.LiquidPreparationId = mappedModel.Id;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                       // det.ModifiedBy = userId;
                       // det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LiquidPreparationInstructionDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

                #region ChecklistDetails
                mappedModel.LiquidPreparationChecklistDetails.Clear();
                foreach (var list in model.liquidPreparationChecklistDetails)
                {
                    try
                    {
                        LiquidPreparationChecklistDetails det = new LiquidPreparationChecklistDetails();
                        _dataMapper.Map<LiquidPreparationChecklistDetailsAddEdit, LiquidPreparationChecklistDetails>(list, det);

                        det.LiquidPreparationId = mappedModel.Id;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                      //  det.ModifiedBy = userId;
                      //  det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LiquidPreparationChecklistDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

                #region SpecificationDetails
                mappedModel.LiquidPreparationSpecificationDetails.Clear();
                foreach (var list in model.liquidPreparationSpecificationDetails)
                {
                    try
                    {
                        LiquidPreparationSpecificationDetails det = new LiquidPreparationSpecificationDetails();
                        _dataMapper.Map<LiquidPreparationSpecificationDetailsAddEdit, LiquidPreparationSpecificationDetails>(list, det);

                        if (list.AnalysisDoneByList != null && list.AnalysisDoneByList.Count() > 0)
                        {
                            det.AnalysisDoneByIds = string.Join(",", list.AnalysisDoneByList);
                        }

                        det.LiquidPreparationId = mappedModel.Id;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                     //   det.ModifiedBy = userId;
                      //  det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LiquidPreparationSpecificationDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

                #region AdjustmentDetails
                mappedModel.LiquidPreparationAdjustmentDetails.Clear();
                foreach (var list in model.liquidPreparationAdjustmentDetails)
                {
                    try
                    {
                        LiquidPreparationAdjustmentDetails det = new LiquidPreparationAdjustmentDetails();
                        _dataMapper.Map<LiquidPreparationAdjustmentDetailsAddEdit, LiquidPreparationAdjustmentDetails>(list, det);

                        det.LiquidPreparationId = mappedModel.Id;
                        det.LiquidPreparationInstructionId = list.LiquidPreparationInstructionId;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                      //  det.ModifiedBy = userId;
                     //   det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LiquidPreparationAdjustmentDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

                await _liquidPreparationRepository.AddAsync(mappedModel);
                //await _unitOfWork.Save();
                return mappedModel.Id;

            }

            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }

            // await _WeightCheckRepository.AddAsync(company);
        }

        public async Task<long> UpdateLiquidPreparationAsync(LiquidPreparationAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                var entity = await _liquidPreparationRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;
                if (entity.LiquidPreparationAdjustmentDetails != null)
                {
                    foreach (var detailEntity in entity.LiquidPreparationAdjustmentDetails)
                    {
                        _liquidPreparationAdjustmentDetailsRepository.DeleteEntity(detailEntity);
                    }
                }
                if (entity.LiquidPreparationChecklistDetails != null)
                {
                    foreach (var detailEntity in entity.LiquidPreparationChecklistDetails)
                    {
                        _liquidPreparationChecklistDetailsRepository.DeleteEntity(detailEntity);
                    }
                }
                if (entity.LiquidPreparationInstructionDetails != null)
                {
                    foreach (var detailEntity in entity.LiquidPreparationInstructionDetails)
                    {
                        _liquidPreparationInstructionDetailsRepository.DeleteEntity(detailEntity);
                    }
                }
                if (entity.LiquidPreparationSpecificationDetails != null)
                {
                    foreach (var detailEntity in entity.LiquidPreparationSpecificationDetails)
                    {
                        _liquidPreparationSpecificationDetailsRepository.DeleteEntity(detailEntity);
                    }
                }


                if (model.AnalysisDoneByList != null && model.AnalysisDoneByList.Count() > 0)
                {
                    model.AnalysisDoneByIds = string.Join(",", model.AnalysisDoneByList);
                }
                entity.ModifiedBy = loggedinuserId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<LiquidPreparationAddEdit, LiquidPreparation>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;


                //mappedModel.IsActive = true;

                #region InstructionDetails
                mappedModel.LiquidPreparationInstructionDetails.Clear();
                foreach (var list in model.liquidPreparationInstructionDetails)
                {
                    try
                    {
                        LiquidPreparationInstructionDetails det = new LiquidPreparationInstructionDetails();
                        _dataMapper.Map<LiquidPreparationInstructionDetailsAddEdit, LiquidPreparationInstructionDetails>(list, det);

                        DateTime addedTime = list.CurrentTime != null && list.CurrentTime != "" ? Convert.ToDateTime(list.CurrentTime) : DateTime.Now;

                        if (list.DoneByList != null && list.DoneByList.Count() > 0)
                        {
                            det.DoneByIds = string.Join(",", list.DoneByList);
                        }
                        det.Id = 0;// list.Id;
                        det.LiquidPreparationId = mappedModel.Id;
                        det.AddedTime = addedTime;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                        det.ModifiedBy = loggedinuserId;
                        det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LiquidPreparationInstructionDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

                #region ChecklistDetails
                mappedModel.LiquidPreparationChecklistDetails.Clear();
                foreach (var list in model.liquidPreparationChecklistDetails)
                {
                    try
                    {
                        LiquidPreparationChecklistDetails det = new LiquidPreparationChecklistDetails();
                        _dataMapper.Map<LiquidPreparationChecklistDetailsAddEdit, LiquidPreparationChecklistDetails>(list, det);

                        det.Id = 0;
                        det.LiquidPreparationId = mappedModel.Id;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                        det.ModifiedBy = loggedinuserId;
                        det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LiquidPreparationChecklistDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

                #region SpecificationDetails
                mappedModel.LiquidPreparationSpecificationDetails.Clear();
                foreach (var list in model.liquidPreparationSpecificationDetails)
                {
                    try
                    {
                        LiquidPreparationSpecificationDetails det = new LiquidPreparationSpecificationDetails();
                        _dataMapper.Map<LiquidPreparationSpecificationDetailsAddEdit, LiquidPreparationSpecificationDetails>(list, det);

                        if (list.AnalysisDoneByList != null && list.AnalysisDoneByList.Count() > 0)
                        {
                            det.AnalysisDoneByIds = string.Join(",", list.AnalysisDoneByList);
                        }

                        det.Id = 0;// list.Id;
                        det.LiquidPreparationId = mappedModel.Id;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                        det.ModifiedBy = loggedinuserId;
                        det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LiquidPreparationSpecificationDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

                #region AdjustmentDetails
                mappedModel.LiquidPreparationAdjustmentDetails.Clear();
                foreach (var list in model.liquidPreparationAdjustmentDetails)
                {
                    try
                    {
                        LiquidPreparationAdjustmentDetails det = new LiquidPreparationAdjustmentDetails();
                        _dataMapper.Map<LiquidPreparationAdjustmentDetailsAddEdit, LiquidPreparationAdjustmentDetails>(list, det);
                        det.Id = 0;//list.Id;
                        det.LiquidPreparationId = mappedModel.Id;

                        //if(mappedModel.LiquidPreparationInstructionDetailsEntities != null && mappedModel.LiquidPreparationInstructionDetailsEntities.Count()> 0)
                        //{
                        //    var insData = mappedModel.LiquidPreparationInstructionDetailsEntities.Where(a => a.MaterialId == list.MaterialId && a.WeightAdded == list.Weight).FirstOrDefault();
                        //    det.LiquidPreparationInstructionId = mappedModel.LiquidPreparationInstructionDetailsEntities.Where(a => a.MaterialId == list.MaterialId && a.WeightAdded == list.Weight).FirstOrDefault().Id; //list.LiquidPreparationInstructionId;
                        //}

                        det.LiquidPreparationInstructionId = list.LiquidPreparationInstructionId;
                        det.CreatedBy = loggedinuserId;
                        det.CreatedDate = DateTime.Now;
                        det.ModifiedBy = loggedinuserId;
                        det.ModifiedDate = DateTime.Now;
                        det.IsActive = true;

                        mappedModel.LiquidPreparationAdjustmentDetails.Add(det);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion

              await  _liquidPreparationRepository.UpdateAsync(mappedModel);
               // await _unitOfWork.Save();
                await UpdateAdjustmentDetailsInstructionId(mappedModel.Id);
                return entity.Id;

            }

            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }

            // await _WeightCheckRepository.AddAsync(company);
        }

        private async Task<bool> UpdateAdjustmentDetailsInstructionId(long id)
        {
            try
            {
                var entity = await _liquidPreparationRepository.GetByIdAsync(id);
                foreach (var item in entity.LiquidPreparationAdjustmentDetails)
                {
                    if (item.MaterialId != null && item.Weight != null)
                    {
                        var data = entity.LiquidPreparationInstructionDetails.Where(a => a.MaterialId == item.MaterialId && a.WeightAdded == item.Weight).FirstOrDefault();
                        if (data != null)
                        {
                            item.LiquidPreparationInstructionId = data.Id;

                            await _liquidPreparationAdjustmentDetailsRepository.UpdateAsync(item);
                           //  _unitOfWork.Save();
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return true;
        }

        public async Task DeletLiquidPreparationAsync(long Id, long userId)
        {
            long loggedinuserId = _claimAccessorService.GetUserId();
            var entity = await _liquidPreparationRepository.GetByIdAsync(Id);
            entity.ModifiedBy = loggedinuserId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;
            await _liquidPreparationRepository.UpdateAsync(entity);

            //  return new ResponseModel { IsSuccess = true, Message = "Deleted Successfully." };
        }

    }
}
