using Mvc7_QuestionaryModelBinding.Models;
using Mvc7_QuestionaryModelBinding.ViewModels;
using Newtonsoft.Json;

namespace Mvc7_QuestionaryModelBinding.Services
{
    public class TransformModelService
    {

        public Questionary QuestionaryViewModelToDataModel(QuestionaryViewModel questionaryVM)
        {
            Questionary questionary = new Questionary()
            {
                EventId = Guid.NewGuid().ToString(),
                UserName = questionaryVM.UserName,
                Mobile = questionaryVM.Mobile,
                Email = questionaryVM.Email,
                Gender = questionaryVM.Gender,
                City = questionaryVM.City,
                Address = questionaryVM.Address,
                Car = questionaryVM.Car,
                Volume = questionaryVM.Volume,
                Habbits = JsonConvert.SerializeObject(questionaryVM.Habbits)
            };

            return questionary;
        }
    }
}
