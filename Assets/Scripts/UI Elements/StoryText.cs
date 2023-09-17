using System.Collections;
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
         StopAllCoroutines();
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
        storyText.text = "Es war einmal in einem mystischen Land von ELDORIA, wo ein weiser und maechtiger Zauberer namens ALARIC lebte.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText2());
    }
    
    IEnumerator StoryText2()
    {
        StartCoroutine(FadeIn());
        storyText.text = "ALARIC war nah und fern bekannt fuer seine extraordinaeren magischen Faehigkeiten und seiner Hingabe das Reich vor allen moeglichen dunklen Maechten zu schuetzen.";
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText3());
    }
    
    IEnumerator StoryText3()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Er hatte viele Jahre damit verbracht, seine Kraefte einem jungen und erpichten Lehrling, namens Martin, beizubringen.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText4());
    }
    
    IEnumerator StoryText4()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Martin war ein aufgeweckter und zielstrebiger junger Mann mit einer natuerlichen Affinitaet fuer Magie.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText5());
    }
    
    IEnumerator StoryText5()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Er kam zu ALARIC als Kind und trainierte unter seiner Aufsicht seine magischen Talente, da seine Eltern keinerlei Magie besassen.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText6());
    }
    
    IEnumerator StoryText6()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Zusammen formten die beiden eine untrennbare Bindung und ALARIC sah grosses Potential in seinem Lehrling.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText7());
    }
    
    IEnumerator StoryText7()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Eines schicksalhaften Tages, als die Sonne den Himmel in orangen und pinken Farbtoenen malte, begab sich ALARIC auf eine gefaehrliche Suche, um einen Riss zu schliessen, der sich in der dunkelsten Ecke des magischen Reiches geoeffnet hatte. ";
        yield return new WaitForSeconds(8f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText8());
    }
    
    IEnumerator StoryText8()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Er liess eine detaillierte Anweisung fuer Martin zurueck, erklaerend, dass dies eine Aufgabe sei, die nur er uebernehmen koenne und er mehrere Wochen lang weg sein wuerde.";
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText9());
    }
    
    IEnumerator StoryText9()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Aus Wochen wurden Monate und weiterhin gab es kein Zeichen von ALARIC's Rueckkehr.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText10());
    }
    
    IEnumerator StoryText10()
    {
        StartCoroutine(FadeIn());
        storyText.text = "ELDORIA's Bewohner wurden aengstlich und Geruechte verbreiteten sich wie Lauffeuer durch das Land.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText11());
    }
    
    IEnumerator StoryText11()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Jemand fluesterte, dass ALARIC sein Schicksal in dem Riss gefunden haette, waehrend andere daran glaubten, dass er seine Pflichten aufgegeben hat.";
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(3f);
        StartCoroutine(StoryText12());
    }
    
    IEnumerator StoryText12()
    {
        StartCoroutine(FadeIn());
        storyText.text = "Martin jedoch weigerte sich, eine der beiden Theorien zu glauben. Er kannte seinen Mentor besser als irgendjemand und er war sich sicher, dass er seine Heimat niemals im Stich lassen wuerde.";
        yield return new WaitForSeconds(6.5f);
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
