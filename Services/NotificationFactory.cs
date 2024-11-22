namespace SolarMonitorProject.Services
{
    public static class NotificationFactory
    {
        public static string GetRecommendation(double solarIntensity)
        {
            if (solarIntensity > 800) return "Ideal para usar energia solar.";
            if (solarIntensity > 400) return "Condições razoáveis para energia solar.";
            return "Não recomendado para uso solar.";
        }
    }
}