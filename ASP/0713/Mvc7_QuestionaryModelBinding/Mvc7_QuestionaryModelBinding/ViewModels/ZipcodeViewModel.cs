namespace Mvc7_QuestionaryModelBinding.ViewModels
{
    #nullable disable
    public class ZipcodeViewModel
    {
        public string City { get; set; }
        public List<DistrictInfo> Districts { get; set; }

        public class DistrictInfo
        {
            public string District { get; set; }
            public string Zipcode { get; set; }
        }
    }


}
