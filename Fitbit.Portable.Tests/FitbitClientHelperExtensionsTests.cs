﻿using System;
using Fitbit.Api.Portable;
using NUnit.Framework;

namespace Fitbit.Portable.Tests
{
    [TestFixture]
    public class FitbitClientHelperExtensionsTests
    {
        [Test]
        public void ToFullUrl_No_Preceeding_Slash()
        {
            var apiCall = "1/user/-/devices.json".ToFullUrl();

            Assert.IsNotNull(apiCall);
            Assert.IsFalse(string.IsNullOrWhiteSpace(apiCall));
            Assert.AreEqual("https://api.fitbit.com/1/user/-/devices.json", apiCall);
        }

        [Test]
        public void ToFullUrl_Preceeding_Slash()
        {
            var apiCall = "/1/user/-/devices.json".ToFullUrl();

            Assert.IsNotNull(apiCall);
            Assert.IsFalse(string.IsNullOrWhiteSpace(apiCall));
            Assert.AreEqual("https://api.fitbit.com/1/user/-/devices.json", apiCall);
        }

        [Test]
        public void ToFullUrl_No_Preceeding_Slash_UserId_NotSpecified()
        {
            var apiCall = "1/user/{0}/friends.json".ToFullUrl();

            Assert.IsNotNull(apiCall);
            Assert.IsFalse(string.IsNullOrWhiteSpace(apiCall));
            Assert.AreEqual("https://api.fitbit.com/1/user/-/friends.json", apiCall);
        }

        [Test]
        public void ToFullUrl_Preceeding_Slash_UserId_NotSpecified()
        {
            var apiCall = "/1/user/{0}/friends.json".ToFullUrl();

            Assert.IsNotNull(apiCall);
            Assert.IsFalse(string.IsNullOrWhiteSpace(apiCall));
            Assert.AreEqual("https://api.fitbit.com/1/user/-/friends.json", apiCall);
        }

        [Test]
        public void ToFullUrl_No_Preceeding_Slash_UserId_Specified()
        {
            var apiCall = "1/user/{0}/friends.json".ToFullUrl("2KNXXX");

            Assert.IsNotNull(apiCall);
            Assert.IsFalse(string.IsNullOrWhiteSpace(apiCall));
            Assert.AreEqual("https://api.fitbit.com/1/user/2KNXXX/friends.json", apiCall);
        }

        [Test]
        public void ToFullUrl_Preceeding_Slash_UserId_Specified()
        {
            var apiCall = "/1/user/{0}/friends.json".ToFullUrl("2KNXXX");

            Assert.IsNotNull(apiCall);
            Assert.IsFalse(string.IsNullOrWhiteSpace(apiCall));
            Assert.AreEqual("https://api.fitbit.com/1/user/2KNXXX/friends.json", apiCall);
        }

        [Test]
        public void ToFitbitFormat_DateTime()
        {
            DateTime date = new DateTime(2014, 08, 21);
            Assert.AreEqual("2014-08-21", date.ToFitbitFormat());
        }

        [Test]
        public void ToElapsedSeconds_Mightnight()
        {
            DateTime date = new DateTime(2014, 10, 10, 0, 0, 0);
            Assert.AreEqual(0, date.ToElapsedSeconds());
        }

        [Test]
        public void ToElapsedSeconds_OneMinutePassedMidnight()
        {
            DateTime date = new DateTime(2014, 10, 10, 0, 1, 0);
            Assert.AreEqual(60, date.ToElapsedSeconds());
        }

        [Test]
        public void ToElapsedSeconds_OneAM()
        {
            DateTime date = new DateTime(2014, 10, 10, 1, 0, 0);
            Assert.AreEqual(3600, date.ToElapsedSeconds());
        }

        [Test]
        public void ToElapsedSeconds_ElevenPM()
        {
            DateTime date = new DateTime(2014, 10, 10, 23, 0, 0);
            Assert.AreEqual(82800, date.ToElapsedSeconds());
        }
    }
}