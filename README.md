# 🍽️ SaborFast - Sistema de Gestão de Restaurantes

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-orange)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-green)
![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow)

## 📋 Sobre o Projeto

**SaborFast** é um sistema completo de gestão de restaurantes e cardápios desenvolvido em **.NET 8** seguindo os princípios de **Clean Architecture**. O projeto foi estruturado para ser escalável, manutenível e seguir as melhores práticas de desenvolvimento de software.

## 🏗️ Arquitetura do Projeto

O projeto segue os princípios de **Clean Architecture** organizados em camadas bem definidas:

```
🏛️ SaborFast/
├── 📁 src/
│   ├── 🎯 SaborFast.Core/              # Camada de Domínio
│   │   ├── 📝 Entities/                # Entidades de negócio
│   │   ├── 🔌 Interfaces/              # Contratos e abstrações
│   │   └── ⚙️ Configuration/           # Configurações do domínio
│   │
│   ├── 💼 SaborFast.Application/       # Camada de Aplicação
│   │   ├── 🛠️ Services/                # Lógica de negócio
│   │   ├── 📦 DTOs/                    # Data Transfer Objects
│   │   └── 🗺️ Mappings/                # AutoMapper profiles
│   │
│   ├── 🏢 SaborFast.Infrastructure/    # Camada de Infraestrutura
│   │   ├── 📊 Data/                    # DbContext e configurações
│   │   ├── 🗃️ Repositories/            # Implementação dos repositórios
│   │   └── 🔧 Services/                # Serviços de infraestrutura
│   │
│   └── 🌐 SaborFast.Api/               # Camada de Apresentação
│       ├── 🎮 Controllers/             # Controladores da API
│       ├── 🔒 Middlewares/             # Middlewares customizados
│       └── ⚙️ Configuration/           # Configurações da API
│
├── 🧪 Tests/
│   └── SaborFast.Tests/                # Testes unitários e integração
│
└── 📄 Documentação
```

## 🎯 Funcionalidades

### 🏪 Gestão de Restaurantes
- [x] **CRUD Completo** - Criar, listar, atualizar e excluir restaurantes
- [x] **Busca por Categoria** - Filtrar restaurantes por tipo de culinária
- [x] **Busca por Nome** - Busca parcial e completa por nome
- [x] **Validação de Nome Único** - Impede duplicação de nomes
- [ ] **Geolocalização** - Endereços e coordenadas GPS
- [ ] **Horário de Funcionamento** - Controle de abertura/fechamento
- [ ] **Avaliações e Comentários** - Sistema de reviews

### 🍕 Gestão de Cardápios
- [x] **CRUD de Itens** - Gerenciar pratos e bebidas
- [x] **Busca por Restaurante** - Listar cardápio específico
- [x] **Busca por Faixa de Preço** - Filtrar por valores
- [x] **Busca por Nome** - Localizar itens específicos
- [x] **Controle de Disponibilidade** - Ativar/desativar itens
- [ ] **Categorias de Pratos** - Organizacão por tipo (entrada, principal, sobremesa)
- [ ] **Promoções e Descontos** - Sistema de ofertas
- [ ] **Upload de Imagens** - Fotos dos pratos

### 📊 Funcionalidades Futuras
- [ ] **Sistema de Pedidos** - Gestão completa de orders
- [ ] **Pagamentos Online** - Integração com gateways
- [ ] **Delivery Tracking** - Rastreamento de entregas
- [ ] **Dashboard Analytics** - Relatórios e métricas
- [ ] **Sistema de Notificações** - Alerts em tempo real
- [ ] **API de Terceiros** - Integração com iFood, Uber Eats
- [ ] **Multi-tenancy** - Suporte a múltiplos clientes

## 🛠️ Tecnologias Utilizadas

### Backend
- **Framework**: .NET 8.0
- **ORM**: Entity Framework Core
- **Banco de Dados**: SQL Server (configurável)
- **Documentação**: Swagger/OpenAPI
- **Testes**: xUnit, Moq, FluentAssertions

### Arquitetura e Padrões
- **Clean Architecture** - Separação clara de responsabilidades
- **Repository Pattern** - Abstração do acesso a dados
- **Unit of Work** - Controle transacional
- **Dependency Injection** - Inversão de controle nativa
- **SOLID Principles** - Código limpo e manutenível

### Práticas de Desenvolvimento
- **Code First** - Migrations automáticas
- **Async/Await** - Programação assíncrona
- **XML Documentation** - Documentação completa do código
- **Data Annotations** - Validações declarativas
- **Lazy Loading** - Carregamento sob demanda

## 📊 Modelo de Dados

### 🏪 Restaurante
```csharp
public class Restaurante : BaseEntity
{
    public string Nome { get; set; }           // Nome único, obrigatório
    public string? Categoria { get; set; }     // Tipo de culinária
    public ICollection<CardapioItem> CardapioItens { get; set; }
}
```

### 🍽️ CardapioItem
```csharp
public class CardapioItem : BaseEntity
{
    public int RestauranteId { get; set; }     // FK para Restaurante
    public string Item { get; set; }           // Nome do prato/bebida
    public decimal Price { get; set; }         // Preço com precisão decimal
    public string Description { get; set; }    // Descrição detalhada
    public Restaurante Restaurante { get; set; }
}
```

