# SolarMonitorProject

O **SolarMonitorProject** é uma aplicação ASP.NET Core que monitora dados climáticos e solares, utiliza machine learning para realizar previsões e recomendações com base em dados fornecidos. Ele inclui uma API para interagir com os dados e modelos de aprendizado de máquina.

---

## Funcionalidades

- **Monitoração do clima e intensidade solar:** Captura e armazena informações meteorológicas.
- **Previsão com Machine Learning:** Permite prever comportamentos com base nos dados fornecidos.
- **Treinamento do Modelo:** Treina um modelo de aprendizado de máquina com dados personalizados.
- **API RESTful:** Fornece endpoints para interagir com os dados e o modelo.
- **Banco de Dados em Memória:** Utiliza o Entity Framework Core com um banco de dados em memória.

---

## Tecnologias Utilizadas

- **.NET 8.0**
- **ASP.NET Core** para desenvolvimento de APIs.
- **Entity Framework Core** para acesso a dados.
- **In-Memory Database** para armazenamento temporário de dados.
- **ML.NET** para aprendizado de máquina.
- **Swagger** para documentação e teste da API.
- **xUnit** para testes unitários.

---

## Estrutura do Projeto

```plaintext
SolarMonitorProject/
├── Controllers/
│   └── WeatherMonitorController.cs   # Controlador principal da API
├── Models/
│   └── ModelInput.cs                 # Modelo para entrada do ML
├── Repositories/
│   ├── IWeatherRepository.cs         # Interface do repositório
│   └── WeatherRepository.cs          # Implementação do repositório
├── Services/
│   └── ModelTrainer.cs               # Serviço de treinamento de modelo ML
├── Program.cs                        # Configuração do pipeline e serviços
├── SolarMonitorProject.csproj        # Configuração do projeto principal
└── README.md                         # Documentação do projeto
Endpoints da API
Base URL
https://localhost:<porta>/api/weatherMonitor
Endpoints
Treinar Modelo

Rota: POST /train
Descrição: Treina o modelo de machine learning com os dados armazenados.
Exemplo de Resposta:
json

{
  "message": "Model trained successfully."
}
Prever Dados

Rota: POST /predict
Descrição: Retorna previsões com base nos dados fornecidos.
Exemplo de Entrada:
json

{
  "Temperature": 25.5,
  "SolarIntensity": 78.2,
  "Recommendation": "High Usage"
}
Exemplo de Saída:
json

{
  "Prediction": "Optimal Usage"
}
Como Executar
Pré-requisitos
.NET 8.0 SDK instalado no sistema.
Ferramentas de desenvolvimento como Visual Studio ou Visual Studio Code (opcional).
Passos
Clone o repositório:



git clone <URL_DO_REPOSITORIO>
cd SolarMonitorProject
Restaure os pacotes NuGet:


dotnet restore
Compile o projeto:


dotnet build
Execute a aplicação:


dotnet run
Acesse a interface Swagger para testar os endpoints:


https://localhost:<porta>/swagger/index.html
Como Testar
Navegue até o diretório de testes:


cd SolarMonitorProject.Tests
Execute os testes:


dotnet test
