﻿using System;
using System.Collections.Generic;

namespace ServiceManagerApi.Data
{
    public partial class ScheduleTransaction
    {
        public Guid Id { get; set; }
        public string? EquipmentId { get; set; }
        public byte[]? ReferenceId { get; set; }
        public int ItemValueId { get; set; }

        public virtual ItemValue ItemValue { get; set; } = null!;
    }
}
