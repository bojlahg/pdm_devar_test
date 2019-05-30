using UnityEngine;
using System.Collections;

public static class Ease
{
	public enum Easing
	{
		Linear = 0,

		InQuad = 1,
		OutQuad = 2,
		InOutQuad = 3,
		OutInQuad = 4,

		InCubic = 5,
		OutCubic = 6,
		InOutCubic = 7,
		OutInCubic = 8,

		InQuart = 9,
		OutQuart = 10,
		InOutQuart = 11,
		OutInQuart = 12,

		InQuint = 13,
		OutQuint = 14,
		InOutQuint = 15,
		OutInQuint = 16,

		InSin = 17,
		OutSin = 18,
		InOutSin = 19,
		OutInSin = 20,

		InExp = 21,
		OutExp = 22,
		InOutExp = 23,
		OutInExp = 24,

		InCirc = 25,
		OutCirc = 26,
		InOutCirc = 27,
		OutInCirc = 28,

		InElastic = 29,
		OutElastic = 30,
		InOutElastic = 31,
		OutInElastic = 32,

		InBounce = 33,
		OutBounce = 34,
		InOutBounce = 35,
		OutInBounce = 36,

		InBack = 37,
		OutBack = 38,
		InOutBack = 39,
		OutInBack = 40
	}

	public delegate T EaseFunc<T>(T start, T end, float t);

	private static readonly EaseFunc<float>[] FloatFuncs = new EaseFunc<float>[] {
		Linear,
		InQuad, OutQuad, InOutQuad, OutInQuad,
		InCubic, OutCubic, InOutCubic, OutInCubic,
		InQuart, OutQuart, InOutQuart, OutInQuart,
		InQuint, OutQuint, InOutQuint, OutInQuint,
		InSin, OutSin, InOutSin, OutInSin,
		InExp, OutExp, InOutExp, OutInExp,
		InCirc, OutCirc, InOutCirc, OutInCirc,
		InElastic, OutElastic, InOutElastic, OutInElastic,
		InBounce, OutBounce, InOutBounce, OutInBounce,
		InBack, OutBack, InOutBack, OutInBack };

	private static readonly EaseFunc<Vector2>[] Vector2Funcs = new EaseFunc<Vector2>[] {
		Linear,
		InQuad, OutQuad, InOutQuad, OutInQuad,
		InCubic, OutCubic, InOutCubic, OutInCubic,
		InQuart, OutQuart, InOutQuart, OutInQuart,
		InQuint, OutQuint, InOutQuint, OutInQuint,
		InSin, OutSin, InOutSin, OutInSin,
		InExp, OutExp, InOutExp, OutInExp,
		InCirc, OutCirc, InOutCirc, OutInCirc,
		InElastic, OutElastic, InOutElastic, OutInElastic,
		InBounce, OutBounce, InOutBounce, OutInBounce,
		InBack, OutBack, InOutBack, OutInBack };

	private static readonly EaseFunc<Vector3>[] Vector3Funcs = new EaseFunc<Vector3>[] {
		Linear,
		InQuad, OutQuad, InOutQuad, OutInQuad,
		InCubic, OutCubic, InOutCubic, OutInCubic,
		InQuart, OutQuart, InOutQuart, OutInQuart,
		InQuint, OutQuint, InOutQuint, OutInQuint,
		InSin, OutSin, InOutSin, OutInSin,
		InExp, OutExp, InOutExp, OutInExp,
		InCirc, OutCirc, InOutCirc, OutInCirc,
		InElastic, OutElastic, InOutElastic, OutInElastic,
		InBounce, OutBounce, InOutBounce, OutInBounce,
		InBack, OutBack, InOutBack, OutInBack };

	private static readonly EaseFunc<Quaternion>[] QuaternionFuncs = new EaseFunc<Quaternion>[] {
		Linear,
		InQuad, OutQuad, InOutQuad, OutInQuad,
		InCubic, OutCubic, InOutCubic, OutInCubic,
		InQuart, OutQuart, InOutQuart, OutInQuart,
		InQuint, OutQuint, InOutQuint, OutInQuint,
		InSin, OutSin, InOutSin, OutInSin,
		InExp, OutExp, InOutExp, OutInExp,
		InCirc, OutCirc, InOutCirc, OutInCirc,
		InElastic, OutElastic, InOutElastic, OutInElastic,
		InBounce, OutBounce, InOutBounce, OutInBounce,
		InBack, OutBack, InOutBack, OutInBack };

	private static readonly EaseFunc<Color>[] ColorFuncs = new EaseFunc<Color>[] {
		Linear,
		InQuad, OutQuad, InOutQuad, OutInQuad,
		InCubic, OutCubic, InOutCubic, OutInCubic,
		InQuart, OutQuart, InOutQuart, OutInQuart,
		InQuint, OutQuint, InOutQuint, OutInQuint,
		InSin, OutSin, InOutSin, OutInSin,
		InExp, OutExp, InOutExp, OutInExp,
		InCirc, OutCirc, InOutCirc, OutInCirc,
		InElastic, OutElastic, InOutElastic, OutInElastic,
		InBounce, OutBounce, InOutBounce, OutInBounce,
		InBack, OutBack, InOutBack, OutInBack };

	public static float EaseByType(Easing e, float start, float end, float t)
	{
		return FloatFuncs[(int)e](start, end, t);
	}

	public static float Linear(float start, float end, float t)
	{
		return t * (end - start) + start;
	}

	public static float InQuad(float start, float end, float t)
	{
		return t * t * (end - start) + start;
	}

	public static float OutQuad(float start, float end, float t)
	{
		return -(t * (t - 2)) * (end - start) + start;
	}

