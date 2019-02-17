## Ports

Uma Port é uma maneira que um ator pode interagir com a camada de aplicação. O papel das Ports é traduzir a entrada do Ator em estruturas que o Application Services possa entender. Por exemplo, uma porta pode ser um aplicativo da Web, um aplicativo de console ou um script em lote. Eu preciso ressaltar que o ator poderia ser um usuário real ou outro sistema.

Para este artigo, o Port suporta o protocolo REST e foi implementado usando o framework WebApi.

```
[Route("api/[controller]")]
public class AccountsController : Controller
{
  private readonly IDepositService depositService;

  public AccountsController(
    IDepositService depositService)
  {
    this.depositService = depositService;
  }

  /// <summary>
  /// Deposit from an account
  /// </summary>
  [HttpPatch("Deposit")]
  public async Task<IActionResult> Deposit([FromBody]DepositRequest request)
  {
    var command = new DepositCommand(
      request.AccountId,
      request.Amount);

    DepositResult depositResult = await depositService.Process(command);

    if (depositResult == null)
    {
      return new NoContentResult();
    }

    Model model = new Model(
      depositResult.Transaction.Amount,
      depositResult.Transaction.Description,
      depositResult.Transaction.TransactionDate,
      depositResult.UpdatedBalance
    );

    return new ObjectResult(model);
  }
}
```

The WebApi has Controllers that dot not depends on Application Services implementation details, its easy to mock this services. In an Enterprise Application we use to have multiple Ports.

O Web Api possui Controllers que não dependem dos detalhes de implementação do Application Services, é fácil burlar esses serviços. Em um aplicativo corporativo, usamos várias portas.

## Port Components

Nós separamos em Port por casos de uso, por exemplo, o caso de uso de depósito teria um diretório de `Deposit` com os seguintes arquivos:

* Request (DepositRequest)
* Controller + Action (DepositController)
* Model
