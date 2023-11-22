public class AuthenticationService
{
    private Account currentUser;

    public bool IsUserLoggedIn()
    {
        return currentUser != null;
    }

    public void SetLoggedInUser(Account user)
    {
        currentUser = user;
    }

    public Account GetLoggedInUser()
    {
        return currentUser;
    }

    public void Logout()
    {
        currentUser = null;
    }
}
