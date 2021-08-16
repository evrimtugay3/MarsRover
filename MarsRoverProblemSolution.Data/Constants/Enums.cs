namespace MarsRoverMain.Data.Constants
{
    /// <summary>
    /// compass directions
    /// </summary>
    public enum Directions
    {
        /// <summary>
        /// North
        /// </summary>
        N,

        /// <summary>
        /// East
        /// </summary>
        E,

        /// <summary>
        /// South
        /// </summary>
        S,

        /// <summary>
        /// West
        /// </summary>
        W
    }

    /// <summary>Extensions for Enums</summary>
    public static class EnumExtensions
    {
        /// <summary>To the enum value.</summary>
        /// <typeparam name="T">The enum type to cast to.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ToEnumValue<T>(this string value) where T : System.Enum
        {
            try
            {
                return (T)System.Enum.Parse(typeof(T), value);
            }
            catch
            {
                return default;
            }
        }
    }
}