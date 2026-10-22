# 🎓 EduTechPlatform

![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/Testes-xUnit-5C2D91?style=for-the-badge)
![License](https://img.shields.io/badge/Licença-MIT-green?style=for-the-badge)

Solução .NET que concentra as regras de negócio de uma plataforma educacional: **notas**, **frequência** e **matrícula financeira**, com testes unitários parametrizados em **xUnit**. 📚

> [!NOTE]
> Projeto desenvolvido em equipe como atividade prática da disciplina de **Garantia da Qualidade de Software**.

---

## 📖 Visão geral

A `EduTechPlatform` é dividida em dois projetos:

| Projeto | Papel |
|---|---|
| `EduTechPlatform.App` | Código de produção, com as três classes de serviço |
| `EduTechPlatform.Tests` | Testes unitários parametrizados com xUnit |

## ⚙️ Requisitos do ambiente

- **.NET 10 SDK** ([download](https://dotnet.microsoft.com/download))
- Um terminal (Git Bash, PowerShell, etc.)

```bash
dotnet --version
```

---

## 💼 Responsabilidade de cada classe de serviço

### `NotaDesempenhoService`: desempenho acadêmico

| Método | Responsabilidade |
|---|---|
| `CalcularMediaPonderada(nota1, nota2, notaProjeto)` | Calcula a média final com pesos 3, 3 e 4: `((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10` |
| `ObterSituacaoAcademica(mediaFinal)` | Retorna `"APROVADO"` (≥ 7,0), `"RECUPERACAO"` (de 5,0 a 6,99) ou `"REPROVADO"` (< 5,0) |

### `FrequenciaService`: presença nas aulas

| Método | Responsabilidade |
|---|---|
| `CalcularPorcentagemPresenca(aulasTotais, faltas)` | Retorna o percentual de presença: `((aulasTotais - faltas) / aulasTotais) * 100` |
| `AprovadoPorFrequencia(aulasTotais, faltas)` | Retorna `true` se a presença for de **no mínimo 75%** |

### `MatriculaFinanceiraService`: mensalidade e rematrícula

| Método | Responsabilidade |
|---|---|
| `CalcularValorMensalidade(valorBase, diaPagamento, eBolsista)` | Bolsista: 50% de desconto em qualquer dia. Não bolsista até o dia 5: 10% de desconto. Não bolsista após o dia 5: valor integral |
| `PodeRealizarRematricula(possuiPendenciaFinanceira, situacaoAcademica)` | Retorna `true` apenas se **não houver pendência financeira** e a situação acadêmica **não for** `"REPROVADO"` |

---

## 🧪 Cobertura dos testes parametrizados

Os testes usam `[Theory]` com `[InlineData]`. Em vez de um `[Fact]` por cenário, **um único método** roda várias vezes, uma para cada `[InlineData]`, e cada linha aparece como um teste individual no relatório do xUnit.

| Classe de testes | Regra validada | Cenários |
|---|---|---|
| `NotaDesempenhoServiceTests` | Média ponderada | 2 |
| `NotaDesempenhoServiceTests` | Situação acadêmica | 3 (aprovado, recuperação, reprovado) |
| `FrequenciaServiceTests` | Percentual de presença | 2 |
| `FrequenciaServiceTests` | Aprovação por frequência | 2 (limite exato de 75% e abaixo dele) |
| `MatriculaFinanceiraServiceTests` | Valor da mensalidade | 3 (bolsista, pontual, atrasado) |
| `MatriculaFinanceiraServiceTests` | Elegibilidade para rematrícula | 3 (liberada, com pendência, reprovado) |

**Total: 6 métodos `[Theory]`, resultando em 15 execuções de teste.**

---

## 🚀 Guia de execução

### 1. Clonar o repositório

```bash
git clone https://github.com/miguelalchaar/edutech-platform-xunit.git
cd edutech-platform-xunit
```

### 2. Restaurar as dependências

```bash
dotnet restore
```

### 3. Compilar a solução

```bash
dotnet build
```

### 4. Executar os testes

```bash
dotnet test
```

Saída esperada:

```
Resumo do teste: total: 15; falhou: 0; bem-sucedido: 15; ignorado: 0
```

---

## 🛠️ Tecnologias utilizadas

- 🟣 **.NET 10**
- 🧪 **xUnit**, com `[Theory]` e `[InlineData]`

## 📄 Licença

Este projeto está sob a licença **MIT**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
