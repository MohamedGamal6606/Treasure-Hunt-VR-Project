using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public GameObject questionUI;
    public GameObject islandObject;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerTexts;

    private GameObject currentKey;
    private int solvedQuestions = 0;
    public int totalQuestions = 4;

    [System.Serializable]
    public class Question
    {
        public string question;
        public string[] answers;
        public int correctIndex;
    }

    public Question[] questions;

    private int currentQuestionIndex;

    public void ShowQuestion(GameObject key, int index)
    {
        currentKey = key;
        currentQuestionIndex = index;
        Debug.Log("questionText: " + questionText);
        Debug.Log("questions length: " + questions.Length);

        questionText.text = questions[index].question;

        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = questions[index].answers[i];
        }
        Debug.Log("Showing question: " + questions[index].question);
        questionUI.SetActive(true);
    }

    public void Answer(int index)
    {
        if (index == questions[currentQuestionIndex].correctIndex)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }

    void CorrectAnswer()
    {
        questionUI.SetActive(false);

        if (currentKey != null)
        {
            currentKey.SetActive(false);
        }

        solvedQuestions++;

        if (solvedQuestions == totalQuestions)
        {
            islandObject.SetActive(true);
        }
    }

    void WrongAnswer()
    {
        questionUI.SetActive(false);
    }
}