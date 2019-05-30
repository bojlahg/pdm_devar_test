using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : UIScreen
{
	private static ResultScreen _instance;
	public static ResultScreen instance { get { return _instance; } }
	//
	public Text resultText;

	public override void InitScreen()
	{
		_instance = this;
	}

	public void PlayerWin()
	{
		resultText.text = "ВЫ ВЫИГРАЛИ";
	}

	public void PlayerLoose()
	{
		resultText.text = "ВЫ ПРОИГРАЛИ";
	}

	public void Draw()
	{
		resultText.text = "НИЧЬЯ";
	}

	public void RestartButtonClick()
	{
		Game.instance.Restart();
	}
}
