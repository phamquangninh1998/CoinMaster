using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spinner : MonoBehaviour
{
    public Animator animator;
    public bool spinning;
    public int spinTurn;
    public int maxSpinTurn = 50;

    public Image spinBar;
    public Text turnText;

    public float spinDuration;
    // Start is called before the first frame update
    void Start()
    {
        spinTurn = Random.Range(1, 50);
        ResetSpinBar();
        spinning = false;
    }

    private void ResetSpinBar()
    {

        float fillAmount = (float)spinTurn / maxSpinTurn;
        spinBar.fillAmount = fillAmount;
        turnText.text = spinTurn + "/" + maxSpinTurn;
    }

    public void Spin()
    {
        if (spinTurn == 0) return;
        if (spinning) return;
        spinTurn--;
        ResetSpinBar();
        StartCoroutine(DOSpin());
    }

    IEnumerator DOSpin()
    {
        spinning = true;

        int result;
        int randomNumber = Random.Range(0, 11);

        if (randomNumber >= 10)
        {
            animator.Play("SpinAttack");
            result = 5;
        }
        else
        {
            if (randomNumber >= 9)
            {
                animator.Play("SpinShield");
                result = 4;
            }
            else
            {
                if (randomNumber >= 8)
                {
                    animator.Play("SpinBigGold");
                    result = 3;
                }
                else
                {
                    if (randomNumber >= 4)
                    {
                        animator.Play("SpinSmallGold");
                        result = 2;
                    }
                    else
                    {
                        animator.Play("SpinNothing" + randomNumber);
                        result = 1;
                    }
                }
            }
        }

        yield return new WaitForSeconds(spinDuration);
        spinning = false;

        switch (result)
        {
            case 1:
                Debug.Log("get nothing");
                break;
            case 2:
                Debug.Log("get small gold");
                PlayerData.instance.AddCoin(5);
                break;
            case 3:
                Debug.Log("get big gold");
                PlayerData.instance.AddCoin(50);

                break;
            case 4:
                Debug.Log("add shield");
                break;
            case 5:
                Debug.Log("add attack");
                break;
        }
    }

    public void BackToHome()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("HomeScene");
    }
}
