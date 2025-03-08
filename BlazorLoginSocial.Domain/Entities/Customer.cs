using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLoginSocial.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TownName { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public string Febraban { get; set; } = string.Empty;

}
