using System;
using System.IO;

namespace iptv_cleaner
{
    class Program
    {
        public static void Main()
        {
            try
            {
                using (var sr = new StreamReader("list-in.m3u"))
                {
                    string line, substr;
                    string quality = " FHD";
                    bool next = false;
                    StreamWriter sw = new StreamWriter("list-out.m3u");
                    while ((line = sr.ReadLine()) != null)
                    {
                        if(next) 
                        {
                            sw.WriteLine(line);
                            next = false;
                            continue;
                        }
                        substr = line.Substring(line.Length-quality.Length, quality.Length);
                        if(substr == quality)
                        {
                            sw.WriteLine(line);
                            next = true;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
