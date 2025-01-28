# GitHub API - Blip Challenge

Este repositório contém uma API intermediária que acessa a API pública do GitHub para obter informações sobre os repositórios da organização **Takenet**. A API foi criada como parte do desafio técnico para o desenvolvimento de um chatbot no portal **Blip AI**.

### Desafio Técnico
O objetivo do desafio é criar uma API intermediária que forneça informações sobre os repositórios de linguagem **C#** mais antigos da organização **Takenet** no GitHub. A API também deve retornar o avatar da organização **Blip** para ser usado no chatbot.


### Url Api publicada
https://repository-github.azurewebsites.net/swagger/index.html

---

## Funcionalidades

- **Endpoint `/api/github/avatar`**: Retorna a URL do avatar da organização **Blip** no GitHub.
- **Endpoint `/api/github/repositories`**: Retorna os 5 repositórios mais antigos em **C#** da organização **Takenet**, ordenados por data de criação.

---

## Tecnologias Utilizadas

- **.NET 8**
- **Swagger** para documentação da API
- **HttpClient** para consumir a API pública do GitHub
- **Newtonsoft.Json** para deserialização de dados JSON
- **Swashbuckle.AspNetCore** para integração do Swagger

---

## Requisitos

- **.NET 8 SDK** ou superior
- **Visual Studio 2022** (ou outro IDE compatível com .NET)
- **GitHub API Pública** para acessar os dados dos repositórios e do avatar
