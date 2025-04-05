﻿namespace DataAnalyzeAPI.Services.Analyse.DistanceCalculators.CategoricalMetrics;

public class HammingDistanceMetric : ICategoricalDistanceMetric
{
    public double Calculate(int[] valuesA, int[] valuesB)
    {
        var differences = valuesA.Except(valuesB).Count()
            + valuesB.Except(valuesA).Count();

        return differences / (double)valuesA.Length;
    }
}
