using FluentAssertions;
using NSubstitute;
using UM.Application.Contract.User;
using UM.Application.User;
using UM.Domain.Exceptions;
using UM.Domain.Tests.Unit;
using UM.Domain.UserAgg;

namespace UM.Application.Tests.Unit
{
    public class UserApplicationTests
    {
        private readonly UserTestsBuilder _builder;
        private readonly UserApplication _userApplication;
        private readonly IUserRepository _userRepository;

        public UserApplicationTests()
        {
            
            _builder = new UserTestsBuilder();
            _userRepository = Substitute.For<IUserRepository>();
            _userApplication = new UserApplication(_userRepository);
        }

        [Fact]
        public async void Should_CreateUser()
        {
            #region Arrange

            var user = _builder.Build();

            var command = new CreateUserViewModel
            {
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            #endregion
            
            #region Act

            await _userApplication.CreateUserAsync(command);

            #endregion

            #region Assert

            await _userRepository.ReceivedWithAnyArgs().AddUserAsync(user);

            #endregion
        }



        [Fact]
        public async void Should_CreateUserAndReturnId()
        {
            #region Arrange

            var user = _builder.Build();

            var command = new CreateUserViewModel
            {
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            _userRepository.AddUserAsync(user).Returns(Task.FromResult(10));

            #endregion

            #region Act

            var userId = await _userApplication.CreateUserAsync(command);

            #endregion

            #region Assert

            userId.Should();

            #endregion
        }

        [Fact]
        public async void Should_UpdateUser()
        {
            #region Arrange

            var user = _builder.Build();

            var command = new UpdateUserViewModel
            {
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = 1
            };

            #endregion

            #region Act

            await _userApplication.UpdateUserAsync(command);

            #endregion

            #region Assert

            _userRepository.Received().UpdateUser(Arg.Any<Domain.UserAgg.User>());

            #endregion

        }

        [Fact]
        public async void Should_GetUserById()
        {
            #region Arrange

            const ulong userId = 10;

            #endregion

            #region Act

            await _userApplication.GetUserByAsync(userId);

            #endregion

            #region Assert

            await _userRepository.Received().GetUserByAsync(userId);

            #endregion
        }

        [Fact]
        public async void Should_GetUserByEmail()
        {
            #region Arrange

            const string email = "test@test.com";

            #endregion

            #region Act

            await _userApplication.GetUserByAsync(email);

            #endregion

            #region Assert

            await _userRepository.Received().GetUserByAsync(email);

            #endregion
        }

        [Fact]
        public async void Should_GetUserQueryable()
        {
            #region Arrange

            var model = new FilterUserViewModel();

            #endregion

            #region Act

            await _userApplication.FilterUserAsync(model);

            #endregion

            #region Assert

            _userRepository.Received().GetUserQueryable();

            #endregion
        }


        [Fact]
        public void Should_ChangePassword()
        {
            #region Arrange

            var user = _builder.Build();
            const string newPassword = "123456";

            #endregion

            #region Act

            user.ChangePassword(newPassword);

            #endregion

            #region Assert

            user.Password.Should().Be(newPassword);

            #endregion
        }


        [Fact]
        public void Should_VerifyUser()
        {
            #region Arrange

            var user = _builder.Build();

            var userValidateKey = user.ValidateKey;

            #endregion

            #region Act

            user.VerifyEmail(userValidateKey);

            #endregion

            #region Assert

            user.IsActive.Should().BeTrue();

            #endregion
        }












    }
}