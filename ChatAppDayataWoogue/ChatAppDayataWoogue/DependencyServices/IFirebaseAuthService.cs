using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppDayataWoogue
{
    public interface IFirebaseAuthService
    {
        Task<FirebaseAuthResponseModel> LoginWithEmailPassword(string email, string password);
        Task<FirebaseAuthResponseModel> SignUpWithEmailPassword(string name, string email, string password);
        FirebaseAuthResponseModel SignOut();
        FirebaseAuthResponseModel IsLoggedIn();
        Task<FirebaseAuthResponseModel> ResetPassword(string email);
    }
}
