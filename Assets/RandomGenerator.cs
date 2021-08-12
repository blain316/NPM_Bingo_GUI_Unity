using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RandomGenerator : MonoBehaviour
{
    public GameObject LargeSprite;
    public GameObject[] SmallSprites;
    public Button StartButton;
    public Text ButtonText;
    public int[] numberArray;
    public Sprite[] largeSprites;
    public Sprite[] smallSprites;

   public void OnButtonPress()
    {
        StartButton.interactable = false;
        StartCoroutine(RandonGenerator());
    }

    IEnumerator RandonGenerator ()
    {
        //
        for (int i = 0; i < 36; i++)
        {
            numberArray[i] = Random.Range((1), 49);

            numberArray.Except(numberArray);

            numberArray.Distinct().ToArray();

        }

        for(int k = 0; k < numberArray.Length; k++)
        {
            LargeSprite.GetComponent<Image>().sprite = largeSprites[numberArray[k] -1];
            SmallSprites[k].GetComponent<Image>().sprite = smallSprites[numberArray[k] -1];
            int n = k + 1;

            ButtonText.text = string.Format("Call {0}" + System.Environment.NewLine + "Out of {1}", n, numberArray.Length);
            yield return new WaitForSeconds(2);

        }


        StopCoroutine(RandonGenerator());
        StartButton.interactable = true;
    }
    public int[] RemoveDuplicates(int[] myList)
    {
        System.Collections.ArrayList newList = new System.Collections.ArrayList();

        foreach (int str in myList)
            if (!newList.Contains(str))
                newList.Add(str);
        return (int[])newList.ToArray(typeof(int));
    }


}
