﻿using DataAnalyzeAPI.Models.Domain.Dataset.Analyse;

namespace DataAnalyzeAPI.Models.Domain.Clustering;

public class AgglomerativeCluster : Cluster
{
    public bool IsMerged { get; private set; }

    public AgglomerativeCluster(DataObjectModel obj)
    {
        Objects.Add(obj);
        IsMerged = false;
    }

    public void Merge(AgglomerativeCluster mergedCluster)
    {
        Objects.AddRange(mergedCluster.Objects);
        mergedCluster.IsMerged = true;
    }
}
