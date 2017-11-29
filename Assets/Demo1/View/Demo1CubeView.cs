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

public class Demo1CubeView : View
{

    private Text scoreText=null;

    //全局dispatcher
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    public void Init()
    {
        Debug.Log("Init~!");
        scoreText = GetComponentInChildren<Text>();
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
        dispatcher.Dispatch(Demo1Event.RequestScore_Command);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
