using TMPro;

using UnityEngine;

using UnityEngine.UI;

 

public class VR01_P5_Latihan3 : MonoBehaviour

{

    public int MaxAmmo, CurrentAmmo;

    public TextMeshProUGUI TextAmmo;

    public Button ButtonShoot, ButtonReaload;

 

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        CurrentAmmo = MaxAmmo;

        TextAmmo.text = CurrentAmmo + "/" + MaxAmmo;

 

        ButtonShoot.onClick.AddListener(Shoot);

        ButtonReaload.onClick.AddListener(Reload);

    }

 

    public void Shoot() 

    {

        CurrentAmmo = CurrentAmmo - 1;

        TextAmmo.text = CurrentAmmo + "/" + MaxAmmo;

 

        if (CurrentAmmo == 0)

        {

            ButtonShoot.interactable = false;

        }

    }

 

    public void Reload() 

    {

        CurrentAmmo = MaxAmmo;

        TextAmmo.text = CurrentAmmo + "/" + MaxAmmo;

        ButtonShoot.interactable = true;

    }

 

 

}