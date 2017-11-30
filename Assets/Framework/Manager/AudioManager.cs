using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    //前缀
    public static string auidoTextPathPrefix = Application.dataPath + "\\Framework\\Resources\\";
    
    public static string auidoTextPathMiddle = "audioList";
    //后缀
    public static string auidoTextParhPostfix = ".txt";

    //路径
    public static string AudioTextPath
    {
        get
        {
            return auidoTextPathPrefix + auidoTextPathMiddle + auidoTextParhPostfix;
        }
    }

    //resource路径下的资源，用Resources.Load，不用加后缀，只用和resource路径的相对路径。
    public static string AudioTextPathEx = "audioList";

    //音频片段数据存储Map<name,AudioClip>
    private Dictionary<string, AudioClip> audioClipMap = new Dictionary<string, AudioClip>();


//     public AudioManager()
//     {
//         LoadAudioClip();
//     }

    public void Init()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip()
    {
        audioClipMap = new Dictionary<string, AudioClip>();

        TextAsset ta= Resources.Load<TextAsset>(AudioTextPathEx);
        if (ta==null)
        {
            Debug.LogError("AudioTextPath= " + AudioTextPathEx);
            Debug.LogError("ta==null !!");
            return;
        }
        string[] lines = ta.text.Split('\n');

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty((line)))
            {
                continue;
            }
            string[] keyvalue = line.Split(',');
            if (keyvalue==null || keyvalue.Length<2)
            {
                continue;
            }
            string key = keyvalue[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalue[1]);
            audioClipMap.Add(key, value);
        }
    }


    public void Play(string name)
    {
        AudioClip ac;
        audioClipMap.TryGetValue(name, out ac);
        if (ac!=null)
        {
            AudioSource.PlayClipAtPoint(ac, Vector3.zero);
        }
    }

    public void Play(string name, Vector3 position)
    {
        AudioClip ac;
        audioClipMap.TryGetValue(name, out ac);
        if (ac!=null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }

}
