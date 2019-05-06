namespace SmsParkPay.Mixins
{
    public static class StringMixins
    {
        public static bool IsNullOrEmpty(this string value)
            => string.IsNullOrEmpty(value);
    }
}
