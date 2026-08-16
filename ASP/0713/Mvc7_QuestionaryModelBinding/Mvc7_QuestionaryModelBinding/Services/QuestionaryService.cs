using Mvc7_QuestionaryModelBinding.ViewModels;

namespace Mvc7_QuestionaryModelBinding.Services
{
    public class QuestionaryService
    {
        private readonly QuestionaryRepository _questionaryRepository;
        public QuestionaryService(QuestionaryRepository questionaryRepository) 
        { 
            _questionaryRepository = questionaryRepository;
        }

        public async Task<bool> AddDataAsync(QuestionaryViewModel qVM)
        {
            bool result = await _questionaryRepository.SaveDataAsync(qVM);

            return result;
        }
    }
}
