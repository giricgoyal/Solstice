using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public Texture2D scaleWinter;
	public Texture2D scaleSummer;
	public Texture2D scaleSpring;
	public Texture2D scaleFall;
	
	public Texture2D winterEmpty;
	public Texture2D springEmpty;
	public Texture2D summerEmpty;
	public Texture2D fallEmpty;
	
	public Texture2D winterFull;
	public Texture2D springFull;
	public Texture2D summerFull;
	public Texture2D fallFull;
	
	public GameObject health;
	
	float scaleWinterX1, scaleWinterX2;
	float scaleWinterY1, scaleWinterY2;
	
	float scaleSpringX1, scaleSpringX2;
	float scaleSpringY1, scaleSpringY2;
	
	float scaleSummerX1, scaleSummerX2;
	float scaleSummerY1, scaleSummerY2;
	
	float scaleFallX1, scaleFallX2;
	float scaleFallY1, scaleFallY2;

	
	// Use this for initialization
	void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			// set winterScaleTexture
			scaleWinterX1 = 200*Utilities.scaleFactor;
			scaleWinterY1 = 550*Utilities.scaleFactor;
			scaleWinterX2 = 20*Utilities.scaleFactor;
			scaleWinterY2 = 85*Utilities.scaleFactor;
			
			scaleWinter = new Texture2D((int)(20*Utilities.scaleFactor),(int)(85*Utilities.scaleFactor));
			scaleWinter = colorScale(scaleWinter, (int)(85*Utilities.scaleFactor));
			
			// set spring texture
			scaleSpringX1 = 220*Utilities.scaleFactor;
			scaleSpringY1 = 630*Utilities.scaleFactor;
			scaleSpringX2 = 100*Utilities.scaleFactor;
			scaleSpringY2 = 25*Utilities.scaleFactor;
			scaleSpring = new Texture2D((int)(100*Utilities.scaleFactor),(int)(25*Utilities.scaleFactor));
			scaleSpring = colorScale(scaleSpring, (int)(105*Utilities.scaleFactor));
			
			// set summer texture
			scaleSummerX1 = 110*Utilities.scaleFactor;
			scaleSummerY1 = 630*Utilities.scaleFactor;
			scaleSummerX2 = 100*Utilities.scaleFactor;
			scaleSummerY2 = 25*Utilities.scaleFactor;
			scaleSummer = new Texture2D((int)(100*Utilities.scaleFactor),(int)(25*Utilities.scaleFactor));
			scaleSummer = colorScale(scaleSummer, (int)(0*Utilities.scaleFactor));
			
		
			// set fall texture
			scaleFallX1 = 200*Utilities.scaleFactor;
			scaleFallY1 = 550*Utilities.scaleFactor;
			scaleFallX2 = 20*Utilities.scaleFactor;
			scaleFallY2 = 80*Utilities.scaleFactor;
			scaleFall = new Texture2D((int)(20*Utilities.scaleFactor),(int)(80*Utilities.scaleFactor));
			scaleFall = colorScale(scaleFall, (int)(0*Utilities.scaleFactor));
		}
	}
	Texture2D colorScale(Texture2D texture, int i) {
		if (texture == scaleWinter) {
			int x=0;
			while(x < texture.width) {
				int y=(int)(85*Utilities.scaleFactor);
				while (y>i) {
					texture.SetPixel(x,y,new Color32(0,0,0,0));
					y--;
				}
				y = i;
				while(y > 0) {
					texture.SetPixel(x,y,new Color32(10,50,255,120));
					y--;
				}
				x++;
			}
		}
		
		else if (texture == scaleSpring) {
			int x=0;
			while (x<i) {
				int y=0;
				while (y<texture.height) {
					texture.SetPixel(x,y,new Color32(200,255,80,120));
					y++;
				}
				x++;
			}
			x=i;
			while (x<texture.width) {
				int y=0;
				while (y<texture.height) {
					texture.SetPixel(x,y,new Color32(0,0,0,0));
					y++;
				}
				x++;
			}
		}
		
		else if (texture == scaleSummer) {
			int x=0;
			while (x<texture.width) {
				int y=0;
				while(y<texture.height) {
					if (x<i) {
						texture.SetPixel(x,y,new Color32(0,0,0,0));	
					}
					else {
						texture.SetPixel(x,y,new Color32(255,230,80,120));
					}
					y++;
				}
				x++;
			}
		}
		
		else if (texture == scaleFall) {
			int x=0;
			while (x<texture.width) {
				int y=(int)(80*Utilities.scaleFactor);
				while (y>i) {
					texture.SetPixel(x,y,new Color32(50,50,50,120));
					y--;
				}
				y=i;
				while (y>=0) {
					texture.SetPixel(x,y,new Color32(0,0,0,0));
					y--;
				}
				x++;
			}
		}
		
		texture.Apply();
		return texture;
	}
	
	
	
	
	void Init() {
		
	}
	
	void refresh() {
		
	}
	
	void OnGUI() {
		if (Utilities.state == Utilities.stateMainGame) {
			GUI.Label(new Rect(200*Utilities.scaleFactor, 550*Utilities.scaleFactor, 20*Utilities.scaleFactor, 85*Utilities.scaleFactor), winterEmpty);
			GUI.Label(new Rect(200*Utilities.scaleFactor, 550*Utilities.scaleFactor, 20*Utilities.scaleFactor, 85*Utilities.scaleFactor), scaleWinter);
			GUI.Label(new Rect(110*Utilities.scaleFactor, 630*Utilities.scaleFactor, 100*Utilities.scaleFactor, 25*Utilities.scaleFactor), summerEmpty);
			GUI.Label(new Rect(110*Utilities.scaleFactor, 630*Utilities.scaleFactor, 100*Utilities.scaleFactor, 25*Utilities.scaleFactor), scaleSummer);
			GUI.Label(new Rect(220*Utilities.scaleFactor, 630*Utilities.scaleFactor, 100*Utilities.scaleFactor, 25*Utilities.scaleFactor), springEmpty);
			GUI.Label(new Rect(220*Utilities.scaleFactor, 630*Utilities.scaleFactor, 100*Utilities.scaleFactor, 25*Utilities.scaleFactor), scaleSpring);
			GUI.Label(new Rect(200*Utilities.scaleFactor, 650*Utilities.scaleFactor, 20*Utilities.scaleFactor, 80*Utilities.scaleFactor), fallEmpty);
			GUI.Label(new Rect(200*Utilities.scaleFactor, 650*Utilities.scaleFactor, 20*Utilities.scaleFactor, 80*Utilities.scaleFactor), scaleFall);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			// scale winter
			if (scaleWinterY2 >= 0){
				//scaleWinterY1++;
			//	scaleWinterY2--;
				scaleWinterY2 = (int)(Utilities.magiaBarWinter / 100 * 85*Utilities.scaleFactor);
				scaleWinter = colorScale(scaleWinter, (int)(scaleWinterY2));
			}
			
			// scale spring
			if (scaleSpringX2 >= 0) {
				//scaleSpringX2--;
				scaleSpringX2 = (int)(Utilities.magiaBarSpring / 100 * 105*Utilities.scaleFactor);
				scaleSpring = colorScale(scaleSpring, (int)scaleSpringX2);
			}
							
			// scaleSummer
			if (scaleSummerX2 >= 0) {
				//scaleSummerX2--;
				//scaleSummerX1++;
				scaleSummerX2 = (int)(Utilities.magiaBarSummer / 100 * 110*Utilities.scaleFactor);
				scaleSummer = colorScale(scaleSummer, (int)(110*Utilities.scaleFactor - scaleSummerX2));
			}
			
			// scaleFall
			if (scaleFallY2 >= 0) {
				//scaleFallY2--;
				scaleFallY2 = (int)(Utilities.magiaBarFall / 100 * 80*Utilities.scaleFactor);
				scaleFall = colorScale(scaleFall, (int)(80*Utilities.scaleFactor - scaleFallY2));
			}
		
		
			if (Utilities.saludBar >= 0) {
				Color32 color;
				if (Utilities.saludBar >= 50) {
					color = new Color32((byte)((int)((100-Utilities.saludBar) / 50 * 255)),255,0,4);
					health.particleSystem.startColor = color;
				}
				else if (Utilities.saludBar < 50) {
					color = new Color32(255,(byte)(255 - (int)((100-Utilities.saludBar) / 50 * 255)),0,4);
					health.particleSystem.startColor = color;
				}
			}
		}
	}
}
