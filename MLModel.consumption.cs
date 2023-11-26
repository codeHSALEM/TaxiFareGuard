﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace TaxiFareApp
{
    public partial class MLModel
    {
        /// <summary>
        /// model input class for MLModel.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"vendor_id")]
            public string Vendor_id { get; set; }

            [ColumnName(@"rate_code")]
            public float Rate_code { get; set; }

            [ColumnName(@"passenger_count")]
            public float Passenger_count { get; set; }

            [ColumnName(@"trip_time_in_secs")]
            public float Trip_time_in_secs { get; set; }

            [ColumnName(@"trip_distance")]
            public float Trip_distance { get; set; }

            [ColumnName(@"payment_type")]
            public string Payment_type { get; set; }

            [ColumnName(@"fare_amount")]
            public float Fare_amount { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for MLModel.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"vendor_id")]
            public float[] Vendor_id { get; set; }

            [ColumnName(@"rate_code")]
            public float Rate_code { get; set; }

            [ColumnName(@"passenger_count")]
            public float Passenger_count { get; set; }

            [ColumnName(@"trip_time_in_secs")]
            public float Trip_time_in_secs { get; set; }

            [ColumnName(@"trip_distance")]
            public float Trip_distance { get; set; }

            [ColumnName(@"payment_type")]
            public float[] Payment_type { get; set; }

            [ColumnName(@"fare_amount")]
            public float Fare_amount { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("MLModel.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
