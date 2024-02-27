using Domain.Enums;
using Domain.Entities;
using Application.Services.Products;

namespace UseCases.Tests
{
    public class TDD
    {
        //TDD(Desenvolvimento Guiado por Testes) :
          //Significado: TDD é uma metodologia que enfatiza a criação de testes automatizados antes de escrever o código real.
          //Processo: 
             //Escreva um teste para a funcionalidade desejada, sem implementar nada.
             //Execute o teste e observe-o falhar.
             //Escreva o código que fará o teste passar.
             //Execute novamente o teste e verifique se ele passa.
             //Revise o código, refatore-o e melhore-o, se necessário.
             //Repita o processo para cada parte do código.
          //Vantagens:
             //Garante cobertura de testes para 100% do código.
             //Ajuda os desenvolvedores a pensar nas implementações e a revisar o trabalho feito.

        //Testes de unidade para verificar funcionalidades específicas e garantir que o código funcione conforme o esperado


        [Fact]
        public void Product_Create_Success()
        {
            //Arrange
            var NewProduct = new
            {
                Name = "Produto 1",
                Description = "Produto para teste, criar novo registro"
            };


            //Act
            Product product = new ProductService().Save(NewProduct.Name, NewProduct.Description);


            //Assert
            Assert.NotNull(product);
            Assert.Equal(NewProduct.Name, product.Name);
            Assert.Equal(NewProduct.Description, product.Description);
        }


        [Fact]
        public void Product_GetAll_Success()
        {
            //Arrange
            Product prod1 = new ProductService().Save("Produto 1", "Produto para teste 1, retornar lista de registros");
            Product prod2 = new ProductService().Save("Produto 2", "Produto para teste 2, retornar lista de registros");
            Product prod3 = new ProductService().Save("Produto 3", "Produto para teste 3, retornar lista de registros");


            //Act
            List<Product> list = new ProductService().GetAll();


            //Assert
            Assert.NotNull(list);
            Assert.Equal(3, list.Count);
            Assert.Contains(prod1, list);
            Assert.Contains(prod2, list);
            Assert.Contains(prod3, list);
        }


        [Fact]
        public void Product_GetById_Success()
        {
            //Arrange
            Product prod1 = new ProductService().Save("Produto 1", "Produto para teste, buscar por id");
            int id = prod1.Id;


            //Act
            Product productFound = new ProductService().GetById(id);


            //Assert
            Assert.NotNull(productFound);
            Assert.Equal(prod1.Name, productFound.Name);
            Assert.Equal(prod1.Description, productFound.Description);
        }


        [Fact]
        public void Product_UpdateName_Success()
        {
            //Arrange
            int id = new ProductService().Save("Produto 1", "Produto para teste, atualizar registro").Id;
            string name = "Produto 1 atualizado";


            //Act
            bool result = new ProductService().UpdateName(id, name);


            //Assert
            Assert.True(result);
            Product productUpdated = new ProductService().GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(name, productUpdated.Name);
        }


        [Fact]
        public void Product_UpdateDescription_Success()
        {
            //Arrange
            int id = new ProductService().Save("Produto 1", "Produto para teste, atualizar registro").Id;
            string description = "Produto para teste, registro atualizado";


            //Act
            bool result = new ProductService().UpdateDescription(id, description);


            //Assert
            Assert.True(result);
            Product productUpdated = new ProductService().GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(description, productUpdated.Description);
        }


        [Fact]
        public void Product_UpdateStatus_Success()
        {
            //Arrange
            int id = new ProductService().Save("Produto 1", "Produto para teste, atualizar status").Id;
            ProductStatus status = ProductStatus.Inativo;


            //Act
            bool result = new ProductService().UpdateStatus(id, status);


            //Assert
            Assert.True(result);
            Product productUpdated = new ProductService().GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(status, productUpdated.Status);
        }


        [Fact]
        public void Product_StockEntry_Success()
        {
            //Arrange
            int id = new ProductService().Save("Produto 1", "Produto para teste, aumentar estoque").Id;

            Product productToUpdate = new ProductService().GetById(id);
            int quantity = +5;


            //Act
            bool result = new ProductService().StockEntry(id, quantity);


            //Assert
            Assert.True(result);
            Product productUpdated = new ProductService().GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(quantity, productUpdated.Quantity);
        }


        [Fact]
        public void Product_StockIssue_Success()
        {
            //Arrange
            int id = new ProductService().Save("Produto 1", "Produto para teste, diminuir estoque").Id;
            new ProductService().StockEntry(id, +7);

            Product productToUpdate = new ProductService().GetById(id);
            int quantity = -2;
            int quantityAftr = productToUpdate.Quantity + quantity;


            //Act
            bool result = new ProductService().StockIssue(id, quantity);


            //Assert
            Assert.True(result);
            Product productUpdated = new ProductService().GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(quantityAftr, productUpdated.Quantity);
        }


        [Fact]
        public void Product_Delete_Success()
        {
            //Arrange
            int id = new ProductService().Save("Produto 1", "Produto para teste, excluir registro").Id;


            //Act
            bool result = new ProductService().Delete(id);


            //Assert
            Assert.True(result);
            List<Product> list = new ProductService().GetAll();
            Assert.NotNull(list);
            Assert.Null(list.Find(x => x.Id == id));
        }
    }
}
