//-------------------------------------------------------------------------------------
//	AudioWindowEditor.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using System.Collections.Generic;

public class AudioWindowEditor : EditorWindow
{

    [MenuItem("Manager/AudioManager")]
    static void CreateWindow()
    {
        // method 1
        //Rect rect = new Rect(400, 400, 400, 400);
        //AudioWindowEditor window = EditorWindow.GetWindowWithRect(typeof(AudioWindowEditor), rect) as AudioWindowEditor;

        // method 2
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("音效管理");
        window.Show();
    }




    public string audioName;
    public string audioPath;
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();

    void OnGUI()
    {
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
                    Debug.LogWarning("添加音效"+audioName+"成功！");
                    audioDict.Add(audioName, audioPath);
                }
                
            }

        }




    }

}
