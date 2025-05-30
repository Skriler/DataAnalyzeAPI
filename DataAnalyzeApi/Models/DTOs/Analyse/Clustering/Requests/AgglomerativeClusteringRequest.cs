﻿using DataAnalyzeApi.Models.Config.Clustering;
using System.ComponentModel.DataAnnotations;

namespace DataAnalyzeApi.Models.DTOs.Analyse.Clustering.Requests;

public record AgglomerativeClusteringRequest : BaseClusteringRequest
{
    [Range(AgglomerativeConfig.Threshold.MinAllowed, AgglomerativeConfig.Threshold.MaxAllowed)]
    public double Threshold { get; init; } = AgglomerativeConfig.Threshold.Default;
}
