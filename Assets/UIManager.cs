using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoText.text = 20.ToString();
    }

    public void UpdateAmmoCount(int playerAmmo) 
    {
        ammoText.text = playerAmmo.ToString();
    }
}
