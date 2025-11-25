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

        public ChangeModelService(
            AppDbContext context,
            CheckModelService checkModelService,
            ProgramCheckService programCheckService,
            StandardProductionService standardProductionService,
            StandardVehicleService standardVehicleService,
            TimeChangeModelService timeChangeModelService,
            PQCCheckService pqcCheckService)
        {
            _context = context;
            _checkModelService = checkModelService;
            _programCheckService = programCheckService;
            _standardProductionService = standardProductionService;
            _standardVehicleService = standardVehicleService;
            _timeChangeModelService = timeChangeModelService;
            _pqcCheckService = pqcCheckService;
        }

        public async Task<IEnumerable<ChangeModelReadDto>> GetAllAsync()
        {
            return await _context.ChangeModels
                .Select(c => new ChangeModelReadDto
                {
                    Id = c.Id,
                    CheckModelId = c.CheckModelId,
                    ProgramCheckId = c.ProgramCheckId,
                    StandardProductId = c.StandardProductId,
                    StandardVehicleId = c.StandardVehicleId,
                    TimeChangeModelId = c.TimeChangeModelId,
                    PQCCheckId = c.PQCCheckId,
                    Status = c.Status
                }).ToListAsync();
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
                StandardProductId = c.StandardProductId,
                StandardVehicleId = c.StandardVehicleId,
                TimeChangeModelId = c.TimeChangeModelId,
                PQCCheckId = c.PQCCheckId,
                Status = c.Status
            };
        }

        public async Task<ChangeModelReadDto> CreateAsync(ChangeModelCreateDto dto)
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
                StandardProductId = standardProduction.Id,
                StandardVehicleId = standardVehicle.Id,
                TimeChangeModelId = timeChangeModel.Id,
                PQCCheckId = pqcCheck.Id,
                Status = dto.Status
            };

            _context.ChangeModels.Add(c);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(c.Id) ?? throw new Exception("Create failed");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var c = await _context.ChangeModels.FindAsync(id);
            if (c == null) return false;

            _context.ChangeModels.Remove(c);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
