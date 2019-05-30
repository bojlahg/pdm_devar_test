using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XOField
{
	public enum CellState
	{
		Empty,  // поле пустое
		Cross,  // крестик
		Circle  // нолик
	}

	public enum Result
	{
		Going,  // игра еще не завершена
		WinX,       // Победа X
		WinO,       // Победа O
		Draw        // Ничья
	}

	private CellState[,] field = new CellState[3, 3]; // состояние игрового поля

	public CellState this[int x, int y]
	{
		get
		{
			return field[x, y];
		}

		set
		{
			field[x, y] = value;
		}
	}

	/*public struct Coords
	{
		public int x, y;
	}*/

	public struct Stat
	{
		public int empty, crosses, circles, empty_x, empty_y; // статистика
		public int this[CellState cs]
		{
			get
			{
				switch(cs)
				{
				case CellState.Empty: return empty;
				case CellState.Cross: return crosses;
				case CellState.Circle: return circles;
				}
				return -1;
			}
		}
	}

	public Stat GetFullStat()
	{
		Stat s = new Stat();
		for(int y = 0; y < 3; ++y)
		{
			for(int x = 0; x < 3; ++x)
			{
				if(field[x, y] == CellState.Cross)
				{
					++s.crosses;
				}
				else if(field[x, y] == CellState.Circle)
				{
					++s.circles;
				}
				else
				{
					++s.empty;
				}
			}
		}
		s.empty_x = -1;
		s.empty_y = -1;
		return s;
	}

	public Stat GetHorizStat(int y)
	{
		//  возвращает кол-во заполненых полей по гоизонтали
		Stat s = new Stat();
		for(int x = 0; x < 3; ++x)
		{
			if(field[x, y] == CellState.Cross)
			{
				++s.crosses;
			}
			else if(field[x, y] == CellState.Circle)
			{
				++s.circles;
			}
			else
			{
				++s.empty;
				s.empty_x = x;
				s.empty_y = y;
			}
		}
		return s;
	}

	public Stat GetVertStat(int x)
	{
		//  возвращает кол-во заполненых полей по вертикали
		Stat s = new Stat();
		for(int y = 0; y < 3; ++y)
		{
			if(field[x, y] == CellState.Cross)
			{
				++s.crosses;
			}
			else if(field[x, y] == CellState.Circle)
			{
				++s.circles;
			}
			else
			{
				++s.empty;
				s.empty_x = x;
				s.empty_y = y;
			}
		}
		return s;
	}

	public Stat GetDiagStat(int idx)
	{
		//  возвращает кол-во заполненых полей по диагонали
		Stat s = new Stat();
		for(int y = 0; y < 3; ++y)
		{
			int x = y;
			if(idx % 2 != 0)
			{
				x = 2 - y;
			}

			if(field[x, y] == CellState.Cross)
			{
				++s.crosses;
			}
			else if(field[x, y] == CellState.Circle)
			{
				++s.circles;
			}
			else
			{
				++s.empty;
				s.empty_x = x;
				s.empty_y = y;
			}
		}

		return s;
	}

	public Result GetResult()
	{
		Stat s;
		// проверяем горизонтали
		for(int y = 0; y < 3; ++y)
		{
			s = GetHorizStat(y);
			if(s.crosses == 3)
			{
				return Result.WinX;
			}
			else if(s.circles == 3)
			{
				return Result.WinO;
			}
		}
		// проверяем вертикали
		for(int x = 0; x < 3; ++x)
		{
			s = GetVertStat(x);
			if(s.crosses == 3)
			{
				return Result.WinX;
			}
			if(s.circles == 3)
			{
				return Result.WinO;
			}
		}
		// проверяем диагонали
		for(int d = 0; d < 2; ++d)
		{
			s = GetDiagStat(d);
			if(s.crosses == 3)
			{
				return Result.WinX;
			}
			if(s.circles == 3)
			{
				return Result.WinO;
			}
		}
		// проверяем закончена ли игра
		s = GetFullStat();
		if(s.empty > 0)
		{
			return Result.Going;
		}
		return Result.Draw;
	}

	public void Clear()
	{
		// Очистка поля
		for(int y = 0; y < 3; ++y)
		{
			for(int x = 0; x < 3; ++x)
			{
				field[x, y] = CellState.Empty;
			}
		}
	}
}