using System.ComponentModel;

namespace PortForYouProject.Models.Enuns
{
    public enum Risk
    {
        [Description("Baixo risco")]
        Low = 1,

        [Description("Médio risco")]
        Medium = 2,

        [Description("Alto risco")]
        High = 3
    }
}
