## Adapters

   Os Adapters fornecem implementações para as preocupações periféricas, você pode ter um Adaptador de Repositório para seu Banco de Dados SQL, um Adaptador para esse Serviço WCF herdado ou até mesmo um Adaptador para essa estrutura NewtonSoft.Json. O que precisamos prestar atenção em projetar Adapters para longo prazo?
   
   * Os Adapters devem implementar as necessidades do aplicativo, e não o contrário!
   * Uma interface de adaptador não expõe assinaturas de implementação internas e estruturas de dados.
   
   Nossa infra-estrutura específica é um projeto único que implementa acesso a dados, mapeamentos e estrutura de DI. Em um momento conveniente, podemos dividir este projeto em Infrastructure.MongoDataAccess, Infrastructure.Mappings e assim por diante.

## Visão Geral dos Componentes
   
   Você percebeu que eu uso padrões de organização específicos para agrupar os módulos por casos de uso, eu recomendo desta forma para que eu possa evoluir o aplicativo ao longo dos sprints com menos alterações na base de código existente.
