using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Core.Models;

namespace SlackClone.Core.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class UserCredentialsTests
    {
        [TestMethod]
        public void Able_to_create_instance_with_app_constructor()
        {
            var expectedEmail = "user@example.com";

            var sut = new UserCredentials(expectedEmail, "password");

            sut.Should().NotBeNull();
            sut.Email.Should().Be(expectedEmail);
            sut.Hash.Should().NotBeNullOrEmpty();
            sut.Salt.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Able_to_create_instance_with_persistence_constructor()
        {
            var expectedEmail = "user@example.com";
            var expectedSalt = "salt";
            var expectedHash = "hash";

            var sut = new UserCredentials(
                expectedEmail,
                expectedSalt,
                expectedHash);

            sut.Should().NotBeNull();
            sut.Email.Should().Be(expectedEmail);
            sut.Salt.Should().Be(expectedSalt);
            sut.Hash.Should().Be(expectedHash);
        }

        [TestMethod]
        public void IsMatchingPassword_returns_true_when_matching_with_right_password()
        {
            var sut = new UserCredentials("user@example.com", "password");

            bool actual = sut.IsMatchingPassword("password");
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void IsMatchingPassword_returns_false_when_matching_with_wrong_password()
        {
            var sut = new UserCredentials("user@example.com", "password");

            bool actual = sut.IsMatchingPassword("wrongpassword");
            actual.Should().BeFalse();
        }
    }
}
