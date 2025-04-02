namespace UserInterface.MVVM.Converters
{
    using DataAccess;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Converts string to WeightGoal.
    /// </summary>
    public class StringToGoalCoverter : IValueConverter
    {
        /// <summary>
        /// Converts.
        /// </summary>
        /// <param name="value">Convert value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString()!;
        }

        /// <summary>
        /// Converts back.
        /// </summary>
        /// <param name="value">Convert value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res = value.ToString()!.Replace(" ", string.Empty).Split(":")[1];
            switch (res)
            {
                case "Gain":
                    return WeightGoal.Gain;
                case "Lose":
                    return WeightGoal.Lose;
                case "Maintain":
                    return WeightGoal.Maintain;
                default:
                    return WeightGoal.Maintain;
            }
        }
    }
}
