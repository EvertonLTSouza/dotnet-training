# [Story] Cadastrar categorias

## Narrativa de negócio

**Como** gerente de uma linha de produtos<br/>
**Desejo** cadastrar categorias de produtos<br/>
**Para** poder organizar os itens do meu catálogo

## Grooming de negócio

Propriedade | Tipo | Obrigatório | Regras
--- | --- | --- | ---
Id | GUID | Sim | Chave primária
Código | Texto | Sim | Deve conter exatamente 4 caracteres
Descrição | Texto | Sim |
Data de criação | Data/hora | Sim | Neste momento **não** é necessário alterar o formato de exibição

O cadastro de categorias deve incluir as operações CRUD: **criar, ler/listar, atualizar e excluir**. Deverá existir 3 tipos de leitura:
* Ler/listar todas as categorias;
* Ler/listar uma categoria específica (a partir do seu id);
* Ler/listar categorias que atendam ao termo de busca (a partir da descrição).

## Grooming técnico

Criar uma controller **CategoriasController** com actions que atendam aos contratos abaixo.

Categoria JSON (valores arbitrários):
```json
{
    "Id": "be36c0ce-951f-4c1e-89b8-73d9ef3d3962",
    "Codigo": "4urf",
    "Descricao": "Cereais",
    "CriadoEm": "2019-03-28T10:02:35"
}
```

Listar todas as categorias:
```
Request URL: GET http://<api_url>/api/categorias
Response code: 200
Response body: array de categorias
```

Listar uma categoria pelo seu ID:
```
Request URL: GET http://<api_url>/api/categorias/{id}
Response code: 200
Response body: categoria
```

Listar categoria pesquisando pela descrição (ou parte dela):
```
Request URL: GET http://<api_url>/api/categorias/search?descricao={search_text}
Response code: 200
Response body: array de categorias
```

Criar uma categoria:
```
Request URL: POST http://<api_url>/api/categorias
Request body: categoria
Response code: 200
```

Atualizar uma categoria:
```
Request URL: PUT http://<api_url>/api/categorias/{id}
Request body: categoria
Response code: 200
```

Excluir uma categoria:
```
Request URL: DELETE http://<api_url>/api/categorias/{id}
Response code: 200
```

**Atenção às responsabilidades de cada camada:**
* **Repository:** deve conter entidades e classes de repositório, que por sua vez utilizam expressões LINQ para acessar os dados do banco;
* **Business:** deve realizar validações de negócio, invocar os métodos do repositório e, caso necessário, lançar exceções.
* **API:** deve receber os parâmetros da requisição e invocar os métodos de business. Também será responsável por capturar possíveis exceções de negócio e retornar um **BadRequest** (ou **Ok**, se não houver erros).

**Tratamento de exceções:**
* Criar uma classe **BusinessException**, que estende a classe **Exception**, no projeto **Business**. Ela deverá ter um construtor que recebe um parâmetro **string errorMessage**, que será repassado à propriedade **Message** da classe base.
* Todas exceções de negócio devem ser lançadas por esta classe, porém com mensagens de erro diferentes para cada tipo de exceção.
* O frontend irá exibir a mensagem de erro retornada pelo backend. Para isso, passe a mensagem da exceção como argumento ao método BadRequest:
    ```csharp
    return BadRequest(ex.Message);
    ```