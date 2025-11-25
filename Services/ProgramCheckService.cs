using SMDCheckSheet.Data;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Diagnostics.Eventing.Reader;

namespace SMDCheckSheet.Services
{
    public class ProgramCheckService
    {
        private readonly AppDbContext _context;

        public ProgramCheckService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramCheckReadDto>> GetAllAsync()
        {
            return await _context.ProgramChecks
                .Select(p => new ProgramCheckReadDto
                {
                    Id = p.Id,
                    PrinterProgram = p.PrinterProgram,
                    SPIProgram = p.SPIProgram,
                    MounterProgram = p.MounterProgram,
                    PointMounter = p.PointMounter,
                    MOAIProgram = p.MOAIProgram,
                    SOAIProgram = p.SOAIProgram,
                    PointSOAI = p.PointSOAI,
                    ReflowProgram = p.ReflowProgram,
                    ReflowSpeed = p.ReflowSpeed
                }).ToListAsync();
        }

        public async Task<ProgramCheckReadDto?> GetByIdAsync(int id)
        {
            var p = await _context.ProgramChecks.FindAsync(id);
            if (p == null) return null;

            return new ProgramCheckReadDto
            {
                Id = p.Id,
                PrinterProgram = p.PrinterProgram,
                SPIProgram = p.SPIProgram,
                MounterProgram = p.MounterProgram,
                PointMounter = p.PointMounter,
                MOAIProgram = p.MOAIProgram,
                SOAIProgram = p.SOAIProgram,
                PointSOAI = p.PointSOAI,
                ReflowProgram = p.ReflowProgram,
                ReflowSpeed = p.ReflowSpeed
            };
        }

        public async Task<ProgramCheckReadDto> CreateAsync(ProgramCheckCreateDto dto)
        {
            var p = new ProgramCheck
            {
                PrinterProgram = dto.PrinterProgram ?? "",
                SPIProgram = dto.SPIProgram ?? "",
                MounterProgram = dto.MounterProgram ??"",
                PointMounter = dto.PointMounter ?? 0,
                MOAIProgram = dto.MOAIProgram ?? "",
                SOAIProgram = dto.SOAIProgram ?? "",
                PointSOAI = dto.PointSOAI ?? 0,
                ReflowProgram = dto.ReflowProgram ?? "",
                ReflowSpeed = dto.ReflowSpeed ?? 0
            };

            _context.ProgramChecks.Add(p);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(p.Id) ?? throw new Exception("Create failed");
        }

        public async Task<ProgramCheckReadDto> CreateEmptyAsync()
        {
            var p = new ProgramCheck
            {
                PrinterProgram ="",
                SPIProgram ="",
                MounterProgram ="",
                PointMounter =0,
                MOAIProgram ="",
                SOAIProgram ="",
                PointSOAI =0,
                ReflowProgram = "",
                ReflowSpeed =0
            };

            _context.ProgramChecks.Add(p);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(p.Id) ?? throw new Exception("Create failed");
        }

        public async Task<ProgramCheck> UpdateAsync(int id, ProgramCheckUpdateDto dto)
        {
            var programCheck = await _context.ProgramChecks.FindAsync(id);
            if (programCheck == null)  return null;

            programCheck.PrinterProgram = dto.PrinterProgram ?? programCheck.PrinterProgram;
            programCheck.SPIProgram = dto.SPIProgram ?? programCheck.SPIProgram;
            programCheck.MounterProgram = dto.MounterProgram ?? programCheck.MounterProgram;
            programCheck.PointMounter = dto.PointMounter ?? programCheck.PointMounter;
            programCheck.MOAIProgram = dto.MOAIProgram ?? programCheck.MOAIProgram;
            programCheck.SOAIProgram = dto.SOAIProgram ?? programCheck.SOAIProgram;
            programCheck.PointSOAI = dto.PointSOAI ?? programCheck.PointSOAI;
            programCheck.ReflowProgram = dto.ReflowProgram ?? programCheck.ReflowProgram;
            programCheck.ReflowSpeed = dto.ReflowSpeed ?? programCheck.ReflowSpeed;

            await _context.SaveChangesAsync();
            return programCheck;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = await _context.ProgramChecks.FindAsync(id);
            if (p == null) return false;

            _context.ProgramChecks.Remove(p);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
