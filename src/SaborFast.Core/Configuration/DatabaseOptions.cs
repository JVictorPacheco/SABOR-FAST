// PELO O QUE EU ENTENDI ESTE ARQUIVO SERIA PARA DEFINIR AS VARIVAIES DE CONEXÃO DO ARQUIVO APPSETINGS.JSON

namespace SaborFast.Core.Configuration;

public class DatabaseOptions
{
    public const string SectionName = "Database";
    // - Define uma constante com o nome da seção no arquivo de configuração
    // - Usado para mapear esta classe com a seção "Database" no appsettings.json
    //- Evita "magic strings" espalhadas pelo código

    public string ConnectionString { get; set; } = string.Empty;
    //  - Propriedade que armazena a string de conexão com o banco PostgreSQL
    //  - get; set; = propriedade com getter e setter automáticos
    //  - = string.Empty = valor padrão (string vazia) para evitar
    //   valores null

    public int MaxRetryCount { get; set; } = 3;
    //  - Define quantas tentativas de reconexão o Entity Framework fará em caso de falha

    public TimeSpan CommandTimeout { get; set; } = TimeSpan.FromSeconds(30);
    // - Define o tempo limite para execução de comandos SQL
    // - TimeSpan.FromSeconds(30) = 30 segundos de timeout
    // - Evita que comandos SQL travem a aplicação indefinidamente



    public bool EnableSensitiveDataLogging { get; set; } = false;
}