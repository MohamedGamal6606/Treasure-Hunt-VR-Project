using UnityEngine;
using TMPro;

public class KeyPuzzle : MonoBehaviour
{
    public GameObject questionUI;
    public GameObject keyObject;

    public TMP_InputField answerInput;
    public int correctAnswer = 5;

    public Transform playerCamera;
    public float distanceFromPlayer = 2f;

    bool keyCollected = false;

    void Start()
    {
        // نتأكد إنه مخفي أول ما اللعبة تبدأ
        questionUI.SetActive(false);
    }

    // لما تضغطي على المفتاح
    void OnMouseDown()
    {
        if (!keyCollected)
        {
            ShowQuestionInFront();
        }
    }

    void ShowQuestionInFront()
    {
        Vector3 pos = playerCamera.position + playerCamera.forward * distanceFromPlayer;

        questionUI.transform.position = pos;

        Vector3 dir = questionUI.transform.position - playerCamera.position;
        questionUI.transform.rotation = Quaternion.LookRotation(dir);

        questionUI.SetActive(true);
    }

    // لما تضغطي submit
    public void CheckAnswer()
    {
        int playerAnswer;

        if (int.TryParse(answerInput.text, out playerAnswer))
        {
            if (playerAnswer == correctAnswer)
            {
                keyCollected = true;

                questionUI.SetActive(false);
                keyObject.SetActive(false);

                Debug.Log("Correct! Key collected");
            }
            else
            {
                Debug.Log("Wrong! Try again");
            }
        }
    }
}