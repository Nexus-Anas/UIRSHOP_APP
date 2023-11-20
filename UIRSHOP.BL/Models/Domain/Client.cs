using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UIRSHOP.DAL;

public partial class Client
{
    public int Id { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Email { get; set; }

    public string? Address { get; set; }

    public string Tel { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime DateCreation { get; set; } = DateTime.Now;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
