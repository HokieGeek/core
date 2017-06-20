﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bit.Core.Models.Api
{
    public class UpdateTwoFactorAuthenticatorRequestModel : TwoFactorRequestModel
    {
        [Required]
        [StringLength(50)]
        public string Token { get; set; }
    }

    public class UpdateTwoFactorDuoRequestModel : TwoFactorRequestModel
    {
        [Required]
        [StringLength(50)]
        public string IntegrationKey { get; set; }
        [Required]
        [StringLength(50)]
        public string SecretKey { get; set; }
        [Required]
        [StringLength(50)]
        public string Host { get; set; }
    }

    public class UpdateTwoFactorYubicoOtpRequestModel : TwoFactorRequestModel, IValidatableObject
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string Key4 { get; set; }
        public string Key5 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrWhiteSpace(Key1) && string.IsNullOrWhiteSpace(Key2) && string.IsNullOrWhiteSpace(Key3) &&
                string.IsNullOrWhiteSpace(Key4) && string.IsNullOrWhiteSpace(Key5))
            {
                yield return new ValidationResult("A Key is required.", new string[] { nameof(Key1) });
            }
        }
    }

    public class TwoFactorEmailRequestModel : TwoFactorRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
    }

    public class UpdateTwoFactorEmailRequestModel : TwoFactorEmailRequestModel
    {
        [Required]
        [StringLength(50)]
        public string Token { get; set; }
    }

    public class TwoFactorProviderRequestModel : TwoFactorRequestModel
    {
        [Required]
        public Enums.TwoFactorProviderType? Type { get; set; }
    }

    public class TwoFactorRequestModel
    {
        [Required]
        public string MasterPasswordHash { get; set; }
    }

    public class TwoFactorRecoveryRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public string MasterPasswordHash { get; set; }
        [Required]
        [StringLength(32)]
        public string RecoveryCode { get; set; }
    }
}