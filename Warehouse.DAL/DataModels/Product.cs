using System;
using System.Collections.Generic;

namespace Warehouse.DAL.DataModels;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