### 📋 BaseEntity
```csharp
public abstract class BaseEntity
{
    public int Id { get; set; }               // Chave primária
    public DateTime CreatedAt { get; set; }   // Data de criação
    public DateTime UpdatedAt { get; set; }   // Última atualização
}
```

## 🚀 Status de Desenvolvimento

### ✅ Implementado (Camadas Core + Infrastructure)

#### 📁 SaborFast.Core
- ✅ **Entidades**: BaseEntity, Restaurante, CardapioItem
- ✅ **Interfaces**: IRepository<T>, IRestauranteRepository, ICardapioItemRepository
- ✅ **Configurações**: DatabaseOptions para configuração de banco

#### 📁 SaborFast.Infrastructure  
- ✅ **DbContext**: SaborFastDbContext configurado com EF Core
- ✅ **Repositories**: BaseRepository<T>, RestauranteRepository, CardapioItemRepository
- ✅ **Configurações**: Mapeamento completo das entidades

### 🔄 Em Desenvolvimento (Camada Application)

#### 📁 SaborFast.Application - **PRÓXIMO PASSO**
- 🔄 **Interfaces de Services**: IRestauranteService, ICardapioItemService
- 🔄 **Implementação de Services**: RestauranteService, CardapioItemService  
- ⏳ **DTOs**: RestauranteDto, CardapioItemDto, CreateDto, UpdateDto
- ⏳ **Validações**: FluentValidation para regras de negócio
- ⏳ **Mappings**: AutoMapper para conversões

### ⏳ Planejado (Camadas API + Tests)

#### 📁 SaborFast.Api
- ⏳ **Controllers**: RestauranteController, CardapioItemController
- ⏳ **Middlewares**: ExceptionHandler, Logging, CORS
- ⏳ **Configurações**: DI Container, Swagger, Authentication
- ⏳ **Endpoints**: CRUD completo para todas as entidades

#### 📁 SaborFast.Tests
- ⏳ **Unit Tests**: Testes para Services e Repositories
- ⏳ **Integration Tests**: Testes de API end-to-end
- ⏳ **Mock Data**: Factory de dados para testes

## 🔧 Configuração do Ambiente

### Pré-requisitos
```bash
- .NET 8.0 SDK
- SQL Server ou SQL Server LocalDB
- Visual Studio 2022 / VS Code / Rider
```

### Instalação
```bash
# Clone o repositório
git clone [url-do-repositorio]

# Navigate to project
cd Sabor-Fast

# Restore packages
dotnet restore

# Update database
dotnet ef database update --project src/SaborFast.Infrastructure

# Run the application
dotnet run --project src/SaborFast.Api
```

### String de Conexão
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SaborFastDb;Trusted_Connection=true;"
  }
}
```

## 📈 Próximos Passos de Desenvolvimento

### 🎯 Fase 1: Services (Em Andamento)
1. **Criar interfaces de Services** no SaborFast.Core/Interfaces
2. **Implementar Services** no SaborFast.Application/Services
3. **Adicionar validações de negócio** e tratamento de exceções
4. **Criar DTOs** para transferência de dados

### 🎯 Fase 2: API Layer
1. **Configurar Controllers** com endpoints RESTful
2. **Implementar middlewares** de erro e logging
3. **Configurar Swagger** para documentação
4. **Adicionar autenticação/autorização**

### 🎯 Fase 3: Testes e Qualidade
1. **Escrever testes unitários** para todas as camadas
2. **Criar testes de integração** para APIs
3. **Implementar code coverage** e quality gates
4. **Adicionar CI/CD pipeline**

## 🏆 Conceitos Aplicados

### 🧹 Clean Code
- **Nomes descritivos** e significativos
- **Métodos pequenos** com responsabilidade única
- **Comentários explicativos** via XML Documentation
- **Princípios DRY** (Don't Repeat Yourself)

### ⚡ SOLID Principles
- **SRP**: Cada classe tem uma responsabilidade específica
- **OCP**: Extensível para novos recursos sem modificar código existente
- **LSP**: Interfaces bem definidas e substituíveis
- **ISP**: Interfaces específicas para cada necessidade
- **DIP**: Dependências abstratas via interfaces

### 🔗 Design Patterns
- **Repository Pattern**: Abstração do acesso a dados
- **Unit of Work**: Controle transacional via DbContext
- **Dependency Injection**: Inversão de controle nativa do .NET
- **Factory Pattern**: Para criação de entidades e DTOs

## 📞 Contato e Contribuição

Este projeto está sendo desenvolvido como estudo de caso para demonstrar a implementação de uma arquitetura limpa e escalável em .NET 8.

### 🚀 Como Contribuir
1. Fork o projeto
2. Crie uma branch para sua feature
3. Faça commit das mudanças
4. Abra um Pull Request

---

**📝 Nota**: Este README será atualizado conforme o desenvolvimento progride. Fique atento às mudanças e novas funcionalidades implementadas.

**🔄 Última atualização**: Novembro 2024 - Camadas Core e Infrastructure concluídas, iniciando Application Services.