﻿using SlackClone.Contract.Requests;
using SlackClone.Core.Services;
using System;

namespace SlackClone.Core.UseCases
{
    public interface IAuthCommandFactory :
        ICommandFactory
    {
    }

    public class AuthCommandFactory :
        IAuthCommandFactory
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepo;

        public AuthCommandFactory(
            ITokenGenerator tokenGenerator, 
            IUserRepository userRepo)
        {
            _tokenGenerator = tokenGenerator;
            _userRepo = userRepo;
        }

        public ICommand<T> Create<T>(IRequest request)
        {
            switch(request)
            {
                case SignInUserRequest signInUserRequest:
                    return new SignInUserCommand(
                        signInUserRequest,
                        _userRepo,
                        _tokenGenerator) as ICommand<T>;

                case SignUpUserRequest signUpUserRequest:
                    return new SignUpUserCommand(
                        signUpUserRequest,
                        _userRepo,
                        _tokenGenerator) as ICommand<T>;

                default:
                    throw new Exception("Unable to create auth command.");
            }
        }
    }
}
