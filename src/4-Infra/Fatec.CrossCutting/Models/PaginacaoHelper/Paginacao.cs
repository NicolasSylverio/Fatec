namespace Fatec.CrossCutting.Models.PaginacaoHelper
{
    public sealed class Paginacao
    {
        public Paginacao()
        {

        }

        public Paginacao(int pagina, int totalPagina)
        {
            Pagina = pagina;
            TotalPorPagina = totalPagina;
        }

        public Paginacao(int pagina, int totalPagina, string ordenarPor, string direcao)
        {
            Pagina = pagina;
            TotalPorPagina = totalPagina;
            OrdenarPor = ordenarPor;
            Direcao = direcao;
        }

        public int ExibindoDe(int totalItens)
        {
            return totalItens == 0 ? 0 : 1 + TotalPorPagina * (Pagina - 1);
        }

        public int ExibindoAte(int totalItens)
        {
            return TotalPorPagina * Pagina < totalItens ? TotalPorPagina * Pagina : totalItens;
        }


        public int Pagina { get; set; } = 1;
        public int TotalPorPagina { get; set; } = 10;
        public int TotalPaginacao => (Pagina - 1) * TotalPorPagina;
        public bool TodosRegistros => TotalPorPagina == default(int);
        public string OrdenarPor { get; set; }
        public string Direcao { get; set; }
    }
}
