using Microsoft.ML;
using Microsoft.ML.Data;

namespace SolarMonitorProject.ML
{
    public class ModelTrainer
    {
        private readonly MLContext _mlContext;
        private readonly string _modelPath = "MLModel.zip";

        public ModelTrainer()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(IEnumerable<ModelInput> data)
        {
            // Define o esquema de dados e o pipeline
            var dataView = _mlContext.Data.LoadFromEnumerable(data);
            var pipeline = _mlContext.Transforms.Conversion
                .MapValueToKey("Recommendation", "Recommendation")
                .Append(_mlContext.Transforms.Concatenate("Features", "Temperature", "SolarIntensity"))
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Recommendation", "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("Recommendation"));

            // Treina o modelo
            var model = pipeline.Fit(dataView);

            // Salva o modelo
            _mlContext.Model.Save(model, dataView.Schema, _modelPath);
        }

        public ModelOutput Predict(ModelInput input)
        {
            var model = _mlContext.Model.Load(_modelPath, out var _);
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(model);
            return predictionEngine.Predict(input);
        }
    }
}