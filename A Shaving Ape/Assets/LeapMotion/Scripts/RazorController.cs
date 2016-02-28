using UnityEngine;
using System.Collections;
using Leap;

public class RazorController : MonoBehaviour {
  //  public GameObject cubePrefab;

    public LeapHandController hc;
    private HandModel hm;
    public GameObject razorObj = null;

    // Update is called once per frame
    Frame currentFrame;

    Frame lastFrame = null;
    Frame thisFrame = null;

    Vector3 righthandPos;
    Vector3 righthandRotation;
    // Use this for initialization
    void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
        this.currentFrame = hc.GetFrame();
       
        

        foreach (var h in hc.GetFrame().Hands)
        {
            if (h.IsRight)
            {
                 righthandPos = h.PalmPosition.ToUnity();

                razorObj.transform.position = new Vector3(righthandPos.x, righthandPos.y, righthandPos.z);


                
                righthandRotation = new Vector3(h.Direction.Pitch, h.Direction.Yaw, h.Direction.Roll);


             //   this.lblRightHandPosition.text = string.Format("Right Hand Position: {0}", h.PalmPosition.ToUnity());
               // this.lblRightHandRotation.text = string.Format("Right Hand Rotation: <{0},{1},{2}>", h.Direction.Pitch, h.Direction.Yaw, h.Direction.Roll);

                if (this.razorObj != null)
                    this.razorObj.transform.rotation = Quaternion.EulerRotation(-h.Direction.Pitch, -h.Direction.Yaw, h.PalmNormal.Roll);

                foreach (var f in h.Fingers)
                {
                    
                 
                    if (f.Type == Finger.FingerType.TYPE_THUMB)
                    {
                        // this code converts the tip position from leap motion to unity world position
                        Leap.Vector position = f.TipPosition;
                        Vector3 unityPosition = position.ToUnityScaled();
                        Vector3 worldPosition = hc.transform.TransformPoint(unityPosition);

                          //  this.razorObj.transform.rotation = Quaternion.Euler(f.Direction.Pitch, f.Direction.Yaw, f.Direction.Roll);
                            //worldPosition = f.TipPosition.ToUnity();
                            //razorObj.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

                            //string msg = string.Format("Finger ID:{0} Finger Type: {1} Tip Position: {2}", f.Id, f.Type(), worldPosition);
                            //Debug.Log(msg);
                        }
                }

            }
            if (h.IsLeft)
            {
                //this.lblLeftHandPosition.text = string.Format("Left Hand Position: {0}", h.PalmPosition.ToUnity());
                //this.lblLeftHandRotation.text = string.Format("Left Hand Rotation: <{0},{1},{2}>", h.Direction.Pitch, h.Direction.Yaw, h.Direction.Roll);

                if (this.razorObj != null)
                    this.razorObj.transform.rotation = Quaternion.EulerRotation(h.Direction.Pitch, h.Direction.Yaw, h.Direction.Roll);
            }

        }

    }

}

