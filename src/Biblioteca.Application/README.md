## CQRS

Para tornar mais fácil de entender os diferentes protocolos que a camada de Application suporta, eu separei em duas pilhas que terminam em dois modelos diferentes.

![Hexagonal Architecture](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/cqrs.png)

Para implementar corretamente o CQRS, precisamos implementar nossos métodos seguindo as idéias do CQS, métodos em que o estado de mudanças não deve ter um valor de retorno. Métodos que retornam um valor não devem mudar de estado. Em seguida, o CQRS está seguindo caminhos diferentes no sistema, um para o Modelo de Leitura e outro para o Modelo de Gravação.

1. Uma pilha para os comandos _(Commands)_ que faz alterações no estado do aplicativo. Eles são impostos pela Camada de Domínio, processada pelo Application Services, que chama os Repositories para persistência.

2. O outro é uma pilha mais fina para as consultas que chamam os Repositories diretamente.

### Commands

Para ver como ele é implementado com o .NET, dê uma olhada no seguinte Application Service para o Caso de Uso de Depósito:

```
public class DepositService : IDepositService
{
  private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
  private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
  private readonly IResultConverter resultConverter;

  public DepositService(
    IAccountReadOnlyRepository accountReadOnlyRepository,
    IAccountWriteOnlyRepository accountWriteOnlyRepository,
    IResultConverter resultConverter)
  {
    this.accountReadOnlyRepository = accountReadOnlyRepository;
    this.accountWriteOnlyRepository = accountWriteOnlyRepository;
    this.resultConverter = resultConverter;
  }

  public async Task Process(DepositCommand command)
  {
    Account account = await accountReadOnlyRepository.Get(command.AccountId);
    if (account == null)
      throw new AccountNotFoundException(
      $"The account {command.AccountId} does not exists or is already closed.");

    Credit credit = new Credit(account.Id, command.Amount);
    account.Deposit(credit);

    await accountWriteOnlyRepository.Update(account, credit);

    TransactionResult transactionResult = resultConverter.Map(credit);
    DepositResult result = new DepositResult(
      transactionResult,
      account.GetCurrentBalance().Value);

    return result;
  }
}
```

### Queries

E para as Queries, veja que só temos uma assinatura de método delegando os detalhes de implementação para um Adapter de Repository. Por temos uma garantia de que o método não faz nada, você pode aproveitar as melhores soluções para escrever e ler operações. Por exemplo, podemos usar o armazenamento em cache para leitura, bancos de dados segregados para melhorar o desempenho ou escopos de transação para os Commands.

```
public interface IAccountsQueries
{
  Task<AccountResult> GetAccount(Guid id);
}
```

### Use Cases Components

É muito importante organizar a Camada de Aplicação de uma maneira significativa, uma boa opção é organizar os Commands e Queries por Casos de Uso, então, num exemplo de caso de uso de depósito, teremos a pasta `Deposit` com os seguintes arquivos:

* Comando (DepositCommand)
* Interface do Application Service (IDepositService)
* Implementação do Application Service (DepositService)
* Resultado do Comando (DepositResult)

Com essa abordagem, temos um design de aplicativo que suporta novas implementações de casos de uso com poucas alterações na base de código existente. Isso mantém o esforço de trabalho para novas constantes de implementações de casos de uso ao longo dos sprints em uma metodologia Ágil.

