using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable] 
public class GameConsole : System.Object {

	public Text _gameConsole;
	private string _totalConsoleText;
	private float _startConsoleSize;
	private float _totalConsoleSize;


	public void AppendText(string textToAppend){

		if (textToAppend == ""){
			return;
		}

		_totalConsoleText = _totalConsoleText + "\n" + textToAppend;
		_gameConsole.text = _totalConsoleText;

		_startConsoleSize = _gameConsole.rectTransform.sizeDelta.y;
		_totalConsoleSize = _startConsoleSize;
		_totalConsoleSize += 20;
		_gameConsole.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _totalConsoleSize);
	}

	public void EraseText(){
		_gameConsole.text = "\n";
		_totalConsoleText = _gameConsole.text;
		
		_totalConsoleSize = _startConsoleSize;
		_gameConsole.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _totalConsoleSize);
	}

}
