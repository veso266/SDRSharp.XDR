using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDRSharp.XDR.Tools
{
    class CustomToolTip : ToolTip
    {
        Image img;
        public CustomToolTip()
        {
            this.LoadImage(SDRSharp.XDR.Properties.Resources.ResourceManager.GetObject("Wolf"));
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
        }

        public void LoadImage(object ImageResource)
        {
            this.img = (Image)ImageResource;
        }
        public Image LoadImage()
        {
            return this.img;
        }

        private void OnPopup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(LoadImage().Width, LoadImage().Height);
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.DrawImage(img, 0, 0);
            var YourTipTextPoint = new Point(0, 0);
            e.Graphics.DrawString("When wolves imprint only death tears them apart", SystemFonts.DefaultFont, Brushes.White, YourTipTextPoint);
        }
    }
}
