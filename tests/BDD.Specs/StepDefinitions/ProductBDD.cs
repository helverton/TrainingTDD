using Application.Services.Products;
using Domain.Entities;
using Domain.Enums;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace BDD.Specs.StepDefinitions
{
    [Binding]
    public sealed class ProductBDD
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

        #region @save
        [Given("name '(.*)' and description '(.*)' to the new product")]
        public void GivenNameAndDescriptionToTheNewProduct(string name, string description)
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

        [Then("Product should be in the database")]
        public void ThenProductShouldBeInTheDatabase()
        {
            //TODO: implement assert (verification) logic

            var productDb = _productService.GetById(_product.Id);

            Assert.NotNull(productDb);
            Assert.Equal(_product.Name, productDb.Name);
            Assert.Equal(_product.Description, productDb.Description);
        }

        [Then("Status should be '(.*)' Active")]
        public void ThenStatusShouldBeActive(ProductStatus status)
        {
            //TODO: implement assert (verification) logic

            var productDb = _productService.GetById(_product.Id);

            Assert.NotNull(productDb);
            Assert.Equal(status, productDb.Status);
        }

        [Then("Quantity should be '(.*)'")]
        public void ThenQuantityShouldBe0(int quantity)
        {
            //TODO: implement assert (verification) logic

            var productDb = _productService.GetById(_product.Id);

            Assert.NotNull(productDb);
            Assert.Equal(quantity, productDb.Quantity);

            //Finally
            Assert.True(_productService.ForcedDelete(productDb.Id));
        }
        #endregion


        #region @update
        [Given("a product to update with name '(.*)' and description '(.*)'")]
        public void GivenAProductWithNameXXXAndDescriptionXXX(string name, string description)
        {
            //TODO: implement arrange (precondition) logic

            Assert.NotNull(name);
            Assert.NotNull(description);

            _product = _productService.Save(name, description);
            Assert.NotNull(_product);
            Assert.Equal(name, _product.Name);
        }

        [When("I update the name to '(.*)'")]
        public void WhenIUpdateTheNameToXXX(string name)
        {
            //TODO: implement act (action) logic

            Assert.NotNull(name);
            bool result = _productService.UpdateName(_product.Id, name);

            Assert.True(result);
        }

        [Then("the product name should be '(.*)'")]
        public void ThenTheProductNameShouldBeXXX(string name)
        {
            //TODO: implement assert (verification) logic

            var productDb = _productService.GetById(_product.Id);

            Assert.NotNull(productDb);
            Assert.Equal(name, productDb.Name);

            //Finally
            Assert.True(_productService.ForcedDelete(productDb.Id));
        }
        #endregion


        #region @stock_issue
        [Given("a product to stock issue with name '(.*)' and description '(.*)'")]
        public void GivenAProductWithNameYYYAndDescriptionYYY(string name, string description)
        {
            //TODO: implement arrange (precondition) logic

            Assert.NotNull(name);
            Assert.NotNull(description);

            _product = _productService.Save(name, description);
            Assert.NotNull(_product);
            Assert.Equal(name, _product.Name);
        }

        [Then("I enter negative quantity '(.*)' and try to save the result should be '(.*)'")]
        public void ThenITryToSaveTheResultShouldBeFalse(int quantity, bool resultShouldBe)
        {
            //TODO: implement assert (verification) logic

            Assert.True(quantity < 0);
            bool result = _productService.StockIssue(_product, quantity);
            Assert.Equal(resultShouldBe, result);

            //Finally
            Assert.True(_productService.ForcedDelete(_product.Id));
        }
        #endregion


        #region @stock_issue
        [Given("a product to delete with name '(.*)' and description '(.*)'")]
        public void GivenAProductWithNameJJJAndDescriptionJJJ(string name, string description)
        {
            //TODO: implement arrange (precondition) logic

            Assert.NotNull(name);
            Assert.NotNull(description);

            _product = _productService.Save(name, description);
            _productService.StockEntry(_product, 10);
            Assert.NotNull(_product);
            Assert.Equal(name, _product.Name);
        }

        [Then("I try to delete the product the result should be '(.*)'")]
        public void ThenITryToDeleteTheProductTheResultShouldBeFalse(bool resultShouldBe)
        {
            //TODO: implement assert (verification) logic

            bool result = _productService.Delete(_product.Id);
            Assert.Equal(resultShouldBe, result);

            //Finally
            Assert.True(_productService.ForcedDelete(_product.Id));
        }
        #endregion
    }
}
