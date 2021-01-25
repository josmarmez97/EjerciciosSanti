Imports Microsoft.VisualBasic

Namespace WebFormsMembershipCaptchaExampleVBNet

    Public Class MockMembershipProvider
        Inherits System.Web.Security.MembershipProvider
        Public Sub New()
        End Sub

        Public Overrides Property ApplicationName() As String
            Get
                Return "/"
            End Get
            Set(ByVal value As String)
            End Set
        End Property

        Public Overrides Function ChangePassword(ByVal username As String, ByVal oldPassword As String, ByVal newPassword As String) As Boolean
            Return True
        End Function

        Public Overrides Function ChangePasswordQuestionAndAnswer(ByVal username As String, ByVal password As String, ByVal newPasswordQuestion As String, ByVal newPasswordAnswer As String) As Boolean
            Return True
        End Function

        Public Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, ByVal passwordQuestion As String, ByVal passwordAnswer As String, ByVal isApproved As Boolean,
         ByVal providerUserKey As Object, ByRef status As MembershipCreateStatus) As MembershipUser
            Dim user As New MembershipUser("MockMembershipProvider", username, Nothing, email, passwordQuestion, Nothing,
             isApproved, False, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now,
             DateTime.Now)
            status = MembershipCreateStatus.Success
            Return user
        End Function

        Public Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean
            Return True
        End Function

        Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Function FindUsersByEmail(ByVal emailToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
            totalRecords = 0
            Return New MembershipUserCollection()
        End Function

        Public Overrides Function FindUsersByName(ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
            totalRecords = 0
            Return New MembershipUserCollection()
        End Function

        Public Overrides Function GetAllUsers(ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
            totalRecords = 0
            Return New MembershipUserCollection()
        End Function

        Public Overrides Function GetNumberOfUsersOnline() As Integer
            Return 0
        End Function

        Public Overrides Function GetPassword(ByVal username As String, ByVal answer As String) As String
            Return "password"
        End Function

        Public Overrides Function GetUser(ByVal username As String, ByVal userIsOnline As Boolean) As MembershipUser
            Dim user As New MembershipUser("MockMembershipProvider", username, Nothing, Nothing, Nothing, Nothing,
             True, False, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now,
             DateTime.Now)
            Return user
        End Function

        Public Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As MembershipUser
            Dim user As New MembershipUser("MockMembershipProvider", Nothing, Nothing, Nothing, Nothing, Nothing,
             True, False, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now,
             DateTime.Now)
            Return user
        End Function

        Public Overrides Function GetUserNameByEmail(ByVal email As String) As String
            Return "username"
        End Function

        Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
            Get
                Return 0
            End Get
        End Property

        Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
            Get
                Return 0
            End Get
        End Property

        Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
            Get
                Return 0
            End Get
        End Property

        Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
            Get
                Return 0
            End Get
        End Property

        Public Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
            Get
                Return MembershipPasswordFormat.Clear
            End Get
        End Property

        Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
            Get
                Return ""
            End Get
        End Property

        Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String
            Return "password"
        End Function

        Public Overrides Function UnlockUser(ByVal userName As String) As Boolean
            Return True
        End Function

        Public Overrides Sub UpdateUser(ByVal user As MembershipUser)
        End Sub

        Public Overrides Function ValidateUser(ByVal username As String, ByVal password As String) As Boolean
            Dim result As Boolean
            result = False

            If username.Trim().Length > 4 And password.Trim().Length > 4 Then
                result = True
            End If

            Return result
        End Function
    End Class

End Namespace
