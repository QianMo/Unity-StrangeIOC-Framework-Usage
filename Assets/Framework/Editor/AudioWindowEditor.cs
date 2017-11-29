//-------------------------------------------------------------------------------------
//	AudioWindowEditor.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEditor;

public class AudioWindowEditor : EditorWindow
{

    [MenuItem("test/test1")]
    static void CreateWindow()
    {
        Rect rect = new Rect(400, 400, 400, 400);
        AudioWindowEditor window = EditorWindow.GetWindowWithRect(typeof(AudioWindowEditor), rect) as AudioWindowEditor;
        window.Show();
    }

}
