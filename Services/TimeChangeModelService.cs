using SMDCheckSheet.Data;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SMDCheckSheet.Services
{
    public class TimeChangeModelService
    {
        private readonly AppDbContext _context;

        public TimeChangeModelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeChangeModelReadDto>> GetAllAsync()
        {
            return await _context.TimeChangeModels
                .Select(t => new TimeChangeModelReadDto
                {
                    Id = t.Id,
                    QC = t.QC,
                    Result = t.Result,
                    StartTime = t.StartTime,
                    EndTime = t.EndTime,
                    CountTime = t.CountTime,
                    History = t.History
                }).ToListAsync();
        }

        public async Task<TimeChangeModelReadDto?> GetByIdAsync(int id)
        {
            var t = await _context.TimeChangeModels.FindAsync(id);
            if (t == null) return null;

            return new TimeChangeModelReadDto
            {
                Id = t.Id,
                QC = t.QC,
                Result = t.Result,
                StartTime = t.StartTime,
                EndTime = t.EndTime,
                CountTime = t.CountTime,
                History = t.History
            };
        }

        public async Task<TimeChangeModelReadDto> CreateAsync(TimeChangeModelCreateDto dto)
        {
            var t = new TimeChangeModel
            {
                QC = dto.QC ?? "",
                Result = dto.Result ?? "",
                StartTime = dto.StartTime ?? TimeSpan.Zero,
                EndTime = dto.EndTime ?? TimeSpan.Zero,
                CountTime = dto.CountTime ?? 0,
                History = dto.History ?? ""
            };

            _context.TimeChangeModels.Add(t);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(t.Id) ?? throw new Exception("Create failed");
        }

        public async Task<TimeChangeModelReadDto> CreateEmptyAsync()
        {
            var t = new TimeChangeModel
            {
                QC ="",
                Result ="",
                StartTime =TimeSpan.Zero,
                EndTime =TimeSpan.Zero,
                CountTime =0,
                History = ""
            };

            _context.TimeChangeModels.Add(t);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(t.Id) ?? throw new Exception("Create failed");
        }

        public async Task<TimeChangeModel> UpdateAsync( int id, TimeChangeModelUpdateDto dto)
        {
            var tmc = await _context.TimeChangeModels.FindAsync(id);
            if (tmc == null) return null;

            tmc.QC = dto.QC ?? tmc.QC;
            tmc.Result = dto.Result ?? tmc.Result;
            tmc.StartTime = dto.StartTime ?? tmc.StartTime;
            tmc.EndTime = dto.EndTime ?? tmc.EndTime;
            tmc.CountTime = dto.CountTime ?? tmc.CountTime;
            tmc.History = dto.History ?? tmc.History;

            await _context.SaveChangesAsync();
            return tmc;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var t = await _context.TimeChangeModels.FindAsync(id);
            if (t == null) return false;

            _context.TimeChangeModels.Remove(t);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
