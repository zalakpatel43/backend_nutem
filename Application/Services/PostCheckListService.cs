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
    public class PostCheckListService : IPostCheckListService
    {
        private readonly IPostCheckListRepository _postCheckListRepository;
        private readonly IPostCheckListDetailRepository _postCheckListDetailRepository;
        private readonly IMapper _dataMapper;
        private readonly IClaimAccessorService _claimAccessorService;

        public PostCheckListService(IPostCheckListRepository postCheckListRepository,
                                    IPostCheckListDetailRepository postCheckListDetailRepository,
                                    IMapper dataMapper,
                                    IClaimAccessorService claimAccessorService)
        {
            _postCheckListRepository = postCheckListRepository;
            _postCheckListDetailRepository = postCheckListDetailRepository;
            _dataMapper = dataMapper;
            _claimAccessorService = claimAccessorService;
        }

        public async Task<IEnumerable<PostCheckList>> GetAllPostCheckListAsync()
        {
            var entities = await _postCheckListRepository.GetAllAsync();

            // Map entities to PostCheckList view models
            var result = entities.Select(entity => new PostCheckList
            {
                Id = entity.Id,
                Code = entity.Code,
                EndDateTime = entity.EndDateTime,
                ProductionOrderId = entity.ProductionOrderId,
                ProductId = entity.ProductId,
                ProductName = entity.ProductMaster?.ProductName, // Map the ProductName from ProductMaster entity
                ShiftId = entity.ShiftId,
                ShiftName = entity.ShiftMaster?.ShiftName,       // Map the ShiftName from ShiftMaster entity
                FillingLine = entity.FillingLine,
                FillingLineNumber = entity.Masters?.Name,
                FillerUserIds = entity.FillerUserIds,
                Comments = entity.Comments,
                IsActive = entity.IsActive
            }).ToList();

            return result;
        }

        public async Task<PostCheckListAddEdit> GetPostCheckListByIdAsync(long id)
        {
            var entity = await _postCheckListRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            // Manually load the related PostCheckListDetails if not already included
            var details = await _postCheckListDetailRepository.GetAllAsync(); // Get all details from the repository
            var postCheckListDetails = details.Where(d => d.PostCheckListId == id).ToList();

            // Assign the related details to the entity
            entity.PostCheckListDetails = postCheckListDetails;

            // Map the entity to the view model
            var result = _dataMapper.Map<PostCheckListEntity, PostCheckListAddEdit>(entity);
            return result;
        }

        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _postCheckListRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"PSTCL" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<long> AddPostCheckListAsync(PostCheckListAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                var mappedModel = _dataMapper.Map<PostCheckListEntity>(model);
                mappedModel.CreatedBy = loggedinuserId;
                mappedModel.CreatedDate = DateTime.Now;
              //  mappedModel.ModifiedBy = userId;
              //  mappedModel.ModifiedDate = DateTime.Now;
                mappedModel.IsActive = true;
                mappedModel.Code = await GenerateCode();

                // Save the PostCheckListEntity first to generate its ID
                await _postCheckListRepository.AddAsync(mappedModel);

                #region Details
                // Now that the PostCheckListEntity is saved, the Id is generated
                foreach (var list in model.PostCheckListDetails)
                {
                    PostCheckListDetailEntity det = new PostCheckListDetailEntity();
                    _dataMapper.Map<PostCheckListDetailAddEdit, PostCheckListDetailEntity>(list, det);

                    det.HeaderId = mappedModel.Id;  // Assign the generated Id
                    det.CreatedBy = loggedinuserId;
                    det.CreatedDate = DateTime.Now;
                   // det.ModifiedBy = userId;
                   // det.ModifiedDate = DateTime.Now;
                    det.IsActive = true;
                    await _postCheckListDetailRepository.AddAsync(det);
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

        public async Task<long> UpdatePostCheckListAsync(PostCheckListAddEdit model, long userId)
        {
            try
            {
                long loggedinuserId = _claimAccessorService.GetUserId();
                var entity = await _postCheckListRepository.GetByIdAsync(model.Id);
                string code = entity.Code;
                bool isActive = entity.IsActive;

                if (entity.PostCheckListDetails != null)
                {
                    foreach (var detailEntity in entity.PostCheckListDetails)
                    {
                        _postCheckListDetailRepository.DeleteEntity(detailEntity);
                    }
                }

                entity.ModifiedBy = loggedinuserId;
                entity.ModifiedDate = DateTime.Now;
                var mappedModel = _dataMapper.Map<PostCheckListAddEdit, PostCheckListEntity>(model, entity);
                mappedModel.Code = code;
                mappedModel.IsActive = isActive;

                #region Details
                mappedModel.PostCheckListDetails.Clear();
                foreach (var list in model.PostCheckListDetails)
                {
                    PostCheckListDetailEntity det = new PostCheckListDetailEntity();
                    _dataMapper.Map<PostCheckListDetailAddEdit, PostCheckListDetailEntity>(list, det);

                    det.HeaderId = mappedModel.Id;
                    det.CreatedBy = loggedinuserId;
                    det.CreatedDate = DateTime.Now;
                    det.ModifiedBy = loggedinuserId;
                    det.ModifiedDate = DateTime.Now;
                    det.IsActive = true;
                    mappedModel.PostCheckListDetails.Add(det);
                }
                #endregion

                await _postCheckListRepository.UpdateAsync(mappedModel);
                return entity.Id;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., logging)
                return await Task.Run(() => 0);
            }
        }

        public async Task DeletePostCheckListAsync(long id, long userId)
        {
            long loggedinuserId = _claimAccessorService.GetUserId();
            var entity = await _postCheckListRepository.GetByIdAsync(id);
            entity.ModifiedBy = loggedinuserId;
            entity.ModifiedDate = DateTime.Now;
            entity.IsActive = false;
            await _postCheckListRepository.UpdateAsync(entity);
        }
    }
}
