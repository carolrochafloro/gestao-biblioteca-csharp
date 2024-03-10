# Console app de gestão de biblioteca

Projeto desenvolvido para a prática dos conceitos de orientação a objetos em C# com .NET Entity Framework Core

## Modelagem

#### Usuário
- Tem um id
- Tem um nome
- Tem 0, N emprestimo_id

###### Métodos
- Cadastrar usuário
- Deletar usuário

#### Livro
- Tem um id
- Tem um autor
- Tem um título
- Ten um número de páginas
- Tem um status de emprestado (true or false)

###### Métodos
- Cadastrar livro
- Deletar livro

#### Empréstimo - associação entre livro e usuário
- Tem um id
- Tem um usuario_id
- Tem um livro_id
- Tem um status de atividade (true or false)
- Tem uma data de empréstimo
- Tem uma data de devolução

#### User interface
- Menu - lógica implementada dentro de cada opção

## Funcionalidades
- Cadastrar usuário - ok
- Cadastrar livro - ok
- Listar todos os livros - ok
- Listar empréstimos por usuário - ok
- Listar livros emprestados
- Listar livros não emprestados
- Listar todos os usuários - ok
- Emprestar um livro - ok
- Devolver um livro - ok
- Deletar um usuário
- Deletar um livro



