﻿// file:	Supervised\KNN\KNNGenerator.cs
//
// summary:	Implements the knn generator class
using System;
using System.Linq;
using System.Threading.Tasks;
using numl.Math.LinearAlgebra;
using System.Collections.Generic;

namespace numl.Supervised.KNN
{
    /// <summary>A knn generator.</summary>
    public class KNNGenerator : Generator
    {
        /// <summary>Gets or sets the k.</summary>
        /// <value>The k.</value>
        public int K { get; set; }
        /// <summary>Constructor.</summary>
        /// <param name="k">(Optional) the int to process.</param>
        public KNNGenerator(int k = 5)
        {
            K = k;
        }
        /// <summary>Generate model based on a set of examples.</summary>
        /// <param name="X">The Matrix to process.</param>
        /// <param name="y">The Vector to process.</param>
        /// <returns>Model.</returns>
        public override IModel Generate(Matrix X, Vector y)
        {
            this.Preprocess(X);

            return new KNNModel
            {
                Descriptor = Descriptor,
                NormalizeFeatures = base.NormalizeFeatures,
                FeatureNormalizer = base.FeatureNormalizer,
                FeatureProperties = base.FeatureProperties,
                X = X,
                Y = y,
                K = K
            };
        }
    }
}