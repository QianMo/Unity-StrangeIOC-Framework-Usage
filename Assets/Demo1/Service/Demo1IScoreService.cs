using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public interface Demo1IScoreService
{
    //请求分数
    void RequestScore(string url);

    //收到服务器发送过来的分数
    int OnReceiveScore();

    //
    void UpdataScore(string url, int score);

    IEventDispatcher dispatcher { get; set; }

}
