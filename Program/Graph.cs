using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Program
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        public void updategraph(List<double> data)
        {
            double[] points = data.ToArray();
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.AddSignal(points);
            formsPlot1.Refresh();
        }
        public void savegraph(string filename)
        {
            formsPlot1.Plot.SaveFig($"{filename}.png");
        }
    }
}
