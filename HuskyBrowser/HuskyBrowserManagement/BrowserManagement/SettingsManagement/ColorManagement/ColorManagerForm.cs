using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuskyBrowser.HuskyBrowserManagement.BrowserManagement.SettingsManagement.ColorManagement
{
    public partial class ColorManagerForm : MaterialForm
    {
        Color _BackColor { get; set; } = Color.FromArgb(255, 50, 50, 50);
        public ColorManagerForm()
        {
            InitializeComponent();
            panel1.BackColor = _BackColor;
            panel3.BackColor = _BackColor;
            panel5.BackColor = _BackColor;
            panel7.BackColor = _BackColor;
        }        
        private Color ColorChanger(int[] rgb) 
        {
            Color color = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
            return color;
        }
        private void SliderAccentPrimaryValueChanged(object sender, int newValue)
        {
            panel8.BackColor = ColorChanger(new int[] { materialSlider12.Value, materialSlider11.Value, materialSlider10.Value });
        }
        private void SliderLightPrimaryValueChanged(object sender, int newValue)
        {
            panel6.BackColor = ColorChanger(new int[] { materialSlider9.Value, materialSlider8.Value, materialSlider7.Value });
        }
        private void SliderDarkPrimaryValueChanged(object sender, int newValue)
        {
            panel4.BackColor = ColorChanger(new int[] { materialSlider3.Value, materialSlider2.Value, materialSlider1.Value });
        }
        private void SliderPrimaryValueChanged(object sender, int newValue)
        {
            panel2.BackColor = ColorChanger(new int[] { materialSlider6.Value, materialSlider5.Value, materialSlider4.Value });            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
