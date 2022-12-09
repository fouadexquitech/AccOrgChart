using AccOrgChart.Repository.View_Models;

namespace AccOrgChart.Repository.Interfaces
{
    public interface IlogonRepository
    {
        User GetLogin(string user, string pass);
        User GetUser(string username);

    }
}
