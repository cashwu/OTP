using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RsaSecureToken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace RsaSecureToken.Tests
{
    [TestClass()]
    public class AuthenticationServiceTests
    {
        [TestMethod()]
        public void IsValidTest()
        {
            var profileDao = Substitute.For<IProfile>();
            profileDao.GetPassword(Arg.Any<string>()).Returns("91");
            var rsaToken = Substitute.For<IToken>();
            rsaToken.GetRandom(Arg.Any<string>()).Returns("000000");
            
            var target = new AuthenticationService(profileDao, rsaToken);

            var actual = target.IsValid("joey", "91000000");

            //always failed
            Assert.IsTrue(actual);                       
        }
    }
}
