using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public TrainingService(ITrainingRepository trainingRepository, IUserRepository userRepository,
            IRegistrationRepository registrationRepository)
        {
            _trainingRepository = trainingRepository;
            _userRepository = userRepository;
            _registrationRepository = registrationRepository;
        }

        public void DeleteTraining()
        {
            throw new NotImplementedException();
        }

        public void FinishTrainig()
        {
            throw new NotImplementedException();
        }

        public IList<TrainingDTO> GetAll(string category, Paging paging)
        {
            var query = _trainingRepository.GetAll(paging).AsQueryable();
            
            if(!String.IsNullOrEmpty(category))
                query = query.Where(t => t.Category.ToUpper() == category.ToUpper());

            if(!query.ToList().Any())
                throw new Exception("Register not found!");

            return query.Select(t => new TrainingDTO(t)).ToList();
        }

        public TrainingDTO GetById(int id)
        {
            var training = _trainingRepository.GetById(id);
        
            return new TrainingDTO(training);

        }


        public TrainingDTO GetTrainingFinish()
        {
            throw new NotImplementedException();
        }

        public TrainingDTO GetTrainingProgress()
        {
            throw new NotImplementedException();
        }

        public IList<TrainingDTO> GetTrainingsByUser(int userId, Paging paging)
        {
            var trainingWithRegisters = _registrationRepository.GetRegistrationsByUser(userId, paging);
            var trainingsByUser = trainingWithRegisters.Select(r => new TrainingDTO(r.Training)).ToList();

            return trainingsByUser;
        }

        public int ObterTotal()
        {
            return _trainingRepository.ObterTotal();
        }
    }
}