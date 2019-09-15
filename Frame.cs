using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft;
using System.Linq;
using Newtonsoft.Json;

class Frame
	{
        private int Index;
        private List<string> Headers;
        private string Data;

		public Frame(int Index, List<string> Headers, string Data)
		{
			this.Index = Index;
			this.Headers = Headers;
			this.Data = Data;
		}
		
		public void Print()
        {
            foreach(string header in Headers)
            {
                Console.Write(header + "\t");
            }
		}

		//filter column
		public void FilterColumn( string ColumnName, string Value)
		{
            Frame ReturnFrame;
		}

		//compare if it's different return true, if it's false reutrn false
		public Frame Compare(Frame CompareFrame)
		{
            Frame ReturnFrame = CompareFrame;
            return ReturnFrame;
		}

		//diff return Frame of differences
		public Frame Diff(Frame DiffFrame)
		{
            Frame ReturnFrame = DiffFrame;
            return ReturnFrame;
		}


	}


class Program{
	static void Main()
	{
        Console.WriteLine("Entering Path");
        Frame df = read_csv("C:\\Users\\garyh\\Desktop\\test_csv.csv");
        Console.WriteLine(df);
        df.Print();
        Console.ReadLine();
	}
	
	static Frame read_csv(string Path, char Delimiter=',', Nullable<int> Headers=0, Nullable<int> Index=0)
	{
		Frame F;
        List<string> HeaderData = new List<string>();
        Dictionary<string,string> Data = new Dictionary<string,string>();

        string result = System.IO.Path.GetFullPath(Path);

        Console.ReadLine();
		using(var reader = new StreamReader(result))
		{
			int i = 0;
			while(!reader.EndOfStream)
			{
                int LineNumber = 0;
				var line = reader.ReadLine();
				var values = line.Split(Delimiter);
				
				if(Headers != null & i.Equals(Headers)){
					foreach(string column in values){
						HeaderData.Add(column);
					}
                    i += 1;
				}
                if(Headers == null & i.Equals(0))
                {
                    int j = 0;
                    foreach(string column in values)
                    {
                        HeaderData.Add(j.ToString());
                    }
                }

				if(Index.HasValue){
					Data[values[Index.Value]] = GetJson(values, HeaderData);
				}

                if(Index == null)
                {
                    Data[LineNumber.ToString()] = GetJson(values, HeaderData);
                    LineNumber += 1;
                }
			}	
		}

        string DataJson = JsonConvert.SerializeObject(Data);
        F = new Frame(Index.Value, HeaderData, DataJson);
		return F;	
	}


    public static string GetJson(string[] Rows, List<string> Headers)
    {

        Dictionary<string, string> values = new Dictionary<string, string>();
        var zipHeadersAndRow = Headers.Zip(Rows, (h, r) => new { Header = h, Row = r });
        foreach (var zipped in zipHeadersAndRow)
        {
            string key = zipped.Header;
            string value = zipped.Row;
            values.Add(key, value);
        }

        string json = JsonConvert.SerializeObject(values);
        return json;
    }
}
