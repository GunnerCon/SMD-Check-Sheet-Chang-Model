using SMDCheckSheet.Data;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SMDCheckSheet.Services
{
    public class StandardVehicleService
    {
        private readonly AppDbContext _context;

        public StandardVehicleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StandardVehicleReadDto>> GetAllAsync()
        {
            return await _context.StandardVehicles
                .Select(v => new StandardVehicleReadDto
                {
                    Id = v.Id,
                    PrinterSpecGTAL = v.PrinterSpecGTAL,
                    PrinterSpecTDQ = v.PrinterSpecTDQ,
                    PrinterSpecTDKC = v.PrinterSpecTDKC,
                    PrinterSpecDSL = v.PrinterSpecDSL,
                    PrinterRealTDQ = v.PrinterRealTDQ,
                    PrinterRealTDKC = v.PrinterRealTDKC,
                    PrinterRealDSL = v.PrinterRealDSL,
                    PrinterQ1 = v.PrinterQ1,
                    SPIQ1 = v.SPIQ1,
                    MountQ1 = v.MountQ1,
                    MountQ2 = v.MountQ2,
                    ReflowQ1 = v.ReflowQ1,
                    ReFlowSettingRail = v.ReFlowSettingRail,
                    ReFlowRealRail = v.ReFlowRealRail,
                    AOIQ1 = v.AOIQ1,
                    AOICheck = v.AOICheck,
                    NameOP = v.NameOP,
                    NameAOI = v.NameAOI
                }).ToListAsync();
        }

        public async Task<StandardVehicleReadDto?> GetByIdAsync(int id)
        {
            var v = await _context.StandardVehicles.FindAsync(id);
            if (v == null) return null;

            return new StandardVehicleReadDto
            {
                Id = v.Id,
                PrinterSpecGTAL = v.PrinterSpecGTAL,
                PrinterSpecTDQ = v.PrinterSpecTDQ,
                PrinterSpecTDKC = v.PrinterSpecTDKC,
                PrinterSpecDSL = v.PrinterSpecDSL,
                PrinterRealTDQ = v.PrinterRealTDQ,
                PrinterRealTDKC = v.PrinterRealTDKC,
                PrinterRealDSL = v.PrinterRealDSL,
                PrinterQ1 = v.PrinterQ1,
                SPIQ1 = v.SPIQ1,
                MountQ1 = v.MountQ1,
                MountQ2 = v.MountQ2,
                ReflowQ1 = v.ReflowQ1,
                ReFlowSettingRail = v.ReFlowSettingRail,
                ReFlowRealRail = v.ReFlowRealRail,
                AOIQ1 = v.AOIQ1,
                AOICheck = v.AOICheck,
                NameOP = v.NameOP,
                NameAOI = v.NameAOI
            };
        }

        public async Task<StandardVehicleReadDto> CreateAsync(StandardVehicleCreateDto dto)
        {
            var v = new StandardVehicle
            {
                PrinterSpecGTAL = dto.PrinterSpecGTAL ?? 0,
                PrinterSpecTDQ = dto.PrinterSpecTDQ ?? 0,
                PrinterSpecTDKC = dto.PrinterSpecTDKC ?? 0,
                PrinterSpecDSL = dto.PrinterSpecDSL ?? 0,
                PrinterRealTDQ = dto.PrinterRealTDQ ?? 0,
                PrinterRealTDKC = dto.PrinterRealTDKC ?? 0,
                PrinterRealDSL = dto.PrinterRealDSL ?? 0,
                PrinterQ1 = dto.PrinterQ1 ?? false,
                SPIQ1 = dto.SPIQ1 ?? false,
                MountQ1 = dto.MountQ1 ?? false,
                MountQ2 = dto.MountQ2 ?? false,
                ReflowQ1 = dto.ReflowQ1 ?? false,
                ReFlowSettingRail = dto.ReFlowSettingRail ?? 0,
                ReFlowRealRail = dto.ReFlowRealRail ?? 0,
                AOIQ1 = dto.AOIQ1 ?? false,
                AOICheck = dto.AOICheck ?? "",
                NameOP = dto.NameOP ?? "",
                NameAOI = dto.NameAOI ?? ""
            };

            _context.StandardVehicles.Add(v);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(v.Id) ?? throw new Exception("Create failed");
        }

        public async Task<StandardVehicleReadDto> CreateEmptyAsync()
        {
            var v = new StandardVehicle
            {
                PrinterSpecGTAL =0,
                PrinterSpecTDQ =0,
                PrinterSpecTDKC =0,
                PrinterSpecDSL = 0,
                PrinterRealTDQ = 0,
                PrinterRealTDKC = 0,
                PrinterRealDSL = 0,
                PrinterQ1 = false,
                SPIQ1 = false,
                MountQ1 = false,
                MountQ2 = false,
                ReflowQ1 = false,
                ReFlowSettingRail = 0,
                ReFlowRealRail = 0,
                AOIQ1 = false,
                AOICheck = "",
                NameOP = "",
                NameAOI = ""
            };

            _context.StandardVehicles.Add(v);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(v.Id) ?? throw new Exception("Create failed");
        }

        public async Task<StandardVehicle?> UpdateAsync(int id, StandardVehicleUpdateDto dto)
        {
            var sv = await _context.StandardVehicles.FindAsync(id);
            if (sv == null) return null;

            sv.PrinterSpecGTAL = dto.PrinterSpecGTAL ?? sv.PrinterSpecGTAL;
            sv.PrinterSpecTDQ = dto.PrinterSpecTDQ ?? sv.PrinterSpecTDQ;
            sv.PrinterSpecTDKC = dto.PrinterSpecTDKC ?? sv.PrinterSpecTDKC;
            sv.PrinterSpecDSL = dto.PrinterSpecDSL ?? sv.PrinterSpecDSL;
            sv.PrinterRealTDQ = dto.PrinterRealTDQ ?? sv.PrinterRealTDQ;
            sv.PrinterRealTDKC = dto.PrinterRealTDKC ?? sv.PrinterRealTDKC;
            sv.PrinterRealDSL = dto.PrinterRealDSL ?? sv.PrinterRealDSL;
            sv.PrinterQ1 = dto.PrinterQ1 ?? sv.PrinterQ1;
            sv.SPIQ1 = dto.SPIQ1 ?? sv.SPIQ1;
            sv.MountQ1 = dto.MountQ1 ?? sv.MountQ1;
            sv.MountQ2 = dto.MountQ2 ?? sv.MountQ2;
            sv.ReflowQ1 =dto.ReflowQ1 ?? sv.ReflowQ1;
            sv.ReFlowSettingRail = dto.ReFlowSettingRail ?? sv.ReFlowSettingRail;
            sv.ReFlowRealRail = dto.ReFlowRealRail ?? sv.ReFlowRealRail;
            sv.AOIQ1 = dto.AOIQ1 ?? sv.AOIQ1;
            sv.AOICheck = dto.AOICheck ?? sv.AOICheck;
            sv.NameOP = dto.NameOP ?? sv.NameOP;
            sv.NameAOI = dto.NameAOI ?? sv.NameAOI;

            await _context.SaveChangesAsync();
            return sv;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var v = await _context.StandardVehicles.FindAsync(id);
            if (v == null) return false;

            _context.StandardVehicles.Remove(v);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
