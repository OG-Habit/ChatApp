using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatAppDayataWoogue.Droid;
using Firebase.Auth;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ChatAppDayataWoogue.Constants;

[assembly: Dependency(typeof(FirebaseAuthService))]
namespace ChatAppDayataWoogue.Droid
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        DataClass dataClass = DataClass.GetInstance;

        public FirebaseAuthResponseModel IsLoggedIn()
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status = true,
                    Response = MSG_ISLOGGEDIN
                };
                if(FirebaseAuth.Instance.CurrentUser.Uid == null)
                {
                    response = new FirebaseAuthResponseModel()
                    {
                        Status = false,
                        Response = MSG_ISLOGGEDOUT
                    };
                    dataClass.IsSignedIn = false;
                    dataClass.LoggedInUser = new UserModel();
                } else
                {
                    dataClass.LoggedInUser = new UserModel()
                    {
                        Uid = FirebaseAuth.Instance.CurrentUser.Uid,
                        Email = FirebaseAuth.Instance.CurrentUser.Email,
                        Name = dataClass.LoggedInUser.Name,
                        UserType = dataClass.LoggedInUser.UserType,
                        CreatedAt = dataClass.LoggedInUser.CreatedAt
                    };
                    dataClass.IsSignedIn = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status=false,
                    Response = ex.Message
                };
                dataClass.IsSignedIn = false;
                dataClass.LoggedInUser = new UserModel();
                return response;
            }
        }

        public async Task<FirebaseAuthResponseModel> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status = true,
                    Response = MSG_SUCCESS_LOGIN
                };
                IAuthResult result = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);

                if(result.User.IsEmailVerified && email == result.User.Email)
                {
                    var document = await CrossCloudFirestore.Current
                                        .Instance
                                        .GetCollection("users")
                                        .GetDocument(result.User.Uid)
                                        .GetDocumentAsync();
                                        //.Collection("users")
                                        //.Document(result.User.Uid)
                                        //.GetAsync();
                    var yourModel = document.ToObject<UserModel>();

                    dataClass.LoggedInUser = new UserModel()
                    {
                        Uid = result.User.Uid,
                        Email = result.User.Email,
                        Name = yourModel.Name,
                        UserType = yourModel.UserType,
                        CreatedAt = yourModel.CreatedAt
                    };
                    dataClass.IsSignedIn = true;
                } else
                {
                    FirebaseAuth.Instance.CurrentUser.SendEmailVerification();
                    response.Status = false;
                    response.Response = MSG_FAIL_EMAIL_VERIFICATION;
                    dataClass.LoggedInUser = new UserModel();
                    dataClass.IsSignedIn = false;
                }

                return response;
            }
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status = false,
                    Response = ex.Message
                };
                dataClass.IsSignedIn = false;
                return response;
            }
        }

        public async Task<FirebaseAuthResponseModel> ResetPassword(string email)
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status = true,
                    Response = MSG_SUCCESS_EMAIL_SENT
                };
                await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
                return response;
            }
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status = false,
                    Response = ex.Message
                };
                return response;
            }
        }

        public FirebaseAuthResponseModel SignOut()
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status = true,
                    Response = MSG_SUCCESS_SIGNOUT
                };
                FirebaseAuth.Instance.SignOut();
                dataClass.IsSignedIn = false;
                dataClass.LoggedInUser = new UserModel();
                return response;
            } 
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status= false,
                    Response=ex.Message
                };
                dataClass.IsSignedIn = true;
                return response;
            }
        }

        public async Task<FirebaseAuthResponseModel> SignUpWithEmailPassword(string name, string email, string password)
        {
            try
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status = true,
                    Response = MSG_SUCCESS_SIGNUP
                };
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                FirebaseAuth.Instance.CurrentUser.SendEmailVerification();

                int ndx = email.IndexOf("@");
                int cnt = email.Length - ndx;
                string defaultName = string.IsNullOrEmpty(name) ? email.Remove(ndx, cnt) : name;

                dataClass.LoggedInUser = new UserModel()
                {
                    Uid = FirebaseAuth.Instance.CurrentUser.Uid,
                    Email = email,
                    Name = defaultName,
                    UserType = 0,
                    CreatedAt = DateTime.UtcNow.ToString("u")
                };
                return response;
            } 
            catch (Exception ex)
            {
                FirebaseAuthResponseModel response = new FirebaseAuthResponseModel()
                {
                    Status = false,
                    Response = ex.Message   
                };
                return response;
            }
        }
    }
}