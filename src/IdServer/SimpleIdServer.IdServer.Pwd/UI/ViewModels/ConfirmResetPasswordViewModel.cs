﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SimpleIdServer.IdServer.Pwd.UI.ViewModels
{
    public class ConfirmResetPasswordViewModel
    {
        public string? Destination { get; set; }
        public string? Code { get; set; }
        public string? Password { get; set; } = null;
        public string? ConfirmationPassword { get; set; } = null;
        public bool IsPasswordUpdated { get; set; }
        public string? ReturnUrl { get; set; } = null;

        public void Validate(ModelStateDictionary modelState)
        {
            if(Code == null)
                modelState.AddModelError("missing_code", "missing_code");

            if (string.IsNullOrWhiteSpace(Destination))
                modelState.AddModelError("missing_destination", "missing_destination");

            if (string.IsNullOrWhiteSpace(Password))
                modelState.AddModelError("missing_password", "missing_password");

            if (string.IsNullOrWhiteSpace(ConfirmationPassword))
                modelState.AddModelError("confirmation_password", "confirmation_password");

            if (Password != ConfirmationPassword)
                modelState.AddModelError("unmatch_password", "unmatch_password");
        }
    }
}
