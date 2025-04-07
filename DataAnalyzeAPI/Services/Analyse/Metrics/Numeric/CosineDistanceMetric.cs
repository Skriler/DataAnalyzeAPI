﻿namespace DataAnalyzeAPI.Services.Analyse.Metrics.Numeric;

public class CosineDistanceMetric : BaseDistanceMetric<double>, INumericDistanceMetric
{
    /// <summary>
    /// Calculates cosine distance between two numeric vectors.
    /// Distance is calculated as: 1 - (dot product / (|A| * |B|)).
    /// </summary>
    public double Calculate(double[] valuesA, double[] valuesB)
    {
        Validate(valuesA, valuesB);

        var dotProduct = 0d;
        var magnitudeA = 0d;
        var magnitudeB = 0d;

        for (int i = 0; i < valuesA.Length; i++)
        {
            dotProduct += valuesA[i] * valuesB[i];
            magnitudeA += valuesA[i] * valuesA[i];
            magnitudeB += valuesB[i] * valuesB[i];
        }

        if (magnitudeA == 0 || magnitudeB == 0)
            return 1;

        var cosineSimilarity = dotProduct / (Math.Sqrt(magnitudeA) * Math.Sqrt(magnitudeB));
        return 1 - cosineSimilarity;
    }
}
