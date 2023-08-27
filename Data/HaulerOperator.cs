﻿using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class HaulerOperator
{
    public string EmpCode { get; set; } = null!;

    public string? EmpName { get; set; }

    public string? TenantId { get; set; }

    public int Id { get; set; }

    public virtual ICollection<CycleDetail> CycleDetails { get; set; } = new List<CycleDetail>();
}
