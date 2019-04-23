using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    public float time = 100;
    private float timeburn = 1f;

    private void Awake()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update ()
    {
        if (!player)
            return;

        if (time > 0)
        {
            time -= timeburn * Time.deltaTime;
            slider.value = time;
        } else
        {
            Destroy(player);
        }
	}

    void GetReferences()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("TimeSlider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = time;
        slider.value = slider.maxValue;
    }
}
