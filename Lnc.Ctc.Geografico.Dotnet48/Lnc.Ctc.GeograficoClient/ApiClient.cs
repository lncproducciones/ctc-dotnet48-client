using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Lnc.Ctc.GeograficoClient
{
	/// <summary>
	/// Contiene funcionalidades de consumo de APIs.
	/// </summary>
	internal class ApiClient : Settings
	{
		/// <summary>
		/// Convierte un objeto a formato Json.
		/// </summary>
		/// <param name="json">objeto a convertir.</param>
		/// <returns></returns>
		private static string ToJson(dynamic json)
		{
			return JsonConvert.SerializeObject(json);
		}

		/// <summary>
		/// Rutinas comunes.
		/// </summary>
		public class Common
		{
			/// <summary>
			/// Genera la URL del método a invocar.
			/// </summary>
			/// <param name="path">Ruta dentro del API, sin la llave de autenticación.</param>
			/// <returns></returns>
			public static string url(string path)
			{
				return ApiRoot + path;
			}

			/// <summary>
			/// Consume un método API bajo el verbo GET y devuelve la respuesta.
			/// </summary>
			/// <param name="url">URL del método API.</param>
			/// <returns></returns>
			public static dynamic GetApiResponse(string url)
			{
				dynamic json = null;
				HttpWebRequest request = WebRequest.CreateHttp(url);
				request.Method = "GET";
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				{
					using (Stream responseStream = response.GetResponseStream())
					{
						using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
						{
							string responseJson = myStreamReader.ReadToEnd();
							try
							{
								json = JsonConvert.DeserializeObject(responseJson);
							}
							catch
							{
								json = responseJson;
							}
						}
					}
				}
				return json;
			}

			/// <summary>
			/// Consume un método API bajo el verbo POST y devuelve la respuesta.
			/// </summary>
			/// <param name="url">URL del método API.</param>
			/// <param name="postData">Parámetros a enviar.</param>
			/// <returns></returns>
			public static dynamic PostApiResponse(string url, string postData)
			{
				dynamic json = null;
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.ContentType = "application/json; charset=utf-8";
				request.Method = "POST";
				request.Accept = "application/json; charset=utf-8";

				using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
				{
					writer.Write(postData);
					writer.Flush();
					writer.Close();

					using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
					{
						using (Stream responseStream = response.GetResponseStream())
						{
							using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
							{
								string responseJson = myStreamReader.ReadToEnd();
								json = JsonConvert.DeserializeObject(responseJson);
							}
						}
					}
				}
				return json;
			}

			/// <summary>
			/// Consume un método API bajo el verbo PUT y devuelve la respuesta.
			/// </summary>
			/// <param name="url">URL del método API.</param>
			/// <param name="postData">Parámetros a enviar.</param>
			/// <returns></returns>
			public static dynamic PutApiResponse(string url, string postData)
			{
				dynamic json = null;
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.ContentType = "application/json; charset=utf-8";
				request.Method = "PUT";
				request.Accept = "application/json; charset=utf-8";

				using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
				{
					writer.Write(postData);
					writer.Flush();
					writer.Close();

					using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
					{
						using (Stream responseStream = response.GetResponseStream())
						{
							using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
							{
								string responseJson = myStreamReader.ReadToEnd();
								json = JsonConvert.DeserializeObject(responseJson);
							}
						}
					}
				}
				return json;
			}

			/// <summary>
			/// Consume un método API bajo el verbo DELETE y devuelve la respuesta.
			/// </summary>
			/// <param name="url">URL del método API.</param>
			/// <param name="postData">Opcional. Parámetros a enviar.</param>
			/// <returns></returns>
			public static dynamic DeleteApiResponse(string url, string postData = "")
			{
				dynamic json = null;
				HttpWebRequest request = WebRequest.CreateHttp(url);
				request.Method = "DELETE";
				if (postData.Trim() != "")
				{
					using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
					{
						writer.Write(postData);
						writer.Flush();
						writer.Close();

						using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
						{
							using (Stream responseStream = response.GetResponseStream())
							{
								using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
								{
									string responseJson = myStreamReader.ReadToEnd();
									json = JsonConvert.DeserializeObject(responseJson);
								}
							}
						}
					}
				}
				else
				{
					using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
					{
						using (Stream responseStream = response.GetResponseStream())
						{
							using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
							{
								string responseJson = myStreamReader.ReadToEnd();
								json = JsonConvert.DeserializeObject(responseJson);
							}
						}
					}
				}
				return json;
			}
		}

		internal static Types.Common.OperationResult ToOperacion(dynamic json)
		{
			return new Types.Common.OperationResult
			{
				AffectedRows = json.operacion.affectedRows,
				Codigo = json.operacion.codigo.ToOperationCode(),
				Detalle = json.operacion.detalle,
				Mensaje = json.operacion.mensaje,
				NewItemGuid = json.operacion.newItemGuid.ToGuid(),
				NewItemId = json.operacion.newItemId
			};
		}
	}
}
