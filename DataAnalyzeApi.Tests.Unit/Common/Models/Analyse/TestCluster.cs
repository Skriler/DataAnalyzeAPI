﻿namespace DataAnalyzeApi.Tests.Common.Models.Analyse;

/// <summary>
/// Model of test cluster that can be used as test data.
/// </summary>
public class TestCluster
{
    /// <summary>
    /// List of objects with their test data.
    /// </summary>
    public List<NormalizedDataObject> Objects { get; set; } = new();
}
