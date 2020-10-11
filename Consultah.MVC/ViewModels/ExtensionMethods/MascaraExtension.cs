namespace Consultah.MVC.ViewModels.ExtensionMethods
{
    public static class MascaraExtension
    {
        public static string GerarCPFMascara(this string str)
        {
            var cpfMascarado = $"{str[0]}{str[1]}{str[2]}.{str[3]}{str[4]}{str[5]}.{str[6]}{str[7]}{str[8]}-{str[9]}{str[10]}";
            
            return cpfMascarado;
        }

        public static string GerarTelefoneMascara(this string str)
        {
            var telefoneMascarado = $"({str[0]}{str[1]}) {str[2]} {str[3]}{str[4]}{str[5]}{str[6]}-{str[7]}{str[8]}{str[9]}{str[10]}";

            return telefoneMascarado;
        }
    }
}