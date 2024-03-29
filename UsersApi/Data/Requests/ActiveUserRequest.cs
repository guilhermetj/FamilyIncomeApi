﻿using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.Requests
{
    public class ActiveUserRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ActiveCode { get; set; }
    }
}
