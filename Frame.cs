using System;


public class Frame
	{
		public int Index {get; set;};
		public string[] Headers{get; set;};
		public Json Data{get; set;};

		public Frame(int Index, string[] headers, Json Data)
		{
			_Index = Index;
			_Headers = Headers;
			_Data = Data;
		}
		
		public static void Print(){

		}

		//filter column
		public static Frame FilterColumn(string ColumnName,string value)
		{
			Frame return_frame;

		}

		//compare if it's different return true, if it's false reutrn false
		public static Frame Compare(Frame CompareFrame)
		{	

		}

		//diff return Frame of differences
		public static Frame Diff(Frame DiffFrame)
		{

		}


	}

public static Json GetJson(string[] rows, string[] Headers)
{
	Dictionary<string,string> values = new Dictionary <string,string>();
	foreach(string zipped in System.Collections.Generic.IEnumerable<string,string>(rows,Headers);)
	{
		values.add(zipped[0],zipped[1]);
	}
	Json json = JsonConvert.SerializeObject(values);
	return json 
}

class Program{
	static void Main()
	{
		
	}
	
	static Frame read_csv(string path, delimiter=",",Headers=0,index=false)
	{
		Frame f;
		using(var reader = new StreamReader(@"{path}"))
		{
			int i = 0;
			while(!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				var values = line.Split(delimiter);
				
				if(Headers is not None & i == 0){
					for(string column in values){
						f.Headers.add(column);
					}
					i+= 1
				}

				if(index){
					f.Data[line[index]] = GetJson(string[] rows, f.Headers);
				}			
			}	
		}
		return f;	
	}
}
