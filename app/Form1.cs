using BrightIdeasSoftware;
using System.Drawing;
using System.Windows.Forms;

namespace app
{
    public partial class Form1 : Form
    {
        private readonly Model model = new("Test");
        private readonly Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
            olvColumn1.Renderer = new Renderer();

            timer.Tick += Timer_Tick;
            timer.Interval = 5;
            timer.Start();

            objectListView1.AddObject(model);
        }

        private void reloadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            objectListView1.RefreshObject(model);
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            objectListView1.RefreshObject(model);
        }

        public class Model
        {
            public Model(string title)
            {
                Title = title;
            }

            public string Title { get; }
        }

        private class Renderer : BaseRenderer
        {
            public override void Render(Graphics g, Rectangle r)
            {
                DrawBackground(g, r);
                g.DrawString(((Model)RowObject).Title, SystemFonts.DefaultFont, SystemBrushes.ControlText, r);
            }
        }
    }
}