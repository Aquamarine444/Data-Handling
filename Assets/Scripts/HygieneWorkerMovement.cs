using TMPro;
using UnityEngine;

public class HygieneWorkerMovement : MonoBehaviour
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
            if (DragonCare.Hygiene != 7)
            {
                DragonCare.Hygiene += 1;
                if (DragonCare.Energy != 0)
                {
                    DragonCare.Energy -= 1;
                }
                if (DragonCare.Attention != 7)
                {
                    DragonCare.Attention += 1;
                }
                DisplayMessage.text = "Dragon received +1 Hygiene." + "\n" +
                 "Dragon lost -1 Energy." + "\n" +
                 "Dragon received +1 Attention.";
                DragonCare.HygieneTimed = false;
                if (DragonCare.HygieneTimed == false)
                {
                    DragonCare.HygieneTimed = true;
                    DragonCare.HygieneTimer = 25;
                }
            }
        }

        if (other.gameObject.name == "btn_Pheonix")
        {
            if (PheonixCare.Hygiene != 5)
            {
                PheonixCare.Hygiene += 1;
                if (PheonixCare.Hunger != 0)
                {
                    PheonixCare.Hunger -= 1;
                }
                if (PheonixCare.Attention != 5)
                {
                    PheonixCare.Attention += 1;
                }
                DisplayMessage.text = "Pheonix received +1 Hygiene." + "\n" +
                    "Pheonix lost -1 Hunger." + "\n" +
                    "Pheonix received +1 Attention.";
                PheonixCare.HygieneTimed = false;
                if (PheonixCare.HygieneTimed == false)
                {
                    PheonixCare.HygieneTimed = true;
                    PheonixCare.HygieneTimer = 40;
                }
            }
        }

        if (other.gameObject.name == "btn_Gryffin")
        {
            if (GryffinCare.Hygiene != 10)
            {
                GryffinCare.Hygiene += 1;
                if (GryffinCare.Hunger != 0)
                {
                    GryffinCare.Hunger -= 1;
                }
                if (GryffinCare.Energy != 10)
                {
                    GryffinCare.Energy += 1;
                }
                DisplayMessage.text = "Gryffin received +1 Hygiene." + "\n" +
                    "Gryffin became hungrier -1 Hunger." + "\n" +
                    "Gryffin got +1 Energy." + "\n";
                GryffinCare.HygieneTimed = false;
                if (GryffinCare.HygieneTimed == false)
                {
                    GryffinCare.HygieneTimed = true;
                    GryffinCare.HygieneTimer = 25;
                }
            }
        }
    }
}
