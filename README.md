# Console app de gestão de biblioteca

Projeto desenvolvido para a prática dos conceitos de orientação a objetos em C#.

## Modelagem
#### Biblioteca
- Tem 0, N usuários
- Tem 0, N livros

###### Métodos
- Listar livros
- Listar usuários
- Emprestar livro - cria linha na tabela empréstimos
- Devolver livro - altera status na tabela empréstimos e no livro

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
- Tem um status de emprestado (true or false)
- Tem 1 empréstimo ativo por vez

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
- LerInteiro - ler número inteiro

## Funcionalidades
- Cadastrar usuário
- Cadastrar livro
- Listar todos os livros
- Listar livros emprestados
- Listar livros não emprestados
- Listar todos os usuários
- Emprestar um livro
- Devolver um livro
- Deletar um usuário
- Deletar um livro



