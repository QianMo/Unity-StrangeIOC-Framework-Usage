//-------------------------------------------------------------------------------------
//	TestProtobuf.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;

public class TestProtobuf : MonoBehaviour 
{

	void Start () 
	{
        SerializeTest();

        DeSerializeTest();

    }

    public static void SerializeTest()
    {
        User user = new User();

        user.ID = 100;
        user.Username = "hello";
        user.PassWord = "123456";
        user.Level = 100;
        user._UserType = User.UserType.Master;


        //         FileStream fs=File.Create(Application.dataPath + "/user.bin");
        //         Debug.Log("")
        //         Serializer.Serialize<User>(fs, user);
        //         fs.Close();

        using (var fs = File.Create(Application.dataPath + "/user.bin"))
        {
            Serializer.Serialize<User>(fs, user);
        }

    }


    public static void DeSerializeTest()
    {
        User user = null;

        using (var fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
            user = Serializer.Deserialize<User>(fs);
        }
        print(user.ID);
        print(user.Username);
        print(user.PassWord);
        print(user.Level);
        print(user._UserType);

    }

    void Update () 
	{
		
	}
}
