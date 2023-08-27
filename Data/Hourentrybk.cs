﻿using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Hourentrybk
{
    public int Id { get; set; }

    public string? FleetId { get; set; }

    public DateTime? Date { get; set; }

    public double? PreviousReading { get; set; }

    public double? CurrentReading { get; set; }

    public string? TenantId { get; set; }
}
