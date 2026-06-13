using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tugas_5 : MonoBehaviour
{
    [Header("HP UI")]
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI StatusText;
    public Button DamageButton;
    public Button HealButton;
    public Image EffectImage;

    [Header("HP Settings")]
    public int MaxHp = 100;
    public int DamageAmount = 10;
    public int HealAmount = 10;

    [Header("Effect Settings")]
    public float DamageAlpha = 0.6f;
    public float HealAlpha = 0.4f;
    public float LowHpAlpha = 0.2f;
    public float FadeSpeed = 2.5f;

    [Header("Ammo UI")]
    public TextMeshProUGUI AmmoText;
    public Button ShootButton;
    public Button ReloadButton;

    [Header("Ammo Settings")]
    public int MaxAmmo = 10;

    private int CurrentHp;
    private int CurrentAmmo;

    private Color CurrentEffectColor;
    private float CurrentAlpha;
    private float TargetAlpha;

    private void Start()
    {
        CurrentHp = MaxHp;
        CurrentAmmo = MaxAmmo;

        CurrentEffectColor = Color.red;
        CurrentAlpha = 0f;
        TargetAlpha = 0f;

        DamageButton.onClick.AddListener(TakeDamage);
        HealButton.onClick.AddListener(Heal);

        ShootButton.onClick.AddListener(Shoot);
        ReloadButton.onClick.AddListener(Reload);

        UpdateUI();
        UpdateStatus("Game Dimulai");
    }

    private void Update()
    {
        if (CurrentAlpha > TargetAlpha)
        {
            CurrentAlpha -= FadeSpeed * Time.deltaTime;

            if (CurrentAlpha < TargetAlpha)
                CurrentAlpha = TargetAlpha;

            UpdateEffect();
        }
        else if (CurrentAlpha < TargetAlpha)
        {
            CurrentAlpha += FadeSpeed * Time.deltaTime;

            if (CurrentAlpha > TargetAlpha)
                CurrentAlpha = TargetAlpha;

            UpdateEffect();
        }
    }

    private void TakeDamage()
    {
        CurrentHp -= DamageAmount;

        if (CurrentHp < 0)
            CurrentHp = 0;

        CurrentEffectColor = Color.red;
        CurrentAlpha = DamageAlpha;

        TargetAlpha = IsLowHp() ? LowHpAlpha : 0f;

        if (CurrentHp <= 0)
            UpdateStatus("Player Kalah");
        else
            UpdateStatus("Player Terkena Damage");

        UpdateUI();
        UpdateEffect();
    }

    private void Heal()
    {
        CurrentHp += HealAmount;

        if (CurrentHp > MaxHp)
            CurrentHp = MaxHp;

        CurrentEffectColor = Color.green;
        CurrentAlpha = HealAlpha;

        TargetAlpha = IsLowHp() ? LowHpAlpha : 0f;

        UpdateStatus("Player Mendapat Heal");

        UpdateUI();
        UpdateEffect();
    }

    private void Shoot()
    {
        if (CurrentAmmo <= 0)
            return;

        CurrentAmmo--;

        UpdateStatus("Menembak");

        UpdateUI();
    }

    private void Reload()
    {
        CurrentAmmo = MaxAmmo;

        UpdateStatus("Reload Ammo");

        UpdateUI();
    }

    private void UpdateUI()
    {
        string hpColor = "white";

        if (CurrentHp <= MaxHp * 0.25f)
            hpColor = "red";
        else if (CurrentHp <= MaxHp * 0.5f)
            hpColor = "yellow";

        HpText.text = "HP : <color=" + hpColor + ">" + CurrentHp + "</color>/" + MaxHp;

        AmmoText.text = "Ammo : " + CurrentAmmo + "/" + MaxAmmo;

        DamageButton.interactable = CurrentHp > 0;
        HealButton.interactable = CurrentHp < MaxHp;

        ShootButton.interactable = CurrentAmmo > 0;
        ReloadButton.interactable = CurrentAmmo < MaxAmmo;
    }

    private void UpdateEffect()
    {
        Color color = CurrentEffectColor;
        color.a = CurrentAlpha;
        EffectImage.color = color;
    }

    private void UpdateStatus(string text)
    {
        StatusText.text = text;
    }

    private bool IsLowHp()
    {
        return CurrentHp <= MaxHp * 0.25f;
    }

    private void OnDestroy()
    {
        DamageButton.onClick.RemoveListener(TakeDamage);
        HealButton.onClick.RemoveListener(Heal);

        ShootButton.onClick.RemoveListener(Shoot);
        ReloadButton.onClick.RemoveListener(Reload);
    }
}