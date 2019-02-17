## Características do estilo de arquitetura
   
   Com esse estilo, temos um domínio independente para incorporar um pequeno conjunto de regras comerciais críticas. Ports que dão acesso aos Application Services, Adapters que fornecem interfaces para estruturas, bancos de dados e outros sistemas. Uma maneira de explicar a arquitetura hexagonal é por suas formas. Dê uma olhada na seguinte imagem:

![Hexagonal Architecture](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/hexagonal.png)

* No centro temos o Domínio com uma pequena forma de batata e há razão para isso. Todo domínio de negócios tem suas próprias regras, especificações diferentes umas das outras, essa é a razão dessa forma indefinida. Por exemplo, em nosso exemplo muito específico nós projetamos com DDD Patterns.

* As regras de negócios conhecidas como Domain e Application não conhecem as implementações dos Adapters.

* O Application tem uma forma hexagonal porque cada um dos seus lados tem protocolos específicos, em nosso exemplo temos **Commands** e **Queries** dando acesso ao Application Service.

* As Ports e Adapters são implementados fora do aplicativo como plugins.

* Externamente, temos outros sistemas.

* Os componentes da aplicação são acoplamentos soltos, fazendo alterações mais rápidas.

Para todos os benefícios que a arquitetura hexagonal trás, nós começamos a achar que ele é difícil, mas conforme ganhamos experiência com o Dependency Inversion Principle and Separation of Concerns a implementação torna-se natural. 
O segundo pensamento é "É provado ser uma boa solução?" e artigos como os de [Alistair Cockburn](http://alistair.cockburn.us/Hexagonal+architecture) de treze anos e outros recentes como os de [Building Microservices](https://samnewman.io/talks/principles-of-microservices/) trazem confiança.

## Layers

O software usa camadas para Separation of Concerns e reforçar o design do aplicativo. As conseqüências dessas escolhas são bem descritas por [Vaughn Vernon (IDDD, 2013)](https://www.amazon.com/Implementing-Domain-Driven-Design-Vaughn-Vernon/dp/0321834577):

> A essência dessa definição é comunicar que um componente que fornece serviços de baixo nível (Infrastructure, no nosso caso) deve depender de interfaces definidas por componentes de alto nível (em nosso caso, WebApi, Application e Domain)

Vamos descrever o diagrama de camadas de dependência abaixo:

![Layered Application](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/Layers.png)

* O Domain é totalmente independente de outras camadas e estruturas.
* O Application depende do domínio e é independente de frameworks, bancos de dados e interface do usuário.
* Adapters fornecem implementações para as necessidades do aplicativo.
* A interface do usuário depende do Application e carrega a Infrastructure indiretamente.

Devemos prestar atenção que a Infrastructure geralmente tem dependências diferentes e pode ser projetos separados para banco de dados, bus, segurança, DI frameworks e outras preocupações periféricas. Em nosso caso, apresentamos apenas um projeto para Infraestrutura.
