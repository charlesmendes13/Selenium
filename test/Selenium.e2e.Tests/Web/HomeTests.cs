using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using Xunit;

namespace Selenium.e2e.Tests.Web
{
    public class HomeTests : IDisposable
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        public HomeTests()
        {
            var option = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            };

            driver = new ChromeDriver(option);
            baseURL = "https://localhost:44356/";
            verificationErrors = new StringBuilder();
        }

        [Fact]
        public void Cadastro_Sucesso_Test()
        {
            // Arrange

            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("Nome")).Click();
            driver.FindElement(By.Id("Nome")).Clear();
            driver.FindElement(By.Id("Nome")).SendKeys("Charles");
            driver.FindElement(By.Id("Sobrenome")).Click();
            driver.FindElement(By.Id("Sobrenome")).Clear();
            driver.FindElement(By.Id("Sobrenome")).SendKeys("Mendes");
            driver.FindElement(By.Id("Sexo")).Click();
            new SelectElement(driver.FindElement(By.Id("Sexo"))).SelectByText("Feminino");
            driver.FindElement(By.Id("Sexo")).Click();
            new SelectElement(driver.FindElement(By.Id("Sexo"))).SelectByText("Masculino");
            driver.FindElement(By.Id("RG")).Click();
            driver.FindElement(By.Id("RG")).Clear();
            driver.FindElement(By.Id("RG")).SendKeys("0208304139");
            driver.FindElement(By.Id("CPF")).Click();
            driver.FindElement(By.Id("CPF")).Clear();
            driver.FindElement(By.Id("CPF")).SendKeys("10362015708");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Privacy'])[1]/following::div[10]")).Click();
            driver.FindElement(By.Id("CEP")).Click();
            driver.FindElement(By.Id("CEP")).Clear();
            driver.FindElement(By.Id("CEP")).SendKeys("24723480");
            driver.FindElement(By.Id("Endereco")).Click();
            driver.FindElement(By.Id("Endereco")).Clear();
            driver.FindElement(By.Id("Endereco")).SendKeys("Rua Henrique de Paula Melo, 100");
            driver.FindElement(By.Id("Bairro")).Click();
            driver.FindElement(By.Id("Bairro")).Clear();
            driver.FindElement(By.Id("Bairro")).SendKeys("Largo da Ideia");
            driver.FindElement(By.Id("Estado")).Click();
            new SelectElement(driver.FindElement(By.Id("Estado"))).SelectByText("SP");
            driver.FindElement(By.Id("Estado")).Click();
            new SelectElement(driver.FindElement(By.Id("Estado"))).SelectByText("RJ");
            driver.FindElement(By.Id("Cidade")).Click();
            driver.FindElement(By.Id("Cidade")).Clear();
            driver.FindElement(By.Id("Cidade")).SendKeys("São Gonçalo");
            driver.FindElement(By.XPath("//input[@value='Criar']")).Click();

            // Assert

            Assert.NotNull(driver.FindElement(By.XPath("//pre[contains(text(),'Sucesso')]")));
        }

        [Fact]
        public void Cadastro_Erro_Test()
        {
            // Arrange

            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("Nome")).Click();
            driver.FindElement(By.Id("Nome")).Clear();
            driver.FindElement(By.Id("Nome")).SendKeys("Charles");
            driver.FindElement(By.Id("Sobrenome")).Click();
            driver.FindElement(By.Id("Sobrenome")).Clear();
            driver.FindElement(By.Id("Sobrenome")).SendKeys("Mendes");
            driver.FindElement(By.Id("Sexo")).Click();
            new SelectElement(driver.FindElement(By.Id("Sexo"))).SelectByText("Feminino");
            driver.FindElement(By.Id("Sexo")).Click();
            new SelectElement(driver.FindElement(By.Id("Sexo"))).SelectByText("Masculino");
            driver.FindElement(By.Id("CPF")).Click();
            driver.FindElement(By.Id("CPF")).Clear();
            driver.FindElement(By.Id("CPF")).SendKeys("10362015708");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Privacy'])[1]/following::div[10]")).Click();
            driver.FindElement(By.Id("CEP")).Click();
            driver.FindElement(By.Id("CEP")).Clear();
            driver.FindElement(By.Id("CEP")).SendKeys("24723480");
            driver.FindElement(By.Id("Endereco")).Click();
            driver.FindElement(By.Id("Endereco")).Clear();
            driver.FindElement(By.Id("Endereco")).SendKeys("Rua Henrique de Paula Melo, 100");
            driver.FindElement(By.Id("Bairro")).Click();
            driver.FindElement(By.Id("Bairro")).Clear();
            driver.FindElement(By.Id("Bairro")).SendKeys("Largo da Ideia");
            driver.FindElement(By.Id("Estado")).Click();
            new SelectElement(driver.FindElement(By.Id("Estado"))).SelectByText("SP");
            driver.FindElement(By.Id("Estado")).Click();
            new SelectElement(driver.FindElement(By.Id("Estado"))).SelectByText("RJ");
            driver.FindElement(By.Id("Cidade")).Click();
            driver.FindElement(By.Id("Cidade")).Clear();
            driver.FindElement(By.Id("Cidade")).SendKeys("São Gonçalo");
            driver.FindElement(By.XPath("//input[@value='Criar']")).Click();

            // Assert

            Assert.NotNull(driver.FindElement(By.XPath("//pre[contains(text(),'Erro')]")));
        }

        public void Dispose()
        {
            try
            {
                // driver.Quit();
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

            Assert.Equal("", verificationErrors.ToString());
        }
    }
}
