using System.Web;

namespace Lnc.Ctc.GeograficoClient
{
	public class Paises
	{
		public static Types.Common.ComboResult CargaComboPaisesByFilter(string filter)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("paises/combofilter/" + HttpUtility.UrlEncode(filter)));
			Types.Common.ComboResult res = new Types.Common.ComboResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				foreach (dynamic item in json.items)
				{
					res.Items.Add(new Types.Common.ComboItem
					{
						Texto = item.texto,
						Valor = item.valor
					});
				}
			}
			return res;
		}

		public static Types.Common.ComboResult CargaComboPaisesMonedas()
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("paises/conmonedas"));
			Types.Common.ComboResult res = new Types.Common.ComboResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				foreach (dynamic item in json.items)
				{
					res.Items.Add(new Types.Common.ComboItem
					{
						Texto = item.texto,
						Valor = item.valor
					});
				}
			}
			return res;
		}

		public static Types.Common.ComboResult CargaComboPaises()
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("paises/list"));
			Types.Common.ComboResult res = new Types.Common.ComboResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				foreach (dynamic item in json.items)
				{
					res.Items.Add(new Types.Common.ComboItem
					{
						Texto = item.texto,
						Valor = item.valor
					});
				}
			}
			return res;
		}

		public static Types.Common.ComboResult CargaComboMonedas()
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("paises/monedas"));
			Types.Common.ComboResult res = new Types.Common.ComboResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				foreach (dynamic item in json.items)
				{
					res.Items.Add(new Types.Common.ComboItem
					{
						Texto = item.texto,
						Valor = item.valor
					});
				}
			}
			return res;
		}

		public static Types.Geografico.GetInfoPaisResult GetInfoPais(int PaisId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("paises/get/" + PaisId));
			Types.Geografico.GetInfoPaisResult res = new Types.Geografico.GetInfoPaisResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				res.Info = new Types.Geografico.InfoPais
				{
					Id = json.info.id,
					ISO = json.info.iso,
					Moneda = json.info.moneda,
					MonedaId = json.info.monedaId,
					MonedaISO = json.info.monedaISO,
					MonedaSimbolo = json.info.monedaSimbolo,
					Pais = json.info.pais
				};
			}
			return res;
		}
	}
}
