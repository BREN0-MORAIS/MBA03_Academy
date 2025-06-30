``` 📁 Academy  
├── 📁 API  // Configurações centrais da API, injeção de dependência, autenticação e dados de usuário  
│   ├── 📁 Configurations  // Dependency Injection e configuração do Identity e JWT  
│   ├── 📁 Enums  // Enumerações globais usadas pela API  
│   ├── 📁 Data  // Configurações de usuário com Identity  
│   │   ├── 📁 Const  // Constantes relacionadas a usuário  
│   │   ├── 📁 Dtos  // Objetos de transferência de dados para usuário  
│   │   ├── 📁 Models  // Modelos para persistência e validação do usuário  
│   │   └── 📁 Seed  // Dados iniciais para criação de usuários, perfis etc  
├── 📁 Services  // Serviços de negócio e domínio, organizados por bounded context  
│   ├── 📁 Core  // Infraestrutura e funcionalidades comuns para outros contextos  
│   │   ├── 📁 Data  // Repositório genérico para acesso a dados  
│   │   ├── 📁 DomainObjects  // Objetos do domínio como validações e exceções  
│   │   │   ├── 📁 Exceptions  // Classes de exceção customizadas  
│   │   │   └── 📁 Validations  // Validações de regras de negócio  
│   │   ├── 📁 Entities  // Entidade base para herança  
│   │   ├── 📁 Enums  // Enumerações genéricas  
│   │   ├── 📁 Events  // Eventos de domínio e integrações externas  
│   │   │   ├── 📁 ConsultaExtena  // Chamadas externas a APIs para integração entre contextos  
│   │   │   │   ├── 📁 Dtos  // Objetos de transferência para consultas externas  
│   │   │   │   ├── 📁 Implements  // Implementações concretas das consultas  
│   │   │   │   └── 📁 Interfaces  // Contratos para as consultas externas  
│   │   ├── 📁 Extensions  // Métodos de extensão úteis  
│   │   └── 📁 Interfaces  // Interfaces genéricas para repositórios e serviços  
│   ├── 📁 GestaoAlunos  // Bounded context de alunos e matrícula  
│   │   ├── 📁 Application  // Camada de aplicação e orquestração  
│   │   │   ├── 📁 AutoMapper  // Perfis para mapear DTOs e entidades  
│   │   │   ├── 📁 CQRS  // Implementação de comandos e consultas  
│   │   │   │   ├── 📁 Commands  // Comandos para alterar estado  
│   │   │   │   └── 📁 Queries  // Consultas para leitura de dados  
│   │   │   ├── 📁 DTOs  // Objetos para transferência de dados entre camadas  
│   │   │   ├── 📁 Seed  // Dados iniciais para testes ou configuração  
│   │   │   ├── 📁 Services  // Serviços de negócio específicos  
│   │   │   │   ├── 📁 Implements  // Implementações concretas dos serviços  
│   │   │   │   └── 📁 Interfaces  // Definições dos contratos dos serviços  
│   │   │   └── 📁 Validators  // Validação dos dados e regras do domínio  
│   │   ├── 📁 Data  // Persistência de dados do contexto GestaoAlunos  
│   │   │   ├── 📁 Context  // DbContext e configurações do EF Core  
│   │   │   ├── 📁 Migrations  // Scripts e arquivos de migração do banco  
│   │   │   └── 📁 Repository  // Implementação dos repositórios  
│   │   ├── 📁 Domain  // Domínio do contexto GestaoAlunos  
│   │   │   ├── 📁 Entities  // Entidades específicas do contexto  
│   │   │   ├── 📁 Enums  // Enumerações do domínio  
│   │   │   ├── 📁 Interfaces  // Contratos do domínio para serviços e repositórios  
│   │   │   └── 📁 ObjectValue  // Objetos de valor do domínio (VO)  

// Os bounded contexts GestaoConteudo e PagamentoFaturamento seguem a mesma estrutura do GestaoAlunos.
```