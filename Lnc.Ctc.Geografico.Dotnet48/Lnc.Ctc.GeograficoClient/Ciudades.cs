namespace Lnc.Ctc.GeograficoClient
{
	public class Ciudades
	{
		public static Types.Common.ComboResult CargaComboCiudades(int PaisId, int EstadoId, int MunicipioId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("ciudades/list/" + PaisId + "/" + EstadoId + "/" + MunicipioId));
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

		public static Types.Common.ComboResult CargaComboCiudadesByEstado(int PaisId, int EstadoId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("ciudades/byestado/" + PaisId + "/" + EstadoId));
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

		public static Types.Common.ComboResult CargaComboCodigosAreaFijos(int PaisId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("ciudades/phonecodes/" + PaisId));
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

		public static Types.Geografico.GetInfoCiudadResult GetInfoCiudad(int CiudadId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("ciudades/get/" + CiudadId));
			Types.Geografico.GetInfoCiudadResult res = new Types.Geografico.GetInfoCiudadResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				res.Info = new Types.Geografico.InfoCiudad
				{
					Ciudad = json.info.ciudad,
					CodigoTelefonico = json.info.codigoTelefonico,
					EstadoId = json.info.estadoId,
					Id = json.info.id,
					MunicipioId = json.info.municipioId,
					PaisId = json.info.paisId,
					UniqueId = json.info.uniqueId,
					ZIP = json.info.zip
				};
			}
			return res;
		}
	}
}
