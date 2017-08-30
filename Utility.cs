using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility {

	//this is probably the most important thing in this file
	public static bool IsInLayerMask(int layer, LayerMask layermask)
	{
		return layermask == (layermask | (1 << layer));
	}					

	#region Transform Extensions
	public static void ResetTransformation(this Transform trans)
	{
		trans.position = Vector3.zero;
		trans.localRotation = Quaternion.identity;
		trans.localScale = new Vector3(1,1,1);
	}

	public static void shiftX(this Transform me, float x)
	{
		Vector3 temp = me.position;
		temp.x += x;
		me.position = temp;
	}

	public static void shiftY(this Transform me, float y)
	{
		Vector3 temp = me.position;
		temp.y += y;
		me.position = temp;
	}

	public static void shiftZ(this Transform me, float z)
	{
		Vector3 temp = me.position;
		temp.z += z;
		me.position = temp;
	}
	#endregion

	#region Vector2 Extensions
	public static Vector2 Abs(this Vector2 me)
	{
		return new Vector2( Mathf.Abs(me.x), Mathf.Abs(me.y));
	}

	public static Vector2 withX(this Vector2 me, float x)
	{
		return new Vector2(x, me.y);
	}

	public static Vector2 withY(this Vector2 me, float y)
	{
		return new Vector2(me.x, y);
	}
		
	#endregion

	#region Vector3 Extensions
	public static Vector3 Abs(this Vector3 me)
	{
		return new Vector3( Mathf.Abs(me.x), Mathf.Abs(me.y), Mathf.Abs(me.z));
	}

	public static Vector3 TowardsPosition(this Vector3 me, Vector3 target)
	{
		return target - me;
	}

	public static Vector2 xy(this Vector3 me)
	{
		return new Vector2(me.x, me.y);
	}

	public static Vector3 withX(this Vector3 me, float x)
	{
		return new Vector3(x, me.y, me.z);
	}

	public static Vector3 withY(this Vector3 me, float y)
	{
		return new Vector3(me.x, y, me.z);
	}

	public static Vector3 withZ(this Vector3 me, float z)
	{
		return new Vector3(me.x, me.y, z);
	}
	#endregion

	#region List Extensions
	public static void shuffle<T>(this IList<T> list)
	{				
		int n = list.Count;
		while(n > 1)
		{
			n--;
			int k = Random.Range(0, list.Count);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}

	public static T RandomItem<T>(this IList<T> list)
	{
		if(list.Count == 0) throw new System.IndexOutOfRangeException("Cannot select random item from empty list");
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	#endregion

	public static void PrintJoystickInputs()
	{																					// xbox controller
		if(Input.GetKeyDown(KeyCode.JoystickButton0)){ Debug.Log("JoystickButton0"); }		// A
		if(Input.GetKeyDown(KeyCode.JoystickButton1)){ Debug.Log("JoystickButton1"); }		// B
		if(Input.GetKeyDown(KeyCode.JoystickButton2)){ Debug.Log("JoystickButton2"); }		// X
		if(Input.GetKeyDown(KeyCode.JoystickButton3)){ Debug.Log("JoystickButton3"); }		// Y
		if(Input.GetKeyDown(KeyCode.JoystickButton4)){ Debug.Log("JoystickButton4"); }		// LEFT BUMP
		if(Input.GetKeyDown(KeyCode.JoystickButton5)){ Debug.Log("JoystickButton5"); }		// RIGHT BUMP
		if(Input.GetKeyDown(KeyCode.JoystickButton6)){ Debug.Log("JoystickButton6"); }		// SELECT
		if(Input.GetKeyDown(KeyCode.JoystickButton7)){ Debug.Log("JoystickButton7"); }		// START
		if(Input.GetKeyDown(KeyCode.JoystickButton8)){ Debug.Log("JoystickButton8"); }		// LEFT STICK PRESS
		if(Input.GetKeyDown(KeyCode.JoystickButton9)){ Debug.Log("JPrinoystickButton9"); }		// RIGHT STICK PRESS
	}

	public static void PrintButtons()
	{
		if(Input.GetButtonDown("Jump")) { Debug.Log("JUMP"); }
		if(Input.GetButtonDown("Fire1")){ Debug.Log("Fire1"); }
		if(Input.GetButtonDown("Fire2")){ Debug.Log("Fire2"); }
		if(Input.GetButtonDown("Fire3")){ Debug.Log("Fire3"); }

	}

	public static void PrintAxis()
	{
		if(Input.GetAxis("Jump") != 0)			{ Debug.Log("Jump: " + Input.GetAxisRaw("Jump").ToString() ); }
		if(Input.GetAxis("Horizontal") != 0)	{ Debug.Log("Horizontal: " + Input.GetAxisRaw("Horizontal").ToString() ); }
		if(Input.GetAxis("Vertical") != 0)		{ Debug.Log("Vertical: " + Input.GetAxisRaw("Vertical").ToString() ); }
	}

	public static bool IsBoolArrayAllSame(bool[] array, bool match)
	{
		for(int i=0; i<array.Length; i++)
		{
			if(array[i] != match)
				return false;
		}
		return true;
	}
}
