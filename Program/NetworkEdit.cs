using System;
using System.Collections.Generic;

namespace Program
{
    internal class Network
    {
        public Layer[] layers;
        public int[] LayerSize;
        public string Function;
        public int FunctionVal;
        public MNISTReader Train;
        public MNISTReader Test;

        public Network(int[] LayerSize, int FunctionVal)
        {
            Train = new MNISTReader("train");
            Test = new MNISTReader("test");
            this.FunctionVal = FunctionVal;
            string[] Functions = { "Sigmoid", "ReLU", "TanH" };
            Function = Functions[FunctionVal - 1];

            this.LayerSize = LayerSize;
            layers = new Layer[this.LayerSize.Length];
            for (int i = 0; i < layers.Length; i++)
            {
                if (i == layers.Length - 1)
                {
                    layers[i] = new EndLayer(this.LayerSize[i]);
                }
                else
                {
                    layers[i] = new RegLayer(this.LayerSize[i], this.LayerSize[i + 1]);
                }
            }
        }

        public void train()
        {
            //Console.Write("Enter a name to save this training session as (press enter to skip): ");
            //string filename = Console.ReadLine();
            //StreamWriter sw = null;
            //if (filename != "")
            //{
            //    sw = new StreamWriter($"{filename}.txt",false);
            //}
            Console.Write("Enter a learn rate for this training session: ");
            double learnrate = double.Parse(Console.ReadLine());
            const int batchsize = 100;
            Graph graph = new Graph();
            List<double> datapoints = new List<double>();
            graph.Show();
            graph.BringToFront();
            for (int i = 0; i < 600; i++)
            {
                double output = batch(batchsize, learnrate);
                datapoints.Add(output);
                graph.updategraph(datapoints);
                //sw.Write($"{i}: {output}");
                Console.WriteLine($"{i}: {output}% accurate");
            }
            Train.Close();
            Train = new MNISTReader("train");
            Console.WriteLine("Training Complete");
            graph.Hide();
            graph.ShowDialog();
            Console.Write("Enter a file name to save the graph (leave blank to skip):");
            string filename = Console.ReadLine();
            if (filename != "")
            {
                graph.savegraph(filename);
            }
        }
        public double batch(int batchsize, double learnrate)
        {
            AdjustLayer[] adjusts = new AdjustLayer[layers.Length - 1];
            for (int i = 0; i < adjusts.Length; i++)
            {
                adjusts[i] = new AdjustLayer((RegLayer)layers[i]);
            }
            for (int i = 0; i < batchsize; i++)
            {
                Image currentimage = Train.ReadNext();
                int[] expected = Expected(forwardprop(currentimage), currentimage.label);
                double[][] prevcalc = new double[adjusts.Length][];
                bool[][] calcdone = new bool[adjusts.Length][];
                for (int j = 0; j < adjusts.Length; j++)
                {
                    prevcalc[j] = new double[adjusts[j].weights.rows];
                    calcdone[j] = new bool[adjusts[j].weights.rows];
                }
                //Thread[] tasks = new Thread[adjusts.Length];
                for (int j = adjusts.Length - 1; j >= 0; j--)
                {
                    //j is current adjustment layer
                    //int layer = j;
                    //tasks[j] = new Thread(() => derivativesforlayer(layer, adjusts, expected, prevcalc, calcdone));
                    //tasks[j].Start();
                    derivativesforlayer(j, adjusts, expected, prevcalc, calcdone);
                }
                //foreach (var thread in tasks)
                //{
                //    thread.Join();
                //}
            }
            for (int i = 0; i < layers.Length - 1; i++)
            {
                adjusts[i].weights *= (-learnrate) / batchsize;
                adjusts[i].biases *= (-learnrate) / batchsize;
                ((RegLayer)layers[i]).weights += adjusts[i].weights;
                ((RegLayer)layers[i]).biases += adjusts[i].biases;
            }
            return test() * 100;
        }
        public void derivativesforlayer(int j, AdjustLayer[] adjusts, int[] expected, double[][] prevcalc, bool[][] calcdone)
        {
            for (int k = 0; k < adjusts[j].weights.rows; k++)
            {
                //k is weight/bias row
                for (int l = 0; l < adjusts[j].weights.columns; l++)
                {
                    //l is weight column
                    adjusts[j].weights[k, l] += derivative(adjusts.Length - j, k, l, false, expected, prevcalc, calcdone);
                }
                adjusts[j].biases[k, 0] += derivative(adjusts.Length - j, k, 0, true, expected, prevcalc, calcdone);
            }
        }
        public double derivative(int layerfromlast, int row, int column, bool isbias, int[] expected, double[][] prevcalc, bool[][] calcdone)
        {
            double wholederivative = 0;
            double sumbyvalue = 0;
            double activationbysum = 0;
            double costbyactivation = 0;
            if (isbias)
            {
                sumbyvalue = 1;
            }
            else
            {
                sumbyvalue = (layers[layers.Length - 1 - layerfromlast]).activations[column, 0];
            }
            activationbysum = activationderivative(((RegLayer)layers[layers.Length - 1 - layerfromlast]).weightedsum[row, 0], layerfromlast);

            costbyactivation = Costbyactivation(layerfromlast, row, expected, prevcalc, calcdone);

            wholederivative = sumbyvalue * activationbysum * costbyactivation;
            return wholederivative;
        }
        public double Costbyactivation(int layerfromlast, int row, int[] expected, double[][] prevcalc, bool[][] calcdone)
        {
            if (calcdone[layers.Length - 1 - layerfromlast][row])
            {
                return prevcalc[layers.Length - 1 - layerfromlast][row];
            }
            if (layerfromlast == 1)
            {
                prevcalc[layers.Length - 1 - layerfromlast][row] = 2 * ((layers[layers.Length - 1]).activations[row, 0] - expected[row]);
                calcdone[layers.Length - 1 - layerfromlast][row] = true;
                return prevcalc[layers.Length - 1 - layerfromlast][row];
            }
            else
            {
                double total = 0;
                for (int j = 0; j < layers[layers.Length - layerfromlast + 1].activations.rows; j++)
                {
                    total += ((RegLayer)layers[layers.Length - 1 - layerfromlast]).weights[j, row] * activationderivative(((RegLayer)layers[layers.Length - 1 - layerfromlast]).weightedsum[j, 0], layerfromlast) * Costbyactivation(layerfromlast - 1, j, expected, prevcalc, calcdone);
                }
                prevcalc[layers.Length - 1 - layerfromlast][row] = total;
                calcdone[layers.Length - 1 - layerfromlast][row] = true;
                return total;
            }
        }
        public double activationderivative(double z, int layerfromlast)
        {
            switch (FunctionVal)
            {
                case 1:
                    //sigmoid
                    return (1 / (1 + Math.Exp(-z))) * (1 - (1 / (1 + Math.Exp(-z))));
                case 2:
                    //relu
                    if (layerfromlast == 1)
                    {
                        return (1 / (1 + Math.Exp(-z))) * (1 - (1 / (1 + Math.Exp(-z))));
                    }
                    else
                    {
                        if (z > 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                case 3:
                    //tanh
                    if (layerfromlast == 1)
                    {
                        return (1 / (1 + Math.Exp(-z))) * (1 - (1 / (1 + Math.Exp(-z))));
                    }
                    else
                    {
                        return 1 - (Math.Tanh(z) * Math.Tanh(z));
                    }
                default:
                    return 0;
            }

        }
        public int[] Expected(Matrix result, int label)
        {
            int[] expected = new int[result.rows];
            for (int i = 0; i < expected.Length; i++)
            {
                if (i == label)
                {
                    expected[i] = 1;
                }
                else
                {
                    expected[i] = 0;
                }
            }
            return expected;
        }
        public double test()
        {
            double correct = 0;
            Image currentimage;
            for (int i = 0; i < Test.values; i++)
            {
                currentimage = Test.ReadNext();
                Matrix result = forwardprop(currentimage);
                double largest = result[0, 0];
                int index = 0;
                for (int j = 1; j < result.rows; j++)
                {
                    if (result[j, 0] > largest)
                    {
                        largest = result[j, 0];
                        index = j;
                    }
                }
                if (index == currentimage.label)
                {
                    correct++;
                }
            }
            Test.Close();
            Test = new MNISTReader("test");
            return correct / Test.values;
        }
        public Matrix forwardprop(Image image)
        {
            for (int j = 0; j < layers[0].activations.rows; j++)
            {
                layers[0].activations[j, 0] = image.data[j];
            }
            for (int j = 0; j < layers.Length - 1; j++)
            {
                Matrix weights = ((RegLayer)layers[j]).weights;
                Matrix activations = ((RegLayer)layers[j]).activations;
                Matrix biases = ((RegLayer)layers[j]).biases;
                ((RegLayer)layers[j]).weightedsum = (weights * activations) + biases;
                switch (FunctionVal)
                {
                    case 1:
                        layers[j + 1].activations = Matrix.Sigmoid(((RegLayer)layers[j]).weightedsum);
                        break;
                    case 2:
                        if (j == layers.Length - 2)
                        {
                            layers[j + 1].activations = Matrix.Sigmoid(((RegLayer)layers[j]).weightedsum);
                        }
                        else
                        {
                            layers[j + 1].activations = Matrix.ReLU(((RegLayer)layers[j]).weightedsum);
                        }
                        break;
                    case 3:
                        layers[j + 1].activations = Matrix.Tanh(((RegLayer)layers[j]).weightedsum);
                        break;
                }
            }
            return layers[layers.Length - 1].activations;
        }

    }
    abstract class Layer
    {
        public Matrix activations;
    }
    class RegLayer : Layer
    {
        public Matrix weights;
        public Matrix biases;
        public Matrix weightedsum;
        public RegLayer(int size, int nextsize)
        {
            weights = new Matrix(new double[nextsize, size], true);
            biases = new Matrix(new double[nextsize, 1]);
            weightedsum = new Matrix(new double[size, 1]);
            activations = new Matrix(new double[size, 1]);
        }
    }
    class EndLayer : Layer
    {
        public EndLayer(int size)
        {
            activations = new Matrix(new double[size, 1]);
        }
    }
    class AdjustLayer
    {
        public Matrix weights;
        public Matrix biases;
        public AdjustLayer(RegLayer layer)
        {
            weights = new Matrix(new double[layer.weights.rows, layer.weights.columns]);
            biases = new Matrix(new double[layer.biases.rows, layer.biases.columns]);
        }

    }
}
