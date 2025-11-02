//using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using SaborFast.Core.Entities;


namespace SaborFast.Infrastructure.Data;


    /// <summary>
        /// Contexto principal do Entity Framework Core para o SaborFast.
        /// Gerencia a conexão com o banco de dados e mapeia as entidades para tabelas.
        /// Esta classe é o ponto central de acesso aos dados da aplicação.
         /// </summary>
        /// <remarks>
        /// O DbContext implementa os padrões Unit of Work e Repository,
        /// permitindo operações transacionais e rastreamento de mudanças nas entidades.
        /// Todas as operações de CRUD passam por este contexto.
    /// </remarks>
public class SaborFastDbContext : DbContext
{

    /// <summary>
        /// Inicializa uma nova instância do SaborFastDbContext com as opções especificadas.
        /// </summary>
        // <param name="options">
        /// Configurações do DbContext incluindo string de conexão, provider do banco,
        /// configurações de logging e comportamentos específicos do Entity Framework.
        /// </param>
        /// <remarks>
        /// As opções são injetadas via Dependency Injection e configuradas no Program.cs.
        /// O construtor repassa as configurações para a classe base DbContext.
    /// </remarks>
    public SaborFastDbContext(DbContextOptions<SaborFastDbContext> options) : base(options)
    {
    }

    /// <summary>
        /// Representa a tabela de Restaurantes no banco de dados.
        /// Fornece acesso às operações CRUD para entidades do tipo Restaurante.
        /// </summary>
        /// <value>
        /// DbSet que mapeia para a tabela "Restaurantes" no banco.
        /// Permite operações como Add, Update, Remove e consultas LINQ.
    /// </value>
    public DbSet<Restaurante> Restaurantes { get; set; } = null!;



    /// <summary>
        /// Representa a tabela de Itens do Cardápio no banco de dados.
        /// Fornece acesso às operações CRUD para entidadesdo tipo CardapioItem.
        /// </summary>
        /// <value>
        /// DbSet que mapeia para a tabela "CardapioItems" no banco.
        /// Possui relacionamento de Foreign Key com a tabela Restaurantes.
    /// </value>
    public DbSet<CardapioItem> CardapioItems { get; set; } = null!;

    /// <summary>
        /// Configura o modelo de dados durante a criação do banco.
        /// Override do método base para personalizar mapeamentos, relacionamentos e restrições.
        /// </summary>
        // <param name="modelBuilder"> 
        /// /// Construtor do modelo que permite configurar entidades, relacionamentos,
        /// índices, restrições e outras configurações específicas do banco.
        /// </param>
        /// <remarks>
        /// Este método é executado automaticamente pelo EFCore durante a inicialização.
        /// Chama base.OnModelCreating() primeiro para aplicar convenções padrão,
        /// depois permite configurações customizadas específicas do domínio.
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}