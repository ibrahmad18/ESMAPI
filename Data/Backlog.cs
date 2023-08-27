﻿using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data;

public partial class Backlog
{
    public int Id { get; set; }

    public string? EquipmentId { get; set; }

    public DateTime? Bdate { get; set; }

    public string? Item { get; set; }

    public string? Note { get; set; }

    public string? Comment { get; set; }

    public string? ReferenceId { get; set; }

    public string? Status { get; set; }

    public DateTime? Cdate { get; set; }

    public string? TenantId { get; set; }

    public string? Priority { get; set; }

    public string? Source { get; set; }

    public string? DownType { get; set; }
}
