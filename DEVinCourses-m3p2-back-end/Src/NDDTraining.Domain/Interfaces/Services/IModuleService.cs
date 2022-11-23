using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface IModuleService
    {
        public List<ModuleDTO> GetModule();
        public List<ModuleDTO> GetByTraining(int trainingId);
        public void FinishClassrom();
    }
}
