using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductionOrderService : IProductionOrderService
    {
        private readonly IProductionOrderRepository _productionOrderRepository;
        private readonly IAutoMapperGenericDataMapper _dataMapper;
        private readonly IClaimAccessorService _claimAccessorService;
        public static string PathLogger;
        private readonly IConfiguration _configuration;
        private static string username = "";
        private static string password = "";
        private static string companyDb = "";
        private static string serviceLayerUrl = ""; // Use the external endpoint
        public static int tCt = 0;

        private readonly IAttributeCheckRepository _attributeCheckRepository;
        private readonly IWeightCheckRepository _weightCheckRepository;
        private readonly IWeightCheckService _weightCheckService;
        private readonly IPreCheckListRepository _preCheckListRepository;
        private readonly ILiquidPreparationRepository _liquidPreparationRepository;
        private readonly IPostCheckListRepository _postCheckListRepository;
        private readonly IPalletPackingRepository _palletPackingRepository;
        private readonly IProductMasterRepository _productMasterRepository;
        private readonly IProductMasterService _productMasterService;

        public ProductionOrderService(IProductionOrderRepository productionOrderRepository,
            IAutoMapperGenericDataMapper dataMapper, IClaimAccessorService claimAccessorService, 
            IConfiguration configuration, IAttributeCheckRepository attributeCheckRepository,
            IWeightCheckRepository weightCheckRepository, IPreCheckListRepository preCheckListRepository, ILiquidPreparationRepository liquidPreparationRepository
            , IPostCheckListRepository postCheckListRepository, IPalletPackingRepository palletPackingRepository,
            IProductMasterRepository productMasterRepository, IProductMasterService productMasterService, IWeightCheckService weightCheckService)
        {
            _productionOrderRepository = productionOrderRepository;
            _dataMapper = dataMapper;
            _claimAccessorService = claimAccessorService;
            _configuration = configuration;
            PathLogger = _configuration.GetSection("LogFilePath").Value;
            username = _configuration.GetSection("UserNameTest").Value;
            password = _configuration.GetSection("Password").Value;
            companyDb = _configuration.GetSection("CompanyDB").Value;
            serviceLayerUrl = _configuration.GetSection("ServiceLayer").Value;

            _attributeCheckRepository = attributeCheckRepository;
            _weightCheckRepository = weightCheckRepository;
            _weightCheckService = weightCheckService;
            _preCheckListRepository = preCheckListRepository;
            _liquidPreparationRepository = liquidPreparationRepository;
            _postCheckListRepository = postCheckListRepository;
            _palletPackingRepository = palletPackingRepository;
            _productMasterRepository = productMasterRepository;
            _productMasterService = productMasterService;
        }

        public IQueryable<ProductionOrderList> GetAllProductionOrderAsync()
        {
            var entities = _productionOrderRepository.Get(m => m.IsActive == true );
            var productionOrderLists = _dataMapper.Project<ProductionOrder, ProductionOrderList>(entities);
            return productionOrderLists.AsQueryable(); // Ensure you return IQueryable
        }

        public IQueryable<ProductionOrderList> GetPOByStatus(String status)
        {
            var entities = _productionOrderRepository.Get(m => m.IsActive == true && m.Status == status);
            var productionOrderLists = _dataMapper.Project<ProductionOrder, ProductionOrderList>(entities);
            return productionOrderLists.OrderByDescending(p => p.Id).AsQueryable(); // Ensure you return IQueryable
        }

        public async Task<ProductionOrderList> GetProductionOrderByIdAsync(long id)
        {
            var entity = await _productionOrderRepository.GetProductionOrderWithDetailsByIdAsync(id);
            if (entity == null)
                return null;

            return new ProductionOrderList
            {
                Id = entity.Id,
                Code = entity.Code,
                PONumber = entity.PONumber,
                PODate = entity.PODate,
                PlannedQty = entity.PlannedQty,
                ItemName = entity.ItemName,
                Status=entity.Status,

                // Map WeightChecks 
                WeightChecks = entity.WeightCheck.Select(wc => new WeightCheckList
                {
                    Id=wc.Id,
                    Code = wc.Code,
                    StartDateTime = wc.StartDateTime,
                    EndDateTime = wc.EndDateTime,
                    ProductId = wc.ProductId,
                    ProductName = wc.ProductMaster?.ProductName, 
                    ShiftName = wc.ShiftMaster?.ShiftName, 
                                                           
                }).ToList(),

                // Map AttributeChecks 
                AttributeChecks = entity.AttributeCheck.Select(ac => new AttributeCheckList
                {   
                    Id=ac.Id,
                    Code = ac.Code,
                    ACDate = ac.ACDate,
                    ProductId = ac.ProductId,
                    ProductName = ac.ProductMaster?.ProductName, 
                                                                 
                }).ToList(),

                // Map PreCheckListEntities 
                PreCheckListEntities = entity.PreCheckListEntity.Select(pre => new PreCheckList
                {
                    Id=pre.Id,
                    Code = pre.Code,
                    StartDateTime = pre.StartDateTime,
                    ProductId = pre.ProductId,
                    ProductName = pre.ProductMaster?.ProductName, 
                    ShiftName = pre.ShiftMaster?.ShiftName, 
                                                            
                }).ToList(),

                // Map PostCheckListEntities 
                PostCheckListEntities = entity.PostCheckListEntity.Select(post => new PostCheckList
                {   
                    Id = post.Id,
                    Code = post.Code,
                    EndDateTime = post.EndDateTime,
                    ProductId = post.ProductId,
                    ProductName = post.ProductMaster?.ProductName,
                    ShiftName = post.ShiftMaster?.ShiftName, 
                                                             
                }).ToList(),

                //PalletPackingList = entity.PalletPacking.Select(pp => new PalletPackingList
                //{
                //    Id = pp.Id,
                //    Code = pp.Code,
                //    PackingDateTime = pp.PackingDateTime,
                //    ProductId = pp.ProductId,
                //    ProductName = pp.ProductMaster?.ProductName,
                //    TotalCasesProduced = pp.TotalCasesProduced
                //    //ShiftName = post.ShiftMaster?.ShiftName,

                //}).ToList(),

                 LiquidPreparationList = entity.LiquidPreparation.Select(lp => new LiquidPreparationList
                 {
                     Id = lp.Id,
                     Code = lp.Code,
                     StartDateTime = lp.StartDateTime,
                     EndDateTime = lp.EndDateTime,
                     ProductName = lp.ProductMaster?.ProductName,
                     ShiftName = lp.ShiftMaster?.ShiftName,
                 }).ToList(),

                 DowntimeTrackingList = entity.DowntimeTracking.Select(lp => new DowntimeTrackingList
                 {
                     Id = lp.Id,
                     Code = lp.Code,
                     ProductionDateTime = lp.ProductionDateTime,
                    // EndDateTime = lp.EndDateTime,
                     ProductName = lp.ProductMaster?.ProductName,
                    // ShiftName = lp.ShiftMaster?.ShiftName,
                 }).ToList()
            };
        }
        public async Task<bool> ToggleProductionOrderStatusAsync(long id)
        {
            var entity = await _productionOrderRepository.GetProductionOrderWithDetailsByIdAsync(id);
            if (entity == null)
                return false;

            // Toggle status between "Open" and "Closed"
            entity.Status = entity.Status == "Open" ? "Closed" : "Open";

            // Save changes
            await _productionOrderRepository.UpdateAsync(entity);
            return true;
        }


        #region HangfireProductionOrder
        public async Task<ResponseModel> GetAllProductionOrdersFromSAP()
        {
            bool result = true;
            TraceService("--Start-- Step - 1 **** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
            var sessionId = await AuthenticateAsync();
            if (sessionId != null)
            {
                await FetchAllProductionOrdersAsync(sessionId);
            }

            return new ResponseModel { IsSuccess = true, Message = "Done" };
        }

        public static void TraceService(string content)
        {
            string FilePath = PathLogger; // ConfigurationManager.AppSettings["LogPath"];
            FilePath = FilePath + DateTime.Now.ToString("ddMMyyyy");
            try
            {
                FileStream fs = new FileStream(@"" + FilePath + ".txt", FileMode.OpenOrCreate, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(content);
                sw.Flush();
                sw.Close();
            }
            catch { }
        }

        private static async Task<string> AuthenticateAsync()
        {
            //flowCheck += $"--AuthenticateAsync-- Step - 2";
            TraceService("--AuthenticateAsync-- Step - 2  *** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
            try
            {
                using (var client = new HttpClient())
                {
                    var requestPayload = new
                    {
                        UserName = username,
                        Password = password,
                        CompanyDB = companyDb
                    };

                    TraceService("--AuthenticateAsync-- Step - 3  *** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                    var content = new StringContent(JObject.FromObject(requestPayload).ToString(), Encoding.UTF8, "application/json");
                    TraceService("--AuthenticateAsync-- Step - 4  *** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                    var response = await client.PostAsync($"{serviceLayerUrl}/Login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        //flowCheck += $"--Success!! Authenticated-- Step - 5";
                        TraceService("--Success!! Authenticated-- Step - 5  *** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                        var responseBody = await response.Content.ReadAsStringAsync();
                        //flowCheck += $"--Success!! Authenticated-- Step - 6";
                        TraceService("--Success!! Authenticated-- Step - 6  *** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                        var jsonResponse = JObject.Parse(responseBody);
                        //flowCheck += $"--Success!! Authenticated-- Step - 7 //// *** {jsonResponse} ***";
                        TraceService($"--Success!! Authenticated-- Step - 7  {jsonResponse} *** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                        return jsonResponse["SessionId"].ToString();
                    }
                    else
                    {
                        //flowCheck += $"--Error!! Authentication failed-- Step - 8";
                        TraceService($"--Error!! Authentication failed-- Step - 8 (UserName:{username}||Pass:{password}) *** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                        Console.WriteLine("Authentication failed.");
                        return null;
                    }
                }
            }
            catch (Exception ee)
            {
                TraceService($"--Error Catch Part: {ee.Message} *** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                return null;
            }
        }

        private async Task FetchAllProductionOrdersAsync(string sessionId)
        {
            TraceService($"--Fetching Data : SessionId : {sessionId} **** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Cookie", $"B1SESSION={sessionId}");

                // Initial request to get the total count of production orders
                var initialResponse = await client.GetAsync($"{serviceLayerUrl}/ProductionOrders/$count");
                if (initialResponse.IsSuccessStatusCode)
                {
                    var totalCount = await initialResponse.Content.ReadAsStringAsync();
                    int totalOrders;
                    if (int.TryParse(totalCount, out totalOrders))
                    {
                        int pageSize = 100; // Adjust this value as per your requirement
                        int totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);

                        // Loop through all pages and fetch production orders
                        for (int page = 1; page <= totalPages; page++)
                        {
                            var response = await client.GetAsync($"{serviceLayerUrl}/ProductionOrders?$top={pageSize}&$skip={(page - 1) * pageSize}");
                            if (response.IsSuccessStatusCode)
                            {
                                var responseBody = await response.Content.ReadAsStringAsync();
                                //TraceService($"--Data Fetched - Page No:{page} ***** {responseBody}***** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                                var test = await ParseAndDisplayProductionOrders(responseBody);
                            }
                            else
                            {
                                TraceService("--Failed to fetch production orders**** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                                Console.WriteLine("Failed to fetch production orders.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        TraceService("--Failed to parse total count of production orders**** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                        Console.WriteLine("Failed to parse total count of production orders.");
                    }
                }
                else
                {
                    TraceService("--Failed to fetch total count of production orders**** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
                    Console.WriteLine("Failed to fetch total count of production orders.");
                }
            }

            TraceService("--Data Fetched**** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
        }

        public async Task<bool> ParseAndDisplayProductionOrders(string responseBody)
        {
            var jsonResponse = JObject.Parse(responseBody);
            var productionOrders = jsonResponse["value"];
            var allProductionData = _productionOrderRepository.Get();
            foreach (var order in productionOrders)
            {
                string itemNo = order["ItemNo"].ToString();
                string poNum = order["DocumentNumber"].ToString();
                string productName = order["ProductDescription"].ToString();
                string UOM = order["InventoryUOM"]?.ToString();
                DateTime poDate = DateTime.Now;
                try
                {
                    poDate = order["CreationDate"] != null && order["CreationDate"].ToString() != "" ? Convert.ToDateTime(order["CreationDate"]) : DateTime.Now;
                }
                catch { }
                long productId = 0;
                long productionOrderId = 0;
                if (allProductionData.Where(a => a.PONumber == poNum && a.IsActive == true) == null || allProductionData.Where(a => a.PONumber == poNum && a.IsActive == true).Count() == 0)
                {
                    try
                    {
                        #region ProductRelated
                        var proData = _productMasterRepository.Get(a => a.ItemNo == itemNo && a.IsActive == true).FirstOrDefault();
                        if (proData != null && proData.Id != null && proData.Id != 0)
                        {
                            //Product Already Added (Get Id)
                            productId = proData.Id;
                        }
                        else
                        {
                            //Product Insert
                            ProductMaster proEntity = new ProductMaster();
                            proEntity.ProductName = productName;
                            proEntity.ItemNo = itemNo;
                            proEntity.CreatedBy = 1;
                            proEntity.CreatedDate = DateTime.Now;
                            proEntity.ModifiedBy = 1;
                            proEntity.ModifiedDate = DateTime.Now;
                            proEntity.IsActive = true;
                            proEntity.UOM = UOM;
                            proEntity.ProductCode = await GenerateProductCode();
                            await _productMasterRepository.AddAsync(proEntity);
                          //  await _unitOfWork.Save();
                            productId = proEntity.Id;
                        }
                        #endregion
                    }
                    catch { }

                    try
                    {
                        #region ProductionOrder

                        //Production Order Details Save
                        ProductionOrder mappedModel = new ProductionOrder();
                        mappedModel.InventoryUOM = order["InventoryUOM"]?.ToString();
                        mappedModel.PONumber = order["DocumentNumber"].ToString();
                        mappedModel.ItemNo = order["ItemNo"].ToString();
                        mappedModel.PlannedQty = order["PlannedQuantity"] != null && order["PlannedQuantity"].ToString() != "" ? Convert.ToDecimal(order["PlannedQuantity"]) : decimal.Zero;
                        mappedModel.PODate = poDate;
                        mappedModel.PONumber = order["DocumentNumber"].ToString();
                        mappedModel.ItemName = order["ProductDescription"].ToString();
                        mappedModel.ProductId = productId;
                        mappedModel.CreatedBy = 1;
                        mappedModel.CreatedDate = DateTime.Now;
                        mappedModel.ModifiedBy = 1;
                        mappedModel.ModifiedDate = DateTime.Now;
                        mappedModel.IsActive = true;
                        mappedModel.Code = await GenerateCode();
                        var dataProduction = _productionOrderRepository.AddAsync(mappedModel);
                       // await _unitOfWork.Save();
                        productionOrderId = mappedModel.Id;

                        #endregion
                    }
                    catch { }

                    try
                    {
                        #region AttributeCheck
                        if (_attributeCheckRepository.Get(a => a.ProductionOrderId == productionOrderId && a.ProductId == productId && a.IsActive).Any())
                        {
                            //return;
                        }
                        else
                        {
                            AttributeCheck attEntity = new AttributeCheck();
                            attEntity.Code = await GenerateAttributeCheckCode();
                            attEntity.ProductionOrderId = productionOrderId;
                            attEntity.ProductId = productId;
                            attEntity.ACDate = poDate;
                            attEntity.CreatedBy = 1;
                            attEntity.CreatedDate = DateTime.Now;
                            attEntity.ModifiedBy = 1;
                            attEntity.ModifiedDate = DateTime.Now;
                            attEntity.IsActive = true;
                            await _attributeCheckRepository.AddAsync(attEntity);
                           // await _unitOfWork.Save();
                        }
                        #endregion
                    }
                    catch { }

                    try
                    {
                        #region WeightCheck
                        if (_weightCheckRepository.Get(a => a.SAPProductionOrderId == productionOrderId && a.ProductId == productId && a.IsActive).Any())
                        {
                            //return;
                        }
                        else
                        {
                            WeightCheck weightEntity = new WeightCheck();
                            weightEntity.CreatedBy = 1;
                            weightEntity.CreatedDate = DateTime.Now;
                            weightEntity.ModifiedBy = 1;
                            weightEntity.ModifiedDate = DateTime.Now;
                            weightEntity.IsActive = true;
                            weightEntity.Code = await GenerateWeightCheckCode();
                            weightEntity.ProductId = productId;
                            weightEntity.SAPProductionOrderId = productionOrderId;
                            await _weightCheckRepository.AddAsync(weightEntity);
                           // await _unitOfWork.Save();
                        }
                        #endregion
                    }
                    catch { }

                    try
                    {
                        #region LiquidPreparation
                        if (_liquidPreparationRepository.Get(a => a.SAPProductionOrderId == productionOrderId && a.ProductId == productId && a.IsActive).Any())
                        {
                            //return;
                        }
                        else
                        {
                            LiquidPreparation LPEntity = new LiquidPreparation();
                            LPEntity.CreatedBy = 1;
                            LPEntity.CreatedDate = DateTime.Now;
                            LPEntity.ModifiedBy = 1;
                            LPEntity.ModifiedDate = DateTime.Now;
                            LPEntity.IsActive = true;
                            LPEntity.ProductId = productId;
                            LPEntity.SAPProductionOrderId = productionOrderId;
                            LPEntity.Code = await GenerateLiquidPrepCode();
                            await _liquidPreparationRepository.AddAsync(LPEntity);
                           // await _unitOfWork.Save();
                        }
                        #endregion
                    }
                    catch { }

                    try
                    {
                        #region PreChecklist
                        if (_preCheckListRepository.Get(a => a.ProductionOrderId == productionOrderId && a.ProductId == productId && a.IsActive).Any())
                        {
                            //return;
                        }
                        else
                        {
                            PreCheckListEntity preEntity = new PreCheckListEntity();
                            preEntity.Code = await GeneratePreCode();
                            preEntity.CreatedBy = 1;
                            preEntity.CreatedDate = DateTime.Now;
                            preEntity.ModifiedBy = 1;
                            preEntity.ModifiedDate = DateTime.Now;
                            preEntity.IsActive = true;
                            preEntity.FillingLine = 0;
                            preEntity.ShiftId = 0;
                            preEntity.FillerUserIds = "";
                            preEntity.ProductId = productId;
                            preEntity.ProductionOrderId = productionOrderId;
                            await _preCheckListRepository.AddAsync(preEntity);
                           // await _unitOfWork.Save();
                        }
                        #endregion
                    }
                    catch { }

                    try
                    {
                        #region PostChecklist
                        if (_postCheckListRepository.Get(a => a.ProductionOrderId == productionOrderId && a.ProductId == productId && a.IsActive).Any())
                        {
                            //return;
                        }
                        else
                        {
                            PostCheckListEntity postEntity = new PostCheckListEntity();
                            postEntity.Code = await GeneratePostCode();
                            postEntity.CreatedBy = 1;
                            postEntity.CreatedDate = DateTime.Now;
                            postEntity.ModifiedBy = 1;
                            postEntity.ModifiedDate = DateTime.Now;
                            postEntity.IsActive = true;
                            postEntity.FillingLine = 0;
                            postEntity.ShiftId = 0;
                            postEntity.ProductId = productId;
                            postEntity.FillerUserIds = "";
                            postEntity.ProductionOrderId = productionOrderId;
                            await _postCheckListRepository.AddAsync(postEntity);
                         //   await _unitOfWork.Save();
                        }
                        #endregion
                    }
                    catch { }
                    try
                    {
                        #region PalletPacking
                        if (_palletPackingRepository.Get(a => a.SAPProductionOrderId == productionOrderId && a.ProductId == productId && a.IsActive).Any())
                        {

                        }
                        else
                        {
                            PalletPacking palletEntity = new PalletPacking();
                            palletEntity.CreatedBy = 1;
                            palletEntity.CreatedDate = DateTime.Now;
                            palletEntity.ModifiedBy = 1;
                            palletEntity.ModifiedDate = DateTime.Now;
                            palletEntity.IsActive = true;
                            palletEntity.Code = await GeneratePalletPackingCode();
                            palletEntity.ProductId = productId;
                            palletEntity.SAPProductionOrderId = productionOrderId;
                            await _palletPackingRepository.AddAsync(palletEntity);
                          //  await _unitOfWork.Save();
                        }
                        #endregion
                    }
                    catch { }
                }
                tCt++;
                TraceService($"--Data Fetched Final**** {tCt}.-> PO Number: {order["DocumentNumber"]}***** " + DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
            }
            return true;
        }


        #region GenerateCodes
        // ProductionOrder code
        private async Task<string> GenerateCode()
        {
            string code = "";
            var ct = _productionOrderRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"PO" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<string> GenerateProductCode()
        {
            string code = "";
            var ct = _productMasterRepository.Get().Select(a => a.ProductCode).Distinct().ToList().Count;

            code = $"PRO" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<string> GenerateAttributeCheckCode()
        {
            string code = "";

            var riskCount = _attributeCheckRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"AC" + (riskCount + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<string> GenerateWeightCheckCode()
        {
            string code = "";
            var ct = _weightCheckRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"WTC" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<string> GenerateLiquidPrepCode()
        {
            string code = "";
            var ct = _liquidPreparationRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"LP" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<string> GeneratePreCode()
        {
            string code = "";

            var riskCount = _preCheckListRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"Pre" + (riskCount + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<string> GeneratePostCode()
        {
            string code = "";

            var riskCount = _postCheckListRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"Post" + (riskCount + 1).ToString("0000000");

            return code.ToUpper();
        }

        public async Task<string> GeneratePalletPackingCode()
        {
            string code = "";
            var ct = _palletPackingRepository.Get().Select(a => a.Code).Distinct().ToList().Count;

            code = $"PP" + (ct + 1).ToString("0000000");

            return code.ToUpper();
        }
        #endregion
        #endregion

    }
}
