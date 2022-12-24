using System.ComponentModel;

namespace PortForYouProject.Models.Enuns
{
    public enum Status
    {
        [Description("Em análise")]
        Analise = 1,

        [Description("Análise feita")]
        AnaliseFeita = 2,

        [Description("Análise aprovada")]
        AnaliseAprovada = 3,

        [Description("Iniciado")]
        Iniciado = 4,

        [Description("Planejado")]
        Planejado = 5,

        [Description("Em andamento")]
        EmAndamento = 6,

        [Description("Encerrado")]
        Encerrado = 7,

        [Description("Cancelado")]
        Cancelado = 8,
    }
}
