using SMDCheckSheet.Data;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SMDCheckSheet.Services
{
    public class ChangeModelService
    {
        private readonly AppDbContext _context;
        private readonly CheckModelService _checkModelService;
        private readonly ProgramCheckService _programCheckService;
        private readonly StandardProductionService _standardProductionService;
        private readonly StandardVehicleService _standardVehicleService;
        private readonly TimeChangeModelService _timeChangeModelService;
        private readonly PQCCheckService _pqcCheckService;
        private readonly AccountService _accountService;
        private readonly AzureBlobService _blobService;

        public ChangeModelService(
            AppDbContext context,
            CheckModelService checkModelService,
            ProgramCheckService programCheckService,
            StandardProductionService standardProductionService,
            StandardVehicleService standardVehicleService,
            TimeChangeModelService timeChangeModelService,
            PQCCheckService pqcCheckService,
            AccountService accountService,
            AzureBlobService blobService)
        {
            _context = context;
            _checkModelService = checkModelService;
            _programCheckService = programCheckService;
            _standardProductionService = standardProductionService;
            _standardVehicleService = standardVehicleService;
            _timeChangeModelService = timeChangeModelService;
            _pqcCheckService = pqcCheckService;
            _accountService = accountService;
            _blobService = blobService;
        }

        public async Task<IEnumerable<ChangeModelReadDto>> GetAllAsync()
        {
            return await _context.ChangeModels
                .Select(c => new ChangeModelReadDto
                {
                    Id = c.Id,
                    CheckModelId = c.CheckModelId,
                    ProgramCheckId = c.ProgramCheckId,
                    StandardProductionId = c.StandardProductionId,
                    StandardVehicleId = c.StandardVehicleId,
                    TimeChangeModelId = c.TimeChangeModelId,
                    PQCCheckId = c.PQCCheckId,
                    ExcelFileUrl  = c.ExcelFileUrl,
                    PdfFileUrl  = c.PdfFileUrl,
                    Status = c.Status,
                    AccountId = c.AccountId,
                    CreateAt = c.CreateAt
                }).ToListAsync();
        }

        public async Task<ChangeModelReadObjectDto?> GetAllWithObjectAsync(int id)
        {
            var c = await _context.ChangeModels
                .Include(x => x.CheckModel)
                .Include(x => x.ProgramCheck)
                .Include(x => x.StandardProduction)
                .Include(x => x.StandardVehicle)
                .Include(x => x.TimeChangeModel)
                .Include(x => x.PQCCheck)
                .Include(x => x.Account)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (c == null) return null;

            return new ChangeModelReadObjectDto
            {
                Id = c.Id,
                Status = c.Status,
                ExcelFileUrl = c.ExcelFileUrl,
                PdfFileUrl = c.PdfFileUrl,
                CreateAt = c.CreateAt,
                Account = new Account
                {
                    Id = c.Account.Id,
                    Username = c.Account.Username,
                    Role = c.Account.Role,
                    IsActive = c.Account.IsActive
                },
                CheckModel = new CheckModel
                {
                    Id = c.CheckModel.Id,
                    LineChange = c.CheckModel.LineChange,
                    Model = c.CheckModel.Model,
                    FCode = c.CheckModel.FCode,
                    PCBver = c.CheckModel.PCBver,
                    WorkOrder = c.CheckModel.WorkOrder, 
                    UsedCNcard = c.CheckModel.UsedCNcard,
                    RevS15 = c.CheckModel.RevS15,
                    RevMounter = c.CheckModel.RevMounter,
                    Qty = c.CheckModel.Qty,
                    FeederCheck = c.CheckModel.FeederCheck,
                    OPAccept = c.CheckModel.OPAccept,
                    JIG = c.CheckModel.JIG,
                    CodePCB = c.CheckModel.CodePCB
                },
                ProgramCheck = new ProgramCheck
                {
                    Id = c.ProgramCheck.Id,
                    PrinterProgram = c.ProgramCheck.PrinterProgram,
                    SPIProgram = c.ProgramCheck.SPIProgram,
                    MounterProgram = c.ProgramCheck.MounterProgram,
                    PointMounter = c.ProgramCheck.PointMounter,
                    MAOIProgram = c.ProgramCheck.MAOIProgram,
                    SAOIProgram = c.ProgramCheck.SAOIProgram,
                    PointSAOI = c.ProgramCheck.PointSAOI,
                    ReflowProgram = c.ProgramCheck.ReflowProgram,
                    ReflowSpeed = c.ProgramCheck.ReflowSpeed
                },
                PQCCheck = new PQCCheck
                {
                    Id = c.PQCCheck.Id,
                    ICPlan = c.PQCCheck.ICPlan,
                    ChecksumReal = c.PQCCheck.ChecksumReal,
                    ChecksumConfirm = c.PQCCheck.ChecksumConfirm,
                    Turner = c.PQCCheck.Turner,
                    StartLCR = c.PQCCheck.StartLCR,
                    EndLCR = c.PQCCheck.EndLCR,
                    NameCheck = c.PQCCheck.NameCheck,
                    ResultLCR = c.PQCCheck.ResultLCR
                },
                StandardProduction = new StandardProduction
                {
                    Id = c.StandardProduction.Id,
                    NumMASK = c.StandardProduction.NumMASK,
                    NumMES = c.StandardProduction.NumMES,
                    NumScanPrinter = c.StandardProduction.NumScanPrinter,
                    NumScanSignMES = c.StandardProduction.NumScanSignMES,
                    MLS3Closed = c.StandardProduction.MLS3Closed,
                    UseOnly = c.StandardProduction.UseOnly,
                    LabelProgram = c.StandardProduction.LabelProgram
                },
                StandardVehicle = new StandardVehicle
                {
                    Id = c.StandardVehicle.Id,
                    PrinterSpecGTAL = c.StandardVehicle.PrinterSpecGTAL,
                    PrinterSpecTDQ = c.StandardVehicle.PrinterSpecTDQ,
                    PrinterSpecTDKC = c.StandardVehicle.PrinterSpecTDKC,
                    PrinterSpecDSL = c.StandardVehicle.PrinterSpecDSL,
                    PrinterRealGTAL = c.StandardVehicle.PrinterRealGTAL,
                    PrinterRealTDQ = c.StandardVehicle.PrinterRealTDQ,
                    PrinterRealTDKC = c.StandardVehicle.PrinterRealTDKC,
                    PrinterRealDSL = c.StandardVehicle.PrinterRealDSL,
                    PrinterQ1 = c.StandardVehicle.PrinterQ1,
                    SPIQ1 = c.StandardVehicle.SPIQ1,
                    MountQ1 = c.StandardVehicle.MountQ1,
                    MountQ2 = c.StandardVehicle.MountQ2,
                    ReflowQ1 = c.StandardVehicle.ReflowQ1,
                    ReFlowSettingRail = c.StandardVehicle.ReFlowSettingRail,
                    ReFlowRealRail = c.StandardVehicle.ReFlowRealRail,
                    AOIQ1 = c.StandardVehicle.AOIQ1,
                    AOICheck = c.StandardVehicle.AOICheck,
                    OutputCheck = c.StandardVehicle.OutputCheck,
                    ModelValue = c.StandardVehicle.ModelValue,
                    PitchValue = c.StandardVehicle.PitchValue,
                    PitchReal = c.StandardVehicle.PitchReal,
                    NameOP = c.StandardVehicle.NameOP,
                    NameAOI = c.StandardVehicle.NameAOI
                },
                TimeChangeModel =  new TimeChangeModel
                {
                    Id = c.TimeChangeModel.Id,
                    QC = c.TimeChangeModel. QC,
                    Result = c.TimeChangeModel. Result,
                    StartTime = c.TimeChangeModel. StartTime,
                    EndTime = c.TimeChangeModel. EndTime,
                    CountTime = c.TimeChangeModel. CountTime,
                    History = c.TimeChangeModel. History
                }
            };
        }

        public async Task<IEnumerable<ChangeModelReadDto>> GetByStatusAsync(string status)
        {
            var c = await _context.ChangeModels.FirstOrDefaultAsync(x => x.Status == status);
            if (c == null) return null;

            return new List<ChangeModelReadDto>
            {
                new ChangeModelReadDto
                {
                Id = c.Id,
                CheckModelId = c.CheckModelId,
                ProgramCheckId = c.ProgramCheckId,
                StandardProductionId = c.StandardProductionId,
                StandardVehicleId = c.StandardVehicleId,
                TimeChangeModelId = c.TimeChangeModelId,
                PQCCheckId = c.PQCCheckId,
                ExcelFileUrl  = c.ExcelFileUrl,
                PdfFileUrl  = c.PdfFileUrl,
                CreateAt = c.CreateAt,
                AccountId = c.AccountId,
                Status = c.Status
                }
            };
        }

        public async Task<ChangeModelReadDto?> GetByIdAsync(int id)
        {
            var c = await _context.ChangeModels.FindAsync(id);
            if (c == null) return null;

            return new ChangeModelReadDto
            {
                Id = c.Id,
                CheckModelId = c.CheckModelId,
                ProgramCheckId = c.ProgramCheckId,
                StandardProductionId = c.StandardProductionId,
                StandardVehicleId = c.StandardVehicleId,
                TimeChangeModelId = c.TimeChangeModelId,
                PQCCheckId = c.PQCCheckId,
                ExcelFileUrl  = c.ExcelFileUrl,
                PdfFileUrl  = c.PdfFileUrl,
                CreateAt = c.CreateAt,
                AccountId = c.AccountId,
                Status = c.Status
            };
        }

        public async Task<ChangeModelReadDto> CreateAsync(ChangeModelCreateDto dto, int accountId)
        {
            var checkModel = await _checkModelService.CreateEmptyAsync();
            var programCheck = await _programCheckService.CreateEmptyAsync();
            var standardProduction = await _standardProductionService.CreateEmptyAsync();
            var standardVehicle = await _standardVehicleService.CreateEmptyAsync();
            var timeChangeModel = await _timeChangeModelService.CreateEmptyAsync();
            var pqcCheck = await _pqcCheckService.CreateEmptyAsync();


            var c = new ChangeModel
            {
                CheckModelId = checkModel.Id,
                ProgramCheckId = programCheck.Id,
                StandardProductionId = standardProduction.Id,
                StandardVehicleId = standardVehicle.Id,
                TimeChangeModelId = timeChangeModel.Id,
                PQCCheckId = pqcCheck.Id,
                ExcelFileUrl = dto.ExcelFileUrl ?? "",
                PdfFileUrl = dto.PdfFileUrl ?? "",
                Status = dto.Status,
                CreateAt = DateTime.Now,
                AccountId = accountId
            };

            _context.ChangeModels.Add(c);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(c.Id) ?? throw new Exception("Create failed");
        }

        public async Task<ChangeModel?> UpdateStatusAsync( int id, string status)
        {
            var model = await _context.ChangeModels.FindAsync(id);
            if (model == null)  return null;

            model.Status = status;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<string> UploadFileAsync(IFormFile file, int changeModelId)
        {
            var changeModel = await _context.ChangeModels.FindAsync(changeModelId);
            if (changeModel == null) throw new Exception("Không tìm thấy ChangeModel.");

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var stream = file.OpenReadStream();
            var fileUrl = await _blobService.UploadAsync(fileName, stream);

            if (file.ContentType == "application/pdf")
                changeModel.PdfFileUrl = fileUrl;
            else if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                changeModel.ExcelFileUrl = fileUrl;

            await _context.SaveChangesAsync();
            return fileUrl;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var c = await _context.ChangeModels.FindAsync(id);
            if (c == null) return false;

            _context.ChangeModels.Remove(c);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ChangeModelReadDto>> FilterByDateAsync(DateTime fromDate, DateTime toDate)
        {
            var query = _context.ChangeModels
                .Where(cm => cm.CreateAt >= fromDate && cm.CreateAt <= toDate);

            return await query.Select(cm => new ChangeModelReadDto
            {
                Id = cm.Id,
                CheckModelId = cm.CheckModelId,
                ProgramCheckId = cm.ProgramCheckId,
                StandardProductionId = cm.StandardProductionId,
                StandardVehicleId = cm.StandardVehicleId,
                TimeChangeModelId = cm.TimeChangeModelId,
                PQCCheckId = cm.PQCCheckId,
                Status = cm.Status,
                ExcelFileUrl = cm.ExcelFileUrl,
                PdfFileUrl = cm.PdfFileUrl,
                AccountId = cm.AccountId,
                CreateAt = cm.CreateAt
            }).ToListAsync();
        }

        public async Task<IEnumerable<ChangeModelReadDto>> GetByWorkOrderAsync(string workOrder)
        {
            var query = _context.ChangeModels
                .Include(cm => cm.CheckModel) // load CheckModel để truy cập WorkOrder
                .Where(cm => cm.CheckModel.WorkOrder == workOrder);

            return await query.Select(cm => new ChangeModelReadDto
            {
                Id = cm.Id,
                CheckModelId = cm.CheckModelId,
                ProgramCheckId = cm.ProgramCheckId,
                StandardProductionId = cm.StandardProductionId,
                StandardVehicleId = cm.StandardVehicleId,
                TimeChangeModelId = cm.TimeChangeModelId,
                PQCCheckId = cm.PQCCheckId,
                Status = cm.Status,
                ExcelFileUrl = cm.ExcelFileUrl,
                PdfFileUrl = cm.PdfFileUrl,
                AccountId = cm.AccountId,
                CreateAt = cm.CreateAt
            }).ToListAsync();
        }
    }
}
