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
    public class AttributeCheckService : IAttributeCheckService
    {
        private readonly IAttributeCheckRepository _attributeCheckRepository;
        private readonly IAttributeCheckDetailsRepository _attributeCheckDetailRepository;
        private readonly IMapper _dataMapper;

        public AttributeCheckService(IAttributeCheckRepository attributeCheckRepository,
                                     IAttributeCheckDetailsRepository attributeCheckDetailRepository,
                                     IMapper dataMapper)
        {
            _attributeCheckRepository = attributeCheckRepository;
            _attributeCheckDetailRepository = attributeCheckDetailRepository;
            _dataMapper = dataMapper;
        }

        public async Task<IEnumerable<AttributeCheckList>> GetAllAttributeCheckAsync()
        {
            var entities = await _attributeCheckRepository.GetAllAsync(); // Assuming GetAllAsync is implemented in your repository
            var result = _dataMapper.Map<IEnumerable<AttributeCheck>, IEnumerable<AttributeCheckList>>(entities);
            return result;
        }


        public async Task<AttributeCheckAddEdit> GetAttributeCheckByIdAsync(long id)
        {
            var entity = await _attributeCheckRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            // Manually load the related AttributeCheckDetails if not already included
            var details = await _attributeCheckDetailRepository.GetAllAsync(); // Get all details from the repository
            var attributeCheckDetails = details.Where(d => d.HeaderId == id).ToList();

            // Assign the related details to the entity
            entity.AttributeCheckDetails = attributeCheckDetails;

            // Map the entity to the view model
            var result = _dataMapper.Map<AttributeCheck, AttributeCheckAddEdit>(entity);
            return result;
        }


        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _attributeCheckRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"ATC" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<long> AddAttributeCheckAsync(AttributeCheckAddEdit model, long userId)
        {
            try
            {
                var mappedModel = _dataMapper.Map<AttributeCheck>(model);
                mappedModel.CreatedBy = userId;
                mappedModel.CreatedDate = DateTime.Now;
                mappedModel.ModifiedBy = userId;
                mappedModel.ModifiedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                #region Details
                mappedModel.AttributeCheckDetails.Clear();
                foreach (var list in model.AttributeCheckDetails)
                {
                    AttributeCheckDetails det = new AttributeCheckDetails();
                    _dataMapper.Map<AttributeCheckDetailsAddEdit, AttributeCheckDetails>(list, det);

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
                    mappedModel.AttributeCheckDetails.Add(det);
                }
                #endregion

                await _attributeCheckRepository.AddAsync(mappedModel);
                return mappedModel.Id;
            }
            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }
        }

        public async Task<long> UpdateAttributeCheckAsync(AttributeCheckAddEdit model, long userId)
        {
            try
            {
                var entity = await _attributeCheckRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;

                if (entity.AttributeCheckDetails != null)
                {
                    foreach (var detailEntity in entity.AttributeCheckDetails)
                    {
                        _attributeCheckDetailRepository.DeleteEntity(detailEntity);
                    }
                }

                entity.ModifiedBy = userId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<AttributeCheckAddEdit, AttributeCheck>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;

                #region Details
                mappedModel.AttributeCheckDetails.Clear();
                foreach (var list in model.AttributeCheckDetails)
                {
                    AttributeCheckDetails det = new AttributeCheckDetails();
                    _dataMapper.Map<AttributeCheckDetailsAddEdit, AttributeCheckDetails>(list, det);

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
                    mappedModel.AttributeCheckDetails.Add(det);
                }
                #endregion

                await _attributeCheckRepository.UpdateAsync(mappedModel);
                return entity.Id;
            }
            catch (Exception ex)
            {
                return await Task.Run(() => 0);
            }
        }

        public async Task DeleteAttributeCheckAsync(long id, long userId)
        {
            var entity = await _attributeCheckRepository.GetByIdAsync(id);
            entity.ModifiedBy = userId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;
            await _attributeCheckRepository.UpdateAsync(entity);
        }
    }
}
