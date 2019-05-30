using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : UIScreen
{
	private static GameScreen _instance;
	public static GameScreen instance { get { return _instance; } }
	//
	public Text hintText;

	public override void InitScreen()
	{
		_instance = this;
	}

	public void SetYoursX()
	{
		hintText.text = "ВЫ ИГРАЕТЕ КРЕСТИКАМИ";
	}

	public void SetYoursO()
	{
		hintText.text = "ВЫ ИГРАЕТЕ НОЛИКАМИ";
	}
}
