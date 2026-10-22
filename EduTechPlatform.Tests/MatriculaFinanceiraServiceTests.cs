using EduTechPlatform.App;

namespace EduTechPlatform.Tests;

public class MatriculaFinanceiraServiceTests
{
    private readonly MatriculaFinanceiraService _service = new();

    [Theory]
    [InlineData(1000.00, 10, true, 500.00)]
    [InlineData(1000.00, 4, false, 900.00)]
    [InlineData(1000.00, 10, false, 1000.00)]
    public void CalcularValorMensalidade_RetornaValorEsperado(
        double valorBase,
        int diaPagamento,
        bool eBolsista,
        double valorEsperado)
    {
        var resultado = _service.CalcularValorMensalidade(
            (decimal)valorBase,
            diaPagamento,
            eBolsista);

        Assert.Equal((decimal)valorEsperado, resultado);
    }

    [Theory]
    [InlineData(false, "APROVADO", true)]
    [InlineData(true, "APROVADO", false)]
    [InlineData(false, "REPROVADO", false)]
    public void PodeRealizarRematricula_RetornaResultadoEsperado(
        bool possuiPendenciaFinanceira,
        string situacaoAcademica,
        bool podeRealizarEsperado)
    {
        var resultado = _service.PodeRealizarRematricula(
            possuiPendenciaFinanceira,
            situacaoAcademica);

        Assert.Equal(podeRealizarEsperado, resultado);
    }
}
