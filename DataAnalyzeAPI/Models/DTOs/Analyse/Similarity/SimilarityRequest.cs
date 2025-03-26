﻿using DataAnalyzeAPI.Models.DTOs.Analyse.Settings;

namespace DataAnalyzeAPI.Models.DTOs.Analyse.Similarity;

public class SimilarityRequest
{
    public List<ParameterSettingsDto> ParameterSettings { get; set; } = new();
}
