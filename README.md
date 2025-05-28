# MindRelief API

## 💡 Descrição
API RESTful desenvolvida com ASP.NET Core para oferecer apoio psicológico remoto em contextos de calamidade. Permite o cadastro de psicólogos e pacientes, além do agendamento de sessões com persistência em banco relacional e documentação via Swagger.

## ✅ Funcionalidades
- Cadastro de psicólogos e pacientes
- Agendamento de sessões (1 psicólogo → N sessões)
- API documentada com Swagger
- Migrations e integração com banco relacional

## 🛠 Tecnologias
- ASP.NET Core 7
- Entity Framework Core
- Swagger
- Oracle ou SQL Server

## 🔄 Relacionamento
Um Psicólogo pode ter várias Sessões:
```csharp
public class Psicologo {
    public List<Sessao> Sessoes { get; set; }
}
```

## 🚀 Como Rodar
1. Configure sua string de conexão em `appsettings.json`
2. Rode os comandos:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

3. Acesse:
- `https://localhost:5001/swagger` → Swagger UI

## 🧪 Exemplo de Teste com Swagger
```json
POST /api/sessoes
{
  "dataHora": "2025-06-01T10:00:00",
  "psicologoId": 1,
  "pacienteId": 4,
  "descricao": "Sessão de apoio após enchente"
}
```

---

Desenvolvido para a disciplina Advanced Business Development with .NET - FIAP.