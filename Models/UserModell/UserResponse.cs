﻿namespace EventTicketingApp.Models.UserModell
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public Guid RoleId { get; set; } = default!;
        public Guid WalletId { get; set; } = default!;
    }
}
