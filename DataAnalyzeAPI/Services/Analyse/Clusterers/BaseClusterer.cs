﻿using DataAnalyzeAPI.Models.Domain.Clustering;
using DataAnalyzeAPI.Models.Domain.Dataset.Analyse;
using DataAnalyzeAPI.Models.Domain.Settings;
using DataAnalyzeAPI.Services.Analyse.DistanceCalculators;

namespace DataAnalyzeAPI.Services.Analyse.Clusterers;

public abstract class BaseClusterer<TSettings> where TSettings : IClusterSettings
{
    protected abstract string ClusterPrefix { get; }

    protected readonly IDistanceCalculator distanceCalculator;

    protected BaseClusterer(IDistanceCalculator distanceCalculator)
    {
        this.distanceCalculator = distanceCalculator;
    }

    public abstract List<Cluster> Cluster(List<DataObjectModel> Objects, TSettings settings);
}
