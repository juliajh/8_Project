
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System.Collections.Generic;

public enum ImageType
{
	PNG,
	JPG
}
namespace check
{
	public class ImageUploader : MonoBehaviour
	{
		// 이미지
		Texture2D imageTexture;
		string fieldName;
		string fileName = "defaultImageName";
		ImageType imageType = ImageType.PNG;
		// 원래는 이거 써야 함
		private string url = "https://metajihyun.herokuapp.com";
		
		// 테스트용
		//string url = "http://192.168.0.37:5080";

		// 카테고리, 가구명, 사진, 가격, 게시판 제목, 내용, 등록자id
		string category = "1";
		string furnitureName = "1";
		string price = "1";
		string title = "1";
		string context = "1";
		string uploaderId = "1";
		string index = "-1";


		//Events
		UnityAction<string> OnErrorAction;
		UnityAction<string> OnCompleteAction;


		public static ImageUploader Initialize()
		{
			return new GameObject("ImageUploader").AddComponent<ImageUploader>();
		}

		public ImageUploader SetTexture(Texture2D texture)
		{
			this.imageTexture = texture;
			return this;
		}

		public ImageUploader SetFileName(string filename)
		{
			this.fileName = filename;
			return this;
		}

		public ImageUploader SetFieldName(string fieldName)
		{
			this.fieldName = fieldName;
			return this;
		}

		public ImageUploader SetType(ImageType type)
		{
			this.imageType = type;
			return this;
		}

		public ImageUploader SetCategory(string category)
		{
			this.category = category;
			return this;
		}

		public ImageUploader SetFurnitureName(string furnitureName)
		{
			this.furnitureName = furnitureName;
			return this;
		}

		public ImageUploader SetPrice(string price)
		{
			this.price = price;
			return this;
		}

		public ImageUploader SetTitle(string title)
		{
			this.title = title;
			return this;
		}

		public ImageUploader SetContext(string context)
		{
			this.context = context;
			return this;
		}

		public ImageUploader SetUploaderId()
		{
			this.uploaderId = UnityEngine.SystemInfo.deviceUniqueIdentifier;
			return this;
		}

		public ImageUploader SetUrl(string url)
		{
			this.url += url;
			return this;
        }

        public ImageUploader SetIndex(string index)
        {
            this.index = index;
            return this;
        }


        //events
        public ImageUploader OnError(UnityAction<string> action)
		{
			this.OnErrorAction = action;
			return this;
		}

		public ImageUploader OnComplete(UnityAction<string> action)
		{
			this.OnCompleteAction = action;
			return this;
		}

		public void Start()
		{
			if (url == null)
				Debug.LogError("Url is not assigned, use SetUrl( url ) to set it. ");

			// StartCoroutine(StartUploading());
		}

		public void Upload()

		{
			//check/validate fields
			if (url == null)
				Debug.LogError("Url is not assigned, use SetUrl( url ) to set it. ");
			//...other checks...
			//...

			// StopAllCoroutines();
			// StartCoroutine(StartUploading());
		}



		public async Task<Dictionary<string,string>> StartUploading()
		{
			WWWForm form = new WWWForm();
			byte[] textureBytes = null;

			//Get a copy of the texture, because we can't access original texure data directly. 
			Texture2D imageTexture_copy = GetTextureCopy(imageTexture);

			switch (imageType)
			{
				case ImageType.PNG:
					textureBytes = imageTexture_copy.EncodeToPNG();
					break;
				case ImageType.JPG:
					textureBytes = imageTexture_copy.EncodeToJPG();
					break;
			}

			//image file extension
			string extension = imageType.ToString().ToLower();

			// 이미지 파일
			form.AddBinaryData(fieldName, textureBytes, fileName + "." + extension, "image/" + extension);

            // 게시글 정보 추가
            form.AddField("category", category);
            form.AddField("furnitureName", furnitureName);
            form.AddField("price", price);
            form.AddField("title", title);
            form.AddField("context", context);
            form.AddField("uploaderId", uploaderId);
			// 글 등록일 땐 index는 "-1"임
			form.AddField("index", index);

			UnityWebRequest w = UnityWebRequest.Post(url, form);

			await w.SendWebRequest();

			if (w.error != null)
			{
				Debug.Log(w.downloadHandler.text);
			}
			else
			{
                //success
                var text = w.downloadHandler.text;
                Debug.Log($"[Network|Recv|{url}]\n{text}");

				var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);

                print("결과-------------");
                //print(text);
                w.Dispose();
                Destroy(this.gameObject);
                return obj;

                if (OnCompleteAction != null)
					OnCompleteAction(w.downloadHandler.text); //or OnCompleteAction.Invoke (w.error);
			}

			w.Dispose();
			Destroy(this.gameObject);

			return new Dictionary<string, string>();
        }

		Texture2D GetTextureCopy(Texture2D source)
		{
			//Create a RenderTexture
			RenderTexture rt = RenderTexture.GetTemporary(
								   source.width,
								   source.height,
								   0,
								   RenderTextureFormat.Default,
								   RenderTextureReadWrite.Linear
							   );

			//Copy source texture to the new render (RenderTexture) 
			Graphics.Blit(source, rt);

			//Store the active RenderTexture & activate new created one (rt)
			RenderTexture previous = RenderTexture.active;
			RenderTexture.active = rt;

			//Create new Texture2D and fill its pixels from rt and apply changes.
			Texture2D readableTexture = new Texture2D(source.width, source.height);
			readableTexture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
			readableTexture.Apply();

			//activate the (previous) RenderTexture and release texture created with (GetTemporary( ) ..)
			RenderTexture.active = previous;
			RenderTexture.ReleaseTemporary(rt);

			return readableTexture;
		}

	}
}
