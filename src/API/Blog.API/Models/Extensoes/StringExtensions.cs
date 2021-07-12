using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blog.API.Models.Extensoes
{
    public static class StringExtensions
    {
        public static string ToSlug(this string value, int? maxLength = null)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            // if it's already a valid slug, return it
            if (RegexUtils.SlugRegex.IsMatch(value))
                return value;

            return GerarSlug(value, maxLength);
        }

        /// <summary>
        /// Creditos para http://stackoverflow.com/questions/2920744/url-slugify-alrogithm-in-cs
        /// </summary>
        private static string GerarSlug(string value, int? maxLength = null)
        {
            //prepara a string, converte hifens em espaços, deixa tudo minúsculo e remove acentos.
            var retorno = RemoverAcentos(value).Replace("-", " ").ToLowerInvariant();

            retorno = Regex.Replace(retorno, @"[^a-z0-9\s-]", string.Empty);
            retorno = Regex.Replace(retorno, @"\s+", " ").Trim(); // converte vários espaços em um

            if (maxLength.HasValue)
                retorno = retorno.Substring(0, retorno.Length <= maxLength ? retorno.Length : maxLength.Value).Trim();

            return Regex.Replace(retorno, @"\s", "-"); // troca espaços por hifens
        }
        private static string RemoverAcentos(string value)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
