using DataAnalyzeApi.Exceptions.Vector;
using DataAnalyzeApi.Services.Analysis.Metrics;

namespace DataAnalyzeApi.Unit.Tests.Services.Analysis.Metrics.Numeric;

[Trait("Category", "Unit")]
[Trait("Component", "Metrics")]
[Trait("SubComponent", "Numeric")]
public abstract class NumericDistanceMetricTests
{
    protected abstract IDistanceMetric<double> Metric { get; }

    [Theory]
    [InlineData(new double[] { 0.2, 0.6 }, new double[] { 0.2, 0.6 }, 0)] // Identical vectors
    [InlineData(new double[] { 1, 0 }, new double[] { 0, 1 }, 1)] // Orthogonal vectors
    [InlineData(new double[] { 0, 0 }, new double[] { 1, 1 }, 1)] // Zero vector
    public void Calculate_ReturnsExpectedDistance(double[] valuesA, double[] valuesB, double expectedDistance)
    {
        // Act
        var distance = Metric.Calculate(valuesA, valuesB);

        // Assert
        Assert.Equal(distance, expectedDistance, precision: 4);
    }

    [Fact]
    public void Calculate_ShouldThrowException_WhenVectorIsNull()
    {
        // Arrange
        var valuesA = new double[] { 1, 2, 3 };

        // Act & Assert
        Assert.Throws<VectorNullException>(() => Metric.Calculate(null!, valuesA));
        Assert.Throws<VectorNullException>(() => Metric.Calculate(valuesA, null!));
    }

    [Fact]
    public void Calculate_ShouldThrowException_WhenVectorsHaveDifferentLengths()
    {
        // Arrange
        var valuesA = new double[] { 1, 2, 3 };
        var valuesB = new double[] { 1, 2 };

        // Act & Assert
        Assert.Throws<VectorLengthMismatchException>(() => Metric.Calculate(valuesA, valuesB));
    }

    [Fact]
    public void Calculate_ShouldThrowException_WhenVectorsAreEmpty()
    {
        // Arrange
        var valuesA = Array.Empty<double>();
        var valuesB = Array.Empty<double>();

        // Act & Assert
        Assert.Throws<EmptyVectorException>(() => Metric.Calculate(valuesA, valuesB));
    }
}
