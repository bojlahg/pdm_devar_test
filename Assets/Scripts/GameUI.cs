using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	private static GameUI _instance;
	public static GameUI instance { get { return _instance; } }
	//
	public UIScreen curScreen;

	private void Awake()
	{
		_instance = this;
		for(int i = 0; i < transform.childCount; ++i)
		{
			Transform tfm = transform.GetChild(i);
			UIScreen uiscr = tfm.GetComponent<UIScreen>();
			if(uiscr != null)
			{
				uiscr.InitScreen();
				uiscr.gameObject.SetActive(uiscr.startingScreen);
			}
		}
	}

	public void ShowScreen(UIScreen scr)
	{
		if(curScreen != null)
		{
			curScreen.gameObject.SetActive(false);
		}
		curScreen = scr;
		if(curScreen != null)
		{
			curScreen.gameObject.SetActive(true);
		}
	}
}
