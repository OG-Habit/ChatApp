using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatAppDayataWoogue
{
    public static class Constants
    {
        public static readonly object DEFAULT_PADDING_VERTICAL = 20;
        public static readonly object DEFAULT_PADDING_HORIZONTAL = 30;

        public static readonly TextAlignment HORIZONTAL_TEXTALIGNMENT_START = TextAlignment.Start;
        public static readonly TextAlignment HORIZONTAL_TEXTALIGNMENT_END = TextAlignment.End;
        public static readonly LayoutOptions HORIZONTAL_START = LayoutOptions.Start;
        public static readonly LayoutOptions HORIZONTAL_END = LayoutOptions.End;

        public static readonly string BGCOLOR_PRIMARY_USER = "#90ee90";
        public static readonly string BGCOLOR_SECONDARY_USER = "#156DC2";

        public static readonly string MSG_EMPTY_CONVO = "You can now start a conversation with this person.";
        public static readonly string MSG_ISLOGGEDIN = "Currently logged in.";
        public static readonly string MSG_ISLOGGEDOUT = "Currently logged out.";
        public static readonly string MSG_SUCCESS_LOGIN = "Login successful.";
        public static readonly string MSG_SUCCESS_SIGNUP = "Sign up successful. Verification email sent.";
        public static readonly string MSG_SUCCESS_EMAIL_SENT = "Email has been sent to your email address";
        public static readonly string MSG_SUCCESS_SIGNOUT = "Sign out successful.";
        public static readonly string MSG_FAIL_EMAIL_VERIFICATION = "Email not verified. Sent another verification email.";

        public static readonly string KEY_EMAIL = "Email";
        public static readonly string KEY_PASSWORD = "Password";
        public static readonly string KEY_USERNAME = "Username";
        public static readonly string KEY_ISSIGNEDIN = "IsSignedIn";
        public static readonly string KEY_LOGGEDIN = "LoggedIn";
    }
}
