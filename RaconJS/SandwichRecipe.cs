using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SandwichRecipe : MonoBehaviour
{
	// Start is called before the first frame update
	public struct Item{
		public string id;
		public int cooked;
		public int sliced;
	}
	public Item[] list;
	public enum listItem
	{
		id,
		cooked,
		sliced
	}
	static string[][] recipies = {
		new string[]{"bread", "lettice", "bread"},
		new string[]{"bread", "egg", "bread"},
		new string[]{"bread", "chicken", "lettice", "bread"}
	};
	SandwichRecipe setList(Item[] list){this.list = list;return this;}
	void Start()
	{
		
	}
	// Update is called once per frame
	void Update()
	{
		
	}
}