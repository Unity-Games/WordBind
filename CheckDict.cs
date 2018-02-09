using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyTree;

public class CheckDict : MonoBehaviour {

	public InputField inpText;
	public Text showText;
	public TextAsset dictFile;

	private string textToString;

	private List<string> dictList;
	private int dictLen;
	private PrefixTree dictionary;

	void Start () {
		dictList = TextToList (dictFile);
		dictLen = dictList.Count;
		dictionary = new PrefixTree ();
		//dictionary.root = new Node();

		showText.text = dictList[5];
		for (int i = 0; i < 20; i++)
			dictionary.Insert (dictList [i]);
	}

	private List<string> TextToList (TextAsset ts) {
		return new List<string> (ts.text.Split ('\n'));
	}
	public void OnSubmit () {
		textToString = inpText.text.ToString();
		int i = dictionary.Search (textToString);
		showText.text = i.ToString();
//		if (dictList.BinarySearch (textToString) < 0)
//			showText.text = "Word missing from dictionary";
//		else
//			showText.text = textToString;
	}
}