	public static float InOutQuad(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * (end - start) + start;
		}
		else
		{
			--t;
			return -0.5f * (t * (t - 2) - 1) * (end - start) + start;
		}
	}

	public static float OutInQuad(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (-0.5f * (t * (t - 2) - 1) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static float InCubic(float start, float end, float t)
	{
		return t * t * t * (end - start) + start;
	}

	public static float OutCubic(float start, float end, float t)
	{
		--t;
		return (t * t * t + 1) * (end - start) + start;
	}

	public static float InOutCubic(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * t * (end - start) + start;
		}
		else
		{
			t -= 2;
			return 0.5f * (t * t * t + 2) * (end - start) + start;
		}
	}

	public static float OutInCubic(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * (t * t * t + 2) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static float InQuart(float start, float end, float t)
	{
		return t * t * t * t * (end - start) + start;
	}

	public static float OutQuart(float start, float end, float t)
	{
		--t;
		return -(t * t * t * t - 1) * (end - start) + start;
	}

	public static float InOutQuart(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * t * t * (end - start) + start;
		}
		else
		{
			t -= 2;
			return -0.5f * (t * t * t * t - 2) * (end - start) + start;
		}
	}

	public static float OutInQuart(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (-0.5f * t * t * t * t + 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static float InQuint(float start, float end, float t)
	{
		return t * t * t * t * t * (end - start) + start;
	}

	public static float OutQuint(float start, float end, float t)
	{
		--t;
		return (t * t * t * t * t + 1) * (end - start) + start;
	}

	public static float InOutQuint(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * t * t * t * t * t) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (0.5f * t * t * t * t * t + 1) * (end - start) + start;
		}
	}

	public static float OutInQuint(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * (t * t * t * t * t) + 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static float InSin(float start, float end, float t)
	{
		return -Mathf.Cos(t * Mathf.PI * 0.5f) * (end - start) + end;
	}

	public static float OutSin(float start, float end, float t)
	{
		return Mathf.Sin(t * Mathf.PI * 0.5f) * (end - start) + start;
	}

	public static float InOutSin(float start, float end, float t)
	{
		return (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f) * (end - start) + start;
	}

	public static float OutInSin(float start, float end, float t)
	{
		return (t - (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f - t)) * (end - start) + start;
	}

	public static float InExp(float start, float end, float t)
	{
		return Mathf.Pow(2, 10 * (t - 1)) * (end - start) + start;
	}

	public static float OutExp(float start, float end, float t)
	{
		return (1 - Mathf.Pow(2, -10 * t)) * (end - start) + start;
	}

	public static float InOutExp(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * Mathf.Pow(2, 10 * (t - 1)) * (end - start) + start;
		}
		else
		{
			--t;
			return 0.5f * (2 - Mathf.Pow(2, -10 * t)) * (end - start) + start;
		}
	}

	public static float OutInExp(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * (2 - Mathf.Pow(2, -10 * t)) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * Mathf.Pow(2, 10 * (t - 1)) + 0.5f) * (end - start) + start;
		}
	}

	public static float InCirc(float start, float end, float t)
	{
		return -(Mathf.Sqrt(1 - t * t) - 1) * (end - start) + start;
	}

	public static float OutCirc(float start, float end, float t)
	{
		--t;
		return Mathf.Sqrt(1 - t * t) * (end - start) + start;
	}

	public static float InOutCirc(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (-0.5f * (Mathf.Sqrt(1 - t * t) - 1)) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (0.5f * (Mathf.Sqrt(1 - t * t) + 1)) * (end - start) + start;
		}
	}

	public static float OutInCirc(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * Mathf.Sqrt(1 - t * t)) * (end - start) + start;
		}
		else
		{
			--t;
			return (-0.5f * Mathf.Sqrt(1 - t * t) + 1) * (end - start) + start;
		}
	}

	public static float InElastic(float start, float end, float t)
	{
		float p = 0.3f, s = 0.075f;
		--t;
		return (-Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + start;
	}

	public static float OutElastic(float start, float end, float t)
	{
		float p = 0.3f, s = 0.075f;
		return (Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + end;
	}

	public static float InOutElastic(float start, float end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			--t;
			return (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + end;
		}
	}

	public static float OutInElastic(float start, float end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			return (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) - 0.5f) * (end - start) + end;
		}
		else
		{
			t -= 2;
			return (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) + 0.5f) * (end - start) + start;
		}
	}

	public static float InBounce(float start, float end, float t)
	{

		t = 1 - t;
		if(t < 1 / 2.75f)
		{
			return (-7.5625f * t * t + 1) * (end - start) + start;
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return (-7.5625f * t * t - 0.75f + 1) * (end - start) + start;
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return (-7.5625f * t * t - 0.9375f + 1) * (end - start) + start;
		}
		else
		{
			t -= 2.625f / 2.75f;
			return (-7.5625f * t * t - 0.984375f + 1) * (end - start) + start;
		}
	}

	public static float OutBounce(float start, float end, float t)
	{

		if(t < 1 / 2.75f)
		{
			return (7.5625f * t * t) * (end - start) + start;
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return (7.5625f * t * t + 0.75f) * (end - start) + start;
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return (7.5625f * t * t + 0.9375f) * (end - start) + start;
		}
		else
		{
			t -= 2.625f / 2.75f;
			return (7.5625f * t * t + 0.984375f) * (end - start) + start;
		}
	}

	public static float InOutBounce(float start, float end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			t = 1 - t;
			if(t < 1 / 2.75f)
			{
				return (-0.5f * 7.5625f * t * t + 0.5f) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.75f) + 0.5f) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.9375f) + 0.5f) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.984375f) + 0.5f) * (end - start) + start;
			}
		}
		else
		{
			--t;
			if(t < 1 / 2.75f)
			{
				return (0.5f * 7.5625f * t * t + 0.5f) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.75f) + 0.5f) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.9375f) + 0.5f) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.984375f) + 0.5f) * (end - start) + start;
			}
		}
	}

	public static float OutInBounce(float start, float end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			if(t < 1 / 2.75f)
			{
				return (0.5f * 7.5625f * t * t) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.75f)) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.9375f)) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.984375f)) * (end - start) + start;
			}
		}
		else
		{
			t = 2 - t;
			if(t < 1 / 2.75f)
			{
				return (-0.5f * 7.5625f * t * t + 1) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.75f) + 1) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.9375f) + 1) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.984375f) + 1) * (end - start) + start;
			}
		}
	}

	public static float InBack(float start, float end, float t)
	{
		return t * t * (2.70158f * t - 1.70158f) * (end - start) + start;
	}

	public static float OutBack(float start, float end, float t)
	{
		--t;
		return (1 - t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
	}

	public static float InOutBack(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * t * t * (2.70158f * t - 1.70158f)) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (1 - 0.5f * t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
		}
	}

	public static float OutInBack(float start, float end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f - 0.5f * t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * (2.70158f * t - 1.70158f) + 0.5f) * (end - start) + start;
		}
	}

	public static Vector2 EaseByType(Easing e, Vector2 start, Vector2 end, float t)
	{
		return Vector2Funcs[(int)e](start, end, t);
	}

	public static Vector2 Linear(Vector2 start, Vector2 end, float t)
	{
		return t * (end - start) + start;
	}

	public static Vector2 InQuad(Vector2 start, Vector2 end, float t)
	{
		return t * t * (end - start) + start;
	}

	public static Vector2 OutQuad(Vector2 start, Vector2 end, float t)
	{
		return -(t * (t - 2)) * (end - start) + start;
	}

	public static Vector2 InOutQuad(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * (end - start) + start;
		}
		else
		{
			--t;
			return -0.5f * (t * (t - 2) - 1) * (end - start) + start;
		}
	}

	public static Vector2 OutInQuad(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (-0.5f * (t * (t - 2) - 1) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Vector2 InCubic(Vector2 start, Vector2 end, float t)
	{
		return t * t * t * (end - start) + start;
	}

	public static Vector2 OutCubic(Vector2 start, Vector2 end, float t)
	{
		--t;
		return (t * t * t + 1) * (end - start) + start;
	}

	public static Vector2 InOutCubic(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * t * (end - start) + start;
		}
		else
		{
			t -= 2;
			return 0.5f * (t * t * t + 2) * (end - start) + start;
		}
	}

	public static Vector2 OutInCubic(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * (t * t * t + 2) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Vector2 InQuart(Vector2 start, Vector2 end, float t)
	{
		return t * t * t * t * (end - start) + start;
	}

	public static Vector2 OutQuart(Vector2 start, Vector2 end, float t)
	{
		--t;
		return -(t * t * t * t - 1) * (end - start) + start;
	}

	public static Vector2 InOutQuart(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * t * t * (end - start) + start;
		}
		else
		{
			t -= 2;
			return -0.5f * (t * t * t * t - 2) * (end - start) + start;
		}
	}

	public static Vector2 OutInQuart(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (-0.5f * t * t * t * t + 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Vector2 InQuint(Vector2 start, Vector2 end, float t)
	{
		return t * t * t * t * t * (end - start) + start;
	}

	public static Vector2 OutQuint(Vector2 start, Vector2 end, float t)
	{
		--t;
		return (t * t * t * t * t + 1) * (end - start) + start;
	}

	public static Vector2 InOutQuint(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * t * t * t * t * t) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (0.5f * t * t * t * t * t + 1) * (end - start) + start;
		}
	}

	public static Vector2 OutInQuint(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * (t * t * t * t * t) + 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Vector2 InSin(Vector2 start, Vector2 end, float t)
	{
		return -Mathf.Cos(t * Mathf.PI * 0.5f) * (end - start) + end;
	}

	public static Vector2 OutSin(Vector2 start, Vector2 end, float t)
	{
		return Mathf.Sin(t * Mathf.PI * 0.5f) * (end - start) + start;
	}

	public static Vector2 InOutSin(Vector2 start, Vector2 end, float t)
	{
		return (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f) * (end - start) + start;
	}

	public static Vector2 OutInSin(Vector2 start, Vector2 end, float t)
	{
		return (t - (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f - t)) * (end - start) + start;
	}

	public static Vector2 InExp(Vector2 start, Vector2 end, float t)
	{
		return Mathf.Pow(2, 10 * (t - 1)) * (end - start) + start;
	}

	public static Vector2 OutExp(Vector2 start, Vector2 end, float t)
	{
		return (1 - Mathf.Pow(2, -10 * t)) * (end - start) + start;
	}

	public static Vector2 InOutExp(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * Mathf.Pow(2, 10 * (t - 1)) * (end - start) + start;
		}
		else
		{
			--t;
			return 0.5f * (2 - Mathf.Pow(2, -10 * t)) * (end - start) + start;
		}
	}

	public static Vector2 OutInExp(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * (2 - Mathf.Pow(2, -10 * t)) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * Mathf.Pow(2, 10 * (t - 1)) + 0.5f) * (end - start) + start;
		}
	}

	public static Vector2 InCirc(Vector2 start, Vector2 end, float t)
	{
		return -(Mathf.Sqrt(1 - t * t) - 1) * (end - start) + start;
	}

	public static Vector2 OutCirc(Vector2 start, Vector2 end, float t)
	{
		--t;
		return Mathf.Sqrt(1 - t * t) * (end - start) + start;
	}

	public static Vector2 InOutCirc(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (-0.5f * (Mathf.Sqrt(1 - t * t) - 1)) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (0.5f * (Mathf.Sqrt(1 - t * t) + 1)) * (end - start) + start;
		}
	}

	public static Vector2 OutInCirc(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * Mathf.Sqrt(1 - t * t)) * (end - start) + start;
		}
		else
		{
			--t;
			return (-0.5f * Mathf.Sqrt(1 - t * t) + 1) * (end - start) + start;
		}
	}

	public static Vector2 InElastic(Vector2 start, Vector2 end, float t)
	{
		float p = 0.3f, s = 0.075f;
		--t;
		return (-Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + start;
	}

	public static Vector2 OutElastic(Vector2 start, Vector2 end, float t)
	{
		float p = 0.3f, s = 0.075f;
		return (Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + end;
	}

	public static Vector2 InOutElastic(Vector2 start, Vector2 end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			--t;
			return (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + end;
		}
	}

	public static Vector2 OutInElastic(Vector2 start, Vector2 end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			return (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) - 0.5f) * (end - start) + end;
		}
		else
		{
			t -= 2;
			return (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) + 0.5f) * (end - start) + start;
		}
	}

	public static Vector2 InBounce(Vector2 start, Vector2 end, float t)
	{

		t = 1 - t;
		if(t < 1 / 2.75f)
		{
			return (-7.5625f * t * t + 1) * (end - start) + start;
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return (-7.5625f * t * t - 0.75f + 1) * (end - start) + start;
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return (-7.5625f * t * t - 0.9375f + 1) * (end - start) + start;
		}
		else
		{
			t -= 2.625f / 2.75f;
			return (-7.5625f * t * t - 0.984375f + 1) * (end - start) + start;
		}
	}

	public static Vector2 OutBounce(Vector2 start, Vector2 end, float t)
	{

		if(t < 1 / 2.75f)
		{
			return (7.5625f * t * t) * (end - start) + start;
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return (7.5625f * t * t + 0.75f) * (end - start) + start;
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return (7.5625f * t * t + 0.9375f) * (end - start) + start;
		}
		else
		{
			t -= 2.625f / 2.75f;
			return (7.5625f * t * t + 0.984375f) * (end - start) + start;
		}
	}

	public static Vector2 InOutBounce(Vector2 start, Vector2 end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			t = 1 - t;
			if(t < 1 / 2.75f)
			{
				return (-0.5f * 7.5625f * t * t + 0.5f) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.75f) + 0.5f) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.9375f) + 0.5f) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.984375f) + 0.5f) * (end - start) + start;
			}
		}
		else
		{
			--t;
			if(t < 1 / 2.75f)
			{
				return (0.5f * 7.5625f * t * t + 0.5f) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.75f) + 0.5f) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.9375f) + 0.5f) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.984375f) + 0.5f) * (end - start) + start;
			}
		}
	}

	public static Vector2 OutInBounce(Vector2 start, Vector2 end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			if(t < 1 / 2.75f)
			{
				return (0.5f * 7.5625f * t * t) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.75f)) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.9375f)) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.984375f)) * (end - start) + start;
			}
		}
		else
		{
			t = 2 - t;
			if(t < 1 / 2.75f)
			{
				return (-0.5f * 7.5625f * t * t + 1) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.75f) + 1) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.9375f) + 1) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.984375f) + 1) * (end - start) + start;
			}
		}
	}

	public static Vector2 InBack(Vector2 start, Vector2 end, float t)
	{
		return t * t * (2.70158f * t - 1.70158f) * (end - start) + start;
	}

	public static Vector2 OutBack(Vector2 start, Vector2 end, float t)
	{
		--t;
		return (1 - t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
	}

	public static Vector2 InOutBack(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * t * t * (2.70158f * t - 1.70158f)) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (1 - 0.5f * t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
		}
	}

	public static Vector2 OutInBack(Vector2 start, Vector2 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f - 0.5f * t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * (2.70158f * t - 1.70158f) + 0.5f) * (end - start) + start;
		}
	}

	public static Vector3 EaseByType(Easing e, Vector3 start, Vector3 end, float t)
	{
		return Vector3Funcs[(int)e](start, end, t);
	}

	public static Vector3 Linear(Vector3 start, Vector3 end, float t)
	{
		return t * (end - start) + start;
	}

	public static Vector3 InQuad(Vector3 start, Vector3 end, float t)
	{
		return t * t * (end - start) + start;
	}

	public static Vector3 OutQuad(Vector3 start, Vector3 end, float t)
	{
		return -(t * (t - 2)) * (end - start) + start;
	}

	public static Vector3 InOutQuad(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * (end - start) + start;
		}
		else
		{
			--t;
			return -0.5f * (t * (t - 2) - 1) * (end - start) + start;
		}
	}

	public static Vector3 OutInQuad(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (-0.5f * (t * (t - 2) - 1) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Vector3 InCubic(Vector3 start, Vector3 end, float t)
	{
		return t * t * t * (end - start) + start;
	}

	public static Vector3 OutCubic(Vector3 start, Vector3 end, float t)
	{
		--t;
		return (t * t * t + 1) * (end - start) + start;
	}

	public static Vector3 InOutCubic(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * t * (end - start) + start;
		}
		else
		{
			t -= 2;
			return 0.5f * (t * t * t + 2) * (end - start) + start;
		}
	}

	public static Vector3 OutInCubic(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * (t * t * t + 2) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Vector3 InQuart(Vector3 start, Vector3 end, float t)
	{
		return t * t * t * t * (end - start) + start;
	}

	public static Vector3 OutQuart(Vector3 start, Vector3 end, float t)
	{
		--t;
		return -(t * t * t * t - 1) * (end - start) + start;
	}

	public static Vector3 InOutQuart(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * t * t * (end - start) + start;
		}
		else
		{
			t -= 2;
			return -0.5f * (t * t * t * t - 2) * (end - start) + start;
		}
	}

	public static Vector3 OutInQuart(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (-0.5f * t * t * t * t + 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Vector3 InQuint(Vector3 start, Vector3 end, float t)
	{
		return t * t * t * t * t * (end - start) + start;
	}

	public static Vector3 OutQuint(Vector3 start, Vector3 end, float t)
	{
		--t;
		return (t * t * t * t * t + 1) * (end - start) + start;
	}

	public static Vector3 InOutQuint(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * t * t * t * t * t) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (0.5f * t * t * t * t * t + 1) * (end - start) + start;
		}
	}

	public static Vector3 OutInQuint(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * (t * t * t * t * t) + 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Vector3 InSin(Vector3 start, Vector3 end, float t)
	{
		return -Mathf.Cos(t * Mathf.PI * 0.5f) * (end - start) + end;
	}

	public static Vector3 OutSin(Vector3 start, Vector3 end, float t)
	{
		return Mathf.Sin(t * Mathf.PI * 0.5f) * (end - start) + start;
	}

	public static Vector3 InOutSin(Vector3 start, Vector3 end, float t)
	{
		return (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f) * (end - start) + start;
	}

	public static Vector3 OutInSin(Vector3 start, Vector3 end, float t)
	{
		return (t - (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f - t)) * (end - start) + start;
	}

	public static Vector3 InExp(Vector3 start, Vector3 end, float t)
	{
		return Mathf.Pow(2, 10 * (t - 1)) * (end - start) + start;
	}

	public static Vector3 OutExp(Vector3 start, Vector3 end, float t)
	{
		return (1 - Mathf.Pow(2, -10 * t)) * (end - start) + start;
	}

	public static Vector3 InOutExp(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * Mathf.Pow(2, 10 * (t - 1)) * (end - start) + start;
		}
		else
		{
			--t;
			return 0.5f * (2 - Mathf.Pow(2, -10 * t)) * (end - start) + start;
		}
	}

	public static Vector3 OutInExp(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * (2 - Mathf.Pow(2, -10 * t)) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * Mathf.Pow(2, 10 * (t - 1)) + 0.5f) * (end - start) + start;
		}
	}

	public static Vector3 InCirc(Vector3 start, Vector3 end, float t)
	{
		return -(Mathf.Sqrt(1 - t * t) - 1) * (end - start) + start;
	}

	public static Vector3 OutCirc(Vector3 start, Vector3 end, float t)
	{
		--t;
		return Mathf.Sqrt(1 - t * t) * (end - start) + start;
	}

	public static Vector3 InOutCirc(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (-0.5f * (Mathf.Sqrt(1 - t * t) - 1)) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (0.5f * (Mathf.Sqrt(1 - t * t) + 1)) * (end - start) + start;
		}
	}

	public static Vector3 OutInCirc(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * Mathf.Sqrt(1 - t * t)) * (end - start) + start;
		}
		else
		{
			--t;
			return (-0.5f * Mathf.Sqrt(1 - t * t) + 1) * (end - start) + start;
		}
	}

	public static Vector3 InElastic(Vector3 start, Vector3 end, float t)
	{
		float p = 0.3f, s = 0.075f;
		--t;
		return (-Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + start;
	}

	public static Vector3 OutElastic(Vector3 start, Vector3 end, float t)
	{
		float p = 0.3f, s = 0.075f;
		return (Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + end;
	}

	public static Vector3 InOutElastic(Vector3 start, Vector3 end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			--t;
			return (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + end;
		}
	}

	public static Vector3 OutInElastic(Vector3 start, Vector3 end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			return (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) - 0.5f) * (end - start) + end;
		}
		else
		{
			t -= 2;
			return (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) + 0.5f) * (end - start) + start;
		}
	}

	public static Vector3 InBounce(Vector3 start, Vector3 end, float t)
	{

		t = 1 - t;
		if(t < 1 / 2.75f)
		{
			return (-7.5625f * t * t + 1) * (end - start) + start;
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return (-7.5625f * t * t - 0.75f + 1) * (end - start) + start;
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return (-7.5625f * t * t - 0.9375f + 1) * (end - start) + start;
		}
		else
		{
			t -= 2.625f / 2.75f;
			return (-7.5625f * t * t - 0.984375f + 1) * (end - start) + start;
		}
	}

	public static Vector3 OutBounce(Vector3 start, Vector3 end, float t)
	{

		if(t < 1 / 2.75f)
		{
			return (7.5625f * t * t) * (end - start) + start;
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return (7.5625f * t * t + 0.75f) * (end - start) + start;
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return (7.5625f * t * t + 0.9375f) * (end - start) + start;
		}
		else
		{
			t -= 2.625f / 2.75f;
			return (7.5625f * t * t + 0.984375f) * (end - start) + start;
		}
	}

	public static Vector3 InOutBounce(Vector3 start, Vector3 end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			t = 1 - t;
			if(t < 1 / 2.75f)
			{
				return (-0.5f * 7.5625f * t * t + 0.5f) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.75f) + 0.5f) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.9375f) + 0.5f) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.984375f) + 0.5f) * (end - start) + start;
			}
		}
		else
		{
			--t;
			if(t < 1 / 2.75f)
			{
				return (0.5f * 7.5625f * t * t + 0.5f) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.75f) + 0.5f) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.9375f) + 0.5f) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.984375f) + 0.5f) * (end - start) + start;
			}
		}
	}

	public static Vector3 OutInBounce(Vector3 start, Vector3 end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			if(t < 1 / 2.75f)
			{
				return (0.5f * 7.5625f * t * t) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.75f)) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.9375f)) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.984375f)) * (end - start) + start;
			}
		}
		else
		{
			t = 2 - t;
			if(t < 1 / 2.75f)
			{
				return (-0.5f * 7.5625f * t * t + 1) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.75f) + 1) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.9375f) + 1) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.984375f) + 1) * (end - start) + start;
			}
		}
	}

	public static Vector3 InBack(Vector3 start, Vector3 end, float t)
	{
		return t * t * (2.70158f * t - 1.70158f) * (end - start) + start;
	}

	public static Vector3 OutBack(Vector3 start, Vector3 end, float t)
	{
		--t;
		return (1 - t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
	}

	public static Vector3 InOutBack(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * t * t * (2.70158f * t - 1.70158f)) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (1 - 0.5f * t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
		}
	}

	public static Vector3 OutInBack(Vector3 start, Vector3 end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f - 0.5f * t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * (2.70158f * t - 1.70158f) + 0.5f) * (end - start) + start;
		}
	}

	public static Quaternion EaseByType(Easing e, Quaternion start, Quaternion end, float t)
	{
		return QuaternionFuncs[(int)e](start, end, t);
	}

	public static Quaternion Linear(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, t);
	}

	public static Quaternion InQuad(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, t * t);
	}

	public static Quaternion OutQuad(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, -(t * (t - 2)));
	}

	public static Quaternion InOutQuad(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, 0.5f * t * t);
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, -0.5f * (t * (t - 2) - 1));
		}
	}

	public static Quaternion OutInQuad(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, (-0.5f * (t * (t - 2) - 1) - 0.5f));
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, (0.5f * t * t + 0.5f));
		}
	}

	public static Quaternion InCubic(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, t * t * t);
	}

	public static Quaternion OutCubic(Quaternion start, Quaternion end, float t)
	{
		--t;
		return Quaternion.Lerp(start, end, (t * t * t + 1));
	}

	public static Quaternion InOutCubic(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, 0.5f * t * t * t);
		}
		else
		{
			t -= 2;
			return Quaternion.Lerp(start, end, 0.5f * (t * t * t + 2));
		}
	}

	public static Quaternion OutInCubic(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return Quaternion.Lerp(start, end, (0.5f * (t * t * t + 2) - 0.5f));
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, (0.5f * t * t * t + 0.5f));
		}
	}

	public static Quaternion InQuart(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, t * t * t * t);
	}

	public static Quaternion OutQuart(Quaternion start, Quaternion end, float t)
	{
		--t;
		return Quaternion.Lerp(start, end, -(t * t * t * t - 1));
	}

	public static Quaternion InOutQuart(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, 0.5f * t * t * t * t);
		}
		else
		{
			t -= 2;
			return Quaternion.Lerp(start, end, -0.5f * (t * t * t * t - 2));
		}
	}

	public static Quaternion OutInQuart(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return Quaternion.Lerp(start, end, (-0.5f * t * t * t * t + 0.5f));
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, (0.5f * t * t * t * t + 0.5f));
		}
	}

	public static Quaternion InQuint(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, t * t * t * t * t);
	}

	public static Quaternion OutQuint(Quaternion start, Quaternion end, float t)
	{
		--t;
		return Quaternion.Lerp(start, end, (t * t * t * t * t + 1));
	}

	public static Quaternion InOutQuint(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, (0.5f * t * t * t * t * t));
		}
		else
		{
			t -= 2;
			return Quaternion.Lerp(start, end, (0.5f * t * t * t * t * t + 1));
		}
	}

	public static Quaternion OutInQuint(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return Quaternion.Lerp(start, end, (0.5f * (t * t * t * t * t) + 0.5f));
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, (0.5f * t * t * t * t * t + 0.5f));
		}
	}

	public static Quaternion InSin(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, -Mathf.Cos(t * Mathf.PI * 0.5f));
	}

	public static Quaternion OutSin(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, Mathf.Sin(t * Mathf.PI * 0.5f));
	}

	public static Quaternion InOutSin(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, -0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f);
	}

	public static Quaternion OutInSin(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, (t - (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f - t)));
	}

	public static Quaternion InExp(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, Mathf.Pow(2, 10 * (t - 1)));
	}

	public static Quaternion OutExp(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, (1 - Mathf.Pow(2, -10 * t)));
	}

	public static Quaternion InOutExp(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, 0.5f * Mathf.Pow(2, 10 * (t - 1)));
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, 0.5f * (2 - Mathf.Pow(2, -10 * t)));
		}
	}

	public static Quaternion OutInExp(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, 0.5f * (2 - Mathf.Pow(2, -10 * t)) - 0.5f);
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, 0.5f * Mathf.Pow(2, 10 * (t - 1)) + 0.5f);
		}
	}

	public static Quaternion InCirc(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, -(Mathf.Sqrt(1 - t * t) - 1));
	}

	public static Quaternion OutCirc(Quaternion start, Quaternion end, float t)
	{
		--t;
		return Quaternion.Lerp(start, end, Mathf.Sqrt(1 - t * t));
	}

	public static Quaternion InOutCirc(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, -0.5f * (Mathf.Sqrt(1 - t * t) - 1));
		}
		else
		{
			t -= 2;
			return Quaternion.Lerp(start, end, 0.5f * (Mathf.Sqrt(1 - t * t) + 1));
		}
	}

	public static Quaternion OutInCirc(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return Quaternion.Lerp(start, end, 0.5f * Mathf.Sqrt(1 - t * t));
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, -0.5f * Mathf.Sqrt(1 - t * t) + 1);
		}
	}

	public static Quaternion InElastic(Quaternion start, Quaternion end, float t)
	{
		float p = 0.3f, s = 0.075f;
		--t;
		return Quaternion.Lerp(start, end, -Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p));
	}

	public static Quaternion OutElastic(Quaternion start, Quaternion end, float t)
	{
		float p = 0.3f, s = 0.075f;
		return Quaternion.Lerp(start, end, Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p));
	}

	public static Quaternion InOutElastic(Quaternion start, Quaternion end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			--t;
			return Quaternion.Lerp(start, end, (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)));
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)));
		}
	}

	public static Quaternion OutInElastic(Quaternion start, Quaternion end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, 0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) - 0.5f);
		}
		else
		{
			t -= 2;
			return Quaternion.Lerp(start, end, -0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) + 0.5f);
		}
	}

	public static Quaternion InBounce(Quaternion start, Quaternion end, float t)
	{

		t = 1 - t;
		if(t < 1 / 2.75f)
		{
			return Quaternion.Lerp(start, end, -7.5625f * t * t + 1);
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return Quaternion.Lerp(start, end, -7.5625f * t * t - 0.75f + 1);
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return Quaternion.Lerp(start, end, -7.5625f * t * t - 0.9375f + 1);
		}
		else
		{
			t -= 2.625f / 2.75f;
			return Quaternion.Lerp(start, end, -7.5625f * t * t - 0.984375f + 1);
		}
	}

	public static Quaternion OutBounce(Quaternion start, Quaternion end, float t)
	{

		if(t < 1 / 2.75f)
		{
			return Quaternion.Lerp(start, end, 7.5625f * t * t);
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return Quaternion.Lerp(start, end, 7.5625f * t * t + 0.75f);
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return Quaternion.Lerp(start, end, 7.5625f * t * t + 0.9375f);
		}
		else
		{
			t -= 2.625f / 2.75f;
			return Quaternion.Lerp(start, end, 7.5625f * t * t + 0.984375f);
		}
	}

	public static Quaternion InOutBounce(Quaternion start, Quaternion end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			t = 1 - t;
			if(t < 1 / 2.75f)
			{
				return Quaternion.Lerp(start, end, -0.5f * 7.5625f * t * t + 0.5f);
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return Quaternion.Lerp(start, end, -0.5f * (7.5625f * t * t + 0.75f) + 0.5f);
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return Quaternion.Lerp(start, end, -0.5f * (7.5625f * t * t + 0.9375f) + 0.5f);
			}
			else
			{
				t -= 2.625f / 2.75f;
				return Quaternion.Lerp(start, end, -0.5f * (7.5625f * t * t + 0.984375f) + 0.5f);
			}
		}
		else
		{
			--t;
			if(t < 1 / 2.75f)
			{
				return Quaternion.Lerp(start, end, 0.5f * 7.5625f * t * t + 0.5f);
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return Quaternion.Lerp(start, end, 0.5f * (7.5625f * t * t + 0.75f) + 0.5f);
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return Quaternion.Lerp(start, end, 0.5f * (7.5625f * t * t + 0.9375f) + 0.5f);
			}
			else
			{
				t -= 2.625f / 2.75f;
				return Quaternion.Lerp(start, end, 0.5f * (7.5625f * t * t + 0.984375f) + 0.5f);
			}
		}
	}

	public static Quaternion OutInBounce(Quaternion start, Quaternion end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			if(t < 1 / 2.75f)
			{
				return Quaternion.Lerp(start, end, 0.5f * 7.5625f * t * t);
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return Quaternion.Lerp(start, end, 0.5f * (7.5625f * t * t + 0.75f));
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return Quaternion.Lerp(start, end, 0.5f * (7.5625f * t * t + 0.9375f));
			}
			else
			{
				t -= 2.625f / 2.75f;
				return Quaternion.Lerp(start, end, 0.5f * (7.5625f * t * t + 0.984375f));
			}
		}
		else
		{
			t = 2 - t;
			if(t < 1 / 2.75f)
			{
				return Quaternion.Lerp(start, end, -0.5f * 7.5625f * t * t + 1);
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return Quaternion.Lerp(start, end, -0.5f * (7.5625f * t * t + 0.75f) + 1);
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return Quaternion.Lerp(start, end, -0.5f * (7.5625f * t * t + 0.9375f) + 1);
			}
			else
			{
				t -= 2.625f / 2.75f;
				return Quaternion.Lerp(start, end, -0.5f * (7.5625f * t * t + 0.984375f) + 1);
			}
		}
	}

	public static Quaternion InBack(Quaternion start, Quaternion end, float t)
	{
		return Quaternion.Lerp(start, end, t * t * (2.70158f * t - 1.70158f));
	}

	public static Quaternion OutBack(Quaternion start, Quaternion end, float t)
	{
		--t;
		return Quaternion.Lerp(start, end, 1 - t * t * (-2.70158f * t - 1.70158f));
	}

	public static Quaternion InOutBack(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return Quaternion.Lerp(start, end, (0.5f * t * t * (2.70158f * t - 1.70158f)));
		}
		else
		{
			t -= 2;
			return Quaternion.Lerp(start, end, (1 - 0.5f * t * t * (-2.70158f * t - 1.70158f)));
		}
	}

	public static Quaternion OutInBack(Quaternion start, Quaternion end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return Quaternion.Lerp(start, end, 0.5f - 0.5f * t * t * (-2.70158f * t - 1.70158f));
		}
		else
		{
			--t;
			return Quaternion.Lerp(start, end, (0.5f * t * t * (2.70158f * t - 1.70158f) + 0.5f));
		}
	}

	public static Color EaseByType(Easing e, Color start, Color end, float t)
	{
		return ColorFuncs[(int)e](start, end, t);
	}

	public static Color Linear(Color start, Color end, float t)
	{
		return t * (end - start) + start;
	}

	public static Color InQuad(Color start, Color end, float t)
	{
		return t * t * (end - start) + start;
	}

	public static Color OutQuad(Color start, Color end, float t)
	{
		return -(t * (t - 2)) * (end - start) + start;
	}

	public static Color InOutQuad(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * (end - start) + start;
		}
		else
		{
			--t;
			return -0.5f * (t * (t - 2) - 1) * (end - start) + start;
		}
	}

	public static Color OutInQuad(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (-0.5f * (t * (t - 2) - 1) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Color InCubic(Color start, Color end, float t)
	{
		return t * t * t * (end - start) + start;
	}

	public static Color OutCubic(Color start, Color end, float t)
	{
		--t;
		return (t * t * t + 1) * (end - start) + start;
	}

	public static Color InOutCubic(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * t * (end - start) + start;
		}
		else
		{
			t -= 2;
			return 0.5f * (t * t * t + 2) * (end - start) + start;
		}
	}

	public static Color OutInCubic(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * (t * t * t + 2) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Color InQuart(Color start, Color end, float t)
	{
		return t * t * t * t * (end - start) + start;
	}

	public static Color OutQuart(Color start, Color end, float t)
	{
		--t;
		return -(t * t * t * t - 1) * (end - start) + start;
	}

	public static Color InOutQuart(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * t * t * t * t * (end - start) + start;
		}
		else
		{
			t -= 2;
			return -0.5f * (t * t * t * t - 2) * (end - start) + start;
		}
	}

	public static Color OutInQuart(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (-0.5f * t * t * t * t + 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Color InQuint(Color start, Color end, float t)
	{
		return t * t * t * t * t * (end - start) + start;
	}

	public static Color OutQuint(Color start, Color end, float t)
	{
		--t;
		return (t * t * t * t * t + 1) * (end - start) + start;
	}

	public static Color InOutQuint(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * t * t * t * t * t) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (0.5f * t * t * t * t * t + 1) * (end - start) + start;
		}
	}

	public static Color OutInQuint(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * (t * t * t * t * t) + 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * t * t * t + 0.5f) * (end - start) + start;
		}
	}

	public static Color InSin(Color start, Color end, float t)
	{
		return -Mathf.Cos(t * Mathf.PI * 0.5f) * (end - start) + end;
	}

	public static Color OutSin(Color start, Color end, float t)
	{
		return Mathf.Sin(t * Mathf.PI * 0.5f) * (end - start) + start;
	}

	public static Color InOutSin(Color start, Color end, float t)
	{
		return (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f) * (end - start) + start;
	}

	public static Color OutInSin(Color start, Color end, float t)
	{
		return (t - (-0.5f * Mathf.Cos(t * Mathf.PI) + 0.5f - t)) * (end - start) + start;
	}

	public static Color InExp(Color start, Color end, float t)
	{
		return Mathf.Pow(2, 10 * (t - 1)) * (end - start) + start;
	}

	public static Color OutExp(Color start, Color end, float t)
	{
		return (1 - Mathf.Pow(2, -10 * t)) * (end - start) + start;
	}

	public static Color InOutExp(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return 0.5f * Mathf.Pow(2, 10 * (t - 1)) * (end - start) + start;
		}
		else
		{
			--t;
			return 0.5f * (2 - Mathf.Pow(2, -10 * t)) * (end - start) + start;
		}
	}

	public static Color OutInExp(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * (2 - Mathf.Pow(2, -10 * t)) - 0.5f) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * Mathf.Pow(2, 10 * (t - 1)) + 0.5f) * (end - start) + start;
		}
	}

	public static Color InCirc(Color start, Color end, float t)
	{
		return -(Mathf.Sqrt(1 - t * t) - 1) * (end - start) + start;
	}

	public static Color OutCirc(Color start, Color end, float t)
	{
		--t;
		return Mathf.Sqrt(1 - t * t) * (end - start) + start;
	}

	public static Color InOutCirc(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (-0.5f * (Mathf.Sqrt(1 - t * t) - 1)) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (0.5f * (Mathf.Sqrt(1 - t * t) + 1)) * (end - start) + start;
		}
	}

	public static Color OutInCirc(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f * Mathf.Sqrt(1 - t * t)) * (end - start) + start;
		}
		else
		{
			--t;
			return (-0.5f * Mathf.Sqrt(1 - t * t) + 1) * (end - start) + start;
		}
	}

	public static Color InElastic(Color start, Color end, float t)
	{
		float p = 0.3f, s = 0.075f;
		--t;
		return (-Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + start;
	}

	public static Color OutElastic(Color start, Color end, float t)
	{
		float p = 0.3f, s = 0.075f;
		return (Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + end;
	}

	public static Color InOutElastic(Color start, Color end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			--t;
			return (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p)) * (end - start) + end;
		}
	}

	public static Color OutInElastic(Color start, Color end, float t)
	{
		float p = 0.3f, s = 0.075f;
		t *= 2;
		if(t < 1)
		{
			return (0.5f * Mathf.Pow(2, -10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) - 0.5f) * (end - start) + end;
		}
		else
		{
			t -= 2;
			return (-0.5f * Mathf.Pow(2, 10 * t) * Mathf.Sin((t - s) * (2 * Mathf.PI) / p) + 0.5f) * (end - start) + start;
		}
	}

	public static Color InBounce(Color start, Color end, float t)
	{

		t = 1 - t;
		if(t < 1 / 2.75f)
		{
			return (-7.5625f * t * t + 1) * (end - start) + start;
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return (-7.5625f * t * t - 0.75f + 1) * (end - start) + start;
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return (-7.5625f * t * t - 0.9375f + 1) * (end - start) + start;
		}
		else
		{
			t -= 2.625f / 2.75f;
			return (-7.5625f * t * t - 0.984375f + 1) * (end - start) + start;
		}
	}

	public static Color OutBounce(Color start, Color end, float t)
	{

		if(t < 1 / 2.75f)
		{
			return (7.5625f * t * t) * (end - start) + start;
		}
		else if(t < 2.0f / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return (7.5625f * t * t + 0.75f) * (end - start) + start;
		}
		else if(t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return (7.5625f * t * t + 0.9375f) * (end - start) + start;
		}
		else
		{
			t -= 2.625f / 2.75f;
			return (7.5625f * t * t + 0.984375f) * (end - start) + start;
		}
	}

	public static Color InOutBounce(Color start, Color end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			t = 1 - t;
			if(t < 1 / 2.75f)
			{
				return (-0.5f * 7.5625f * t * t + 0.5f) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.75f) + 0.5f) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.9375f) + 0.5f) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.984375f) + 0.5f) * (end - start) + start;
			}
		}
		else
		{
			--t;
			if(t < 1 / 2.75f)
			{
				return (0.5f * 7.5625f * t * t + 0.5f) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.75f) + 0.5f) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.9375f) + 0.5f) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.984375f) + 0.5f) * (end - start) + start;
			}
		}
	}

	public static Color OutInBounce(Color start, Color end, float t)
	{

		t *= 2;
		if(t < 1)
		{
			if(t < 1 / 2.75f)
			{
				return (0.5f * 7.5625f * t * t) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.75f)) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.9375f)) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (0.5f * (7.5625f * t * t + 0.984375f)) * (end - start) + start;
			}
		}
		else
		{
			t = 2 - t;
			if(t < 1 / 2.75f)
			{
				return (-0.5f * 7.5625f * t * t + 1) * (end - start) + start;
			}
			else if(t < 2.0f / 2.75f)
			{
				t -= 1.5f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.75f) + 1) * (end - start) + start;
			}
			else if(t < 2.5f / 2.75f)
			{
				t -= 2.25f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.9375f) + 1) * (end - start) + start;
			}
			else
			{
				t -= 2.625f / 2.75f;
				return (-0.5f * (7.5625f * t * t + 0.984375f) + 1) * (end - start) + start;
			}
		}
	}

	public static Color InBack(Color start, Color end, float t)
	{
		return t * t * (2.70158f * t - 1.70158f) * (end - start) + start;
	}

	public static Color OutBack(Color start, Color end, float t)
	{
		--t;
		return (1 - t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
	}

	public static Color InOutBack(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			return (0.5f * t * t * (2.70158f * t - 1.70158f)) * (end - start) + start;
		}
		else
		{
			t -= 2;
			return (1 - 0.5f * t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
		}
	}

	public static Color OutInBack(Color start, Color end, float t)
	{
		t *= 2;
		if(t < 1)
		{
			--t;
			return (0.5f - 0.5f * t * t * (-2.70158f * t - 1.70158f)) * (end - start) + start;
		}
		else
		{
			--t;
			return (0.5f * t * t * (2.70158f * t - 1.70158f) + 0.5f) * (end - start) + start;
		}
	}
}