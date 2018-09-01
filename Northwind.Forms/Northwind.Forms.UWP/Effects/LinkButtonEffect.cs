using Northwind.Forms.UWP.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("Northwind.Core")]
[assembly: ExportEffect(typeof(LinkButtonEffect), "LinkButtonEffect")]
namespace Northwind.Forms.UWP.Effects {
    public class LinkButtonEffect: PlatformEffect {

        protected override void OnAttached() {
            if(Control is Windows.UI.Xaml.Controls.Button btn)
            {
                btn.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent);
            }
        }

        protected override void OnDetached() {
            
        }

    }
}
