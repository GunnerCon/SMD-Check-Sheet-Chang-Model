using SMDCheckSheet.Data;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SMDCheckSheet.Services
{
    public class PQCCheckService
    {
        private readonly AppDbContext _context;

        public PQCCheckService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PQCCheckReadDto>> GetAllAsync()
        {
            return await _context.PQCChecks
                .Select(p => new PQCCheckReadDto
                {
                    Id = p.Id,
                    ICPlan = p.ICPlan,
                    ChecksumReal = p.ChecksumReal,
                    ChecksumConfirm = p.ChecksumConfirm,
                    Turner = p.Turner,
                    StartLCR = p.StartLCR,
                    EndLCR = p.EndLCR,
                    NameCheck = p.NameCheck,
                    ResultLCR = p.ResultLCR
                }).ToListAsync();
        }

        public async Task<PQCCheckReadDto?> GetByIdAsync(int id)
        {
            var p = await _context.PQCChecks.FindAsync(id);
            if (p == null) return null;

            return new PQCCheckReadDto
            {
                Id = p.Id,
                ICPlan = p.ICPlan,
                ChecksumReal = p.ChecksumReal,
                ChecksumConfirm = p.ChecksumConfirm,
                Turner = p.Turner,
                StartLCR = p.StartLCR,
                EndLCR = p.EndLCR,
                NameCheck = p.NameCheck,
                ResultLCR = p.ResultLCR
            };
        }

        public async Task<PQCCheckReadDto> CreateAsync(PQCCheckCreateDto dto)
        {
            var p = new PQCCheck
            {
                ICPlan = dto.ICPlan ?? "",
                ChecksumReal = dto.ChecksumReal ?? "",
                ChecksumConfirm = dto.ChecksumConfirm ?? "",
                Turner = dto.Turner ?? "",
                StartLCR = dto.StartLCR ?? TimeSpan.Zero,
                EndLCR = dto.EndLCR ?? TimeSpan.Zero,
                NameCheck = dto.NameCheck ?? "",
                ResultLCR = dto.ResultLCR ?? false
            };

            _context.PQCChecks.Add(p);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(p.Id) ?? throw new Exception("Create failed");
        }

        public async Task<PQCCheckReadDto> CreateEmptyAsync()
        {
            var p = new PQCCheck
            {
                ICPlan ="",
                ChecksumReal ="",
                ChecksumConfirm ="",
                Turner ="",
                StartLCR =TimeSpan.Zero,
                EndLCR =TimeSpan.Zero,
                NameCheck ="",
                ResultLCR =false
            };

            _context.PQCChecks.Add(p);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(p.Id) ?? throw new Exception("Create failed");
        }

        public async Task<PQCCheck?> UpdateAsync(int id, PQCCheckUpdateDto dto)
        {
            var pqc = await _context.PQCChecks.FindAsync(id);
            if (pqc == null) return null;

            pqc.ICPlan = dto.ICPlan ?? pqc.ICPlan;
            pqc.ChecksumReal = dto.ChecksumReal ?? pqc.ChecksumReal;
            pqc.ChecksumConfirm =  dto.ChecksumConfirm ?? pqc.ChecksumConfirm;
            pqc.Turner = dto.Turner ?? pqc.Turner;
            pqc.StartLCR = dto.StartLCR ?? pqc.StartLCR;
            pqc.EndLCR = dto.EndLCR ?? pqc.EndLCR;
            pqc.NameCheck = dto.NameCheck ?? pqc.NameCheck;
            pqc.ResultLCR = dto.ResultLCR ?? pqc.ResultLCR;

            await _context.SaveChangesAsync();
            return pqc;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = await _context.PQCChecks.FindAsync(id);
            if (p == null) return false;

            _context.PQCChecks.Remove(p);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
