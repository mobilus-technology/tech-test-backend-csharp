# Prova Técnica - Desenvolvedor de Software Backend C#

## Instruções

- A prova consiste na implementação de uma API em C# seguindo os requisitos e critérios estabelecidos abaixo.
- Utilize o formato MarkDown para formatar todas as informações que são relevantes para o projeto.
- O candidato deve realizar as tarefas descritas na prova e enviar o código-fonte completo junto com um arquivo explicativo em Markdown descrevendo as soluções adotadas, no prazo de 7 dias para o e-mail recrutamento@mobilus.com.br com o assunto "Vaga Desenvolvedor - [seu nome]".
- Faça um fork privado do presente repositório e adicione o usuário "alexmontanha@mobilus.com.br".

## Descrição do Projeto

A empresa "Mobilus Tecnologia" está em busca de um desenvolvedor de software altamente qualificado para implementar uma API em C#. A API deve oferecer um CRUD completo, conter regras de validação e campos calculados, e utilizar três repositórios distintos: Arquivo texto, Banco de dados SQL e Banco NoSQL.

## Requisitos Técnicos

- Linguagem de Programação: C#
- Desenvolvimento Backend
- Bancos de Dados SQL
- Padrões de Projeto
- Princípios do SOLID
- Testes Unitários usando MSTests

## Tarefas

1. Implemente uma API em C# que realize operações de CRUD (Create, Read, Update, Delete) completo para um recurso chamado "Produto". O "Produto" deve conter os seguintes atributos: Id (identificador único), Nome, Preço, Quantidade em Estoque, e Data de Criação. Os endpoints esperados são:

``` http 
   - `POST /api/produtos`: Cria um novo produto.
   - `GET /api/produtos`: Retorna a lista de todos os produtos.
   - `GET /api/produtos/{id}`: Retorna os detalhes de um produto específico.
   - `PUT /api/produtos/{id}`: Atualiza os dados de um produto existente.
   - `DELETE /api/produtos/{id}`: Remove um produto do sistema.
```

2. Implemente uma regra de validação para o atributo "Preço" do produto. O preço não pode ser negativo, e o sistema deve retornar uma mensagem de erro apropriada em caso de tentativa de criação ou atualização de um produto com preço inválido.

3. Adicione um campo calculado ao produto chamado "Valor Total" que represente o valor total do produto em estoque (Preço x Quantidade em Estoque). Esse campo deve ser retornado na consulta de detalhes do produto.

4. Utilize três repositórios distintos para armazenar os dados dos produtos:
   - 4.1) Repositório de Arquivo Texto: Os dados devem ser armazenados em um arquivo texto com formato adequado. Implemente as operações de leitura e escrita nesse repositório.
   - 4.2) Repositório de Banco de Dados SQL: Utilize um banco de dados SQL de sua escolha (por exemplo, SQL Server, MySQL, PostgreSQL) para implementar as operações de persistência.
   - 4.3) Repositório de Banco NoSQL: Utilize um banco de dados NoSQL de sua escolha (por exemplo, MongoDB, Cassandra, Couchbase) para implementar as operações de persistência.

## Critérios de Avaliação

- API implementada, rodando e com uma forma de acesso para teste em produção.
- Implementação correta e funcional da API com todas as operações CRUD.
- Correta aplicação da regra de validação para o atributo "Preço".
- Cálculo correto do campo "Valor Total".
- Implementação dos três repositórios distintos com sucesso na persistência dos dados.
- Organização e clareza do código.
- Utilização adequada dos princípios do SOLID.
- Criação de testes unitários para as principais funcionalidades da API.

## Observações

- O candidato tem liberdade para escolher a estrutura do projeto, frameworks e bibliotecas adicionais que julgar adequados para a realização da prova.
- É importante seguir as boas práticas de desenvolvimento e manter um código limpo e legível.
- Inclua no arquivo explicativo em Markdown informações sobre como executar o projeto, incluindo a configuração dos bancos de dados (caso necessário) e a execução dos testes unitários.

Boa prova e sucesso no desafio! Em caso de dúvidas, entre em contato pelo e-mail recrutamento@mobilus.com.br.