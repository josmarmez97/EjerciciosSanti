using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebFormsMembershipCaptchaExampleCSharp
{
    /// <summary>
    /// A mock MembershipProvider, doesn't actually work but makes the example simpler, 
    /// since it's functionality is irrelevant to Captcha integration
    /// </summary>
    public class MockMembershipProvider : System.Web.Security.MembershipProvider
    {
        public MockMembershipProvider()
        {
        }

        public override string ApplicationName
        {
            get
            {
                return "/";
            }
            set
            {
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return true;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return true;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            MembershipUser user = new MembershipUser("MockMembershipProvider", username, null, email, passwordQuestion, null, isApproved, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            status = MembershipCreateStatus.Success;
            return user;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            return true;
        }

        public override bool EnablePasswordReset
        {
            get { return true; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return true; }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            totalRecords = 0;
            return new MembershipUserCollection();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            totalRecords = 0;
            return new MembershipUserCollection();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            totalRecords = 0;
            return new MembershipUserCollection();
        }

        public override int GetNumberOfUsersOnline()
        {
            return 0;
        }

        public override string GetPassword(string username, string answer)
        {
            return "password";
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser user = new MembershipUser("MockMembershipProvider", username, null, null, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            return user;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            MembershipUser user = new MembershipUser("MockMembershipProvider", null, null, null, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            return user;
        }

        public override string GetUserNameByEmail(string email)
        {
            return "username";
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 0; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 0; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 0; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Clear; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return ""; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override string ResetPassword(string username, string answer)
        {
            return "password";
        }

        public override bool UnlockUser(string userName)
        {
            return true;
        }

        public override void UpdateUser(MembershipUser user)
        {
        }

        public override bool ValidateUser(string username, string password)
        {
            bool result = false;
            if (username.Trim().Length > 4 && password.Trim().Length > 4)
            {
                result = true;
            }
            return result;
        }
    }
}
