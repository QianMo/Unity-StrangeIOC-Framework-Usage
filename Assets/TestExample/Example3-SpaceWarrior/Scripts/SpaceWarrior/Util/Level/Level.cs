using System;


[Serializable]
public class Level
{
	public string name;


	public OpponentModel Asteroid;
	public OpponentModel Enemy;


	public Level(string levelName, OpponentModel asteroid, OpponentModel enemy)
	{
		name = levelName;
		Asteroid = asteroid;
		Enemy = enemy;
	}
}
