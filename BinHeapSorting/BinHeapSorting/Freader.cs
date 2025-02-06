using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeapSorting
{
    public class Freader
    {
        public static int[] Read(string fname)
        {
            List<int> listRead = new List<int>();
            try
            {
                using (StreamReader reader = new StreamReader(fname))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        foreach (string str in values)
                        {
                            if (!string.IsNullOrWhiteSpace(str))
                            {
                                listRead.Add(int.Parse(str.Trim()));
                            }
                        }
                    }
                }
            }
            catch (IOException)
            {
                throw new Exception("Error reading the file.");
            }
            return listRead.ToArray();
        }
    }
}
