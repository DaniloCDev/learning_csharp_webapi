# README - API CRUD de Posts

## Descrição do Projeto

Este é um projeto de uma API CRUD (Create, Read, Update, Delete) para gerenciamento de posts, construído utilizando C# e .NET Core. O projeto foi desenvolvido com o objetivo de aprender os conceitos e fundamentos das tecnologias envolvidas, como desenvolvimento de APIs RESTful, integração com MongoDB,Docker e boas práticas de programação. ( deixo bem claro que tudo aqui foi apenas para aprendizado não sou nenhum profissional ou algo assim, estou aprendendo e com este projeto aprendi o basico para saber oque e aonde aplicar )!. 

A API permite realizar as seguintes operações:

- **GET /api/Post**: Recupera todos os posts.
- **POST /api/Post**: Cria um novo post.
- **GET /api/Post/{id}**: Recupera um post específico pelo ID.
- **PUT /api/Post/{id}**: Atualiza um post existente.
- **DELETE /api/Post/{id}**: Deleta um post pelo ID.

O armazenamento dos posts é feito no **MongoDB**, um banco de dados NoSQL. A API é estruturada de forma a ser facilmente escalável, modular e bem documentada.

---

## Tecnologias Utilizadas

- **C#**: Linguagem de programação utilizada para desenvolver a API, focando em aprendizado de boas práticas de programação orientada a objetos e construção de APIs.
- **.NET Core**: Framework utilizado para o desenvolvimento da API. A escolha do .NET Core foi motivada pelo seu desempenho, flexibilidade e suporte à criação de APIs robustas e eficientes.
- **MongoDB**: Banco de dados NoSQL utilizado para armazenar os posts. Escolhido pela flexibilidade de seu modelo de dados e facilidade de integração com o .NET Core.
- **Swagger**: Ferramenta para documentação da API, gerando uma interface gráfica para fácil interação com os endpoints da API. A documentação gerada está disponível na URL `/swagger/v1/swagger.json` e permite testar a API diretamente através de um navegador.
- **Docker**: Utilizado para empacotar a aplicação e suas dependências em containers. O uso do Docker facilita a criação de ambientes de desenvolvimento e produção consistentes, além de melhorar a portabilidade e escalabilidade da aplicação.

---

## Como rodar o projeto

### Pré-requisitos

Antes de rodar o projeto, você precisará ter as seguintes ferramentas instaladas:

- **.NET SDK** (versão 6 ou superior)
- **MongoDB** (local ou na nuvem)
- **Docker** (opcional, mas recomendado)

### Instruções para execução

1. **Clonar o repositório:**

   Clone este repositório para sua máquina local:

   ```bash
   git clone https://github.com/DaniloCDev/learning_csharp_webapi.git
   ```

2. **Configurar o MongoDB:**

   Certifique-se de que o MongoDB está rodando localmente ou que você tenha uma instância na nuvem. Se estiver utilizando o MongoDB localmente, o padrão da URL de conexão será algo como `mongodb://localhost:27017`.

3. **Configuração de Docker (opcional):**

   Se preferir rodar a aplicação em um container Docker, você pode utilizar o arquivo `Dockerfile` presente no projeto. Basta executar o seguinte comando na raiz do projeto:

   ```bash
   docker build -t nome-da-imagem .
   docker run -p 5000:80 nome-da-imagem
   ```

   A aplicação ficará disponível no endereço `http://localhost:5000`.

4. **Executar a API:**

   Se não for utilizar Docker, pode executar a aplicação diretamente com o comando:

   ```bash
   dotnet run
   ```

   A API estará disponível em `http://localhost:5000`.

---

## Endpoints da API

Abaixo estão os principais endpoints da API e seus detalhes:

### 1. **GET /api/Post**

Recupera todos os posts armazenados no MongoDB.

