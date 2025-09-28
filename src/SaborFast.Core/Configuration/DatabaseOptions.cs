namespace SaborFast.Core.Configuration;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public string ConnectionString { get; set; } = string.Empty;

    public int MaxRetryCount { get; set; } = 3;

    public TimeSpan CommandTimeout { get; set; } = TimeSpan.FromSeconds(30);

    public bool EnableSensitiveDataLogging { get; set; } = false;
}