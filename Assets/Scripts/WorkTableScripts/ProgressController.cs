using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MyBaseBehaviour
{
       [SerializeField] private GameObject unlockProgressObj;
       [SerializeField] private Image progressBar;
       [SerializeField] private TextMeshProUGUI dollarAmount;
       [SerializeField] private int deskPrice,deskRemainPrice;
       [SerializeField] private float ProgressValue;
    
    void Start()
    {
        dollarAmount.text = deskPrice.ToString();
        deskRemainPrice = deskPrice;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("money") > 0)
        {
            Debug.Log("Workin is progress");

            ProgressValue = CalculateMoney() / deskPrice;

            if (PlayerPrefs.GetInt("money") >= deskPrice)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - deskPrice);

                deskRemainPrice = 0;
            }
            else
            {
                deskRemainPrice -= PlayerPrefs.GetInt("money");
                PlayerPrefs.SetInt("money", 0);
            }

            progressBar.fillAmount = ProgressValue;

            dollarAmount.text = deskRemainPrice.ToString();

            if (deskRemainPrice == 0)
            {
                Destroy(gameObject);
                e_objectPool.ActivePoolObject(ObjectTag.WorkTable, transform);
            }
        }
    }

    private float CalculateMoney()
    {
        return deskRemainPrice - PlayerPrefs.GetInt("dollar");
    }
}
