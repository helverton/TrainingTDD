using Application.Services.Products;
using Domain.Entities;
using Domain.Enums;
using Xunit.Gherkin.Quick;

namespace UseCases.Tests.BDD.Definitions
{
    [FeatureFile(@"./Features/Product.feature")]
    public sealed class BDD : Feature
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
        private Product _product = new Product();

        [Given(@"Given I enter ""(\w+?)"" name and ""(\w+?)"" description to new product")]
        public void I_given_data_new_product(string name, string description)
        {
            Assert.NotNull(name); 
            Assert.NotNull(description);
            _product.SetName(name);
            _product.SetDescription(description);
        }

        [When(@"I save the product")]
        public void I_save_the_product()
        {
            _product = _productService.Save(_product.Name, _product.Description);

            Assert.NotNull(_product);
        }

        [Then(@"Then product should be (\d+) saved in the database")]
        public void Then_product_should_be_save_in_the_database()
        {
            var productDb = _productService.GetById(_product.Id);

            Assert.NotNull(productDb);
            Assert.Equal(_product.Name, productDb.Name);
            Assert.Equal(_product.Description, productDb.Description);
        }

        [And(@"And product should be (\d+) saved with quantity 0")]
        public void And_product_should_be_saved_with_quantity_0()
        {
            var productDb = _productService.GetById(_product.Id);

            Assert.NotNull(productDb);
            Assert.Equal(0, productDb.Quantity);
        }

        [And(@"And product should be (\d+) saved with Active status")]
        public void The_product_should_be_saved_with_active_status()
        {
            var productDb = _productService.GetById(_product.Id);

            Assert.NotNull(productDb);
            Assert.Equal(ProductStatus.Ativo, productDb.Status);
        }
    }
}
