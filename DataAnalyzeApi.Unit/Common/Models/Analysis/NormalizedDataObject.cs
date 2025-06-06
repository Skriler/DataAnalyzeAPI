namespace DataAnalyzeApi.Unit.Common.Models.Analysis;

/// <summary>
/// Model of test data object that can be used as normalized test data.
/// </summary>
public record NormalizedDataObject
{
    /// <summary>
    /// Normalized numeric values after processing.
    /// </summary>
    public List<double> NumericValues { get; init; } = [];

    /// <summary>
    /// Normalized categorical values after processing (one-hot encoded).
    /// </summary>
    public List<int[]> CategoricalValues { get; init; } = [];
}
