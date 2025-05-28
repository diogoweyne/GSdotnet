# 🧠 MindRelief API

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
