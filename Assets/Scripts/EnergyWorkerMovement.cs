using TMPro;
using UnityEngine;

public class EnergyWorkerMovement : MonoBehaviour
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
            if (DragonCare.Energy != 7)
            {
                DragonCare.Energy += 1;
                if (DragonCare.Hunger != 0)
                {
                    DragonCare.Hunger -= 2;
                }
                DisplayMessage.text = "Dragon received +1 Energy." + "\n" +
                 "Dragon lost -2 Hunger." + "\n";
                DragonCare.EnergyTimed = false;
                if (DragonCare.EnergyTimed == false)
                {
                    DragonCare.EnergyTimed = true;
                    DragonCare.EnergyTimer = 40;
                }
            }
        }

        if (other.gameObject.name == "btn_Pheonix")
        {
            if (PheonixCare.Energy != 5)
            {
                PheonixCare.Energy += 1;
                if (PheonixCare.Hunger != 0)
                {
                    PheonixCare.Hunger -= 1;
                }
                if (PheonixCare.Attention != 0)
                {
                    PheonixCare.Attention -= 1;
                }
                if (PheonixCare.Hygiene != 0)
                {
                    PheonixCare.Hygiene -= 1;
                }
                DisplayMessage.text = "Pheonix received +1 Energy." + "\n" +
                    "Pheonix lost -1 Hunger." + "\n" + "Pheonix lost -1 Attention" + "\n" +
                    "Pheonix lost -1 Hygiene.";
                PheonixCare.EnergyTimed = false;
                if (PheonixCare.EnergyTimed == false)
                {
                    PheonixCare.EnergyTimed = true;
                    PheonixCare.EnergyTimer = 30;
                }
            }
        }

        if (other.gameObject.name == "btn_Gryffin")
        {
            if (GryffinCare.Energy != 10)
            {
                GryffinCare.Energy += 1;
                if (GryffinCare.Hunger != 0)
                {
                    GryffinCare.Hunger -= 1;
                }
                if (GryffinCare.Attention != 0)
                {
                    GryffinCare.Attention -= 2;
                }
                DisplayMessage.text = "Gryffin received +1 Energy." + "\n" +
                    "Gryffin became hungrier -1 Hunger." + "\n" +
                    "Gryffin lost -2 Attention." + "\n";
                GryffinCare.EnergyTimed = false;
                if (GryffinCare.EnergyTimed == false)
                {
                    GryffinCare.EnergyTimed = true;
                    GryffinCare.EnergyTimer = 30;
                }
            }
        }
    }
}
