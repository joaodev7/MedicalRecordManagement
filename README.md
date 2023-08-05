# MedicalRecordManagement
Medical Record Management - Projeto Técnico
Medical Record Management é um projeto de gerenciamento de registros médicos, desenvolvido usando ASP.NET Core 5.0 com banco de dados SQL Server. O objetivo principal do projeto é fornecer um sistema para manter registros médicos de pacientes, gerenciar usuários e autenticação, e permitir que os médicos e funcionários do hospital acessem e atualizem os registros médicos dos pacientes.

Tecnologias Utilizadas
O projeto foi desenvolvido utilizando as seguintes tecnologias e ferramentas:

ASP.NET Core 5.0: É um framework de desenvolvimento web de código aberto, cross-platform e altamente modular para construir aplicativos modernos.
Entity Framework Core: É um ORM (Object-Relational Mapping) que permite interagir com bancos de dados relacionais usando objetos.
SQL Server: É o sistema de gerenciamento de banco de dados relacional da Microsoft.
Bootstrap: É um framework de código aberto para desenvolvimento front-end que facilita a criação de páginas web responsivas e estilizadas.
JWT (JSON Web Tokens): É um padrão para autenticação de acesso em aplicações web, permitindo a troca de informações de autenticação entre cliente e servidor de forma segura.
Estrutura do Projeto
O projeto possui a seguinte estrutura de diretórios:

Controllers: Contém os controladores que tratam as requisições HTTP e definem as ações para cada rota da aplicação.
Data: Contém o contexto do banco de dados e as classes de entidade que representam as tabelas do banco de dados.
Migrations: Contém as migrações do Entity Framework Core, que representam as alterações no banco de dados.
Models: Contém as classes de modelos de visualização (ViewModels) que são usadas para passar dados para as views.
Views: Contém as views que são renderizadas no navegador e mostram o conteúdo para os usuários.
wwwroot: Contém arquivos estáticos, como folhas de estilo, scripts JavaScript e imagens.
appsettings.json: Arquivo de configuração da aplicação, contendo configurações como a string de conexão com o banco de dados e configurações de autenticação.
Startup.cs: Arquivo que configura a aplicação e define os serviços e middleware a serem usados.
Funcionalidades Principais
O projeto possui as seguintes funcionalidades principais:

Cadastro e Autenticação de Usuários: Os usuários podem se cadastrar no sistema, fornecendo um número de identificação fiscal (Tax Number), senha e função (Role). O sistema usa o JWT para autenticar os usuários e gerar tokens de acesso.
Gerenciamento de Registros Médicos: Os usuários autenticados podem acessar e gerenciar os registros médicos dos pacientes. Eles podem visualizar, criar, atualizar e excluir registros médicos.
Upload de Fotos: Os usuários podem fazer upload de fotos de pacientes e salvar o caminho da foto no banco de dados.
Considerações Finais
O projeto Medical Record Management é uma aplicação web completa, que utiliza as melhores práticas de desenvolvimento para garantir a segurança e o bom funcionamento do sistema. O uso do ASP.NET Core, Entity Framework Core e JWT proporciona uma base sólida para desenvolver sistemas web robustos e escaláveis. O projeto pode ser facilmente estendido e adaptado para atender a diferentes requisitos e necessidades.
