using Application.Services.Products;
using Domain.Entities;
using Domain.Enums;

namespace BDD.Specs.StepDefinitions
{
    [Binding]
    public sealed class ProductStepDefinitions
    {
        //BDD(Desenvolvimento Orientado por Comportamentos) :
            //Significado: BDD é uma técnica de desenvolvimento ágil que visa a colaboração entre desenvolvedores, QAs e analistas, com foco na documentação do comportamento do software.
            //Aplicação em Gherkin: 
                //Use palavras-chave para criar cenários de teste:
                    //Dado (Given): Pré-condições verdadeiras para executar o teste.
                    //Quando (When): Ação a ser executada.
                    //Então (Then): Resultado esperado.
                    //E (And): Adiciona sentenças positivas no Dado, Quando ou Então.
            //Vantagens:
                //Unificação: Negócio e tecnologia se referem às funcionalidades de forma consistente.
                //Visualização de Valor: Analisa o valor de cada funcionalidade para o negócio.
                //Planejamento Completo: Projeta tudo de cima a baixo sem retorno decrescente.
                //Compartilhamento de Conhecimento: Facilita a comunicação entre analistas, desenvolvedores e testadores.
                //Documentação Dinâmica: Promove documentação sem esforço adicional.

        //Testes de comportamentos para verificar funcionalidades específicas e garantir que o código funcione conforme o esperado na especificação

        private readonly ProductService _productService = new ProductService();
        private Product _product = new();

        [Given("I enter name '(.*)' and description '(.*)'")]
        public void GivenIEnterNameAndDescription(string name, string description)
        {
            //TODO: implement arrange (precondition) logic

            Assert.NotNull(name);
            Assert.NotNull(description);
            _product.SetName(name);
            _product.SetDescription(description);
        }

        [When("I save the product")]
        public void WhenISaveTheProduct()
        {
            //TODO: implement act (action) logic

            _product = _productService.Save(_product.Name, _product.Description);

            Assert.NotNull(_product);
        }

        [Then("Product saved in the database")]
        public void ThenProductSavedInTheDatabase()
        {
            //TODO: implement assert (verification) logic

            var productDb = _productService.GetById(_product.Id);

            Assert.NotNull(productDb);
            Assert.Equal(_product.Name, productDb.Name);
            Assert.Equal(_product.Description, productDb.Description);
        }
    }
}
