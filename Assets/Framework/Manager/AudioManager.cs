using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    //前缀
    public static string auidoTextPathPrefix = Application.dataPath + "\\Framework\\Resources";
    //后缀
    public static string auidoTextParhPostfix = "audiolist.txt";

    //路径
    public static string AudioTextPath
    {
        get
        {
            return auidoTextPathPrefix + auidoTextParhPostfix;
        }
    }

    //音频片段数据存储Map<name,AudioClip>
    private Dictionary<string, AudioClip> audioClipMap = new Dictionary<string, AudioClip>();


    public AudioManager()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip()
    {
        TextAsset ta= Resources.Load<TextAsset>(auidoTextPathPrefix);
        string[] lines = ta.text.Split('\n');


    }

}
