# Banco Carrefour - Challenge
Arquitetura Corporativa em C# .NET

# Sobre o projeto
O objetivo deste repositório é fornecer uma estrutura de solução básica que pode ser usada para criar aplicativos SOLID baseados em Domain-Driven Design (DDD) ou simplesmente bem fatorados usando .NET Core. Saiba mais sobre esses temas aqui:

    SOLID Principles for C# Developers
    SOLID Principles of Object Oriented Design (the original, longer course)
    Domain-Driven Design Fundamentals


# Tecnologias usadas

* ASP.NET Core (.NET 6) Web API
* Entity Framework Core (EFCore 6)
* MediatR for .NET 6
* Fluent Validation for .NET 6
* SQLite
* SwaggerUI
* AutoMapper
* Ocelot
* Consul
* Fortgate
* Sonar
* Prometheus
* Redis

![teste drawio](https://github.com/cassio2586/ArquiteturaReferenciaC-/assets/27103177/6cb5c765-8479-42c2-b071-162ab90f01a5)

# Design e arquitetura dos microserviços
O design de arquitetura escolhido foi a arquitetura limpa. Ela não inclui todas as estruturas, ferramentas ou recursos possíveis dos quais um aplicativo corporativo específico pode se beneficiar. Suas escolhas de tecnologia para coisas como acesso a dados estão enraizadas no que é a tecnologia mais comum e acessível para a maioria dos desenvolvedores de software de negócios que usam a pilha de tecnologia da Microsoft. Ele não inclui (atualmente) suporte extensivo para itens como registro, monitoramento ou análise, embora todos possam ser adicionados facilmente. Abaixo está uma lista das dependências de tecnologia que ele inclui e por que elas foram escolhidas. A maioria deles pode ser facilmente trocada pela tecnologia de sua escolha, já que a natureza dessa arquitetura é suportar modularidade e encapsulamento.

# Core
O projeto Core é o centro do projeto na arquitetura limpa e todas as outras dependências do projeto devem apontar para ele. Como tal, tem muito poucas dependências externas. A única exceção nesse caso é o pacote System.Reflection.TypeExtensions, que é usado por ValueObject para ajudar a implementar sua interface IEquatable<>. O projeto principal deve incluir coisas como:

    Entidades
    Agregados
    Eventos de domínio
    DTOs
    Interfaces
    manipuladores de eventos
    Serviços de domínio
    Especificações

# SharedKernel 
Muitas soluções também farão referência a um projeto/pacote Shared Kernel separado. Eu recomendo criar um projeto e uma solução SharedKernel separados se você precisar compartilhar o código entre vários contextos limitados (consulte Fundamentos do DDD). Recomendo ainda que seja publicado como um pacote NuGet (provavelmente de forma privada em sua organização) e referenciado como uma dependência do NuGet pelos projetos que o exigem. Para este exemplo, para simplificar, adicionei um projeto SharedKernel à solução. Ele contém tipos que provavelmente seriam compartilhados entre vários contextos limitados (normalmente soluções VS), na minha experiência. Se você quiser ver um exemplo de um pacote SharedKernel, o que eu uso em meu curso Pluralsight DDD atualizado está no NuGet aqui.


# Infrastructure 
A maioria das dependências de seu aplicativo em recursos externos deve ser implementada em classes definidas no projeto de infraestrutura. Essas classes devem implementar interfaces definidas no Core. Se você tiver um projeto muito grande com muitas dependências, pode fazer sentido ter vários projetos de infraestrutura (por exemplo, Infrastructure.Data), mas para a maioria dos projetos, um projeto de infraestrutura com pastas funciona bem. A amostra inclui acesso a dados e implementações de eventos de domínio, mas você também adicionaria itens como provedores de e-mail, acesso a arquivos, clientes de API da Web etc.

O projeto de infraestrutura depende de Microsoft.EntityFrameworkCore.SqlServer e Autofac. O primeiro é usado porque está integrado aos modelos ASP.NET Core padrão e é o menor denominador comum de acesso a dados. Se desejado, ele pode ser facilmente substituído por um ORM mais leve como o Dapper. Autofac (anteriormente StructureMap) é usado para permitir que a conexão de dependências ocorra mais próximo de onde residem as implementações. Neste caso, uma classe InfrastructureRegistry pode ser utilizada na classe Infrastructure para permitir a conexão de dependências ali, sem que o ponto de entrada da aplicação precise ter uma referência ao projeto ou seus tipos. Saiba mais sobre esta técnica. A implementação atual não inclui esse comportamento - é algo que normalmente abordo e faço com que os próprios alunos adicionem em meus workshops.

# Web
O ponto de entrada do aplicativo é o projeto Web ASP.NET Core. Este é, na verdade, um aplicativo de console, com um método Main public static void em Program.cs. Atualmente, ele usa a organização MVC padrão (pastas Controllers e Views), bem como a maior parte do código de modelo de projeto ASP.NET Core padrão. Isso inclui seu sistema de configuração, que usa o arquivo appsettings.json padrão mais variáveis ​​de ambiente e é configurado em Startup.cs. O projeto delega ao projeto de Infraestrutura para conectar seus serviços usando o Autofac.

# Patterns Usados
Este modelo de solução tem código integrado para dar suporte a alguns padrões comuns, especialmente padrões de Design orientado a domínio. Aqui está uma breve visão geral de como alguns deles funcionam.

# Domain Events
Os eventos de domínio são um ótimo padrão para desacoplar um gatilho para uma operação de sua implementação. Isso é especialmente útil dentro das entidades de domínio, pois os manipuladores dos eventos podem ter dependências, enquanto as próprias entidades normalmente não. No exemplo, você pode ver isso em ação com o método ToDoItem.MarkComplete(). O diagrama de sequência a seguir demonstra como o evento e seu manipulador são usados ​​quando um item é marcado como concluído por meio de um ponto de extremidade da API da Web.



# Observabilidade
Prometheus

# Resiliência
Ocelot

# Escalabilidade

# Performance - CQRS

# Segurança


    
