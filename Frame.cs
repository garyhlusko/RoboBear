using System;

public class Frame
	{
		public string Path {get;set;}
		public bool IndexBool {get;set;}
		public int Index {get;set;}
		public string Delimiter {get;set;}
		public bool HeaderBool {get; set;}
		public string[] HeadersList {get; set;}
		public Json Rows;

		public Frame(string Path,string Delimiter,bool IndexBool, int Index,bool HeaderBool)
		{
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

class Program{
	static void Main()
	{
		
	}
	
	static Frame read_csv(string path, delimiter=",",Headers=true,index=false)
	{
		Frame f;
		using(var reader = new StreamReader(@"{path}"))
		{
			int i = 0;
			while(!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				var values = line.Split(delimiter);
				
				if(Headers & i == 0){
					for(string column in values){
						f.HeadersList.add(column)
					}
					i+= 1
				}
				if(index){
					f.Rows[line[index]] = {Column:value}
				}			
			}	
		}
		return f;	
	}
}
