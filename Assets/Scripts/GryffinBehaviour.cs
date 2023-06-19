using TMPro;
using UnityEngine;

public class GryffinBehaviour : MonoBehaviour
{
    [Header("Gryffin Stats:")]
    public int Hunger = 10;
    public int Energy = 10;
    public int Hygiene = 10;
    public int Attention = 10;
    public int Health = 10;

    [Header("HungerTime Manager:")]
    public float HungerTimer = 35f;
    public bool HungerTimed = false;

    [Header("EnergyTime Manager:")]
    public float EnergyTimer = 30f;
    public bool EnergyTimed = false;

    [Header("HygieneTime Manager:")]
    public float HygieneTimer = 25f;
    public bool HygieneTimed = false;

    [Header("AttentionTime Manager:")]
    public float AttentionTimer = 30f;
    public bool AttentionTimed = false;

    private float HealthTimer = 10f;
    private bool HealthTimed = false;
    private float IncreaseHealth = 5f;
    private bool IncreaseHealthTimed = false;

    [Header("Display Manager:")]
    public TMP_Text HungerDisplay;
    public TMP_Text EnergyDisplay;
    public TMP_Text AttentionDisplay;
    public TMP_Text HealthDisplay;
    public TMP_Text HygieneDisplay;

    [Header("The Gryffin:")]
    public GameObject Gryffin;

    private void Start()
    {
        HungerTimed = true;
        EnergyTimed = true;
        AttentionTimed = true;
        HygieneTimed = true;
    }

    private void Update()
    {
        HungerMeter();
        HealthMeter();
        EnergyMeter();
        AttentionMeter();
        HygieneMeter();

        HungerDisplay.text = Hunger.ToString();
        EnergyDisplay.text = Energy.ToString();
        AttentionDisplay.text = Attention.ToString();
        HealthDisplay.text = Health.ToString();
        HygieneDisplay.text = Hygiene.ToString();
    }
    void HungerMeter()
    {
        if (HungerTimed == true)
        {
            if (HungerTimer > 0)
            {
                HungerTimer -= Time.deltaTime;
            }
            else
            {
                HungerTimer = 0;
                HungerTimed = false;
                Hunger -= 1;
            }
        }
        if (Hunger != 0)
        {
            if (HungerTimer == 0)
            {
                HungerTimed = true;
                HungerTimer = 30;
            }
        }
    }

    void EnergyMeter()
    {
        if (EnergyTimed == true)
        {
            if (EnergyTimer > 0)
            {
                EnergyTimer -= Time.deltaTime;
            }
            else
            {
                EnergyTimer = 0;
                EnergyTimed = false;
                Energy -= 1;
            }
        }
        if (Energy != 0)
        {
            if (EnergyTimer == 0)
            {
                EnergyTimed = true;
                EnergyTimer = 30;
            }
        }
    }

    void AttentionMeter()
    {
        if (AttentionTimed == true)
        {
            if (AttentionTimer > 0)
            {
                AttentionTimer -= Time.deltaTime;
            }
            else
            {
                AttentionTimer = 0;
                AttentionTimed = false;
                Attention -= 1;
            }
        }
        if (Attention != 0)
        {
            if (AttentionTimer == 0)
            {
                AttentionTimed = true;
                AttentionTimer = 30;
            }
        }
    }

    void HygieneMeter()
    {
        if (HygieneTimed == true)
        {
            if (HygieneTimer > 0)
            {
                HygieneTimer -= Time.deltaTime;
            }
            else
            {
                HygieneTimer = 0;
                HygieneTimed = false;
                Hygiene -= 1;
            }
        }
        if (Hygiene != 0)
        {
            if (HygieneTimer == 0)
            {
                HygieneTimed = true;
                HygieneTimer = 25;
            }
        }
    }

    void HealthMeter()
    {
        if (Hunger <= 4)
        {
            if (Energy <= 4)
            {
                if (Attention <= 4)
                {
                    if (Hygiene <= 4)
                    {
                        if (Health != 0)
                        {
                            HealthTimed = true;
                            if (HealthTimer == 0)
                            {
                                HealthTimed = true;
                                HealthTimer = 10;
                            }
                        }
                    }
                }
            }
        }

        if (Health == 0)
        {
            Gryffin.SetActive(false);
            this.gameObject.SetActive(false);
        }

        if (HealthTimed == true)
        {
            if (HealthTimer > 0)
            {
                HealthTimer -= Time.deltaTime;
            }
            else
            {
                HealthTimer = 0;
                HealthTimed = false;
                Health -= 1;
            }
        }

        if (Hunger == 10)
        {
            if (Hygiene == 10)
            {
                if (Attention == 10)
                {
                    if (Energy == 10)
                    {
                        if (Health != 10)
                        {
                            IncreaseHealthTimed = true;
                            if (IncreaseHealth == 0)
                            {
                                IncreaseHealthTimed = true;
                                IncreaseHealth = 5;
                            }
                        }
                    }
                }
            }
        }

        if (IncreaseHealthTimed == true)
        {
            if (IncreaseHealth > 0)
            {
                IncreaseHealth -= Time.deltaTime;
            }
            else
            {
                IncreaseHealth = 0;
                IncreaseHealthTimed = false;
                Health += 1;
            }
        }
    }
}
