using EduTechPlatform.App;

namespace EduTechPlatform.Tests;

public class FrequenciaServiceTests
{
    private readonly FrequenciaService _service = new();

    [Theory]
    [InlineData(80, 20, 75.0)]
    [InlineData(100, 10, 90.0)]
    public void CalcularPorcentagemPresenca_RetornaPercentualEsperado(
        int aulasTotais,
        int faltas,
        double percentualEsperado)
    {
        var resultado = _service.CalcularPorcentagemPresenca(aulasTotais, faltas);

        Assert.Equal(percentualEsperado, resultado);
    }

    [Theory]
    [InlineData(80, 20, true)]
    [InlineData(80, 21, false)]
    public void AprovadoPorFrequencia_RetornaResultadoEsperado(
        int aulasTotais,
        int faltas,
        bool aprovadoEsperado)
    {
        var resultado = _service.AprovadoPorFrequencia(aulasTotais, faltas);

        Assert.Equal(aprovadoEsperado, resultado);
    }

    [Fact]
    public void CalcularPorcentagemPresenca_ComTotalDeAulasInvalido_LancaArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            _service.CalcularPorcentagemPresenca(0, 0));
    }
}
