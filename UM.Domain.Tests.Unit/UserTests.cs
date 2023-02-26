using FluentAssertions;
using UM.Domain.Exceptions;

namespace UM.Domain.Tests.Unit
{
    public class UserTests
    {
        private readonly UserTestsBuilder _builder;

        public UserTests()
        {
            _builder = new UserTestsBuilder();
        }

        [Fact]
        public void Should_ConstructUserProperly()
        {
            #region Act

            var user = _builder.Build();


            #endregion

            #region Arrange

            user.Email.Should().Be(user.Email);
            user.Password.Should().Be(user.Password);
            user.LastName.Should().Be(user.LastName);
            user.FirstName.Should().Be(user.FirstName);

            #endregion


        }

        [Fact]
        public void Should_ThrowException_WhenEmailIsNull()
        {
            #region Act

            Action user = () => _builder.WithEmail(null).Build();

            #endregion

            #region Assert

            user.Should().ThrowExactly<EmailInValidExceptions>();


            #endregion

        }

        [Fact]
        public void Should_ThrowException_WhenPasswordIsNull()
        {
            #region Act

            Action user = () => _builder.WithPassword(null).Build();

            #endregion

            #region Assert

            user.Should().ThrowExactly<PasswordInvalidException>();

            #endregion
        }

        [Theory]
        [InlineData("This Is Invalid Email")]
        [InlineData("Test@Email")]
        public void Should_ThrowException_WhenEmailIsInvalid(string email)
        {

            #region Act
            Action user = () => _builder.WithEmail(email).Build();
            #endregion

            #region Assert

            user.Should().ThrowExactly<EmailInValidExceptions>();

            #endregion
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Should_ChangeUserState(bool changed)
        {
            #region Arrange

            var user = _builder.Build();

            #endregion

            #region Act

            user.ChangeState(changed);

            #endregion

            #region Assert

            user.IsActive.Should().Be(changed);

            #endregion
        }


        [Fact]
        public void Should_UpdateWithValidProperties_ShouldSucceed()
        {
            #region Arrange

            var user = _builder.WithEmail("ali@ali.com")
                .WithPassword("123")
                .WithFirstName("Ali")
                .WithLastName("SH")
                .Build();

            const string firstName = "Ali";
            const string lastName = "SH";

            #endregion

            #region Act

            user.Update(firstName, lastName);

            #endregion

            #region Assert

            user.FirstName.Should().Be(firstName);
            user.LastName.Should().Be(lastName);

            #endregion
        }




    }
}