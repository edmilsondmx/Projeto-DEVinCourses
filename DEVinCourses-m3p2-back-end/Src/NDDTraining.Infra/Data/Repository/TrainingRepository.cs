using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using NDDTraining.Domain.Interfaces.Repositories;

namespace NDDTraining.Infra.Data.Repository
{
  public class TrainingRepository : BaseRepository<Training, int>, ITrainingRepository
  {
    public TrainingRepository(NDDTrainingDbContext context) : base(context) { }

    }
}