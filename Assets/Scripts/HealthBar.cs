using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Player player;
	// Use this for initialization

	
	// Update is called once per frame
	void Update ()
	{
        slider.value = player.CurrentHitPoints;
	}
}
