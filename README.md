# Lead Management API

## Descrição

A Lead Management API é uma aplicação para gerenciar leads, permitindo o registro, filtragem e atualização de leads.

### Notas

- Todo - Deixei no projeto alguns TODOs para melhorias futuras.
- Note - Deixei algumas notas no projeto para explicar algumas decisões tomadas.
- Testes - Não implementei testes unitários, por questão de tempo, mas criei uma collection de testes com IA via Postman, disponível na raiz deste projeto.
- Para simular o envio de email criei um serviço para gerar um arquivo TXT, o arquivo é salvo na raiz da solução API e deixei uma cópia na raiz do projeto.

## Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core

## Estrutura do Projeto

- `src/Backend/LeadManagement.API`: Contém os controladores da API.
- `src/Backend/LeadManagement.Application`: Contém os casos de uso e lógica de aplicação.
- `src/Backend/LeadManagement.Communication`: Contém as requisições e respostas de comunicação.

## Endpoints

### Registrar Lead

- **URL**: `/Lead`
- **Método**: `POST`
- **Request**: `RequestRegisterLeadJson`
- **Responses**:
    - `201 Created`: `ResponseRegisteredLeadJson`
    - `400 Bad Request`: `ResponseErrorJson`

### Filtrar Lead por ID

- **URL**: `/Lead/{id}`
- **Método**: `GET`
- **Responses**:
    - `200 OK`: `ResponseFilteredLeadJson`
    - `404 Not Found`: `ResponseErrorJson`

### Filtrar Leads por Status

- **URL**: `/Lead/filterByStatus`
- **Método**: `GET`
- **Request**: `RequestFilterLeadJson`
- **Responses**:
    - `200 OK`: `ResponseListLeadJson`
    - `204 No Content`: `ResponseErrorJson`

### Atualizar Lead

- **URL**: `/Lead/{id}`
- **Método**: `PUT`
- **Request**: `RequestUpdateLeadJson`
- **Responses**:
    - `200 OK`
    - `404 Not Found`: `ResponseErrorJson`

## Swagger

A API possui documentação gerada automaticamente pelo Swagger. 
Para acessar a documentação, execute a aplicação e acesse a URL 
`https://localhost:7071/swagger/index.html`.

## Como Executar

1. Clone o repositório:
   ```sh
   git clone <URL_DO_REPOSITORIO>