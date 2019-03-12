using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashCanvas : MonoBehaviour
{
	public CanvasGroup cg;
	public bool flash = false;

	void Update ()
	{
		if (flash)
		{
			cg.alpha = cg.alpha - Time.deltaTime;
			if (cg.alpha <= 0)
			{
				cg.alpha = 0;
				flash = false;
			}
		}
	}
	public void playerDamaged()
	{
		flash = true;
		cg.alpha = 1;
	}
}
