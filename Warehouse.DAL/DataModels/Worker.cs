using System;
using System.Collections.Generic;

namespace Warehouse.DAL.DataModels;

public partial class Worker
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; } = new List<Department>();
}
