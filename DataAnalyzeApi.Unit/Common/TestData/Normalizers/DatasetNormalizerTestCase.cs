using DataAnalyzeApi.Unit.Common.Models.Analysis;

namespace DataAnalyzeApi.Unit.Common.TestData.Normalizers;

/// <summary>
/// Test case for DatasetNormalizerTests.
/// </summary>
public record DatasetNormalizerTestCase
{
    /// <summary>
    /// List of objects with their test data.
    /// </summary>
    public List<RawDataObject> RawObjects { get; init; } = [];

    /// <summary>
    /// List of objects with their test data.
    /// </summary>
    public List<NormalizedDataObject> NormalizedObjects { get; init; } = [];
}
