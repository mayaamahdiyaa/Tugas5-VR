using System;

using TMPro;

using UnityEngine;

using UnityEngine.UI;

 

public class VR01_P5_Latihan4 : MonoBehaviour

{

    public Image Gambar;

    public Button ButtonPrev, ButtonNext;

    public TextMeshProUGUI TeksHalaman;

 

    public int MaxPage = 3;

    private int currentPage;

    public Sprite[] KumpulanGambar;

 

    private void Start()

    {

        Initialize();

    }

 

    private void Initialize()

    {

        currentPage = 1;

        TeksHalaman.text = currentPage + "/" + MaxPage;

        Gambar.sprite = KumpulanGambar[currentPage-1];

        ButtonNext.onClick.AddListener(OnNextButtonPressed);

    }

 

    public void OnNextButtonPressed() 

    {

        currentPage = currentPage + 1;

        TeksHalaman.text = currentPage + "/" + MaxPage;

        Gambar.sprite = KumpulanGambar[currentPage - 1];

 

        if (currentPage == MaxPage)

        {

            ButtonNext.gameObject.SetActive(false);

        }

 

    }

}