using SMDCheckSheet.Data;
using SMDCheckSheet.Dtos;
using SMDCheckSheet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SMDCheckSheet.Services
{
    public class CheckModelService
    {
        private readonly AppDbContext _context;

        public CheckModelService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<CheckModelReadDto>> GetAllAsync()
        {
            return await _context.CheckModels
                .Select(c => new CheckModelReadDto
                {
                    Id = c.Id,
                    LineChange = c.LineChange,
                    Model = c.Model,
                    FCode = c.FCode,
                    PCBver = c.PCBver,
                    WorkOrder = c.WorkOrder,
                    UsedCNcard = c.UsedCNcard,
                    RevS15  = c.RevS15,
                    RevMounter = c.RevMounter,
                    Qty = c.Qty ?? 0,
                    FeederCheck = c.FeederCheck,
                    OPAccept = c.OPAccept,
                    JIG = c.JIG,
                    CodePCB = c.CodePCB
                }).ToListAsync();
        }

        public async Task<CheckModelReadDto?> GetByIdAsync(int id)
        {
            var c = await _context.CheckModels.FindAsync(id);
            if (c == null) return null;

            return new CheckModelReadDto
            {
                Id = c.Id,
                LineChange = c.LineChange,
                Model = c.Model,
                FCode = c.FCode,
                PCBver = c.PCBver,
                WorkOrder = c.WorkOrder,
                UsedCNcard = c.UsedCNcard,
                RevS15  = c.RevS15,
                RevMounter = c.RevMounter,
                Qty = c.Qty ?? 0,
                FeederCheck = c.FeederCheck,
                OPAccept = c.OPAccept,
                JIG = c.JIG,
                CodePCB = c.CodePCB
            };
        }

        public async Task<CheckModel> CreateAsync(CheckModelCreateDto dto)
        {
            var checkModel = new CheckModel
            {
                LineChange = dto.LineChange ?? "",
                Model = dto.Model ?? "",
                FCode = dto.FCode ?? "",
                PCBver = dto.PCBver ?? "",
                WorkOrder = dto.WorkOrder ?? "",
                UsedCNcard = dto.UsedCNcard ?? false,
                RevS15 = dto.RevS15 ?? "",
                RevMounter = dto.RevMounter ?? "",
                Qty = dto.Qty ?? 0,
                FeederCheck = dto.FeederCheck ?? DateTime.Now,
                OPAccept = dto.OPAccept ?? DateTime.Now,
                JIG = dto.JIG ?? false,
                CodePCB = dto.CodePCB ?? ""
            };

            _context.CheckModels.Add(checkModel);
            await _context.SaveChangesAsync();
            return checkModel;
        }

        public async Task<CheckModel> CreateEmptyAsync()
        {
            var checkModel = new CheckModel
            {
                LineChange ="",
                Model ="",
                FCode ="",
                PCBver ="",
                WorkOrder ="",
                UsedCNcard =false,
                RevS15 ="",
                RevMounter ="",
                Qty = 0,
                FeederCheck =DateTime.Now,
                OPAccept =DateTime.Now,
                JIG =false,
                CodePCB =""
            };

            _context.CheckModels.Add(checkModel);
            await _context.SaveChangesAsync();
            return checkModel;
        }

        public async Task<CheckModel?> UpdateAsync(int id, CheckModelUpdateDto dto)
        {
            var checkModel = await _context.CheckModels.FindAsync(id);
            if (checkModel == null) return null;

            checkModel.LineChange = dto.LineChange ?? checkModel.LineChange;
            checkModel.Model = dto.Model ?? checkModel.Model;
            checkModel.FCode = dto.FCode ?? checkModel.FCode;
            checkModel.PCBver = dto.PCBver ?? checkModel.PCBver;
            checkModel.WorkOrder = dto.WorkOrder ?? checkModel.WorkOrder;
            checkModel.UsedCNcard = dto.UsedCNcard ?? checkModel.UsedCNcard;
            checkModel.RevS15 = dto.RevS15 ?? checkModel.RevS15;
            checkModel.RevMounter = dto.RevMounter ?? checkModel.RevMounter;
            checkModel.Qty = dto.Qty ?? checkModel.Qty;
            checkModel.FeederCheck = dto.FeederCheck ?? checkModel.FeederCheck;
            checkModel.OPAccept = dto.OPAccept ?? checkModel.OPAccept;
            checkModel.JIG = dto.JIG ?? checkModel.JIG;
            checkModel.CodePCB = dto.CodePCB ?? checkModel.CodePCB;

            await _context.SaveChangesAsync();
            return checkModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var c = await _context.CheckModels.FindAsync(id);
            if (c == null) return false;

            _context.CheckModels.Remove(c);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
