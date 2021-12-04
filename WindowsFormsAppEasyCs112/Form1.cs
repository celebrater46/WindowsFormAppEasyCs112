using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs112
{
    public partial class Form1 : Form
    {
        private TextBox tb;
        private WebBrowser wb;
        private ToolStrip ts;
        private ToolStripButton[] tsb = new ToolStripButton[2];
        
        // [STAThread]
        public Form1()
        {
            InitializeComponent();
            this.Text = "Show WEB";
            this.Width = 600;
            this.Height = 400;

            tb = new TextBox();
            tb.Text = "http://";
            tb.Dock = DockStyle.Top;

            wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;

            ts = new ToolStrip();
            ts.Dock = DockStyle.Top;

            for (int i = 0; i < tsb.Length; i++)
            {
                tsb[i] = new ToolStripButton();
            }

            tsb[0].Text = "Go";
            tsb[1].Text = "<-";

            tsb[0].ToolTipText = "Move";
            tsb[1].ToolTipText = "Back";

            tsb[1].Enabled = false;

            for (int i = 0; i < tsb.Length; i++)
            {
                ts.Items.Add(tsb[i]);
            }

            tb.Parent = this;
            wb.Parent = this;
            ts.Parent = this;

            for (int i = 0; i < tsb.Length; i++)
            {
                tsb[i].Click += new EventHandler(BtClick);
            }

            wb.CanGoBackChanged += new EventHandler(WbCanGoBackChanged);
        }

        public void BtClick(Object sender, EventArgs e)
        {
            if (sender == tsb[0])
            {
                try
                {
                    Uri uri = new Uri(tb.Text);
                    wb.Url = uri;
                }
                catch
                {
                    MessageBox.Show("Input URL")
                }
            }
        }
    }
}