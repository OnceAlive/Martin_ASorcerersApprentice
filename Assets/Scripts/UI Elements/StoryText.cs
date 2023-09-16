using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI storyText;
     private float fadeDuration = 1f;
     private Color initialColor;
     private Color targetColor;
     
     private void Start()
     {
         initialColor = storyText.color;
         targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1f);
         
         StartCoroutine(StoryText1());
     }

     IEnumerator FadeIn()
     {
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            storyText.color = Color.Lerp(initialColor, targetColor, time / fadeDuration);
            yield return null;
        }
     }
     
     IEnumerator FadeOut()
     {
         float time = 0f;
         while (time < fadeDuration)
         {
             time += Time.deltaTime;
             storyText.color = Color.Lerp(targetColor, initialColor, time / fadeDuration);
             yield return null;
         }
     }
     
    IEnumerator StoryText1()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Es war einmal in einem mystischen Land VON ELDORIA, wo ein weiser und mächtiger Zauberer namens ALARIC lebte.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText2());
    }
    
    IEnumerator StoryText2()
    {
        StartCoroutine(FadeIn());
        storyText.text = "ALARIC war nah und fern bekannt für seine extraordinären magischen Fähigkeiten und seiner Hingabe das Reich vor allen möglichen dunklen Mächten zu schützen.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText3());
    }
    
    IEnumerator StoryText3()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Er hatte viele Jahre damit verbracht, seine Kräfte einem jungen und erpichten Lehrling, namens Martin, beizubringen.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText4());
    }
    
    IEnumerator StoryText4()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Martin war ein aufgeweckter und zielstrebiger junger Mann mit einer natürlichen Affinität für Magie.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText5());
    }
    
    IEnumerator StoryText5()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Er kam zu ALARIC als Kind und trainierte unter seiner Aufsicht seine magischen Talente, da seine Eltern keinerlei Magie besaßen.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText6());
    }
    
    IEnumerator StoryText6()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Zusammen formten die beiden eine untrennbare Bindung und ALARIC sah großes Potential in seinem Lehrling.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText7());
    }
    
    IEnumerator StoryText7()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Eines schicksalhaften Tages, als die Sonne den Himmel in orangen und pinken Farbtönen malte, begab sich ALARIC auf eine gefährliche Suche, um einen Riss zu schließen, der sich in der dunkelsten Ecke des magischen Reiches geöffnet hatte. ";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText8());
    }
    
    IEnumerator StoryText8()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Er ließ eine detaillierte Anweisung für Martin zurück, erklärend, dass dies eine Aufgabe sein, die nur er übernehmen könne und er mehrere Wochen lang weg sein würde.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText9());
    }
    
    IEnumerator StoryText9()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Aus Wochen wurden Monate und weiterhin gab es kein Zeichen von ALARIC's Rückkehr.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText10());
    }
    
    IEnumerator StoryText10()
    {
        StartCoroutine(FadeIn());
        storyText.text = "ELDORIA's Bewohner wurden ängstlich und Gerüchte verbreiteten sich wie Lauffeuer durch das Land.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText11());
    }
    
    IEnumerator StoryText11()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Jemand flüsterte, dass ALARIC sein Schicksal in dem Riss gefunden hätte, während andere daran glaubten, dass er seine Pflichten aufgegeben hat.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText12());
    }
    
    IEnumerator StoryText12()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Martin jedoch weigerte sich, eine der beiden Theorien zu glauben. Er kannte seinen Mentor besser als irgendjemand und er war sich sicher, dass er seine Heimat niemals im Stich lassen würde.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText13());
    }
    
    IEnumerator StoryText13()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Entschlossen, die Wahrheit aufzudecken, begannen Martins Untersuchungen.\nUnd so beginnt unsere Reise...";
        
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartGame();
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Overworld");
        Time.timeScale = 1f;
    }
}
