using System;
using UnityEngine;


namespace hamburgames.unity.spacewarriors
{

	[Implements(typeof(IScreenUtil))]
	public class ScreenUtil : IScreenUtil
	{
		public bool IsInCamera(GameObject go)
		{
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
			return GeometryUtility.TestPlanesAABB(planes, go.GetComponent<Renderer>().bounds);
		}


		public Vector3 BottomCenter
		{
			get
			{
				Vector3 bottomCenter = new Vector3((Screen.width / 2) * 1f, 0f, 10f);
				bottomCenter = Camera.main.ScreenToWorldPoint(bottomCenter);
				return bottomCenter;
			}
		}

		public Vector3 maxBound
		{
			get { return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1f, Screen.height * 1f, 10f)); }
		}

	}
}