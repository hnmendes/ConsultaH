namespace Consultah.MVC.ViewModels.ExtensionMethods
{
    public static class RemoverCaracteresExtension
    {
        private static string RemoverCaracteres(string str, string[] caracteres)
        {
            var newStr = string.Empty;

            for (int i = 0; i < caracteres.Length; i++)
            {
                newStr = (i == 0) ? str.Replace(caracteres[i], string.Empty) : newStr.Replace(caracteres[i], string.Empty);
            }

            return newStr;
        }

        public static string RemoverCaractereCPF(this string str)
        {
            var removerCaractereCpf = new string[] { "-", "." };
            var novoCpf = RemoverCaracteres(str, removerCaractereCpf);

            return novoCpf;
        }

        public static string RemoverCaractereTelefone(this string str)
        {
            var removerCaractereTelefone = new string[] { "(", ")", " ", "-" };
            var novoTelefone = RemoverCaracteres(str,removerCaractereTelefone);

            return novoTelefone;
        }
    }
}