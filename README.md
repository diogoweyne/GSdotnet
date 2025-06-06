
# 🧠 OzSafe - Global Solution

API RESTful desenvolvida com **ASP.NET Core 9** para gerenciamento de apoio psicológico remoto em situações de calamidade. A aplicação permite o cadastro de psicólogos e pacientes, além do agendamento de sessões, com persistência em banco de dados Oracle e documentação via Swagger.

---

## 📌 Objetivo

Oferecer uma solução digital para facilitar o acesso a atendimentos psicológicos durante eventos extremos (enchentes, deslizamentos, incêndios etc.), conectando vítimas a profissionais de saúde mental de forma segura, rápida e eficaz.

---

## ✅ Funcionalidades

- 📋 Cadastro de **pacientes** e **psicólogos**
- 📆 Agendamento de **sessões** com data/hora
- 🔁 Relacionamento **1:N** entre Psicólogo e Sessões
- 🔐 Persistência em banco de dados Oracle
- 📄 Documentação automática com **Swagger**
- 🧱 Migrations e versionamento com EF Core
- 🖥️ Preparado para testes via Swagger e Postman

---

## 🧠 Modelo Relacional

- Um **Psicólogo** pode atender várias **Sessões**.
- Cada **Sessão** está associada a um **Paciente** e um **Psicólogo**.

```csharp
public class Psicologo {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Especialidade { get; set; }
    public List<Sessao> Sessoes { get; set; } = new();
}
```

---

## 🛠 Tecnologias Utilizadas

- [.NET 9 (ASP.NET Core)](https://dotnet.microsoft.com/)
- [Entity Framework Core 9](https://learn.microsoft.com/ef/core/)
- [Oracle.EntityFrameworkCore](https://www.nuget.org/packages/Oracle.EntityFrameworkCore)
- [Swagger (Swashbuckle)](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Visual Studio / VS Code](https://visualstudio.microsoft.com/)

---

## ⚙️ Como Configurar

### 1. Clonar o repositório

```bash
git clone https://github.com/diogoweyne/GSdotnet.git
cd MindReliefAPI
```

### 2. Configurar string de conexão

No `appsettings.json`, edite a string:

```json
"ConnectionStrings": {
  "OracleConnection": "User Id=rm558380;Password=fiap24;Data Source=oracle.fiap.com.br:1521/ORCL"
}
```

### 3. Criar banco via EF Core

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Executar a API

```bash
dotnet run
```

Acesse no navegador:  
🔗 [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🔄 Exemplos de Requisições

### 🔹 Criar Psicólogo

`POST /api/psicologos`

```json
{
  "nome": "Dra. Ana Paula",
  "especialidade": "Psicologia Clínica"
}
```

### 🔹 Criar Paciente

`POST /api/pacientes`

```json
{
  "nome": "Carlos Souza",
  "contato": "(11) 91234-5678"
}
```

### 🔹 Agendar Sessão

`POST /api/sessoes`

```json
{
  "dataHora": "2025-06-01T10:00:00",
  "descricao": "Atendimento após desastre natural",
  "psicologoId": 1,
  "pacienteId": 2
}
```

---

## 📂 Estrutura de Pastas

```
MindReliefAPI/
├── Controllers/
│   ├── PacientesController.cs
│   ├── PsicologosController.cs
│   └── SessoesController.cs
├── Models/
│   ├── Paciente.cs
│   ├── Psicologo.cs
│   └── Sessao.cs
├── Data/
│   └── AppDbContext.cs
├── Program.cs
└── appsettings.json
```

---

## 🧪 Testes

- Realizados com o Swagger diretamente via endpoint `/swagger`
- Suporte a testes com Postman (JSON completo disponível no repositório)

## 👨‍💻 Desenvolvido por

 Diogo Weyne, Gustavo Tonato Maia e João Victor de Souza  
Para a disciplina **Advanced Business Development with .NET** - FIAP
