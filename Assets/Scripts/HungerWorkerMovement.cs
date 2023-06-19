using TMPro;
using UnityEngine;

public class HungerWorkerMovement : MonoBehaviour
{
    [Header("The Creatures: ")]
    public GameObject Dragon;
    private DragonBehaviour DragonCare;
    public GameObject Pheonix;
    private PheonixBehaviour PheonixCare;
    public GameObject Gryffin;
    private GryffinBehaviour GryffinCare;

    [Header("Other: ")]
    public TMP_Text DisplayMessage;
    public RectTransform rectTransform;
    Vector3 offset;

    private void Start()
    {
        DragonCare = Dragon.GetComponent<DragonBehaviour>();
        PheonixCare = Pheonix.GetComponent<PheonixBehaviour>();
        GryffinCare = Gryffin.GetComponent<GryffinBehaviour>();
    }
    public void GetOffset()
    {
        offset = rectTransform.position - Input.mousePosition;
    }
    public void MoveObject()
    {
        rectTransform.position = Input.mousePosition + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "btn_Dragon")
        {
            if (DragonCare.Hunger != 7)
            {
                DragonCare.Hunger += 1;
                if (DragonCare.Energy != 7)
                {
                    DragonCare.Energy += 1;
                }
                if (DragonCare.Hygiene != 0)
                {
                    DragonCare.Hygiene -= 1;
                }
                DisplayMessage.text = "Dragon received +1 Hunger ." + "\n" +
                 "Dragon received +1 Energy." + "\n" +
                 "Dragon lost -1 Hygiene.";
                DragonCare.HungerTimed = false;
                if (DragonCare.HungerTimed == false)
                {
                    DragonCare.HungerTimed = true;
                    DragonCare.HungerTimer = 30;
                }
            }
        }

        if (other.gameObject.name == "btn_Pheonix")
        {
            if (PheonixCare.Hunger != 5)
            {
                PheonixCare.Hunger += 1;
                if (PheonixCare.Hygiene != 0)
                {
                    PheonixCare.Hygiene -= 1;
                }
                if (PheonixCare.Attention != 5)
                {
                    PheonixCare.Attention += 1;
                }
                if (PheonixCare.Energy != 7)
                {
                    PheonixCare.Energy += 1;
                }
                DisplayMessage.text = "Pheonix received +1 Hunger." + "\n" +
                    "Pheonix lost -1 Hygiene." + "\n" +
                    "Pheonix received +1 Attention." + "\n" 
                    + " Pheonix received +1 Energy";
                PheonixCare.HungerTimed = false;
                if (PheonixCare.HungerTimed == false)
                {
                    PheonixCare.HungerTimed = true;
                    PheonixCare.HungerTimer = 30;
                }
            }
        }

        if (other.gameObject.name == "btn_Gryffin")
        {
            if (GryffinCare.Hunger != 10)
            {
                GryffinCare.Hunger += 1;
                if (GryffinCare.Hygiene != 0)
                {
                    GryffinCare.Hygiene -= 2;
                }
                if (GryffinCare.Energy != 10)
                {
                    GryffinCare.Energy += 1;
                }
                DisplayMessage.text = "Gryffin received +1 Hunger." + "\n" +
                    "Gryffin became dirtier -2 Hygiene." + "\n" +
                    "Gryffin got +1 Energy." + "\n";
                GryffinCare.HungerTimed = false;
                if (GryffinCare.HungerTimed == false)
                {
                    GryffinCare.HungerTimed = true;
                    GryffinCare.HungerTimer = 35;
                }
            }
        }
    }
}
