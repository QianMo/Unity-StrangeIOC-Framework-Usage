using System;
using UnityEngine;
using System.Collections;

public interface IRoutineRunner
{
	Coroutine StartCoroutine(IEnumerator method);
}


