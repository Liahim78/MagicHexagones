using System;
using UnityEngine;

public class CreateMap : MonoBehaviour
{

    public GameObject Hexagon;
    public GameObject UnactiveHexagon;
    public GameObject TransparentHexagon;

    public int Size;

    // Use this for initialization
    void Start () {

        var rand = new System.Random();
        for (var i = 0; i < Size*2-1; i++)
	    {
	        for (var j = 0; j < Size*2-1; j++)
	        {
	            int offsetLeft, offsetRitht ;
	            if (Size % 2 == 0)
	            {
	                offsetRitht = Math.Abs(i + 1 - Size) / 2;
	                offsetLeft = Math.Abs(i + 1 - Size) % 2 == 0 ? offsetRitht : offsetRitht + 1;
                }
	            else
	            {
	                offsetLeft = Math.Abs(i + 1 - Size) / 2;
	                offsetRitht = Math.Abs(i + 1 - Size) % 2 == 0 ? offsetLeft : offsetLeft + 1;
	            }

	            if (j - offsetLeft < 0 || Size * 2 - 1 - j <= offsetRitht) continue;
                
                var f = rand.Next(20);
                if (i <= 2)
	            {
	                var obj = Instantiate(Hexagon, transform);
	                obj.transform.position = new Vector3(i * 2.5f, 0, 3f * j + (i % 2f) * 1.5f);
	                obj.transform.rotation.Set(-90, obj.transform.rotation.y, obj.transform.rotation.z, obj.transform.rotation.w);
                    obj.transform.localScale = new Vector3(10, 10, 10+f);
                    continue;
	            }
	            var unactive = Instantiate(UnactiveHexagon, transform);
	            unactive.transform.position = new Vector3(i * 2.5f, 0, 3f * j + (i % 2f) * 1.5f);
	            unactive.transform.rotation.Set(-90, unactive.transform.rotation.y, unactive.transform.rotation.z, unactive.transform.rotation.w);
	            unactive.transform.localScale = new Vector3(10, 10, 10+f);
	            var transparentHexagon = Instantiate(TransparentHexagon,transform);
	            transparentHexagon.transform.position = new Vector3(i * 2.5f, 0, 3f * j + (i % 2f) * 1.5f);
	            transparentHexagon.transform.rotation.Set(-90, transparentHexagon.transform.rotation.y, transparentHexagon.transform.rotation.z, transparentHexagon.transform.rotation.w);
	            transparentHexagon.transform.localScale = new Vector3(10, 10, 1000);
            }
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
