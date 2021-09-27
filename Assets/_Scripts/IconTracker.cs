using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconTracker : MonoBehaviour
{
    public static IconTracker it;
    public List<Image> Gems = new List<Image>();
    public Image vent;
    

    void Start()
    {
        if(it == null)
            it = gameObject.GetComponent<IconTracker>();
    }

    public void changeGemAlpha(int element)
    {
        Gems[element-1].color = Color.white;
    }

        public void changeVentAlpha()
    {
        vent.color = Color.white;
    }

}
