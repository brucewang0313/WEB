using JwtCourseApi.Basic.Models;

namespace JwtExercise.API.Services
{
    public interface IDemoUserService
    {
        DemoUser? Authenticate(string username, string password);

    }
}
