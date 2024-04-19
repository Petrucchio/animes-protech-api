# animes-protech-api
API .NET Core para gerenciar animes. Segue Clean Architecture e oferece CRUD de animes, filtros, Swagger, testes e segurança.

# API de Animes ProTech

Este projeto é uma API construída em .NET Core que fornece funcionalidades para gerenciar animes. A API segue os princípios da Clean Architecture e oferece uma série de recursos para facilitar o desenvolvimento e a manutenção do código.

## Funcionalidades

- Cadastro de animes com nome, resumo e diretor.
- Listagem de animes com opções de filtragem por diretor, nome e palavras-chave no resumo.
- Atualização de animes.
- Exclusão lógica de animes.

## Pré-requisitos

- .NET Core SDK 8.0
- Entity Framework Core X.X.X

## Configuração

1. Clone o repositório.
2. Navegue até o diretório do projeto.
3. Execute `dotnet restore` para restaurar as dependências.
4. Configure seu banco de dados no arquivo `appsettings.json`.
5. Execute `dotnet ef database update` para aplicar as migrações ao banco de dados.
6. Execute `dotnet run` para iniciar o servidor.

## Gerador de Token

Esta API utiliza o [Gerador de Token](https://github.com/Petrucchio/gerador-de-token) para gerar tokens de autenticação.

Para configurar o Gerador de Token, siga as instruções no repositório vinculado.

## Testes Unitários

Este projeto inclui testes unitários para garantir a qualidade e integridade do código. Os testes são realizados usando [Testes Unitários](https://github.com/Petrucchio/TestesUnitarios).

Para executar os testes unitários, siga as instruções no repositório vinculado.

## Contribuindo

Para contribuir com este projeto, siga estas etapas:
1. Fork este repositório.
2. Crie uma branch: `git checkout -b feature/NomeDaFeature`.
3. Faça suas alterações e commit: `git commit -m 'Adicione uma nova feature'`.
4. Envie para a branch principal: `git push origin feature/NomeDaFeature`.
5. Envie um pull request.

## Licença

Este projeto está licenciado sob a [Licença MIT](https://opensource.org/licenses/MIT).
