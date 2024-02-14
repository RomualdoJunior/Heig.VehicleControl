using FluentValidation.Results;
using Heig.VehicleControl.Application.ViewModels;

namespace Heig.VehicleControl.Application.Interfaces
{
    public interface IQuestionTemplateAppService : IDisposable
    {
        Task<IEnumerable<QuestionTemplateViewModel>> GetAll();

        Task<QuestionTemplateViewModel> GetById(Guid id);

        Task<ValidationResult> Register(QuestionTemplateViewModel vehicleViewModel);

        Task<ValidationResult> Update(QuestionTemplateViewModel vehicleViewModel);

        Task<ValidationResult> Remove(Guid id);
    }
}