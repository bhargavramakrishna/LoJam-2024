using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] float growthInterval = 0.3f;
    [SerializeField] float maxGrowth = 3f;
    [SerializeField] GameObject largeMushroom;
    [SerializeField] Transform smallMushroom;
    [SerializeField] GameObject memoryOrb;

    private float growthRate = 0.1f;
    private float mushroomGrowth = 1f;
    private float growthTimer;
    // max growth is 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        growthTimer = Time.time;
        largeMushroom.SetActive(false);
    }

    void OnParticleCollision(GameObject other){
        if(other.CompareTag("WaterParticles")){
            if(Time.time > growthTimer) {
                growthTimer = Time.time + growthInterval;
                Grow();
            }
        }
    }

    public void Grow()
    {
        if (mushroomGrowth < maxGrowth)
        {
            mushroomGrowth += growthRate;
            smallMushroom.localScale = new Vector3(mushroomGrowth, mushroomGrowth, 1f);
        } else {
            largeMushroom.SetActive(true);
            smallMushroom.gameObject.SetActive(false);

            if (memoryOrb != null)
                memoryOrb.SetActive(true);
        }
    }
}
