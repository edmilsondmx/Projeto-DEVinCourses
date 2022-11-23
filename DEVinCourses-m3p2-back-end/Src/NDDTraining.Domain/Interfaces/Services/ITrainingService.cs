using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface ITrainingService
    {
        public IList<TrainingDTO> GetAll(string category, Paging paging);
        public TrainingDTO GetById(int id);
        public TrainingDTO GetTrainingFinish();
        public TrainingDTO GetTrainingProgress();
        public void DeleteTraining();
        public void FinishTrainig();
        public IList<TrainingDTO> GetTrainingsByUser(int userId, Paging paging);
        public int ObterTotal();
    }
}
