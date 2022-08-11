using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Panel : MonoBehaviour
{
    public Animation m_PanelAnimator;
    public List<UI_Furniture> Panels;
    public void OnClickBedButton() { OnClickPannelButton(FurnitureType.Bed); }
    public void OnClickBookShelfButton() { OnClickPannelButton(FurnitureType.BookShelf); }
    public void OnClickChairButton() { OnClickPannelButton(FurnitureType.Chair); }
    public void OnClickDeskButton() { OnClickPannelButton(FurnitureType.Desk); }
    public void OnClickFlowerPotButton() { OnClickPannelButton(FurnitureType.FlowerPot); }
    public void OnClickPhotoFrameButton() { OnClickPannelButton(FurnitureType.PhotoFrame); }
    public void OnClickSofaButton() { OnClickPannelButton(FurnitureType.Sofa); }
    public void OnClickStandButton() { OnClickPannelButton(FurnitureType.Stand); }

    private void OnClickPannelButton(FurnitureType furnitureType)
    {

        foreach(UI_Furniture furniture in Panels)
        {
            furniture.gameObject.SetActive(false);
        }


        Panels[(int)furnitureType].gameObject.SetActive(true);
        Panels[(int)furnitureType].Refresh();
        m_PanelAnimator.Play("bottomPanelUp");

    }

}
