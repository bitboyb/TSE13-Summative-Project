using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Use for UI elements in 3D space
/// </summary>
public class AlignToCamera : MonoBehaviour, IPointerClickHandler
{
	
	void LateUpdate () 
	{
		transform.LookAt(Camera.main.transform);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Left)
		{
			return;
		}
		//Debug.Log("PointerClick");
		//if building is higer that last level, turn of the UI element
		if (transform.position.y + 0.5f > GameSettings.Instance.GetMiddleLevel() + 0.5f)
		{
			gameObject.SetActive(false);
		}
		else transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
	}
}
