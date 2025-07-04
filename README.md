# 🎓 **Academy - Plataforma de Educação Online**

## 📌 **1. Apresentação**

Bem-vindo ao repositório do projeto **Academy**, desenvolvido como parte da entrega do MBA **DevXpert Full Stack .NET**, no módulo **Arquitetura, Modelagem e Qualidade de Software**.\
Este projeto tem como objetivo construir uma **plataforma educacional online** baseada em **DDD, TDD, CQRS** e outros padrões arquiteturais modernos, com múltiplos *bounded contexts* (BC), promovendo uma separação de responsabilidades clara e escalável.

> 👨‍💻 **Autor:** Breno Morais

---

## 🎯 **2. Objetivo do Projeto**

O **Academy** visa oferecer:

- **API RESTful:** Para integração com outras aplicações e criação de interfaces alternativas.
- **Gestão de Acesso:** Controle de autenticação e autorização com distinção entre alunos e administradores.
- **Persistência de Dados:** Utilização de ORM para abstração e manutenção do banco de dados.

---

## 🛠️ **3. Tecnologias Utilizadas**

| Categoria             | Tecnologia                          |
| --------------------- | ----------------------------------- |
| Linguagem             | C#                                  |
| Frameworks            | ASP.NET Core, Entity Framework Core |
| Padrões e Arquitetura | DDD, CQRS, TDD                      |
| Validação             | FluentValidation                    |
| Mapeamento            | AutoMapper                          |
| Mensageria (CQRS)     | MediatR                             |
| Autenticação          | ASP.NET Core Identity + JWT         |
| Banco de Dados        | SQLite, SQL Server                  |
| Documentação da API   | Swagger                             |

---

## 🧱 **4. Estrutura do Projeto**

```bash
📁 Academy

🌍📁 API                # Camada de apresentação e configurações da API
│   📁 Configurations  # Injeção de dependências, JWT e Identity
│   📁 Enums
│   └️📁 Data
│       📁 Const
│       📁 Dtos
│       📁 Models
│       📁 Seed

📁 Services           # Lógica de negócio separada por bounded contexts
│   📁 Core           # Camada compartilhada entre os contextos
│   │   📁 Data
│   │   📁 DomainObjects
│   │   │   📁 Exceptions
│   │   │   📁 Validations
│   │   📁 Entities
│   │   📁 Enums
│   │   📁 Events
│   │   │   └️📁 ConsultaExterna
│   │   │       📁 Dtos
│   │   │       📁 Implements
│   │   │       📁 Interfaces
│   │   📁 Extensions
│   │   📁 Interfaces
│   📁 GestaoAlunos   # Contexto de gestão de alunos
│   │   📁 Application
│   │   │   📁 AutoMapper
│   │   │   📁 CQRS
│   │   │   │   📁 Commands
│   │   │   │   📁 Queries
│   │   │   📁 DTOs
│   │   │   📁 Seed
│   │   │   📁 Services
│   │   │   │   📁 Implements
│   │   │   │   📁 Interfaces
│   │   │   └️📁 Validators
│   │   📁 Data
│   │   │   📁 Context
│   │   │   📁 Migrations
│   │   │   📁 Repository
│   │   └️📁 Domain
│   │       📁 Entities
│   │       📁 Enums
│   │       📁 Interfaces
│   │       📁 ObjectValue

│   # Os contextos GestaoConteudo e PagamentoFaturamento seguem a mesma estrutura de GestaoAlunos.

├── README.md
├── FEEDBACK.md
└── .gitignore
```

---

## ✅ **5. Funcionalidades Implementadas**

- 🔐 Autenticação com Identity e JWT
- 🧑‍🏫 Gerenciamento de usuários com perfis distintos (administrador x aluno)
- 📡 API RESTful com documentação via Swagger
- 🧪 Seed automático de dados para testes
- 🔎 Separação de responsabilidades clara por bounded context

---

## 🧩 **6. Funcionalidades da Plataforma**

Este sistema oferece uma plataforma completa para **gerenciamento de cursos online**, com funcionalidades voltadas tanto para administradores quanto para alunos.

### 👨‍🏫 Administrador

- **Cadastro de Curso**\
  Permite ao administrador cadastrar novos cursos, informando nome e conteúdo programático.\
  🔐 Pré-condição: Autenticado.

- **Cadastro de Aula**\
  Após selecionar um curso existente, o administrador pode adicionar aulas com título, conteúdo.\
  🔄 Cada aula é validada e vinculada ao curso.

---

### 🎓 Aluno

- **Matrícula em Curso**\
  Aluno autenticado pode se matricular em cursos disponíveis.\
  📌 A matrícula é criada com status *pendente de pagamento*.

- **Pagamento da Matrícula**\
  O aluno realiza o pagamento informando os dados do cartão.\
  ✅ Pagamentos aprovados ativam automaticamente a matrícula.

- **Realização de Aulas**\
  O aluno pode acessar o conteúdo das aulas.\
  📊 O progresso é registrado automaticamente.

- **Finalização do Curso**\
  Após concluir todas as aulas, o aluno pode solicitar a finalização do curso.\
  🏅 Um certificado é gerado e disponibilizado.

---

### ⚠️ Validações e Erros

- O sistema trata e exibe mensagens claras em casos de:
  - Dados inválidos no cadastro de curso ou aula;
  - Problemas de pagamento;
  - Tentativas de finalizar curso sem concluir as aulas;
  - Falhas de acesso ao conteúdo.

---

## 🚀 **7. Como Executar o Projeto**

### 📋 **Pré-requisitos**

- [.NET SDK 9.0+](https://dotnet.microsoft.com/)
- SQLite
- Visual Studio 2022 ou superior (ou sua IDE preferida)
- Git

### ▶️ **Passos**

1. **Clone o repositório**

   ```bash
   git clone https://github.com/BREN0-MORAIS/MBA03_Academy.git
   cd MBA03_Academy
   ```

2. **Configure o Banco de Dados**

   - Edite `appsettings.json` com a string de conexão do SQLite
   - Execute o projeto: o *seed* criará e populará o banco

3. **Inicie a API**

   ```bash
   cd src/Blog.Api/
   dotnet run
   ```

4. **Acesse o Swagger**

   - [https://localhost:7179/swagger/index.html](https://localhost:7179/swagger/index.html)

---

## ⚙️ **8. Configurações Importantes**

- **JWT:** Configure as chaves e opções no `appsettings.json`
- **Migrations:** Não é necessário aplicar manualmente, pois o *seed* já trata a criação e carga de dados

---

## 📚 **9. Documentação da API**

A documentação gerada pelo **Swagger** permite visualizar e testar todos os endpoints da API de forma prática e interativa:

🔗 [https://localhost:7179/swagger/index.html](https://localhost:7179/swagger/index.html)

---

## 📚 **10. Usuarios para testes**

Administrador: 
email: admin@domain.com
Senha: Admin123!

Aluno:
Email: student@domain.com
Senha:Student123! 

## 📁 **11. Considerações Finais**

- Este repositório faz parte de um projeto acadêmico e **não aceita contribuições externas**.
- Dúvidas e feedbacks devem ser enviados via **Issues**.
- O arquivo `FEEDBACK.md` é exclusivo para anotações do instrutor.

