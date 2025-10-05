using System;
using System.Windows.Markup;
using WpfApp.Utils;

namespace WpfApp.Utils
{
    public class EnumValuesExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumValuesExtension(Type enumType)
        {
            if (enumType == null || !enumType.IsEnum)
                throw new ArgumentException(Constantes.ErroTipoEnum);
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
