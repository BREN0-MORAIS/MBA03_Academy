``` 📁 Academy  
├── 📁 API  // Configurações centrais da API, injeção de dependência, autenticação e dados de usuário  
│   ├── 📁 Configurations  // Dependency Injection e configuração do Identity e JWT  
│   ├── 📁 Enums   
│   ├── 📁 Data  // Configurações de usuário com Identity  
│   │   ├── 📁 Const   
│   │   ├── 📁 Dtos    
│   │   ├── 📁 Models   
│   │   └── 📁 Seed    
├── 📁 Services  // Serviços de negócio e domínio, organizados por bounded context  
│   ├── 📁 Core  // Infraestrutura e funcionalidades comuns para outros contextos  
│   │   ├── 📁 Data  // Repositório genérico para acesso a dados  
│   │   ├── 📁 DomainObjects  // Objetos do domínio como validações e exceções  
│   │   │   ├── 📁 Exceptions   
│   │   │   └── 📁 Validations   
│   │   ├── 📁 Entities  // Entidade base para herança  
│   │   ├── 📁 Enums  
│   │   ├── 📁 Events  // Eventos de domínio e integrações externas  
│   │   │   ├── 📁 ConsultaExtena  // Chamadas externas a APIs para integração entre contextos  
│   │   │   │   ├── 📁 Dtos   
│   │   │   │   ├── 📁 Implements    
│   │   │   │   └── 📁 Interfaces    
│   │   ├── 📁 Extensions   
│   │   └── 📁 Interfaces    
│   ├── 📁 GestaoAlunos   
│   │   ├── 📁 Application  // Camada de aplicação e orquestração  
│   │   │   ├── 📁 AutoMapper    
│   │   │   ├── 📁 CQRS  // Implementação de comandos e consultas  
│   │   │   │   ├── 📁 Commands   
│   │   │   │   └── 📁 Queries  
│   │   │   ├── 📁 DTOs   
│   │   │   ├── 📁 Seed  // Dados iniciais para testes ou configuração  
│   │   │   ├── 📁 Services  // Serviços de negócio específicos  
│   │   │   │   ├── 📁 Implements   
│   │   │   │   └── 📁 Interfaces   
│   │   │   └── 📁 Validators  // Validação dos dados e regras do domínio  
│   │   ├── 📁 Data  // Persistência de dados do contexto GestaoAlunos  
│   │   │   ├── 📁 Context 
│   │   │   ├── 📁 Migrations   
│   │   │   └── 📁 Repository    
│   │   ├── 📁 Domain  // Domínio do contexto GestaoAlunos  
│   │   │   ├── 📁 Entities  
│   │   │   ├── 📁 Enums   
│   │   │   ├── 📁 Interfaces   repositórios  
│   │   │   └── 📁 ObjectValue  // Objetos de valor do domínio (VO)  

// Os bounded contexts GestaoConteudo e PagamentoFaturamento seguem a mesma estrutura do GestaoAlunos.
```
