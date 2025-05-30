﻿using DataAnalyzeApi.Services.Normalizers;
using DataAnalyzeApi.Unit.Common.Assertions;
using DataAnalyzeApi.Unit.Common.Factories.Models;
using DataAnalyzeApi.Unit.Common.TestData.Normalizers;

namespace DataAnalyzeApi.Unit.Tests.Services.Normalizers;

[Trait("Category", "Unit")]
[Trait("Component", "Normalizer")]
public class DatasetNormalizerTests
{
    private readonly DatasetModelFactory datasetModelFactory = new();

    [Theory]
    [MemberData(
        nameof(DatasetNormalizerTestData.NormalizeTestCases),
        MemberType = typeof(DatasetNormalizerTestData))]
    public void Normalize_WhenMixedParameters_ReturnsCorrectNormalization(DatasetNormalizerTestCase testCase)
    {
        // Arrange
        var dataset = datasetModelFactory.Create(testCase.RawObjects);

        // TODO: fix parameters creation
        var expecteDataset = datasetModelFactory.CreateNormalized(testCase.NormalizedObjects);
        var normalizer = new DatasetNormalizer();

        // Act
        var result = normalizer.Normalize(dataset);

        // Assert
        Assert.NotEmpty(result.Objects);
        DatasetAssertions.AssertDataObjectsEqual(expecteDataset.Objects, result.Objects);
    }
}
