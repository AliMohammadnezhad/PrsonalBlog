using FluentAssertions;
using UM.Domain.Exceptions;
using UM.Domain.Services;
using UM.Domain.Tests.Unit;
using UM.Infrastructure.EFCore.Repositories;

namespace UM.Infrastructure.Tests.Integration
{
    public class UserRepositoryTests : IClassFixture<DataBaseFixture>
    {
        private readonly UserRepository _repository;
        private readonly UserTestsBuilder _builder;
        private readonly IUserValidatorService _userValidatorService;

        public UserRepositoryTests(DataBaseFixture baseFixture)
        {
            _repository = new UserRepository(baseFixture.GetContext());
            _userValidatorService = new UserValidatorService(_repository);
            _builder = new UserTestsBuilder();
        }

        [Fact]
        public async void Should_InsertUser()
        {
            #region Arrange

            var newUser = _builder.Build();

            #endregion

            #region Act

            await _repository.AddUserAsync(newUser);
            await _repository.SaveChangesAsync();


            #endregion

            #region Assert

            var user = await _repository.GetUserByAsync(newUser.UserId);

            user.Should().Be(newUser);

            #endregion
        }

        [Fact]
        public async void Should_ThrowExceptionWhenUserEmailDuplicated()
        {

            #region Arrange

            const string email = "Test@test.Com";

            var user = await _builder.WithEmail(email).Build(_userValidatorService);
            await _repository.AddUserAsync(user);
            await _repository.SaveChangesAsync();

            #endregion


            #region Act And Assert

            Func<Task> createAsync = async () => await _builder.WithEmail(email).Build(_userValidatorService);
            await createAsync.Should().ThrowExactlyAsync<UserDuplicatedException>();

            #endregion
        }

        [Fact]
        public async void Should_GetUserById()
        {
            #region Arrange

            var newUser = _builder.Build();

            await _repository.AddUserAsync(newUser);
            await _repository.SaveChangesAsync();
            #endregion

            #region Act

            var user = await _repository.GetUserByAsync(newUser.UserId);

            #endregion

            #region Assert

            user.UserId.Should().Be(newUser.UserId);
            user.Email.Should().Be(newUser.Email);

            #endregion
        }

        [Fact]
        public async void Should_GetUserByEmail()
        {
            #region Arrange


            var newUser = _builder.Build();

            await _repository.AddUserAsync(newUser);
            await _repository.SaveChangesAsync();

            #endregion

            #region Act

            var user = await _repository.GetUserByAsync(newUser.Email);

            #endregion

            #region Assert

            user.UserId.Should().Be(newUser.UserId);
            user.Email.Should().Be(newUser.Email);

            #endregion
        }

        [Fact]
        public async void Should_UpdateUser()
        {
            #region Arrange

            var newUser = _builder.Build();
            await _repository.AddUserAsync(newUser);
            await _repository.SaveChangesAsync();

            var user = await _repository.GetUserByAsync(newUser.UserId);
            const string newName = "Ali";


            #endregion

            #region Act

            user.Update(newName, null);
            _repository.UpdateUser(user);

            #endregion

            #region Assert

            var userByAsync = await _repository.GetUserByAsync(user.UserId);
            userByAsync.FirstName.Should().NotBeNull();

            #endregion
        }
    }
}