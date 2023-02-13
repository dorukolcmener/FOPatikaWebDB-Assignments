using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UserOperations.Commands.CreateUser;

public class CreateUserCommand
{
    public CreateUserModel model { get; set; }
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateUserCommand(IBookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Handle()
    {
        var user = _context.Users.SingleOrDefault(u => u.Email == model.Email);
        if (user != null)
        {
            throw new InvalidOperationException("User with the same e-mail already exists");
        }

        user = _mapper.Map<User>(model);

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}