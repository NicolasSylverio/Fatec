namespace Fatec.Mvc.Models
{
    /// <summary>
    ///     Objeto para montar dropdownlists tipados.
    /// </summary>
    /// <typeparam name="T">Tipagem do identificador do dropdown.</typeparam>
    public class DropDownDto<T>
    {
        /// <summary>
        ///     Id de identificação do DTO, typeof T.
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        ///     Descrição do dropdown.
        /// </summary>
        public string Descricao { get; set; }
    }
}