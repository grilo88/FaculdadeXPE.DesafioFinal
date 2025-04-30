## Documento Técnico - Arquitetura de Software para E-Commerce

### **Pós-Graduação em Arquitetura de Software e Soluções**  
**Universidade: Faculdade XP Educação**  
**Curso: Pós-Graduação em Arquitetura de Software e Soluções**  
**Disciplina: Arquitetura de Software**  
**Aluno:** Guilherme Moreira de Alencar Alves  
**Data:** 29/04/2025

---

## **Resumo**

Este documento descreve a arquitetura de um sistema de E-Commerce desenvolvido com base nos princípios de software escalável e eficiente. A arquitetura foi dividida em camadas MVC evoluída com princípios DDD, cada uma responsável por uma parte específica da aplicação. A documentação aborda cada camada do projeto, explicando a organização dos diretórios e os principais arquivos envolvidos no desenvolvimento da solução.

---

## **Sumário**

1. Introdução
2. Camadas da Arquitetura
   - ECommerce.Api
   - ECommerce.Application
   - ECommerce.Domain
   - ECommerce.Infrastructure
3. Detalhamento de Arquivos e Funcionalidades
   - ECommerce.Api
   - ECommerce.Application
   - ECommerce.Domain
   - ECommerce.Infrastructure
4. Conclusão

---

## **1. Introdução**

Este trabalho tem como objetivo apresentar a estrutura de um projeto de E-Commerce, desenvolvido utilizando práticas modernas de arquitetura de software. A solução foi construída com base no padrão de camadas, que permite uma fácil manutenção e escalabilidade. O sistema gerencia clientes, pedidos e produtos, com funcionalidades robustas e escaláveis.

---

## **2. Camadas da Arquitetura**

A arquitetura do sistema é composta pelas seguintes camadas:

- **ECommerce.Api**: Responsável pela camada de interface com o usuário (API), gerenciando requisições e respostas.
- **ECommerce.Application**: Contém as regras de negócio da aplicação, organizadas por funcionalidades (clientes, pedidos e produtos).
- **ECommerce.Domain**: Representa as entidades e contratos do sistema, incluindo agregados e repositórios.
- **ECommerce.Infrastructure**: Contém a implementação das infraestruturas necessárias para a persistência de dados e injeção de dependências.

---

## **3. Detalhamento de Arquivos e Funcionalidades**

### **3.1 ECommerce.Api**

A camada **ECommerce.Api** é responsável por expor os endpoints através dos controladores, utilizando o padrão MVC (Model-View-Controller) evoluído com os princípios do DDD (Domain-Driven Design). Ela recebe as requisições do cliente e orquestra o fluxo de dados, chamando a camada de **ECommerce.Application** para processar as regras de negócio.

#### **MVC Evoluído com DDD**

- **Model**: Na arquitetura proposta, o **Model** é representado pela camada **ECommerce.Domain**, que contém as entidades de negócio puras, regras de domínio e interfaces de repositórios, sem dependências externas. Essa camada é responsável pela modelagem dos dados e pela aplicação das regras de negócio fundamentais, sem qualquer preocupação com a persistência ou comunicação com o exterior.
  
- **Controller**: A camada **ECommerce.Api** contém os controladores, que são responsáveis por gerenciar as requisições HTTP. Os controladores recebem as entradas, validam os dados, chamam os serviços na camada **ECommerce.Application** e retornam a resposta adequada. Eles orquestram o fluxo de dados, delegando a lógica de negócio para a camada de aplicação.

- **View**: Embora o termo "View" no padrão MVC geralmente se refira à interface visual do usuário, no caso de uma API RESTful, a **View** corresponde à entrega de dados estruturados em formato JSON. A resposta é apresentada de forma estruturada, utilizando o Swagger como documentação visual da API, facilitando a visualização dos endpoints e suas funcionalidades. A **View** aqui serve como a representação dos dados que a API fornece aos clientes em um formato consumível.

#### **Arquivos e Funcionalidades**
A camada **ECommerce.Api** inclui os seguintes arquivos e estruturas:

- **Controllers**
  - **ClienteController.cs**: Controlador responsável por gerenciar as requisições relacionadas aos clientes.
  - **PedidoController.cs**: Controlador responsável por gerenciar as requisições relacionadas aos pedidos.
  - **ProdutoController.cs**: Controlador responsável por gerenciar as requisições relacionadas aos produtos.

- **Arquivos de Configuração**
  - **Program.cs**: Arquivo de configuração da aplicação.
  - **Startup.cs**: Arquivo responsável pela inicialização dos serviços e dependências da aplicação.
  - **appsettings.Development.json**: Configuração da aplicação para o ambiente de desenvolvimento.
  - **appsettings.json**: Arquivo de configuração genérica.

---

### **3.2 ECommerce.Application**

