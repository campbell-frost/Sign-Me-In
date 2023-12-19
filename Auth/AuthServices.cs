public class AuthenticationService
{
    private readonly Context _dbContext;

    public AuthenticationService(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public void Login(string username)
    {
        var user = _dbContext.Accounts.FirstOrDefault(u => u.UserName == username);

        if (user != null)
        {
            user.IsLoggedIn = true;
            _dbContext.SaveChanges();
        }
    }

    public void Logout()
    {
        var loggedInUsers = _dbContext.Accounts.Where(u => u.IsLoggedIn);

        foreach (var user in loggedInUsers)
        {
            user.IsLoggedIn = false;
        }

        _dbContext.SaveChanges();
    }

    public bool IsUserLoggedIn(int accountId)
    {
        var user = _dbContext.Accounts.FirstOrDefault(u => u.AccountID == accountId);
        return user != null && user.IsLoggedIn;
    }
}
