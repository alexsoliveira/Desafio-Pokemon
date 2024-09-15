# Backend Challenge - Pokémons

## Introdução

Este é um teste para que possamos ver as suas habilidades como Front Developer.

Nesse teste você deverá desenvolver um projeto para listar pokémons, utilizando como base a API [https://pokeapi.co/](https://pokeapi.co/ "https://pokeapi.co/").

[SPOILER] As instruções de entrega e apresentação do teste estão no final deste Readme (=

### Antes de começar
 
- O projeto deve utilizar a Linguagem específica na avaliação. Por exempo: C#
- Considere como deadline da avaliação a partir do início do teste. Caso tenha sido convidado a realizar o teste e não seja possível concluir dentro deste período, avise a pessoa que o convidou para receber instruções sobre o que fazer.
- Documentar todo o processo de investigação para o desenvolvimento da atividade (README.md no seu repositório); os resultados destas tarefas são tão importantes do que o seu processo de pensamento e decisões à medida que as completa, por isso tente documentar e apresentar os seus hipóteses e decisões na medida do possível.

## Backend-end

- Get para 10 Pokémon aleatórios
- GetByID para 1 Pokémon específico
- Cadastro do mestre pokemon (dados básicos como nome, idade e cpf) em SQLite4 - Post para informar que um Pokémon foi capturado.5 - Listagem dos Pokémon já capturados.
  

### Requisitos

1 - Todas elas devem retornar os dados básicos do Pokémon, suas evoluções e o base64 de sprite default de cada Pokémon.


## Readme do Repositório

- Deve conter o título do projeto
- Uma descrição sobre o projeto em frase
- Deve conter uma lista com linguagem, framework e/ou tecnologias usadas
- Como instalar e usar o projeto (instruções)
- Não esqueça o [.gitignore](https://www.toptal.com/developers/gitignore)
- Se está usando github pessoal, referencie que é um challenge by coodesh:  

>  This is a challenge by [Coodesh](https://coodesh.com/)

## Finalização e Instruções para a Apresentação

1. Adicione o link do repositório com a sua solução no teste
2. Adicione o link da apresentação do seu projeto no README.md.
3. Verifique se o Readme está bom e faça o commit final em seu repositório;
4. Envie e aguarde as instruções para seguir. Sucesso e boa sorte. =)

## Suporte

Use a [nossa comunidade](https://discord.gg/rdXbEvjsWu) para tirar dúvidas sobre o processo ou envie uma mensagem diretamente a um especialista no chat da plataforma.

# Início do projeto Desafio Pokemon

1. Comecei analisando os requisitos do README.md. Em um folha de papel, utilizei de rascunho para levantar, quais endpoints serão criados. Depois desenhei uma arquitetura em outra folha de papel. E iniciei o projeto criando um repositório no GitHub. Também fiz investigação na api (https://pokeapi.co/) para verificar a documentação.
2. Com uma rascunho de uma possível arquitetura e com um entendimento da api e README.md do desafio, iniciei com a classe MestrePokemon dentro de uma camada Business onde será colocado meu dominio de negocio, também foi criado a camada de Teste Unitario, onde começei testando meu domínio MestrePokemon.
3. Em seguida, foi cria a classe de DomainValidator onde foi colocado algumas regras de validação para o dominio MestrePokemon. Também foi ciara a classe CPF fazendo relacao com a classe MestrePokemon.
4. Foi incluido nos teste de unidade as validações do CPF com sua regras.
5. Depois foi criado o teste de intergraçao e feito teste com banco de dados em memória. Logo em seguida foi criado a interface IMestrePokemonService e a classe MestrePokemonService. Foi criado a camada de data onde foi colocado o EntetyFrameworkCore onde foi colocado o banco de Dados SQLite.
6. A principio tente colocar SQLite4, mais vi que no próprio site do sqlite.org (https://sqlite.org/src4/doc/trunk/www/index.wiki) recomenda utiliza o SQLite3.
7. Tentei colocar o SQLite dentro de um container, mas não consegui ainda, então estou utilizando dentro da aplicacao. Com o banco de dado funcionando comecei os teste de End to End. Em seguida foi cria a camada de api.
8. onde foi colcado as controller MestrePokemon para pode fazer o cadastro de um novo mestre pokemon, passando o nome, idade e cpf. Foi incluido algumas regras para nome, idade e cpf. Para nome é permitido no minimo 3 caracteres e no maximo 30 caracteres. Para Idade é permitido idade no minimo 10 anos e no máximo 100 anos. E para cpf as regras normais que tem de um cpf brasileiro.
9. Depois das validações mestre pokemon, foi usado a api (https://pokeapi.co/) para obter os pokemons. Utilizado a lista de pokemons da primeira geração, para ser fazer o consumo da api.
10. Foi utilizado 3 metodos da api (https://pokeapi.co/) que são: (https://pokeapi.co/api/v2/pokemon-form/{id do pokemon ou nome do pokemon}) para obter os detalhes do pokemon, (https://pokeapi.co/api/v2/pokemon-species/{id d pokemon}) para obter o id da cadeias da evoluções do pokemon e a (https://pokeapi.co/api/v2/evolution-chain/{id do pokemon}) para obter as cadeias de evolução do pokemon.
11. Foi criado na camada de business as classes para consumir do dados da api, também foi criado a interface IPokemonService e a classe PokemonService, responsável por consumir as apis e retorna os dados para controller PokemonController.
12. Em seguida foi criado testes de integração com os metodos fornecidos pela api. 




