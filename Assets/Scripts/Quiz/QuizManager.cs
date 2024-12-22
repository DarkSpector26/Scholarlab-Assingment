using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AnimalQuizManager : MonoBehaviour
{
    public List<AnimalData> animals; 
    public GameObject redBucket, blueBucket; 
    public TMP_Text redBucketLabel , blueBucketLabel;
    public TMP_Text HeadlineText;
    public GameObject IncorrectCardPanel;
    public TMP_Text InccorectCardText;
    public TMP_Text InccorectCardProgressText;
    private int RemanningCard;
    private System.Random random = new System.Random();
    private int score = 0;
    public TMP_Text ScoreText;
    public GameObject GameOverPanael;

    private List<String> IncorrectCard = new List<String>();
    
    public enum QuizCategory { Flying, Insect, Diet, Social, Reproduction }
    private QuizCategory currentCategory;

    private void Start()
    {
        RemanningCard = animals.Count; 
         if(IncorrectCardPanel != null)
        {
            IncorrectCardPanel.SetActive(false);
        }

         if(GameOverPanael != null)
        {
            GameOverPanael.SetActive(false);
        }
        
        StartQuiz();
        
    }

    public void StartQuiz()
    {
        currentCategory = (QuizCategory)random.Next(0, 5);
        Debug.Log("Sorting animals by: " + currentCategory);

       
        UpdateUI();
        UpdateBucketLabels();
    }
    private void UpdateBucketLabels()
    {
        if( currentCategory == QuizCategory.Flying )
        {
            
            redBucketLabel.text = "Flying";
            blueBucketLabel.text = "NonFlying";
        }
        else if ( currentCategory == QuizCategory.Insect )
        {
            redBucketLabel.text = "Insect";
            blueBucketLabel.text = "NonInsect";
        }
        else if ( currentCategory == QuizCategory.Diet )
        {
            redBucketLabel.text = "Herbivorous";
            blueBucketLabel.text = "Omnivorous";
        }
        else if ( currentCategory == QuizCategory.Social )
        {
            redBucketLabel.text = "Solo";
            blueBucketLabel.text = "Group";
        }
        else if( currentCategory == QuizCategory.Reproduction )
        {
            redBucketLabel.text = "LayEggs";
            blueBucketLabel.text = "GiveBirth";

        }
        
    }
    private void UpdateUI()
    {
        
       if( currentCategory == QuizCategory.Flying)
        {
            HeadlineText.text = "Sort animals into Flying or Non-Flying.";
            Debug.Log("Sort animals into Flying or Non-Flying.");
        }
       else if( currentCategory == QuizCategory.Insect)
        {
            HeadlineText.text = "Sort animals into Insect or Non-Insect.";
            Debug.Log("Sort animals into Insect or Non-Insect.");
        }
       else if ( currentCategory == QuizCategory.Diet)
        {
            HeadlineText.text = "Sort animals into Herbivorous or Carnivorous";
            Debug.Log("Sort animals into Herbivorous or Carnivorous");
        }
       else if (currentCategory == QuizCategory.Social)
        {
            HeadlineText.text = "Sort animals into Solo or Group";
            Debug.Log("sort animals into Solo or Group");
        }
       else if ( currentCategory == QuizCategory.Reproduction )
        {
            HeadlineText.text = " sort animals into Give Birth or Lay Eggs";
            Debug.Log("sort animals into Give Birth or Lay Eggs");
        }
    }
    public void UpdateScore()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "Score : " + score;
        }
    }
    public void AnimalIdentifier(AnimalData animal, GameObject selectedBucket)
    {
        bool isCorrect = false;
        bool isRedBucketCorrect = false;
        bool isBlueBucketCorrect = false;

        Debug.Log("Evaluating: " + animal.animalName + " placed in " + selectedBucket.name);
        Debug.Log("Current Category: " + currentCategory);

        if (currentCategory == QuizCategory.Flying)
        {
            isRedBucketCorrect = animal.flyingCategory == FlyingCategory.Flying;
            isBlueBucketCorrect = animal.flyingCategory == FlyingCategory.NonFlying;
        }
        else if (currentCategory == QuizCategory.Insect)
        {
           
            isRedBucketCorrect = animal.insectCategory == InsectCategory.Insect;
            isBlueBucketCorrect = animal.insectCategory == InsectCategory.NonInsect;
        }
        else if (currentCategory == QuizCategory.Diet)
        {
            
            isRedBucketCorrect = animal.dietCategory == DietCategory.Herbivorous;
            isBlueBucketCorrect = animal.dietCategory == DietCategory.Omnivorous;
        }
        else if (currentCategory == QuizCategory.Reproduction)
        {
           
            isRedBucketCorrect = animal.reproductionCategory == ReproductionCategory.LaysEggs;
            isBlueBucketCorrect = animal.reproductionCategory == ReproductionCategory.GivesBirth;
        }
        else if (currentCategory == QuizCategory.Social)
        {
          
            isRedBucketCorrect = animal.socialCategory == SocialCategory.Solo;
            isBlueBucketCorrect = animal.socialCategory == SocialCategory.Group;
        }

       
        isCorrect = (selectedBucket == redBucket && isRedBucketCorrect) || (selectedBucket == blueBucket && isBlueBucketCorrect);

        
       

        if (isCorrect)
        {
            score += 10;
            Debug.Log(animal.animalName + " placed correctly!");
        }
        else
        {
            Debug.Log(animal.animalName + " placed incorrectly!");
            IncorrectCard.Add(animal.animalName);
        }

        RemanningCard--;
        UpdateScore();

        if (RemanningCard <= 0)
        {
            EndGame();
        }
    }
    public void EndGame()
    {
        Debug.Log("GameOver");
       if(RemanningCard <=0 )
        {
            GameOverPanael.SetActive(true); 
        }
        
        else
        {
            InccorectCardText.text = "congratulations All Cards Are Correct ";
        }


    }

    public void ShowWrongCards()
    {
        if(IncorrectCardPanel != null)
        {
            IncorrectCardPanel.SetActive(true );
            
        }

        if(IncorrectCard.Count > 0)
        {
            InccorectCardText.text = "Wrong Cards :\n" + string.Join("\n ", IncorrectCard);
        }

        switch (IncorrectCard.Count)
        {
            case int n when (n >= 18):
                InccorectCardProgressText.text = "Well Done";
                break;
            case int n when (n >= 14):
                InccorectCardProgressText.text = "Good Keep it Up";
                break;
            case int n when (n >= 9):
                InccorectCardProgressText.text = "Keep Going";
                break;
            case int n when (n >= 3):
                InccorectCardProgressText.text = "You have to Learn More";
                break;
            default:
                InccorectCardProgressText.text = "Keep practicing!";
                break;
        }


    }



}
