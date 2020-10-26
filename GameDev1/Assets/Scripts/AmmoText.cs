using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public IntData ammoCount, maxAmmoCount;
    private Text t;

    private void Start()
    {
        t = GetComponent<Text>();
    }

    private void Update()
    {
        t.text = "Ammo: " + ammoCount.value + "/" + maxAmmoCount.value;
        if (ammoCount.value <= 0)
        {
            t.text = "Reloading. . . ";
        }
        else
        {
            t.text = "Ammo: " + ammoCount.value + "/" + maxAmmoCount.value;
        }
    }
}
