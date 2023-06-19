using TMPro;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public TMP_Text EndMessage;
    public TMP_Text WorkerMessage;
    public GameObject EndScreen;
    [Header("Daytime Manager:")]
    public float DayTimer = 240;
    public bool DayTimed;
    public TMP_Text DayText;
    public TMP_Text DayCounterDisplay;
    private int DayCounter = 1;

    [Header("Hygiene Manager:")]
    public float ActiveHygieneTimer = 60;
    public bool HygieneTimerActivated = false;
    public float RestartHygieneTimer = 180f;
    public bool HygieneTimerRestarted = false;
    public GameObject HygieneWorker;

    [Header("Attention Manager:")]
    public float AttentionTimer = 60f;
    public bool AttentionWorkerTimed = false;
    public float ActiveAttentionTimer = 60;
    public bool AttentionTimerActivated = false;
    public float RestartAttentionTimer = 180f;
    public bool AttentionTimerRestarted = false;
    public GameObject AttentionWorker;

    [Header("Hunger Manager:")]
    public float HungerTimer = 120f;
    public bool HungerWorkerTimed = false;
    public float ActiveHungerTimer = 60;
    public bool HungerTimerActivated = false;
    public float RestartHungerTimer = 180f;
    public bool HungerTimerRestarted = false;
    public GameObject HungerWorker;

    [Header("Energy Manager:")]
    public float EnergyTimer = 180f;
    public bool EnergyWorkerTimed = false;
    public float ActiveEnergyTimer = 60;
    public bool EnergyTimerActivated = false;
    public float RestartEnergyTimer = 180f;
    public bool EnergyTimerRestarted = false;
    public GameObject EnergyWorker;

    [Header("The Creatures: ")]
    public GameObject Dragon;
    private DragonBehaviour DragonCare;

    public GameObject Pheonix;
    private PheonixBehaviour PheonixCare;

    public GameObject Gryffin;
    private GryffinBehaviour GryffinCare;

    private void Start()
    {
        DayTimed = true;
        HygieneWorker.SetActive(true);
        WorkerMessage.text = "Worker on Shift: HygieneWorker";
        HygieneTimerActivated = true;
        AttentionWorkerTimed = true;
        HungerWorkerTimed = true;
        EnergyWorkerTimed = true;

        DragonCare = Dragon.GetComponent<DragonBehaviour>();
        PheonixCare = Pheonix.GetComponent<PheonixBehaviour>();
        GryffinCare = Gryffin.GetComponent<GryffinBehaviour>();
    }

    private void Update()
    {
        if (DayTimed == true)
        {
            if (DayTimer > 0)
            {
                DayTimer -= Time.deltaTime;
                DayText.text = (DayTimer).ToString("0");
            }
            else
            {
                DayTimer = 0;
                DayTimed = false;
                Debug.Log("Day is over");

                if (DayTimer == 0)
                {
                    HygieneWorker.SetActive(true);
                    WorkerMessage.text = "Worker on Shift: HygieneWorker";
                    DayTimed = true;
                    DayTimer = 240;
                    DayCounter += 1;
                    DayCounterDisplay.text = (DayCounter).ToString("0");
                }
            }
        }
        HygieneManager();
        AttentionManager();
        HungerManager();
        EnergyManager();

        if (DragonCare.Health == 0)
        {
            EndScreen.SetActive(true);
            EndMessage.text = "An animal(s) died." + "\n" + "You have survived " + DayCounter.ToString("0") + " day(s)";
            this.gameObject.SetActive(false);
        }

        if (PheonixCare.Health == 0)
        {
            EndScreen.SetActive(true);
            EndMessage.text = "An animal(s) died." + "\n" + "You have survived " + DayCounter.ToString("0") + " day(s)";
            this.gameObject.SetActive(false);
        }

        if (GryffinCare.Health == 0)
        {
            EndScreen.SetActive(true);
            EndMessage.text = "An animal(s) died." + "\n" + "You have survived " + DayCounter.ToString("0") + " day(s)";
            this.gameObject.SetActive(false);
        }

    }

    void HygieneManager()
    {
        if (HygieneTimerActivated == true)
        {
            if (ActiveHygieneTimer > 0)
            {
                ActiveHygieneTimer -= Time.deltaTime;
            }
            else
            {
                ActiveHygieneTimer = 0;
                HygieneTimerActivated = false;
                HygieneTimerRestarted = true;
                RestartHygieneTimer = 180f;
                HygieneWorker.SetActive(false);
                //WorkerMessage.text = "HygieneWorker has left for the day";
            }
        }
        if (HygieneTimerRestarted == true)
        {
            if (RestartHygieneTimer > 0)
            {
                RestartHygieneTimer -= Time.deltaTime;
            }
            else
            {
                RestartHygieneTimer = 0;
                HygieneTimerRestarted = false;
                HygieneTimerActivated = true;
                ActiveHygieneTimer = 60f;
                HygieneWorker.SetActive(true);
                WorkerMessage.text = "Worker on Shift: HygieneWorker";
            }
        }
    }

    void AttentionManager()
    {
        if (AttentionWorkerTimed == true)
        {
            if (AttentionTimer > 0)
            {
                AttentionTimer -= Time.deltaTime;
            }
            else
            {
                AttentionTimer = 0;
                AttentionWorkerTimed = false;
                AttentionTimerActivated = true;
                ActiveAttentionTimer = 60;
                AttentionWorker.SetActive(true);
                WorkerMessage.text = "Worker on Shift: AttentionWorker";
            }
        }
        if (AttentionTimerActivated == true)
        {
            if (ActiveAttentionTimer > 0)
            {
                ActiveAttentionTimer -= Time.deltaTime;
            }
            else
            {
                ActiveAttentionTimer = 0;
                AttentionTimerActivated = false;
                AttentionTimerRestarted = true;
                RestartAttentionTimer = 180f;
                AttentionWorker.SetActive(false);
                //WorkerMessage.text = "AttentionWorker has left for the day";
            }
        }
        if (AttentionTimerRestarted == true)
        {
            if (RestartAttentionTimer > 0)
            {
                RestartAttentionTimer -= Time.deltaTime;
            }
            else
            {
                RestartAttentionTimer = 0;
                AttentionTimerRestarted = false;
                AttentionTimerActivated = true;
                ActiveAttentionTimer = 60f;
                AttentionWorker.SetActive(true);
                WorkerMessage.text = "Worker on Shift: AttentionWorker";
            }
        }
    }

    void HungerManager()
    {
        if (HungerWorkerTimed == true)
        {
            if (HungerTimer > 0)
            {
                HungerTimer -= Time.deltaTime;
            }
            else
            {
                HungerTimer = 0;
                HungerWorkerTimed = false;
                HungerTimerActivated = true;
                ActiveHungerTimer = 60;
                HungerWorker.SetActive(true);
            }
        }
        if (HungerTimerActivated == true)
        {
            if (ActiveHungerTimer > 0)
            {
                ActiveHungerTimer -= Time.deltaTime;
            }
            else
            {
                ActiveHungerTimer = 0;
                HungerTimerActivated = false;
                HungerTimerRestarted = true;
                RestartHungerTimer = 180f;
                HungerWorker.SetActive(false);
                //WorkerMessage.text = "HungerWorker has left for the day";
            }
        }
        if (HungerTimerRestarted == true)
        {
            if (RestartHungerTimer > 0)
            {
                RestartHungerTimer -= Time.deltaTime;
            }
            else
            {
                RestartHungerTimer = 0;
                HungerTimerRestarted = false;
                HungerTimerActivated = true;
                ActiveHungerTimer = 60f;
                HungerWorker.SetActive(true);
                WorkerMessage.text = "Worker on Shift: HungerWorker";
            }
        }
    }

    void EnergyManager()
    {
        if (EnergyWorkerTimed == true)
        {
            if (EnergyTimer > 0)
            {
                EnergyTimer -= Time.deltaTime;
            }
            else
            {
                EnergyTimer = 0;
                EnergyWorkerTimed = false;
                EnergyTimerActivated = true;
                ActiveEnergyTimer = 60;
                EnergyWorker.SetActive(true);
                WorkerMessage.text = "Worker on Shift: EnergyWorker";
            }
        }
        if (EnergyTimerActivated == true)
        {
            if (ActiveEnergyTimer > 0)
            {
                ActiveEnergyTimer -= Time.deltaTime;
            }
            else
            {
                ActiveEnergyTimer = 0;
                EnergyTimerActivated = false;
                EnergyTimerRestarted = true;
                RestartEnergyTimer = 180f;
                EnergyWorker.SetActive(false);
                Debug.Log("Doctor has left for the day");
            }
        }
        if (EnergyTimerRestarted == true)
        {
            if (RestartEnergyTimer > 0)
            {
                RestartEnergyTimer -= Time.deltaTime;
            }
            else
            {
                RestartEnergyTimer = 0;
                EnergyTimerRestarted = false;
                EnergyTimerActivated = true;
                ActiveEnergyTimer = 60f;
                EnergyWorker.SetActive(true);
                WorkerMessage.text = "Worker on Shift: EnergyWorker";
            }
        }
    }
}
