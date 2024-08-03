namespace Domain.Extensions
{
    public static class EnumExtension
    {
        public static string EnumKeyNormalize(this Enum value)
        {
            var type = value.GetType();
            string response = Enum.GetName(type, value) ?? throw new Exception("");
            return response.ToUpper();
        }
    }
}
