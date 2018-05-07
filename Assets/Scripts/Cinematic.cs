using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
public class Cinematic : MonoBehaviour {

    public VignetteAndChromaticAberration vignette;
    public Text speech1;
 
    IEnumerator Start(){
        yield return new WaitForSeconds(14);
        for(float i=.30F;i<.40F;i+=.008F)
        {
            vignette.intensity = i;
           
            yield return new WaitForSeconds(.02F);

        }
        vignette.enabled = true;
        yield return new WaitForSeconds(10);

        
        vignette.intensity = 1;

        StartCoroutine(Speech1());
           
           
    }
     IEnumerator Speech1(){
        yield return new WaitForSeconds(2);
        speech1.text= "Hmmm!? Um humano ferido? Porque está tão longe de sua terra?";
        yield return new WaitForSeconds(5);
        speech1.text= "Está envenenado! A Floresta das Aranhas, não é lugar para humanos!" ;
        yield return new WaitForSeconds(5);
        speech1.text= "Vou te curar... provavelmente você não faz ideia de como lutar por aqui humano...";
        yield return new WaitForSeconds(5);
        speech1.text= "Quando acordar, terá as 3 magias básicas para se defender." ;
        yield return new WaitForSeconds(5);
        speech1.text= "Droga! tenho que ir... eles estão atrás de mim! ";
         yield return new WaitForSeconds(5);
         speech1.text= "Vai ter que descobrir como usar as magias sozinho quando acordar!";
          yield return new WaitForSeconds(5);
         speech1.text= "Tomara que sobreviva... humano...";
    }
}
