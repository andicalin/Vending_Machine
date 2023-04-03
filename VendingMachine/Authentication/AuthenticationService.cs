﻿using Nagarro.VendingMachine.Authentication;

namespace RemoteLearning.VendingMachine.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }

        public void Login(string password)
        {
            if (password == "parola")
                IsUserAuthenticated = true;
            else
                throw new InvalidPasswordException();
        }

        public void Logout()
        {
            IsUserAuthenticated = false;
        }
    }
}