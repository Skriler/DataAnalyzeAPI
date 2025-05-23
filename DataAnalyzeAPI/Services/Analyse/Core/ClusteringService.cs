﻿using DataAnalyzeApi.Mappers;
using DataAnalyzeApi.Models.Domain.Dataset.Analyse;
using DataAnalyzeApi.Models.Domain.Settings;
using DataAnalyzeApi.Models.DTOs.Analyse.Clustering.Requests;
using DataAnalyzeApi.Models.DTOs.Analyse.Clustering.Results;
using DataAnalyzeApi.Models.Enums;
using DataAnalyzeApi.Services.Analyse.Factories.Clusterer;

namespace DataAnalyzeApi.Services.Analyse.Core;

public class ClusteringService : BaseAnalysisService
{
    private readonly IClustererFactory clustererFactory;
    private readonly ClusteringCacheService cacheService;

    public ClusteringService(
        DatasetService datasetService,
        AnalysisMapper analysisMapper,
        IClustererFactory clustererFactory,
        ClusteringCacheService cacheService)
        : base(datasetService, analysisMapper)
    {
        this.clustererFactory = clustererFactory;
        this.cacheService = cacheService;
    }

    /// <summary>
    /// Performs clustering analysis on the given dataset using the specified algorithm and settings.
    /// </summary>
    public async Task<ClusteringResult> PerformAnalysisAsync<TSettings>(
        DatasetModel dataset,
        BaseClusteringRequest request,
        TSettings settings) where TSettings : BaseClusterSettings
    {
        var clusterer = clustererFactory.Get<TSettings>(settings.Algorithm);
        var clusters = clusterer.Cluster(dataset.Objects, settings);

        var clustersDto = analysisMapper.MapClusterList(clusters, settings.IncludeParameters);

        var clusteringResult = new ClusteringResult()
        {
            DatasetId = dataset.Id,
            Clusters = clustersDto,
        };

        await cacheService.CacheResultAsync(dataset.Id, settings.Algorithm, request, clusteringResult);

        return clusteringResult;
    }

    /// <summary>
    /// Retrieves a cached clustering result for the given dataset, algorithm, and request, if available.
    /// </summary>
    public async Task<ClusteringResult?> GetCachedResultAsync(
        long datasetId,
        ClusterAlgorithm algorithm,
        BaseClusteringRequest request)
    {
        return await cacheService.GetCachedResultAsync(datasetId, algorithm, request);
    }
}
