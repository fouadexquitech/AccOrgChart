using System.Collections.Generic;
using System.Linq;
using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;
using Microsoft.EntityFrameworkCore;


namespace AccOrgChart.Repository.Managers
{
    public class LogonRepository
    {

        private readonly HR_StatisticsDbContext _dbContext;

        public LogonRepository(HR_StatisticsDbContext context)
        {
            _dbContext = context;
        }


        public User GetLogin(string user, string pass)
        {
            User usr = new User();
            usr = checkCredentials(user, pass);

            //bool isAdmin = (bool)(usr.UsrAdmin);
            //if (!isAdmin)
            //{
               
            //}

            return usr;
        }

        private User checkCredentials(string username, string password)
        {
            var result = from u in _dbContext.TblHrUsers
                         where u.UsrId == username &&
                         u.UsrPwd == password
                         select new User
                         {
                             UsrId = u.UsrId,
                             UsrDesc = u.UsrDesc,
                             UsrPwd = u.UsrPwd,
                             UsrAdmin = u.UsrAdmin
                             //UsrEmail = u.UsrEmail,
                             //UsrEmailSignature = u.EmailSignature
                         };
            User user = new User();
            user = result.FirstOrDefault();

            return user;
        }


        public User GetUser(string username)
        {
            var result = from u in _dbContext.TblHrUsers
                         where u.UsrId == username
                         select new User
                         {
                             UsrId = (u.UsrId == null) ? "" : u.UsrId,
                             UsrDesc = (u.UsrDesc == null) ? "" : u.UsrDesc,
                             UsrPwd = (u.UsrPwd == null) ? "" : u.UsrPwd,
                             UsrAdmin = (u.UsrAdmin == null) ? false : u.UsrAdmin
                             //UsrEmail = (u.UsrEmail == null) ? "" : u.UsrEmail,
                             //UsrEmailSignature = (u.EmailSignature == null) ? "" : u.EmailSignature
                         };

            return result.FirstOrDefault();
        }
    }
}
