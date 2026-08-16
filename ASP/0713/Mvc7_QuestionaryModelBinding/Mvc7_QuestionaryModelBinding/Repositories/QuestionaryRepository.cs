

namespace Mvc7_QuestionaryModelBinding.Repositories
{
    public class QuestionaryRepository
    {
        private readonly TransformModelService _transformModelService;
        private readonly QuestionaryContext _questionaryContext;
        public QuestionaryRepository(TransformModelService transformModelService, QuestionaryContext questionaryContext)
        {
            _transformModelService = transformModelService;
            _questionaryContext = questionaryContext;
        }
        public async Task<bool> SaveDataAsync(QuestionaryViewModel qVM)
        {
            // VM => DM
            Questionary questionary = _transformModelService.QuestionaryViewModelToDataModel(qVM);

            //EF新增資料程式

            _questionaryContext.Questionary.Add(questionary);
            int num = await _questionaryContext.SaveChangesAsync();

            return num > 0 ? true : false;
        }
    }
}
