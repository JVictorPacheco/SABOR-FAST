namespace SaborFast.Configurarion;

public class DatabaseOptions
{   //Nome da seção no appsettings.json
    public const string SectionName = "Database";

    //String de conexão com o banco
    public string ConnectionString { get; set; } = string.Empty;

    // Tentativas de reconexão se der erro
    public int MaxRetryCount { get; set; } = 3;

    //Timeout para comandos SQL
    public TimeSpan CommandTimeout { get; set; } = TimeSpan.FromSeconds(30);

    public bool EnableSensitiveDataLogging { get; set; } = false;
    


}