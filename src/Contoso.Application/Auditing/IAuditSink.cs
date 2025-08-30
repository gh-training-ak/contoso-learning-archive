namespace Contoso.Application.Auditing;

public interface IAuditSink
{
    Task WriteAsync(AuditEntry entry, CancellationToken ct = default);
}
