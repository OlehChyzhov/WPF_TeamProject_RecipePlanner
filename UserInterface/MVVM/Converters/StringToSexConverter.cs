namespace UserInterface.MVVM.Converters
{
    using DataAccess;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// String to Sex converter.
    /// </summary>
    public class StringToSexConverter : IValueConverter
    {
        /// <summary>
        /// Convert method.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString()!;
        }

        /// <summary>
        /// ConvertBack.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string res = value.ToString()!.Replace(" ", "").Split(":")[1];
            switch (res)
            {
                case "Male":
                    return Sex.Male;
                case "Female":
                    return Sex.Female;
                default:
                    return Sex.Male;
            }
        }
    }
}