A camada **ECommerce.Application** contém as regras de negócio e a organização dos comandos e consultas (CQRS). Abaixo estão os detalhes das funcionalidades implementadas:

#### **Clientes**
- **Commands**
  - **CreateClienteCommandHandler.cs**: Responsável por criar um cliente.
  - **DeleteClienteCommandHandler.cs**: Responsável por deletar um cliente.
  - **UpdateClienteCommandHandler.cs**: Responsável por atualizar os dados de um cliente.

- **Queries**
  - **GetAllClientesQueryHandler.cs**: Retorna todos os clientes.
  - **GetClienteByIdQueryHandler.cs**: Retorna um cliente pelo ID.
  - **GetClienteByNomeQueryHandler.cs**: Retorna um cliente pelo nome.

#### **Pedidos**
- **Commands**
  - **CreatePedidoCommandHandler.cs**: Responsável por criar um pedido.
  - **DeletePedidoCommandHandler.cs**: Responsável por deletar um pedido.
  - **UpdatePedidoCommandHandler.cs**: Responsável por atualizar um pedido.

- **Queries**
  - **GetAllPedidosQueryHandler.cs**: Retorna todos os pedidos.
  - **GetPedidoByIdQueryHandler.cs**: Retorna um pedido pelo ID.
  - **GetPedidosByClienteNomeQueryHandler.cs**: Retorna os pedidos de um cliente pelo nome.
  - **GetPedidosByStatusQueryHandler.cs**: Retorna pedidos com base no status.

#### **Produtos**
- **Commands**
  - **CreateProdutoCommandHandler.cs**: Responsável por criar um produto.
  - **DeleteProdutoCommandHandler.cs**: Responsável por deletar um produto.
  - **UpdateProdutoCommandHandler.cs**: Responsável por atualizar um produto.

- **Queries**
  - **GetAllProdutosQueryHandler.cs**: Retorna todos os produtos.
  - **GetProdutoByIdQueryHandler.cs**: Retorna um produto pelo ID.
  - **GetProdutoByNomeQueryHandler.cs**: Retorna um produto pelo nome.

---

### **3.3 ECommerce.Domain**

A camada **ECommerce.Domain** é a base do modelo de dados, onde são definidas as entidades, contratos e interfaces de repositórios.

#### **Entidades**
- **ClienteEntity.cs**: Representa a entidade cliente.
- **PedidoEntity.cs**: Representa a entidade pedido.
- **ProdutoEntity.cs**: Representa a entidade produto.

#### **Repositórios**
- **IClienteRepository.cs**: Interface do repositório de clientes.
- **IPedidoRepository.cs**: Interface do repositório de pedidos.
- **IProdutoRepository.cs**: Interface do repositório de produtos.

---

### **3.4 ECommerce.Infrastructure**

A camada **ECommerce.Infrastructure** é responsável pela implementação da persistência de dados, incluindo a configuração do banco de dados, as migrations e os repositórios concretos.

#### **Data**
- **AppDbContext.cs**: Contexto do banco de dados.
- **ClienteConfiguration.cs**: Configuração do mapeamento da entidade Cliente.
- **PedidoConfiguration.cs**: Configuração do mapeamento da entidade Pedido.
- **ProdutoConfiguration.cs**: Configuração do mapeamento da entidade Produto.

#### **IoC**
- **DependencyInjection.cs**: Implementação da injeção de dependências.

#### **Persistence**
- **Repository.cs**: Implementação genérica do repositório.
- **UnitOfWork.cs**: Implementação do padrão Unit of Work.

#### **Arquivos de Repositórios**
Os repositórios implementam as interfaces **IClienteRepository**, **IPedidoRepository** e **IProdutoRepository** e são fundamentais para a comunicação entre o domínio e a camada de persistência de dados.

- **ClienteRepository.cs**: Implementa a interface **IClienteRepository** e contém as operações de acesso ao banco de dados para a entidade **Cliente**.
  
- **PedidoRepository.cs**: Implementa a interface **IPedidoRepository** e contém as operações de acesso ao banco de dados para a entidade **Pedido**.
  
- **ProdutoRepository.cs**: Implementa a interface **IProdutoRepository** e contém as operações de acesso ao banco de dados para a entidade **Produto**.

Estes repositórios são responsáveis por abstrair a complexidade das consultas e manipulação dos dados, oferecendo uma interface limpa para a camada **ECommerce.Application**.

---

## **4. Conclusão**

O projeto ECommerce segue as boas práticas de arquitetura de software, utilizando camadas bem definidas para garantir escalabilidade e manutenção facilitada. Cada camada tem uma responsabilidade específica, permitindo que a aplicação seja facilmente expandida no futuro. A estrutura proposta garante um bom desacoplamento entre as diferentes partes do sistema, facilitando tanto os testes quanto a evolução da aplicação.
