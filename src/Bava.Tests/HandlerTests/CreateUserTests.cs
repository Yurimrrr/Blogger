using Bava.Domain.Commands.UserCommands;
using Bava.Domain.Handlers.Contracts;

namespace Tests.HandlerTests;

public class CreateUserTests
{
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IBlogRepository> _blogRepository;
    private readonly Mock<IHasher> _hasher;
    private readonly Fixture _fixture;
    private readonly UserHandler _handler;

    public CreateUserTests()
    {
        _fixture = new Fixture();
        _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _userRepository = new Mock<IUserRepository>();
        _hasher = new Mock<IHasher>();

        _handler = new UserHandler(_userRepository.Object, _hasher.Object, _blogRepository.Object);
    }

    [Fact]
    public void ShouldCreateUser()
    {
        var command = new CreateUserCommand
        {
            Name = "Test name",
            Password = "12345678",
            Email = "teste@test.com"
        };

        _userRepository.Setup(repo => repo.GetByEmail(command.Email)).Returns((User) null).Verifiable();
        _userRepository.Setup(repo => repo.Create(It.IsAny<User>())).Verifiable();
        _blogRepository.Setup(repo => repo.Create(It.IsAny<Blog>())).Verifiable();
        
        _hasher.Setup(repo => repo.Hash(command.Password)).Returns(command.Password).Verifiable();

        var result = _handler.Handle(command);
        
        Assert.Equal(Status.Created, result.Status);
        _userRepository.Verify();
        _hasher.Verify();
    }
}