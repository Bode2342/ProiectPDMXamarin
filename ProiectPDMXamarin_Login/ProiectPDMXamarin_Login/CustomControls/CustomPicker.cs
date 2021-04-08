using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProiectPDMXamarin_Login.CustomControls
{
    public class CustomPicker: Picker
    {
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(CustomPicker),
        defaultValue: string.Empty);

        public string Placeholder
        {
            get { return (string) GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(string), typeof(CustomPicker), "#CCCCCC", BindingMode.TwoWay);

        public string PlaceholderColor
        {
            get { return (string)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static string DefaultColor => "#CCCCCC";
    }
}
