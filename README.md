# WebApiProduct

Este é um exemplo de aplicação que demonstra uma API REST simples para gerenciar produtos. A aplicação permite criar, atualizar, buscar e excluir produtos, armazenando-os em bancos de dados SQL Server e MongoDB simultaneamente.

## Requisitos

Certifique-se de ter instalado o seguinte software:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

## Instruções de Uso

1. Clone o repositório para a sua máquina:

```bash
git clone https://github.com/victorfdelima/web-api-product.git
cd web-api-product
```

2. No terminal siga esse fluxo para subir os Containers dos bancos

```bash
./start_containers.sh
```
Após os containers do banco subirem

- Volte ao terminal e dê um dotnet ef add InitialMigrations

- No terminal dê um dotnet ef database update (isso fará com que as tabelas sejam criada no banco)

3. No terminal ainda complete o comando 
```bash
docker-compose up -d
```
- Isso fará com que o container da API suba para a mesma rede que está os bancos e a API funcione.

4. Agora, a aplicação está em execução. A API REST estará disponível em http://localhost:47662

- Você pode conferir a documentação da API em http://localhost:47662/swagger

5. Você pode usar uma ferramenta como o Postman ou curl para interagir com a API. Aqui estão alguns exemplos de endpoints disponíveis:

- GET http://localhost:47662/api/products - Lista todos os produtos.
- GET http://localhost:47662/api/products/{id} - Busca um produto pelo ID.
- POST http://localhost:47662/api/products - Cria um novo produto.
- PUT http://localhost:47662/api/products/{id} - Atualiza um produto existente pelo ID.
- DELETE http://localhost:47662/api/products/{id} - Exclui um produto pelo ID.

## O projeto possui a seguinte estrutura de diretórios:

- **Controllers:** Contém os controladores da API.
- **Context:** Fornece o contexto para o banco de dados SQL Server & Implementações para integração com diferentes tipos de bancos de dados.
- **Interface:** Contém as interfaces para repositórios e serviços.
- **Middleware:** Implementações intermediárias para gerenciamento de repositórios.
- **Models:** Definição das classes de modelo.
- **Repository:** Implementações dos repositórios para cada tipo de armazenamento.
- **Service:** Implementações dos serviços de negócios.

## Diretórios e Métodos

- **Controllers:** Contêm os controladores da API que definem os endpoints
- **Context:** Fornecem o contexto do banco de dados SQL Server & Implementações intermediárias para gerenciar os repositórios de diferentes bancos de dados..
- **Interface:** Define interfaces para repositórios e serviços.
- **Middleware:** Implementações intermediárias que fazem a interação entre os repositórios de diferentes bancos de dados.
- **Models:** Definição das classes de modelo para representar produtos.
- **Repository:** Implementações dos repositórios de dados para cada tipo de armazenamento.
- **Service:** Implementações dos serviços de negócios que contêm a lógica de manipulação dos produtos.

## Princípios SOLID

Este projeto adota os princípios SOLID para escrever um código limpo, de fácil manutenção e expansão:

- **S (Princípio da Responsabilidade Única):** Cada classe e método possui uma única responsabilidade claramente definida, facilitando a manutenção e evolução.
- **O (Princípio do Aberto/Fechado):** O código está aberto para extensões, mas fechado para modificações. Isso é alcançado através da separação de interfaces e implementações.
- **L (Princípio da Substituição de Liskov):** As classes derivadas podem ser usadas como substitutas de suas classes base sem afetar a funcionalidade esperada.
- **I (Princípio da Segregação de Interfaces):** As interfaces são segregadas para atender às necessidades específicas de cada cliente, evitando interfaces monolíticas.
- **D (Princípio da Inversão de Dependência):** As dependências são injetadas em vez de serem criadas internamente, permitindo maior flexibilidade e testabilidade.

## Personalizações

- Personalize as configurações de conexão com bancos de dados no arquivo `docker-compose.yml` e no arquivo `appsettings.json`.

# OBS:

- Caso dê erro na execução, apague a pasta de testes, (Não se coloca teste no projeto, somente numa solução).
