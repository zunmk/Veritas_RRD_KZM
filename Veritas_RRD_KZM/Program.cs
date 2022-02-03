using System;
using System.IO; //System.IO #1
using System.Collections.Generic; //Collections.Generic #3
using CsvHelper.Configuration; // #4
using System.Globalization; //#5
using CsvHelper; //#6
using System.Text;

namespace Veritas_RRD_KZM
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Console.Write("#1. Please write the file path repository.\n");
                Console.Write("For example you can try:\n" +
                    "C\\:Location\\MOCK_DATA.csv\n" +
                    "...Onlyone consider a backslash(\\): "); 
                string locationPath;
                locationPath = Console.ReadLine();

                Console.Write("\n");
                Console.Write("#2. Please write the new* file path repository.\n");
                Console.Write("For example you can try to save something like:\n" +
                    "C\\:Location\\MOCK_DATA_newVersion.csv\n" +
                    "C\\:Location\\MOCK_DATA_newVersion.xls\n" +
                    "C\\:Location\\MOCK_DATA_newVersion.txt\n" +
                    "...New Path:");
                string newLocationPath;
                newLocationPath = Console.ReadLine();

                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ",",
                    Comment = '\t',
                    Encoding = Encoding.UTF8,
                    //DetectDelimiter = false,
                    //AllowComments = false,
                };
                
                var csvConfig2 = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ",".Replace(",", "\t"),
                    Comment = '\t',
                    Encoding = Encoding.UTF8,
                    //Delimiter = ",",
                    //DetectDelimiter = false,
                    //AllowComments = false,
                };

                //MOCK_DATA.csv
                var streamReader = File.OpenText(locationPath);
                var csvReader = new CsvReader(streamReader, csvConfig);
                var search_data = csvReader.GetRecords<objectSearch>();
                var newFile = locationPath;

                //New MOCK_DATA_v2.csv | MOCK_DATA_v2.xls | MOCK_DATA_v2.txt
                using (var create_file = new StreamWriter(newLocationPath))
                using (var file = new CsvWriter(create_file, csvConfig2))
                {
                    file.WriteRecords(search_data);
                }//End using var
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }//End catch

        }//End main

        public class objectSearch
        {
            public string Flag1 { get; set; }
            public string Flag2 { get; set; }
            public string Flag3 { get; set; }
            public string Flag4 { get; set; }
            public string Flag5 { get; set; }
            public string Name1 { get; set; }
            public string Address1 { get; set; }
            public string City1 { get; set; }
            public string State1 { get; set; }
            public string Zip1 { get; set; }

            #region All Properties CVS File
            //Flag1,Flag2,Flag3,Flag4,Flag5,Name1,Name2,Name3,Name4,Address1,Address2,Address3,Address4,City1,City2,City3,City4,State1,State2,State3,State4,Zip1,Zip2,Zip3,Zip4
            //public string Flag1 { get; set; }
            //public string Flag2 { get; set; }
            //public string Flag3 { get; set; }
            //public string Flag4 { get; set; }
            //public string Flag5 { get; set; }

            //public string Name1 { get; set; }
            //public string Name2 { get; set; }
            //public string Name3 { get; set; }
            //public string Name4 { get; set; }

            //public string Address1 { get; set; }
            //public string Address2 { get; set; }
            //public string Address3 { get; set; }
            //public string Address4 { get; set; }

            //public string City1 { get; set; }
            //public string City2 { get; set; }
            //public string City3 { get; set; }
            //public string City4 { get; set; }

            //public string State1 { get; set; }
            //public string State2 { get; set; }
            //public string State3 { get; set; }
            //public string State4 { get; set; }

            //public string Zip1 { get; set; }
            //public string Zip2 { get; set; }
            //public string Zip3 { get; set; }
            //public string Zip4 { get; set; }
            #endregion All Properties CVS File
        }//End objectSearch

    }//End class Program
}

