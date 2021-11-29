using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryController : MonoBehaviour
{
    public Slider hungrySlider;

    public static float hungry;
    float maxHungry = 100f;

    void Start()
    {
        hungry = maxHungry;
    }

    void Update()
    {
        hungrySlider.value = hungry;

        Debug.Log(hungry);

        if (hungry >= 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                hungry -= 10f * Time.deltaTime;

            }
        
            if(Input.GetKey(KeyCode.A)){

                hungry -= 2 * Time.deltaTime;

            }

            if(Input.GetKey(KeyCode.D)){

                hungry -= 2 * Time.deltaTime;

            }

        }
        
    }


}
