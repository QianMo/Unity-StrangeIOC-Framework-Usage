using System;
using UnityEngine;
using System.Collections;
using strange.extensions.injector.api;
using strange.extensions.context.api;

namespace hamburgames.unity.spacewarriors
{


	[Implements(typeof(IRoutineRunner), InjectionBindingScope.CROSS_CONTEXT)]
	public class RoutineRunner : IRoutineRunner
	{

		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{ get; set; }

		private RoutineRunnerBehaviour mb;


		[PostConstruct]
		public void PostConstruct()
		{
			mb = contextView.AddComponent<RoutineRunnerBehaviour>();
		}


		public Coroutine StartCoroutine(IEnumerator routine)
		{
			return mb.StartCoroutine(routine);
		}

	}


	public class RoutineRunnerBehaviour : MonoBehaviour
	{
	
	}

}