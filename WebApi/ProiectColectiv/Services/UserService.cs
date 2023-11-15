using ProiectColectiv.Data;
using ProiectColectiv.AppDbContext;

public class UserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public User GetUserById(Guid userId)
    {
        return _userRepository.GetById(userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public void CreateUser(
        string firstName,
        string lastName,
        DateTime birthDate,
        string phoneNumber,
        string email,
        string credentialEmail,
        string credentialPassword,
        bool isCredentialAdmin)
    {
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber,
            Email = email,
            Credential = new Credential
            {
                Email = credentialEmail,
                Password = credentialPassword,
                IsAdmin = isCredentialAdmin
            }
        };

        _userRepository.Add(user);
    }

    public void UpdateUser(
        Guid userId,
        string firstName,
        string lastName,
        DateTime birthDate,
        string phoneNumber,
        string email,
        string credentialEmail,
        string credentialPassword,
        bool isCredentialAdmin)
    {
        var existingUser = _userRepository.GetById(userId);

        if (existingUser == null)
        {
            throw new ArgumentException($"User with ID {userId} not found.");
        }

        existingUser.FirstName = firstName;
        existingUser.LastName = lastName;
        existingUser.BirthDate = birthDate;
        existingUser.PhoneNumber = phoneNumber;
        existingUser.Email = email;

        if (existingUser.Credential == null)
        {
            existingUser.Credential = new Credential();
        }

        existingUser.Credential.Email = credentialEmail;
        existingUser.Credential.Password = credentialPassword;
        existingUser.Credential.IsAdmin = isCredentialAdmin;

        _userRepository.Update(existingUser);
    }

    public void DeleteUser(Guid userId)
    {
        _userRepository.Delete(userId);
    }
}
