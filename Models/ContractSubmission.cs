using System.ComponentModel.DataAnnotations;

namespace ApartamentosRenta.Models;

public enum ContractSubmissionType
{
    Signature,
    ChangeRequest
}

public class ContractSubmission
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string TenantName { get; set; } = string.Empty;

    [Required, StringLength(256)]
    public string TenantEmail { get; set; } = string.Empty;

    [StringLength(30)]
    public string? TenantPhone { get; set; }

    public ContractSubmissionType SubmissionType { get; set; }

    public byte[]? SignatureImageData { get; set; }

    [StringLength(100)]
    public string? SignatureImageContentType { get; set; }

    [StringLength(4000)]
    public string? ProposedChanges { get; set; }

    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
