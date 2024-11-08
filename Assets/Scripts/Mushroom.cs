using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private float growthRate = 0.1f;
    private float mushroomGrowth = 1f;
    // max growth is 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grow()
    {
        if (mushroomGrowth < 1f)
        {
            mushroomGrowth += growthRate;
            transform.localScale = new Vector3(mushroomGrowth, mushroomGrowth, 1f);
        }
    }
}
