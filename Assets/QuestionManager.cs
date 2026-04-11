using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public Transform playerCamera;
    public GameObject questionUI;
    public GameObject islandObject;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerTexts;

    private GameObject currentKey;
    private int solvedQuestions = 0;
    public int totalQuestions = 4;

    [Header("SFX")]
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip allSolvedSound;
    private AudioSource audioSource;

    [System.Serializable]
    public class Question
    {
        public string question;
        public string[] answers;
        public int correctIndex;
    }

    public Question[] questions;

    private int currentQuestionIndex;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void ShowQuestion(GameObject key, int index)
    {
        currentKey = key;
        currentQuestionIndex = index;

        questionText.text = questions[index].question;

        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = questions[index].answers[i];
        }

        Transform cam = playerCamera;
        questionUI.transform.position = cam.position + cam.forward * 2f + new Vector3(0, 1, 0);
        questionUI.transform.rotation = Quaternion.LookRotation(questionUI.transform.position - cam.position);

        questionUI.SetActive(true);
    }

    public void Answer(int index)
    {
        if (index == questions[currentQuestionIndex].correctIndex)
            CorrectAnswer();
        else
            WrongAnswer();
    }

    void CorrectAnswer()
    {
        questionUI.SetActive(false);

        if (currentKey != null)
            currentKey.SetActive(false);

        if (correctSound != null)
            audioSource.PlayOneShot(correctSound);
        solvedQuestions++;

        if (solvedQuestions == totalQuestions)
        {
            // Play all-solved sound, fallback to correct sound
            if (allSolvedSound != null)
                audioSource.PlayOneShot(allSolvedSound);
            islandObject.SetActive(true);
            WinManager.Instance.isShipWon = true;
        }
        else
        {
            if (correctSound != null)
                audioSource.PlayOneShot(correctSound);
        }
    }

    void WrongAnswer()
    {
        questionUI.SetActive(false);

        if (wrongSound != null)
            audioSource.PlayOneShot(wrongSound);
    }
}