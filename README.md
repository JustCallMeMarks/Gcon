# Gcon
Trabalho de Projetos para Sistemas Web

Gcon - Aplicativo Web para gerenciamento de condomínios.

1. CONTEXTO
     	Condomínios atualmente contam com uma estrutura de síndicos e moradores, fazendo reuniões para discutir assuntos de bem comum do condomínio. Estas reuniões apresentam dificuldades em resolução de problemas, ocasionalmente com duração de múltiplas horas sem alcançar qualquer resultado, ou também com baixa assiduidade de moradores, problemas que são exacerbados em grandes condomínios.
Procuramos desenvolver uma solução para facilitar este processo, que consistirá de uma plataforma online onde será possível cadastrar atas de reuniões e realizar votações de assuntos de interesse de bem comum a qualquer momento e em qualquer lugar, estas votações sendo restritas aos moradores do prédio.
 
2. OBJETIVOS
 - Facilitar a gestão de condomínios
 - Facilitar a realização de votações em assuntos de condomínios
 - Aumentar a participação de moradores em votações e reuniões
 - Facilitar o gerenciamento do resultado de votações
 - Permitir o anonimato em votações
 - Desenvolver um mural de avisos onde o síndico cadastra avisos para os moradores.
 
 
3. TECNOLOGIA
Será utilizado asp.net MVC para a construção do aplicativo web, empregando Twitter Bootstrap para construção do visual das páginas web, e JQuery e outras bibliotecas Javascript para auxílio de operações no sistema.
Será utilizado PostgreSQL para gerenciamento de banco de dados.

4. DESIGN
Descrever design do Web Site. Neste local deve ser elaborado um escopo de como o Web Site deverá ser. Este escopo deve ser o diagrama estrutural da página principal e de todas as demais páginas que apresentarem uma estrutura diferente da página principal. Se possível, já deve ser apresentado neste momento o design gráfico da página principal.
 
5. ESTRUTURA E CONTEÚDO
Descrever o fluxo e o mapa/árvore do Web Site, mostrando todas as ligações entre as páginas, para serem implementadas posteriormente.
 
6. BANCO DE DADOS
Descrever as tabelas do banco de dados para o sistema e para armazenar dados relativos à personalização

7. ETAPAS E CRONOGRAMA
Neste local devem ser descritas as etapas para a construção do Website, descrevendo as entregas previstas para o mesmo. No caso destas entregas sofrerem alterações, as mesmas devem ser renegociadas com a entidade solicitante do Web Site.
 
 =========================================
 
 Regras de Acesso ao sistema:
 
 Existiram três tipos de regras de Acesso para usuários:

Administrador; Votador; Morador

Perfis:
Administrador: Responsável pela administração do sistema, possuirá permissão total a todas páginas do sistema.
Votador: Poderá votar em votações e visualizar todas páginas públicas, porém sem efetuar alterações no conteúdo. Apenas poderá existir 1 votador por apartamento.
Morador: Não poderá votar, e apenas poderá visualizar páginas de Mural e Atas de reunião e configuração de cadastro.

Definição de política de permissões:
Mural:
Visualização: pública, todos perfis possuem permissão. 
Edição/ Cadastro: restrita, apenas administradores possuem permissão.

Votações:
Visualização Simplificada: restrita, administradores e Votadores possuem permissão.
Visualização Detalhada: restrita apenas administradores possuem permissão.
Edição:  restrita, apenas administradores possuem permissão.

Novas Votações: Restrita, apenas administradores possuem permissão.

Atas: Visualização:  pública.
Edição:  restrita, apenas administradores possuem permissão.

Novas Atas: Restrita, apenas administradores possuem permissão de acesso e edição.

Login: Pública.
Cadastro de novos moradores: pública.
Moradores: Visualização e Edição restrita, apenas administradores possuem permissão.

