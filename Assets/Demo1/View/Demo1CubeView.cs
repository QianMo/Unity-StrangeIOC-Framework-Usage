//-------------------------------------------------------------------------------------
//	Demo1CubeView.cs
//
//	Created by 浅墨
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections.Generic;

public class Demo1CubeView : View
{

    private Text scoreText=null;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    [Inject]
    public AudioManager AudioManagerInstance { get; set; }

    public void Init()
    {
        Debug.Log("Init~!");
        scoreText = GetComponentInChildren<Text>();
        Debug.Log(AudioManagerInstance);

    }
    protected override void Awake()
    {

    }

    void Update()
    {
        //Debug.Log("Updata~!");
        transform.Translate(new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), Random.Range(-2, 3)) *0.02f);
    }



    void OnMouseDown()
    {
        Debug.Log("OnMouseDown~!");
        //通过dispatcher，发起请求分数的命令
        dispatcher.Dispatch(Demo1Event.ClickDown_Mediator);


        //测试-dispatch多个参数
        List<object> listData = new List<object>();
        listData.Add("heelo");
        listData.Add(true);
        listData.Add(12356);
        listData.Add(0.6666f);
        dispatcher.Dispatch(Demo1Event.ClickDown_Mediator_Test, listData);


        //
        AudioManagerInstance.Play("Ding");

    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
