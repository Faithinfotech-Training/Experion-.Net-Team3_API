using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagementRestAPI.Models;
using TrainingManagementRestAPI.ViewModel;

namespace TrainingManagementRestAPI.Repository
{
   public interface ITraineeRepository
    {
        //Get all Trainee
        Task<List<TblTrainee>> GetTrainee();

        //Add a new Trainee
        Task<int> AddTrainee(TblTrainee trainee);

        //Update Trainee
        Task UpdateTrainee(TblTrainee trainee);

        //Delete Trainee
        Task DeleteTrainee(int id);

        //Get Trainee by id
        Task<TblTrainee> GetTraineeById(int id);
        Task<List<TraineeViewModel>> GetAllTrainee();


    }
}
