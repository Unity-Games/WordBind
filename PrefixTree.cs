using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTree {
	public class Node {
		const int ALPHABET_SIZE = 26;
		// declaring 26 child nodes
		public Node[] children = new Node[ALPHABET_SIZE];
		// variable to check if at that node a word ends or not
		public bool isEndOfWord;
		// Node constructor
		public Node() {
			isEndOfWord = false;
			// initialsing all child nodes with null value
			for (int i = 0; i < ALPHABET_SIZE; i++)
				children[i]=(null);
		}
	}
	public class PrefixTree {
		public Node root;
		public PrefixTree () {
			root = getNode();
		}

		public Node getNode () {
			return new Node ();
		}

		public void Insert (string key) {
			int level;
			int length = key.Length;
			int i;

			// making a root
			Node pCrawl = root;
			// iterating from the first letter to the last letter
			for (level = 0; level < length; level++) {
				i = key[level] - 'a';
				if (pCrawl.children[i] == null)
					pCrawl.children[i] = getNode();
				pCrawl = pCrawl.children[i];
			}
			pCrawl.isEndOfWord = true;
		}

		public int Search(string key) {
			int level;
			int length = key.Length;
			int i;
			Node pCrawl = root;

			for (level = 0; level < length; level++) {
				i = key[level] - 'a';

				if (pCrawl.children[i] == null)
					return 0;	//Absent
				pCrawl = pCrawl.children[i];
			}
			if (pCrawl != null) {
				if (pCrawl.isEndOfWord == true)
					return 1;	//Present
				return 2;		//Can be completed
			}
			else
				return 0;
		}
	}
}
