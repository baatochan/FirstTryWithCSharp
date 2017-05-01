using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Selector
{
    string[] Items;

    public Selector(string[] SelectableItems)
	{
        Items = SelectableItems;
	}

    public Selector(List<string> SelectableItems) 
    {
        Items = SelectableItems.ToArray();
    }

    public int Select()
    {
        sel:
        Console.Clear();
        for (int i = 0; i < Items.Length; i++) Console.WriteLine((i + 1).ToString() + ": " + Items[i]);
        Console.WriteLine("0: Koniec");
        Console.Write("> ");
        string userInput = Console.ReadLine();
        int selectedIndex = -1;
        if (!int.TryParse(userInput, out selectedIndex) || selectedIndex > Items.Length || selectedIndex < 0) goto sel;
        return selectedIndex;
    }
}
