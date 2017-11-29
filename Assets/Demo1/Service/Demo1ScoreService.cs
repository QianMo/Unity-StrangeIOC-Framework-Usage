using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class Demo1ScoreService : Demo1IScoreService 
{

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public int OnReceiveScore()
    {
        int score = UnityEngine.Random.Range(0, 100);
        dispatcher.Dispatch(Demo1Event.RequestScore_Service,score);
        return score;
    }

    void Demo1IScoreService.RequestScore(string url)
    {
        Debug.Log("RequestScore from : " + url);
        OnReceiveScore();
    }

    void Demo1IScoreService.UpdataScore(string url, int score)
    {
        Debug.Log("Update score to url : "+url +"new score :"+score.ToString());
    }



}
