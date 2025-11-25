using SMDCheckSheet.Data;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SMDCheckSheet.Services
{
    public class StandardProductionService
    {
        private readonly AppDbContext _context;

        public StandardProductionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StandardProductionReadDto>> GetAllAsync()
        {
            return await _context.StandardProductions
                .Select(sp => new StandardProductionReadDto
                {
                    Id = sp.Id,
                    NumMASK = sp.NumMASK,
                    NumMES = sp.NumMES,
                    NumScanPrinter = sp.NumScanPrinter,
                    NumScanSignMES = sp.NumScanSignMES,
                    MLS3Closed = sp.MLS3Closed,
                    UseOnly = sp.UseOnly,
                    LabelProgram = sp.LabelProgram
                }).ToListAsync();
        }

        public async Task<StandardProductionReadDto?> GetByIdAsync(int id)
        {
            var sp = await _context.StandardProductions.FindAsync(id);
            if (sp == null) return null;

            return new StandardProductionReadDto
            {
                Id = sp.Id,
                NumMASK = sp.NumMASK,
                NumMES = sp.NumMES,
                NumScanPrinter = sp.NumScanPrinter,
                NumScanSignMES = sp.NumScanSignMES,
                MLS3Closed = sp.MLS3Closed,
                UseOnly = sp.UseOnly,
                LabelProgram = sp.LabelProgram
            };
        }

        public async Task<StandardProduction> CreateAsync(StandardProductionCreateDto dto)
        {
            var sp = new StandardProduction
            {
                NumMASK = dto.NumMASK ?? "",
                NumMES = dto.NumMES ?? "",
                NumScanPrinter = dto.NumScanPrinter ?? 0,
                NumScanSignMES = dto.NumScanSignMES ?? 0,
                MLS3Closed = dto.MLS3Closed ?? "",
                UseOnly = dto.UseOnly ?? "",
                LabelProgram = dto.LabelProgram ?? ""
            };

            _context.StandardProductions.Add(sp);
            await _context.SaveChangesAsync();

            return sp;
        }

        public async Task<StandardProduction> CreateEmptyAsync()
        {
            var sp = new StandardProduction
            {
                NumMASK ="",
                NumMES ="",
                NumScanPrinter =0,
                NumScanSignMES =0,
                MLS3Closed ="",
                UseOnly ="",
                LabelProgram =""
            };

            _context.StandardProductions.Add(sp);
            await _context.SaveChangesAsync();

            return sp;
        }

        public async Task<StandardProduction?> UpdateAsync(int id, StandardProductionUpdateDto dto)
        {
            var sdp = await _context.StandardProductions.FindAsync(id);
            if(sdp == null) return null;

            sdp.NumMASK = dto.NumMASK ?? sdp.NumMASK;
            sdp.NumMES = dto.NumMES ?? sdp.NumMES;
            sdp.NumScanPrinter = dto.NumScanPrinter ?? sdp.NumScanPrinter;
            sdp.NumScanSignMES = dto.NumScanSignMES ?? sdp.NumScanSignMES;
            sdp.MLS3Closed = dto.MLS3Closed ?? sdp.MLS3Closed;
            sdp.UseOnly = dto.UseOnly ?? sdp.UseOnly;
            sdp.LabelProgram = dto.LabelProgram ?? sdp.LabelProgram;

            await _context.SaveChangesAsync();
            return sdp;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sp = await _context.StandardProductions.FindAsync(id);
            if (sp == null) return false;

            _context.StandardProductions.Remove(sp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
