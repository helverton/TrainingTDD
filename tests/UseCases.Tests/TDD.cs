using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

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
            Product product = new Product(NewProduct.Name, NewProduct.Description);


            //Assert
            Assert.NotNull(product);
            Assert.Equal(product.Name, NewProduct.Name);
            Assert.Equal(product.Description, NewProduct.Description);
        }


        [Fact]
        public void Product_ListAll_Success()
        {
            //Arrange
            Product prod1 = new Product("Produto 1", "Produto para teste 1, retornar lista de registros");
            Product prod2 = new Product("Produto 2", "Produto para teste 2, retornar lista de registros");
            Product prod3 = new Product("Produto 3", "Produto para teste 3, retornar lista de registros");


            //Act
            List<Product> list = ProductService.GetAll();


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
            Product prod1 = new Product("Produto 1", "Produto para teste, buscar por id");
            int id = prod1.Id;


            //Act
            Product productFound = ProductService.GetById(id);


            //Assert
            Assert.NotNull(productFound);
            Assert.Equal(productFound.Name, prod1.Name);
            Assert.Equal(productFound.Description, prod1.Description);
        }


        [Fact]
        public void Product_Update_Success()
        {
            //Arrange
            int id = new Product("Produto 1", "Produto para teste, atualizar registro").Id;

            Product productToUpdate = ProductService.GetById(id);
            productToUpdate.Name = "Produto 1 atualizado";
            productToUpdate.Description = "Produto para teste, registro atualizado";


            //Act
            ProductService.Update(productToUpdate);


            //Assert
            Product productUpdated = ProductService.GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(productUpdated.Name, productToUpdate.Name);
        }


        [Fact]
        public void Product_UpdateStatus_Success()
        {
            //Arrange
            int id = new Product("Produto 1", "Produto para teste, atualizar status", 1).Id;

            Product productToUpdate = ProductService.GetById(id);
            productToUpdate.Status = 0;


            //Act
            ProductService.UpdateStatus(productToUpdate);


            //Assert
            Product productUpdated = ProductService.GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(productUpdated.Status, productToUpdate.Status);
        }


        [Fact]
        public void Product_StockEntry_Success()
        {
            //Arrange
            int id = new Product("Produto 1", "Produto para teste, aumentar estoque", 1).Id;

            Product productToUpdate = ProductService.GetById(id);
            int quantity = 5;


            //Act
            ProductService.StockEntry(productToUpdate, quantity);


            //Assert
            Product productUpdated = ProductService.GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(productUpdated.Quantity, (productToUpdate.Quantity + quantity));
        }


        [Fact]
        public void Product_StockIssue_Success()
        {
            //Arrange
            int id = new Product("Produto 1", "Produto para teste, diminuir estoque", 1).Id;

            Product productToUpdate = ProductService.GetById(id);
            ProductService.StockEntry(productToUpdate, 5);
            int quantity = -2;


            //Act
            ProductService.StockIssue(productToUpdate, quantity);


            //Assert
            Product productUpdated = ProductService.GetById(id);
            Assert.NotNull(productUpdated);
            Assert.Equal(productUpdated.Quantity, (productToUpdate.Quantity + quantity));
        }


        [Fact]
        public void Product_Delete_Success()
        {
            //Arrange
            int id = new Product("Produto 1", "Produto para teste, excluir registro").Id;
            Product productToDelete = ProductService.GetById(id);


            //Act
            ProductService.Delete(productToDelete);


            //Assert
            List<Product> list = ProductService.GetAll();
            Assert.NotNull(list);
            Assert.DoesNotContain(productToDelete, list);
        }
    }
}
