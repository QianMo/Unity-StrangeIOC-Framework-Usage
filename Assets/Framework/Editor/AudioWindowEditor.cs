//-------------------------------------------------------------------------------------
//	test.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class AudioWindowEditor : EditorWindow
{

    [MenuItem("Manager/AudioManager")]
    static void CreateWindow()
    {
        // method 1
        //             Rect rect = new Rect(400, 400, 400, 400);
        //             test window2 = EditorWindow.GetWindowWithRect(typeof(test), rect) as test;
        //             window2.Show();

        // method 2
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("音效管理");
        window.Show();
    }



    public string audioName = "Ding";

    public string audioPath = "Audio/Ding";

    private Dictionary<string, string> audioDict = new Dictionary<string, string>();

    public string savePath = "";



    void Awake()
    {
         savePath = Application.dataPath + "\\Framework\\Resources\\audioList.txt";
        LoadAudioList();
    }

    void OnGUI()
    {
        //return;
        GUILayout.BeginHorizontal();
        GUILayout.Label("名称");
        GUILayout.Label("路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();


        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);

            if (GUILayout.Button("删除"))
            {

                audioDict.Remove(key);
                //LoadAudioList();
                return;
            }
            GUILayout.EndHorizontal();
        }


        audioName = EditorGUILayout.TextField("音效名称", audioName);
        //GUILayout.TextField("输入文字2");
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);
        if (GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(audioPath);
            if (o == null)
            {
                Debug.LogWarning("音效不存在于" + audioPath + "，添加不成功！");
                audioPath = "";
            }
            else
            {
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("名字已经存在，请修改!");

                }
                else
                {
                    Debug.LogWarning("添加音效" + audioName + "成功！");
                    audioDict.Add(audioName, audioPath);
                    //SaveAudioList();
                }

            }

        }

    }

    //------------------------------------------------------------------------
    // 每秒调用10次
    //------------------------------------------------------------------------
    void OnInspectorUpdate()
    {
        Debug.LogWarning("OnInspectorUpdate:");
        SaveAudioList();
    }

    //------------------------------------------------------------------------
    // 保存List到文件
    //------------------------------------------------------------------------
    private void SaveAudioList()
    {
        StringBuilder strb = new StringBuilder();

        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            strb.Append(key + "," + value + "\n");
        }



        File.WriteAllText(savePath, strb.ToString());

        Debug.LogWarning("已经保存到路径:" + savePath);
    }


    //------------------------------------------------------------------------
    // 从文件读取List
    //------------------------------------------------------------------------
    private void LoadAudioList()
    {


        if (File.Exists(savePath) == false)
        {
            return;
        }
        string[] lines = File.ReadAllLines(savePath);
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] keyvalue = line.Split(',');
            if (keyvalue == null || keyvalue.Length < 2)
            {
                continue;
            }
            audioDict.Add(keyvalue[0], keyvalue[1]);
        }
    }

}
