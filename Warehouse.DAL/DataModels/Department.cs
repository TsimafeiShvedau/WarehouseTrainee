using System;
using System.Collections.Generic;

namespace Warehouse.DAL.DataModels;

public partial class Department
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
