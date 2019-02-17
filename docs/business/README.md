# Regras de negócio

Sistema de gerenciamento de biblioteca.

1. Eu, como Bibliotecário, desejo cadastrar uma pessoa.

**Dados de pessoa:**

- CPF
- Nome
- Endereço
- Perfil (Bibliotecário, Cliente)

2. Eu, como Bibliotecário, desejo cadastrar, editar e deletar um modelo.

**Dados de Modelo de um Livro:** 

- Título
- Autor
- Número de páginas
- Categoria
- Editora
- Edição
- Descrição

> Um **modelo** é a representação genérica de um livro.
> E um **exemplar** é sua representação física. Isto é, um modelo pode ter 0 ou vários exemplares.

> Um modelo com exemplares não pode ser deletado.

3. Eu, como Bibliotecário, desejo cadastrar ou remover exemplares de um modelo.

**Dados de Exemplar:**

- Identificador
- Situação _(Disponível, Emprestado, Removido)_

> Um exemplar em empréstimo não pode ser removido.

4. Eu, como Bibliotecário, desejo alterar o valor da multa e do período de empréstimo por página (número de semanas por número de páginas). _(Um empréstimo já concebido não pode ter seu período alterado)_

> **Multa:**
> 
> Padrão: A multa é calculada com a adição de **R$0.50** por dia após o vencimento.

> **Período de empréstimo:**
> 
> Padrão: O período de empréstimo é calculado pelo número de páginas do livro:
> A cada 100 páginas são acrescentados 1 semana ao período, sendo que o valor mínimo é de 1 semana e o máximo de dois meses (8 semanas). E sempre é arredondado por semana.

5. Eu, como Bibliotecário, desejo cadastrar um empréstimo.

**Um empréstimo:**

- Uma Pessoa
- Um exemplar
- Data de empréstimo
- Data de entrega

> Lembrando que um empréstimo não pode ter seus dados alterado, mas a multa deve sofrer o reajuste.

6. Eu, como Bibliotecário, desejo ver uma lista de exemplares emprestados, para quem, e se existe alguma multa relacionada ao empréstimo.

7. Eu, como Bibliotecário, desejo buscar todos os empréstimos atrasados.

8. Eu, como Bibliotecário, desejo retornar/devolver um exemplar emprestado. (Quitar um empréstimo)

9. Eu, como Bibliotecário, desejo renovar um exemplar emprestado à uma Pessoa.

> _Um exemplar só pode ser renovado por até um ano. Após isso ele precisa ser devolvido. E aquela Pessoa não pode pegar outro livro emprestado daquele modelo por pelo menos metade do tempo de empréstimo._

> _Um exemplar com multa não pode ser renovado, e a pessoa não pode pegar nenhum modelo por 10x o tempo (em dias) do atraso, com o mínimo de um mês._

> _Um empréstimo renovado é considerado o mesmo empréstimo._

10. Eu, como Bibliotecário, desejo buscar um exemplar (por identificador).

> _Mostrando a situação atual do exemplar, seu histórico de empréstimos, previsão de entrega pro caso de estar em empréstimo e caso o mesmo esteja vencido, o valor total de sua multa._

11. Eu, como Cliente, desejo buscar um ou mais modelos (por Título, Autor ou Categoria)

> Caso todos os exemplares daquele modelo estejam emprestados ou removidos, apresentar informação de modelo indisponível para empréstimo.


