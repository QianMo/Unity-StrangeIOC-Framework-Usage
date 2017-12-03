using System;
using UnityEngine;
using strange.extensions.pool.api;


public interface ISWPool<T> : IPool where T : PoolableView
{
	// If you ask yourself wtf is that 'new' keyword so here is the answer.
	// http://stackoverflow.com/questions/19193821/use-the-new-keyword-if-hiding-was-intended-warning
	new T GetInstance();
}


