# GerenciadorTarefas

## Rodar o Projeto
1. Entrar na pasta raiz do projeto
2. Rodar o terminal dentro da pasta raiz do projeto
3. Executar o seguinte comando:
``` docker-compose up ```

4. Após isso tanto o banco de dados ( MySQL ) e projeto serão criados (o projeto estará exposto na porta 80)
Obs: O link para executar o swagger no navegar ficará assim -> http://localhost/swagger/index.html



# GerenciadorTarefas Melhororias e Refatorações Futuras
- [X] Criar docker compose com criação do banco e projeto juntos
- [ ] Criar uma camada de Serviço para não expor o Banco aos Endpoints
- [ ] Criar Records para não mexer diretamente com as entidades ( aproveitando também que o Record ajuda com a imutabilidade )
- [ ] Criar testes para camada de API e Serviços

## Próximos passos 
* Separar Tarefas e Projetos em 2 serviços separados
