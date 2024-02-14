using FluentValidation.Results;
using Heig.VehicleControl.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heig.VehicleControl.Application.Interfaces
{
    public interface IChecklistAppService : IDisposable
    {
        Task<IEnumerable<ChecklistViewModel>> GetAll();

        Task<ChecklistViewModel> GetById(Guid id);

        Task<ValidationResult> Register(ChecklistViewModel checklistViewModel);

        Task<ValidationResult> Update(ChecklistViewModel checklistViewModel);

        Task<ValidationResult> Remove(Guid id);
    }
}
