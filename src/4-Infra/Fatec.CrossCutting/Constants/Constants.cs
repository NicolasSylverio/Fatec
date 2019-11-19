namespace Fatec.CrossCutting.Constants
{
    public static class Constants
    {
        public const int NumeroVagasPorPagina = 6;

        public const int NumeroUsuarioPorPagina = 10;

        public const int NumeroPaginacaoDefault = 10;

        public const int NumeroPaginacaoListaDefault = 20;

        // visitantes = usuarios comuns.
        // alunos = usuario com cadastro mais especifico, 
        // administrador = usuarios administradores ex: coordenadores.
        // usuarios = usuarios comuns com acessos simples ex: professores, administrativo.
        public static readonly string[] SystemRoles = { "visitante", "administrador", "usuario", "aluno" };
    }
}