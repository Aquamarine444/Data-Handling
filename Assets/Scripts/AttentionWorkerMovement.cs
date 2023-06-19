using TMPro;
using UnityEngine;

public class AttentionWorkerMovement : MonoBehaviour
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
            if (DragonCare.Attention != 7)
            {
                DragonCare.Attention += 1;
                if (DragonCare.Energy != 0)
                {
                    DragonCare.Energy -= 1;
                }
                if (DragonCare.Hunger != 0)
                {
                    DragonCare.Hunger -= 1;
                }
                DisplayMessage.text = "Dragon received +1 Attention." + "\n" +
                 "Dragon lost -1 Energy." + "\n" +
                 "Dragon lost -1 Hunger.";
                DragonCare.AttentionTimed = false;
                if (DragonCare.AttentionTimed == false)
                {
                    DragonCare.AttentionTimed = true;
                    DragonCare.AttentionTimer = 35;
                }
            }
        }

        if (other.gameObject.name == "btn_Pheonix")
        {
            if (PheonixCare.Attention != 5)
            {
                PheonixCare.Attention += 1;
                if (PheonixCare.Hunger != 0)
                {
                    PheonixCare.Hunger -= 1;
                }
                if (PheonixCare.Energy != 5)
                {
                    PheonixCare.Energy += 1;
                }
                DisplayMessage.text = "Pheonix received +1 Attention." + "\n" +
                    "Pheonix lost -1 hunger." + "\n" +
                    "Pheonix received +1 Energy.";
                PheonixCare.AttentionTimed = false;
                if (PheonixCare.AttentionTimed == false)
                {
                    PheonixCare.AttentionTimed = true;
                    PheonixCare.AttentionTimer = 20;
                }
            }
        }

        if (other.gameObject.name == "btn_Gryffin")
        {
            if (GryffinCare.Attention != 10)
            {
                GryffinCare.Attention += 1;
                if (GryffinCare.Hunger != 0)
                {
                    GryffinCare.Hunger -= 2;
                }
                if (GryffinCare.Energy != 10)
                {
                    GryffinCare.Energy += 1;
                }
                if (GryffinCare.Hygiene != 0)
                {
                    GryffinCare.Hygiene -= 1;
                }
                DisplayMessage.text = "Gryffin received +1 Attention." + "\n" +
                    "Gryffin became hungrier - 2 Hunger." + "\n" + "Gryffin receive +1 Energy" + "\n" +
                    "Gryffin got dirty -1 Hygiene." + "\n";
                GryffinCare.AttentionTimed = false;
                if (GryffinCare.AttentionTimed == false)
                {
                    GryffinCare.AttentionTimed = true;
                    GryffinCare.AttentionTimer = 30;
                }
            }
        }
    }
}

