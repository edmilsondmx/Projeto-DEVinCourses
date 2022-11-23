using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Repositories
{
  public interface ITrainingRepository : IBaseRepository<Training, int>
  {
    public int ObterTotal();

  }
}