using System;
using System.IO;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //MNISTReader aa = new MNISTReader("train");
            //aa.ReadNext();
            //Console.WriteLine(aa.currentlabel);
            //for (int i = 0; i < 28; i++)
            //{
            //    for (int j = 0; j < 28; j++)
            //    {
            //        if (aa.currentimage[i, j] < 10)
            //        {
            //            Console.Write("00" + aa.currentimage[i, j] + ",");
            //        }
            //        else if (aa.currentimage[i, j] < 100)
            //        {
            //            Console.Write("00" + aa.currentimage[i, j] + ",");
            //        }
            //        else
            //        {
            //            Console.Write(aa.currentimage[i, j] + ",");
            //        }
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadKey();
            //aa.Close();

            //Start of code
            Network current = null;
            while (true)
            {
                bool netloaded = false;
                if (current != null)
                {
                    netloaded = true;
                }
                int choice = Menu(netloaded);
                switch (choice)
                {
                    case 1:
                        current = CreateNetwork(current);
                        break;
                    case 2:
                        current = LoadNetwork(current);
                        break;
                    case 3:
                        SaveNetwork(current);
                        break;
                    case 4:
                        TrainNetwork(current);
                        break;
                    case 5:
                        TestNetwork(current);
                        break;
                    case 6:
                        ViewData(current);
                        break;
                    default:
                        break;
                }
            }

            //testing
            //Console.WriteLine("Test 1a:");
            //new Matrix(new double[,] { { 1, 2 }, { 1, 2 } }).Print();

            //new Matrix(new double[,] { { 1, 2, 3 }, { 1, 2, 3 } }).Print();

            //new Matrix(new double[2, 2], true).Print();
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1b:");
            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //new Matrix(new double[,] { { 1, 2 }, { 5, 0 } }).Print();
            //(new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }) * new Matrix(new double[,] { { 1, 2 }, { 5, 0 } })).Print();
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Tests 1b, 1j:");
            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }).Print();
            //try
            //{
            //    (new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }) * new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } })).Print();
            //}
            //catch (MatrixNonConformableException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1c:");
            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //new Matrix(new double[,] { { 4, 3 }, { 2, 1 } }).Print();
            //(new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }) + new Matrix(new double[,] { { 4, 3 }, { 2, 1 } })).Print();

            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //new Matrix(new double[,] { { 0, 1 }, { 2, 3 } }).Print();
            //(new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }) - new Matrix(new double[,] { { 0, 1 }, { 2, 3 } })).Print();
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1c , 1j:");
            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } }).Print();
            //try
            //{
            //    (new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }) + new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } })).Print();
            //}
            //catch (MatrixNonConformableException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } }).Print();
            //try
            //{
            //    (new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }) - new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } })).Print();
            //}
            //catch (MatrixNonConformableException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1d:");
            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //(2 * new Matrix(new double[,] { { 1, 2 }, { 3, 4 } })).Print();
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1e:");
            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //(~new Matrix(new double[,] { { 1, 2 }, { 3, 4 } })).Print();

            //new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } }).Print();
            //(~new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } })).Print();
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1f:");
            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //Console.WriteLine(Matrix.Det(new Matrix(new double[,] { { 1, 2 }, { 3, 4 } })));

            //new Matrix(new double[,] { { 5, -6 }, { 7, 4 } }).Print();
            //Console.WriteLine(Matrix.Det(new Matrix(new double[,] { { 5, -6 }, { 7, 4 } })));

            //new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } }).Print();
            //try
            //{
            //    Console.WriteLine(Matrix.Det(new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } })));
            //}
            //catch (MatrixNonSquareException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1g:");
            //new Matrix(new double[,] { { 1, -2 }, { 3, 4 } }).Print();
            //Matrix.Sigmoid(new Matrix(new double[,] { { 1, -2 }, { 3, 4 } })).Print();
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1h:");
            //new Matrix(new double[,] { { 1, -2 }, { 3, 4 } }).Print();
            //Matrix.Tanh(new Matrix(new double[,] { { 1, -2 }, { 3, 4 } })).Print();
            //Console.ReadKey();

            //Console.Clear();
            //Console.WriteLine("Test 1i:");
            //new Matrix(new double[,] { { 1, -2 }, { 3, 4 } }).Print();
            //Matrix.ReLU(new Matrix(new double[,] { { 1, -2 }, { 3, 4 } })).Print();
            //Console.ReadKey();

            //imagetests

            //Console.Clear();
            //Console.WriteLine("Test 1f Retest:");
            //new Matrix(new double[,] { { 1, 2 }, { 3, 4 } }).Print();
            //Console.WriteLine(Matrix.Det(new Matrix(new double[,] { { 1, 2 }, { 3, 4 } })));
            //Console.ReadKey();

            //MNISTReader train = new MNISTReader("train");
            //for (int T = 0; T < 5; T++)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Test 3a:");
            //    Console.WriteLine("Training Data");
            //    Image current = train.ReadNext();
            //    Bitmap image = new Bitmap(train.imagesize, train.imagesize);
            //    for (int i = 0; i < train.imagesize; i++)
            //    {
            //        for (int j = 0; j < train.imagesize; j++)
            //        {
            //            image.SetPixel(i, j, Color.FromArgb((int)current.data[i + train.imagesize * j], (int)current.data[i + train.imagesize * j], (int)current.data[i + train.imagesize * j]));
            //        }
            //    }
            //    Console.WriteLine($"Image Label: {current.label}");
            //    Picture display = new Picture(image);
            //    display.ShowDialog();
            //}
            //train.Close();
            //Console.ReadKey();

            //MNISTReader test = new MNISTReader("test");
            //for (int T = 0; T < 5; T++)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Test 3b:");
            //    Console.WriteLine("Test Data");
            //    Image current = test.ReadNext();
            //    Bitmap image = new Bitmap(test.imagesize, test.imagesize);
            //    for (int i = 0; i < test.imagesize; i++)
            //    {
            //        for (int j = 0; j < test.imagesize; j++)
            //        {
            //            image.SetPixel(i, j, Color.FromArgb((int)current.data[i + test.imagesize * j], (int)current.data[i + test.imagesize * j], (int)current.data[i + test.imagesize * j]));
            //        }
            //    }
            //    Console.WriteLine($"Image Label: {current.label}");
            //    Picture display = new Picture(image);
            //    display.ShowDialog();
            //}
            //test.Close();
            //Console.ReadKey();

        }
        static Network CreateNetwork(Network currentnet)
        {
            Console.Clear();
            Console.WriteLine("This will overwrite your currently loaded network");
            Console.WriteLine("Press any key to continue or esc to return to the menu");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return currentnet;
            }
            if (currentnet != null)
            {
                currentnet.Train.Close();
                currentnet.Test.Close();
            }
            Console.Write("How many hidden layers: ");
            int layers = int.Parse(Console.ReadLine());
            int[] LayerSize = new int[layers + 2];
            LayerSize[0] = 28 * 28;
            LayerSize[LayerSize.Length - 1] = 10;
            for (int i = 1; i < LayerSize.Length - 1; i++)
            {
                Console.Write($"Size of hidden layer {i}: ");
                LayerSize[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Which activation function: ");
            string[] Functions = { "Sigmoid", "ReLU", "TanH" };
            for (int i = 0; i < Functions.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Functions[i]}");
            }
            int FunctionVal = int.Parse(Console.ReadLine());
            return new Network(LayerSize, FunctionVal);
        }
        static Network LoadNetwork(Network currentnet)
        {
            Console.Clear();
            Console.WriteLine("This will overwrite your currently loaded network");
            Console.WriteLine("Press any key to continue or esc to return to the menu");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return currentnet;
            }
            if (currentnet != null)
            {
                currentnet.Train.Close();
                currentnet.Test.Close();
            }
            Console.Write("Enter the file name you want to load: ");
            string filename = Console.ReadLine();
            BinaryReader Reader = new BinaryReader(File.Open(filename + ".bin", FileMode.Open));
            int FunctionVal = Reader.ReadInt32();
            int[] LayerSize = new int[Reader.ReadInt32()];
            for (int i = 0; i < LayerSize.Length; i++)
            {
                LayerSize[i] = Reader.ReadInt32();
            }
            Network net = new Network(LayerSize, FunctionVal);
            for (int i = 0; i < net.layers.Length - 1; i++)
            {
                RegLayer current = (RegLayer)net.layers[i];
                double[,] weights = new double[Reader.ReadInt32(), Reader.ReadInt32()];
                for (int j = 0; j < weights.GetLength(0); j++)
                {
                    for (int k = 0; k < weights.GetLength(1); k++)
                    {
                        weights[j, k] = Reader.ReadDouble();
                    }
                }
                current.weights = new Matrix(weights);
                double[,] biases = new double[Reader.ReadInt32(), Reader.ReadInt32()];
                for (int j = 0; j < biases.GetLength(0); j++)
                {
                    for (int k = 0; k < biases.GetLength(1); k++)
                    {
                        biases[j, k] = Reader.ReadDouble();
                    }
                }
                current.biases = new Matrix(biases);
                net.layers[i] = current;
            }
            return net;
        }
        static void SaveNetwork(Network net)
        {
            Console.Clear();
            Console.Write("Enter the file name you want to save the network as: ");
            string filename = Console.ReadLine();
            BinaryWriter Writer = new BinaryWriter(new FileStream(filename + ".bin", FileMode.Create));
            Writer.Write(net.FunctionVal);
            Writer.Write(net.LayerSize.Length);
            foreach (var layer in net.LayerSize)
            {
                Writer.Write(layer);
            }
            for (int i = 0; i < net.layers.Length - 1; i++)
            {
                RegLayer current = (RegLayer)net.layers[i];
                Writer.Write(current.weights.rows);
                Writer.Write(current.weights.columns);
                for (int j = 0; j < current.weights.rows; j++)
                {
                    for (int k = 0; k < current.weights.columns; k++)
                    {
                        Writer.Write(current.weights[j, k]);
                    }
                }
                Writer.Write(current.biases.rows);
                Writer.Write(current.biases.columns);
                for (int j = 0; j < current.biases.rows; j++)
                {
                    for (int k = 0; k < current.biases.columns; k++)
                    {
                        Writer.Write(current.biases[j, k]);
                    }
                }
            }
            Writer.Close();
            Console.Write("Save complete! Press any key to continue ");
            Console.ReadKey();
        }
        static void TrainNetwork(Network current)
        {
            Console.Clear();
            current.train();
        }
        static void TestNetwork(Network current)
        {
            Console.Clear();
            Console.WriteLine("Testing Network");
            Console.WriteLine(current.test() * 100 + "% Accurate");
            Console.ReadKey();
        }
        static void ViewData(Network current)
        {
            //unfinished
            Console.Clear();
            Console.WriteLine($"Number of layers: {current.LayerSize.Length}");
            Console.WriteLine($"Number of hidden layers: {current.LayerSize.Length - 2}");
            for (int i = 0; i < current.LayerSize.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"Size of first layer: {current.LayerSize[i]}");
                }
                else if (i == current.LayerSize.Length - 1)
                {
                    Console.WriteLine($"Size of last layer: {current.LayerSize[i]}");
                }
                else
                {
                    Console.WriteLine($"Size of hidden layer {i}: {current.LayerSize[i]}");
                }
            }
            Console.WriteLine($"Activation Function: {current.Function}");
            Console.ReadKey();
            //Console.WriteLine("1) Network Information");
            //Console.WriteLine("2) Graph Data");
        }
        static int Menu(bool netloaded)
        {
            Console.Clear();
            if (netloaded)
            {
                Console.WriteLine("1) Create Network");
                Console.WriteLine("2) Load Network");
                Console.WriteLine("3) Save Network");
                Console.WriteLine("4) Train Network");
                Console.WriteLine("5) Test Network");
                Console.WriteLine("6) View Data");
                return int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("1) Create Network");
                Console.WriteLine("2) Load Network");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("3) Save Network");
                Console.WriteLine("4) Train Network");
                Console.WriteLine("5) Test Network");
                Console.WriteLine("6) View Data");
                Console.ForegroundColor = ConsoleColor.Gray;
                return int.Parse(Console.ReadLine());
            }
        }
    }
}
