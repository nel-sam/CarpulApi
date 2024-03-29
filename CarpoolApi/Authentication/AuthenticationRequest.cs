﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarpoolApi.Api.Authentication
{
    public class AuthenticationRequest
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
