using System;
using System.Reflection;
using UnityEngine;

public class SWElement
{
	public GameObject Warrior;
	public GameObject LevelPanel;

	public static Vector3 PARKED_POS = new Vector3(1000f, 1000f, 0f);

}



public enum SpaceWarriorSpawner
{
	PLAYER_LASER_SPAWNER,
	PLAYER_LASER_HIT_SPAWNER,
	MAIN_SPAWNER,
}



public enum SpaceWarriorTag
{
	[StringValue("PlayerLasersParent")]
	PlayerLasersParent,

	[StringValue("AsteroidsParent")]
	AsteroidsParent,

	[StringValue("GainedScoresParent")]
	GainedScoresParent,

	[StringValue("EnemyShipsParent")]
	EnemysParent,
}





public class StringValue : System.Attribute
{

	private readonly string _value;

	public StringValue(string value)
	{
		_value = value;
	}

	public string Value
	{
		get { return _value; }
	}

}


public static class StringEnum
{
	public static string GetStringValue(Enum value)
	{
		string output = null;
		Type type = value.GetType();

		FieldInfo fi = type.GetField(value.ToString());
		StringValue[] attrs = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];

		if (attrs.Length > 0)
		{
			output = attrs[0].Value;
		}

		return output;
	}
}