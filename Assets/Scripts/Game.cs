using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
	private enum State
	{
		Input,	// Ожидаем ввода от игрока/CPU
		Animation,		// Анимация появления фишки
		Results, // Показываем результат
	}

	private static Game _instance;
	public static Game instance { get { return _instance; } }
	//
	public GameObject	xPrefab, oPrefab; // префабы фишек
	//
	private GameObject[] xPool, oPool; // Пул объектов
	private XOField field = new XOField(); // Игровое поле
	private State gameState = State.Input; // состояние игры
	private float animTimer = 0; // таймер для анимации
	private bool gameOrder = false, // очередность игры, Игрок первый ходит = false, CPU первый ходит = true
				turnOrder = false; // очередность хода, Игрок = false, CPU = true
	private int xPoolIdx = 0, oPoolIdx = 0, // Количество использованых объектов из пула
				turnNum = 0;
	private GameObject animObj; // Анимируемый объект

	private void Awake()
	{
		_instance = this;

		// Создаем пул фишек, оптимизация типа ;)
		xPool = new GameObject[5];
		oPool = new GameObject[5];
		for(int i = 0; i < xPool.Length; ++i)
		{
			GameObject newgo = (GameObject)GameObject.Instantiate(xPrefab, Vector3.zero, Quaternion.identity, transform);
			newgo.SetActive(false);
			xPool[i] = newgo;
		}
		for(int i = 0; i < oPool.Length; ++i)
		{
			GameObject newgo = (GameObject)GameObject.Instantiate(oPrefab, Vector3.zero, Quaternion.identity, transform);
			newgo.SetActive(false);
			oPool[i] = newgo;
		}

		GameScreen.instance.SetYoursX();
	}

	private void Cleanup()
	{
		// Очистка поля
		field.Clear();
		// Скрытие объектов из пула
		for(int i = 0; i < xPool.Length; ++i)
		{
			xPool[i].SetActive(false);
		}
		for(int i = 0; i < oPool.Length; ++i)
		{
			oPool[i].SetActive(false);
		}
		xPoolIdx = 0;
		oPoolIdx = 0;
	}

	public void Restart()
	{
		if(gameState == State.Results)
		{
			Cleanup();
			gameState = State.Input;
			gameOrder = !gameOrder; // меняем очередь игры
			turnOrder = gameOrder;
			turnNum = 0;
			GameUI.instance.ShowScreen(GameScreen.instance);
			if(gameOrder)
			{
				GameScreen.instance.SetYoursO();
			}
			else
			{
				GameScreen.instance.SetYoursX();
			}
		}
	}

	private void CPU_RandomPick()
	{
		// Рандомный выбор
		bool picked = false;
		while(!picked)
		{
			int pickIdx = Random.Range(0, 9); // выберем рандомный индекс
			int x = pickIdx % 3, y = pickIdx / 3; // преобразуем в координаты
			if(field[x, y] == XOField.CellState.Empty) // проверим можно ли туда сходить
			{
				picked = true;
				//
				PlaceChip(!gameOrder, x, y);
			}
		}
	}

	private void CPU_AIPick()
	{
		if(gameOrder && turnNum == 0)
		{
			// Если начало хода играем за X
			PlaceChip(!gameOrder, 1, 1);
		}
		else
		{
			XOField.CellState cpucs = XOField.CellState.Empty;
			XOField.CellState plrcs = XOField.CellState.Empty;
			if(gameOrder)
			{
				cpucs = XOField.CellState.Cross;
				plrcs = XOField.CellState.Circle;
			}
			else
			{
				cpucs = XOField.CellState.Circle;
				plrcs = XOField.CellState.Cross;
			}
			// Проверка мгновенного выигрыша
			XOField.Stat s;
			// горизонталь
			for(int y = 0; y < 3; ++y)
			{
				s = field.GetHorizStat(y);
				if(s[cpucs] == 2 && s[XOField.CellState.Empty] == 1)
				{
					PlaceChip(!gameOrder, s.empty_x, s.empty_y);
					return;
				}
			}
			// вертикаль
			for(int x = 0; x < 3; ++x)
			{
				s = field.GetVertStat(x);
				if(s[cpucs] == 2 && s[XOField.CellState.Empty] == 1)
				{
					PlaceChip(!gameOrder, s.empty_x, s.empty_y);
					return;
				}
			}
			// диагонали
			for(int d = 0; d < 2; ++d)
			{
				s = field.GetDiagStat(d);
				if(s[cpucs] == 2 && s[XOField.CellState.Empty] == 1)
				{
					PlaceChip(!gameOrder, s.empty_x, s.empty_y);
					return;
				}
			}
			// Если можно предотвратить проигрыш
			// горизонталь
			for(int y = 0; y < 3; ++y)
			{
				s = field.GetHorizStat(y);
				if(s[plrcs] == 2 && s[XOField.CellState.Empty] == 1)
				{
					PlaceChip(!gameOrder, s.empty_x, s.empty_y);
					return;
				}
			}
			// вертикаль
			for(int x = 0; x < 3; ++x)
			{
				s = field.GetVertStat(x);
				if(s[plrcs] == 2 && s[XOField.CellState.Empty] == 1)
				{
					PlaceChip(!gameOrder, s.empty_x, s.empty_y);
					return;
				}
			}
			// диагонали
			for(int d = 0; d < 2; ++d)
			{
				s = field.GetDiagStat(d);
				if(s[plrcs] == 2 && s[XOField.CellState.Empty] == 1)
				{
					PlaceChip(!gameOrder, s.empty_x, s.empty_y);
					return;
				}
			}
			// Если больше нечего делать то ткнем рандомно
			CPU_RandomPick();
		}
	}

	private void Update()
	{
		switch(gameState)
		{
		case State.Input:
			if(turnOrder)
			{
				// ход CPU
				//CPU_RandomPick();
				CPU_AIPick();
			}
			else
			{
				// ход игрока
			}
			break;

		case State.Animation:
			animTimer += Time.deltaTime;
			if(animTimer >= 0.5f)	//  анимация (0.5сек)
			{
				// конец анимации
				animObj.transform.localScale = Vector3.one;
				

				// проверка конца игры
				XOField.Result rslt = field.GetResult();
				if(rslt == XOField.Result.Going)
				{
					// меняем ход игрок/CPU
					turnOrder = !turnOrder;
					gameState = State.Input;
				}
				else
				{
					if(rslt == XOField.Result.Draw)
					{
						ResultScreen.instance.Draw();
					}
					else if(rslt == XOField.Result.WinO)
					{
						if(gameOrder && !turnOrder)
						{
							ResultScreen.instance.PlayerWin();
						}
						else
						{
							ResultScreen.instance.PlayerLoose();
						}
					}
					else if(rslt == XOField.Result.WinX)
					{
						if(!gameOrder && !turnOrder)
						{
							ResultScreen.instance.PlayerWin();
						}
						else
						{
							ResultScreen.instance.PlayerLoose();
						}
					}
					GameUI.instance.ShowScreen(ResultScreen.instance);

					gameState = State.Results;
				}
			}
			else
			{
				// анимируем появление
				animObj.transform.localScale = Ease.EaseByType(Ease.Easing.InBounce, Vector3.zero, Vector3.one, animTimer * 2);
			}
			
			break;

		case State.Results:
			break;
		}
	}

	private GameObject GetPoolObject(bool chip)
	{
		GameObject retval = null;
		if(chip)
		{
			if(oPoolIdx >= oPool.Length)
			{
				Debug.LogError("Что-то сломалось, хотя и не должно было");
				throw (new System.Exception("oPool: no more objects"));
			}
			retval = oPool[oPoolIdx];
			++oPoolIdx;
		}
		else
		{
			if(xPoolIdx >= xPool.Length)
			{
				Debug.LogError("Что-то сломалось, хотя и не должно было");
				throw (new System.Exception("xPool: no more objects"));
			}
			retval = xPool[xPoolIdx];
			++xPoolIdx;
		}
		return retval;
	}

	private void PlaceChip(bool chip, int x, int y)
	{
		// достанем объект из пула и используем его
		animObj = GetPoolObject(chip);
		animObj.transform.localPosition = new Vector3(-1f + x, 0, -1f + y);
		animObj.transform.localScale = Vector3.zero;
		animObj.SetActive(true);

		field[x, y] = chip ? XOField.CellState.Circle : XOField.CellState.Cross; // запишем в поле

		++turnNum;
		// уйдем в состояние анимации
		animTimer = 0;
		gameState = State.Animation;
		
	}

	public void PointerDown(BaseEventData bed)
	{
		if(bed is PointerEventData)
		{
			PointerEventData ped = (PointerEventData)bed;
			if(gameState == State.Input && !turnOrder ) // Ожидаем ввод и ход игрока
			{
				Vector3 wpos = ped.pointerCurrentRaycast.worldPosition + new Vector3(1.5f, 0, 1.5f); // корректируем координаты
				int x = Mathf.FloorToInt(wpos.x), y = Mathf.FloorToInt(wpos.z); // целочисленные координаты ячейки

				if(x >= 0 && x <= 2 && y >= 0 && y <= 2) // проверка координат
				{
					PlaceChip(gameOrder, x, y);
				}
			}
		}
	}
}
