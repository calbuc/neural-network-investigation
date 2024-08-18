using System;
using System.IO;

namespace Program
{
    internal class MNISTReader
    {
        BigEndianReader ImageReader;
        BigEndianReader LabelReader;
        public int values;
        public int imagesize;

        public MNISTReader(string mode)
        {
            ImageReader = new BigEndianReader(File.Open($"{mode}-images", FileMode.Open));
            ImageReader.ReadBigEndian();
            values = ImageReader.ReadBigEndian();
            imagesize = ImageReader.ReadBigEndian();
            ImageReader.ReadBigEndian();

            LabelReader = new BigEndianReader(File.Open($"{mode}-labels", FileMode.Open));
            LabelReader.ReadBigEndian();
            LabelReader.ReadBigEndian();
        }

        //public void ReadNext()
        //{
        //    currentimage = new double[imagesize,imagesize];
        //    for (int i = 0; i < currentimage.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < currentimage.GetLength(1); j++)
        //        {
        //            currentimage[i,j] = ImageReader.ReadByte();
        //        }
        //    }
        //    currentlabel = LabelReader.ReadByte();
        //}
        public Image ReadNext()
        {
            Image currentimage = new Image();
            currentimage.label = LabelReader.ReadByte();
            currentimage.data = new double[imagesize * imagesize];
            for (int i = 0; i < currentimage.data.Length; i++)
            {
                currentimage.data[i] = ImageReader.ReadByte();
            }
            return currentimage;
        }
        public void Close()
        {
            ImageReader.Close();
            LabelReader.Close();
        }
    }
    internal class BigEndianReader : BinaryReader
    {
        public BigEndianReader(Stream a) : base(a) { }
        public int ReadBigEndian()
        {
            byte[] data = this.ReadBytes(4);
            byte[] num = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                num[i] = data[3 - i];
            }
            return BitConverter.ToInt32(num, 0);
        }
    }
}
