using Heig.VehicleControl.Domain.Entities;

namespace Heig.VehicleControl.Domain.Interfaces.Repositories
{
    public interface IQuestionTemplateRepository
    {
        Task<QuestionTemplate> GetById(Guid id);

        Task<IEnumerable<QuestionTemplate>> GetAll();

        void Add(QuestionTemplate questionTemplate);

        void Update(QuestionTemplate questionTemplate);

        void Remove(QuestionTemplate questionTemplate);
    }
}