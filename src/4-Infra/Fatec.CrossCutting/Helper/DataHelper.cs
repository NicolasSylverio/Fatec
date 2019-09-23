using System;

namespace Fatec.CrossCutting.Helper
{
    /// <summary>
    ///     Classes de serviços de regras para datas.
    /// </summary>
    public static class DataHelper
    {
        /// <summary>
        ///     Retorna o valor data atual "DateTime.Now" de acordo com o horario brasileiro. Evitando pegar horario do servidor caso hospedado em nuvem ou data mau configurada.
        /// </summary>
        /// <returns>DateTime.Now de acordo com o TimeZone brasil.</returns>
        public static DateTime GetHoraBrasilia() => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
    }
}