**Resposta:**
```json
[
  {
    "id": "7bd1bdd9-6da7-4715-82b6-c8ab88834b9c",
    "title": "teste swagger",
    "content": "Conteúdo do post 2",
    "createdAt": "2025-01-20T15:32:29.4229195Z"
  },
  {
    "id": "7bd1bdd9-6da7-4715-82b6-c8ab88834b9d",
    "title": "Outro post",
    "content": "Conteúdo de outro post",
    "createdAt": "2025-01-19T15:32:29.4229195Z"
  }
]
```

### 2. **POST /api/Post**

Cria um novo post. Envie um objeto JSON no corpo da requisição com os campos `title` e `content` para criar o post.

**Corpo da requisição:**
```json
{
  "title": "Meu novo post 2",
  "content": "Conteúdo do post 2"
}
```

**Resposta:**
```json
{
  "id": "7bd1bdd9-6da7-4715-82b6-c8ab88834b9c",
  "title": "Meu novo post 2",
  "content": "Conteúdo do post 2",
  "createdAt": "2025-01-20T15:32:29.4229195Z"
}
```

### 3. **GET /api/Post/{id}**

Recupera um post específico pelo ID.

**Exemplo de URL:**
```
GET /api/Post/7bd1bdd9-6da7-4715-82b6-c8ab88834b9c
```

**Resposta:**
```json
{
  "id": "7bd1bdd9-6da7-4715-82b6-c8ab88834b9c",
  "title": "Meu novo post 2",
  "content": "Conteúdo do post 2",
  "createdAt": "2025-01-20T15:32:29.4229195Z"
}
```

### 4. **PUT /api/Post/{id}**

Atualiza um post existente. Envie um objeto JSON com os campos `title` e `content`.

**Exemplo de URL:**
```
PUT /api/Post/7bd1bdd9-6da7-4715-82b6-c8ab88834b9c
```

**Corpo da requisição:**
```json
{
  "title": "Título atualizado",
  "content": "Conteúdo do post atualizado"
}
```

**Resposta:**
```json
{
  "id": "7bd1bdd9-6da7-4715-82b6-c8ab88834b9c",
  "title": "Título atualizado",
  "content": "Conteúdo do post atualizado",
  "createdAt": "2025-01-20T15:32:29.4229195Z"
}
```

### 5. **DELETE /api/Post/{id}**

Deleta um post pelo ID.

**Exemplo de URL:**
```
DELETE /api/Post/7bd1bdd9-6da7-4715-82b6-c8ab88834b9c
```

**Resposta:**
```json
{
  "message": "Post deletado com sucesso"
}
```

---

## Aprendizados

### Docker

Durante o desenvolvimento desta API, foi possível aprender sobre a utilização do **Docker** para containerizar aplicações. O Docker permite criar ambientes isolados, garantindo que a aplicação rode da mesma forma em diferentes máquinas, o que facilita o desenvolvimento, testes e deploy. A utilização do Docker foi fundamental para garantir que a API, junto ao MongoDB, fosse facilmente configurada e executada em diferentes ambientes, sem a preocupação com dependências locais.

### C# e .NET

A escolha do **C#** e do **.NET Core** para este projeto foi essencial para aprender sobre o desenvolvimento de APIs com uma linguagem robusta e moderna. Com o .NET Core, pude explorar a criação de rotas, manipulação de requests e responses, e integração com o MongoDB de forma simples e eficiente. O .NET Core também forneceu ferramentas úteis como o Entity Framework e a facilidade de documentação automática com o Swagger, que contribuiu bastante para o aprendizado.

### MongoDB

O uso do **MongoDB** ajudou a entender a diferença entre bancos de dados relacionais e NoSQL, além de proporcionar uma maneira rápida e eficiente de armazenar dados de forma flexível. A integração do MongoDB com o .NET foi feita através de pacotes de NuGet, e com isso pude aprender a realizar operações básicas de CRUD (Create, Read, Update, Delete) diretamente com o banco de dados.

---

## Conclusão

Este projeto foi uma excelente oportunidade de aprendizado, abordando desde a criação de uma API RESTful até a implementação de práticas como o uso de Docker e integração com MongoDB. A experiência proporcionou uma compreensão profunda das tecnologias utilizadas e de como elas se complementam para criar uma aplicação escalável, eficiente e de fácil manutenção.
