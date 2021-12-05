using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleAngTestCase : MonoBehaviour
{
	public float side1, side2, side3;

	private void Start()
	{
		TestTriangleSides();
	}
	private void TestTriangleSides(/*float side1, float side2, float side3*/)
	{
		if (EqualateralTri(side1,side2,side3))
			Debug.Log("Triangle is Equalateral");
		else if (IsoscelesTri(side1,side2,side3))
			Debug.Log("Triangle is Isosceles");
		else if (ScaleneTri(side1,side2,side3))
			Debug.Log("Triangle is Scalene");
	}
	private bool EqualateralTri(float s1, float s2, float s3)
	{
		if (s1 == s2 && s2 == s3) return true;

		return false;
	}
	private bool IsoscelesTri(float s1, float s2, float s3)
	{
		bool temp = false;

		if (s1 == s2 && s2 != s3)
			temp = true;
		else if (s2 == s3 && s3 != s1)
			temp = true;
		else if (s3 == s1 && s1 != s2)
			temp = true;

			return temp;
	}
	private bool ScaleneTri(float s1, float s2, float s3)
	{
		return !EqualateralTri(s1, s2, s3);
	}
}
