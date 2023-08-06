# Desafio Técnico IATec - Bruno Leone / Acetime Soluções Digitais LTDA

Esse projeto tem como objetivo o desenvolvimento de uma RESTFull API em .NET Core que terá como principal função gerenciar uma lista de tarefas.

## Tecnologias Utilizadas

* .NET Core
* Identity Server
* SQLite
* Entity Framework

## Métodos Disponíveis Para Consumo

* Listar tarefas do usuário logado

* Criar tarefas por usuário

* Atualizar tarefa/ tarefas por usuário e ID de tarefa

* Excluir tarefa

## Comandos Essenciais

```bash
dotnet ef migrations add Initial -p IATecTasks.Repository -s IATecTasks.API
```

```bash
dotnet ef migrations remove
```

```bash
dotnet ef database update -s IATecTasks.API
```