﻿namespace ServiceManagerApi.Dtos.FaultEntry;

public record FaultEntryPostDto
{
  public Guid EntryId { get; set; }

  public string FleetId { get; set; } = null!;

  public string VmModel { get; set; } = null!;

  public string VmClass { get; set; } = null!;

  public string? Custodian { get; set; }

  public string DownType { get; set; } = null!;

  public DateTime Downtime { get; set; }

  public string LocationId { get; set; } = null!;

  public string? ResolutionType { get; set; }

  public string? DownStatus { get; set; }

  public string? ResolutionId { get; set; }

  public DateTime? WtimeStart { get; set; }

  public DateTime? WtimeEnd { get; set; }

  public string? Comment { get; set; }

  public short Status { get; set; }

  public string? TenantId { get; set; }

  public string? ReferenceId { get; set; }

  public string? FaultDetails { get; set; }

  public DateTime? ReportedDate { get; set; }
}