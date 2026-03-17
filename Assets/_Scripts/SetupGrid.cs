using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGrid : MonoBehaviour
{
    public GameObject cardPrefab;
    private List<int> values = new List<int>();
    public Transform gridHolder;

    [Range(1,5)]
    public int numberOfRows = 4;

    private int numberOfColums = 6;
    // Start is called before the first frame update
    void OnEnable()
    {
        InitiateGrid();
        ShuffleCards();
        CreateCards();
        StartCoroutine(DisableGrid());
    }

    private void InitiateGrid()
    {
        int requiredCards = (numberOfRows * numberOfColums)/2;
        MatchManager.instance.SetMaxMatchNumber(requiredCards);

        for (int i = 1; i <= requiredCards; i++)
        {
            values.Add(i);
            values.Add(i);
        }
    }

    private void ShuffleCards()
    {
        for (int i = 0; i < values.Count; i++)
        {
            int temp = values[i];
            int randomIndex = Random.Range(i, values.Count);
            values[i] = values[randomIndex];
            values[randomIndex] = temp;
        }
    }

    private void CreateCards()
    {
        for (int i = 0; i < values.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, gridHolder);
            card.GetComponent<Card>().SetupCard(values[i]);
            card.GetComponent<Card>().TurnCard();
        }
    }

    IEnumerator DisableGrid()
    {
        yield return new WaitForSeconds(0.5f);
        gridHolder.GetComponent<GridLayoutGroup>().enabled = false;
    }
}
