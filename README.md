# CRUDSuperHerois
API CRUD de Super Heróis em .NET Core 5.0 com Banco de Dados SQL Server.


#  Explicação da API  

<h3>
Organização do Projeto  
</h3>

O projeto foi organizado em 3 pastas:
 * Controllers:
 Aqui estão localizados os controllers da API, com todos os endpoints e métodos Http.
 
 * Data: Organizado em 4 subpastas: 
    <p>- Mappings: Onde estão localizados as classes de mapeamento das entidades no banco de dados.</p>
    <p>- Migrations: Onde ficam registradas as migrations do projeto.</p>
    <p>- Repository: Onde ficam os repositórios, realizando as transações com o banco de dados.</p>
    <p>- UoW: Onde fica localizada a unidade de trabalho da aplicação.</p>

* Domain: Onde estão as subspastas:
  <p>- DTO: Onde estão localizados os objetos de transferência de dados.</p>  
  <p>- InputModels: Onde estão localizados as classes que serão instanciadas ao realizar algum método POST.</p>
  <p>- Interfaces: Onde estão localizados as interfaces do sistema.</p> 
  <p>- Models: Onde estão localizados os modelos das entidades do sistema.</p>  
  <p>- Services: Pasta onde estão os serviços da API.</p>
  
<h3>Métodos da Controller</h3>
<h4>Heróis</h4>

  * /api/Herois/BuscarHerois : Busca todos os heróis cadastrados no banco de dados.
  * /api/Herois/BuscarHeroiPorId : Busca de um herói por Id.
  * /api/Herois/CadastrarHeroi : Cadastra um herói no banco de dados.
  * /api/Herois/DeletarHeroi : Deleta um herói do banco de dados, passando o Id por parâmetro.
  * /api/Herois/AtualizarHeroi : Atualiza um herói.

<h4>Superpoder</h4>

  * /api/Superpoder/BuscarSuperpoderes : Busca todos os superpoderes cadastrados no banco de dados.
  * /api/Superpoder/BuscarSuperpoderPorId : Busca um superpoder específico passando o Id como parâmetro.
  * /api/Superpoder/DeletarSuperpoder : Deleta um superpoder específico por Id.
  * /api/Superpoder/AdicionarSuperpoder : Adiciona um superpoder ao banco de dados.

<h4>HeroisSuperpoder</h4>

  * /api/HeroisSuperpoderes/BuscarHeroiSuperpoderes : Busca todos os heróis com seus superpoderes.
  * /api/HeroisSuperpoderes/AssociarHeroiSuperpoderes : Associa um herói a um superpoder.
  * /api/HeroisSuperpoderes/DesassociarHeroiSuperpoder : Desassocia um herói de um superpoder (exclusão da tabela HeroisSuperpoderes)
  * /api/HeroisSuperpoderes/AdicionarHeroiSuperpoderes : Adiciona um Heroi ao banco de dados, recebendo uma lista de superpoderes (caso não exista na tabela de superpoderes, adiciona).
  * /api/HeroisSuperpoderes/AtualizarHeroiSuperpoderes : Atualiza um heroi no banco de dados, podendo receber uma lista de superpoderes para atualizar também. (faz a associação ou desassociação caso necessário)
  * /api/HeroisSuperpoderes/ExcluirHeroiSuperpoderes : Deleta um herói fazendo a desassociação ao superpoder.
