﻿using System;
using ASarWebApi.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASarWebApi.Tests
{
    [TestClass]
    public class ASarWepApiTest
    {
        #region Utilities
        [TestMethod]
        public void CheckUserWithID_TandF()
        {
            UserModel user = new UserModel
            {
                Id = 1,
                Name = "newName",
                Birthdate = DateTime.Now
            };
            CheckEF CEF = new CheckEF();
            //CEF.CheckUserWithID(user);

            //expecting true with a valid model
            Assert.IsTrue(CEF.CheckUserWithID(user));
            //expecting false 
            user.Name = "";
            Assert.IsFalse(CEF.CheckUserWithID(user));
        }
        [TestMethod]
        public void CheckUserWithoutID_TandF()
        {
            UserModel user = new UserModel
            {                
                Name = "newName",
                Birthdate = DateTime.Now
            };
            CheckEF CEF = new CheckEF();
            //CEF.CheckUserWithID(user);

            //expecting true with a valid model
            Assert.IsTrue(CEF.CheckUserWithoutID(user));
            //expecting false 
            user.Name = "";
            Assert.IsFalse(CEF.CheckUserWithoutID(user));
        }
        #endregion utilities
    }
}
