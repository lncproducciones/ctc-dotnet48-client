namespace Lnc.Ctc.GeograficoClient
{
	public class Municipios
	{
		public static Types.Common.ComboResult CargaComboMunicipios(int PaisId, int EstadoId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("municipios/list/" + PaisId + "/" + EstadoId));
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

		public static Types.Geografico.GetInfoMunicipioResult GetInfoMunicipio(int MunicipioId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("municipios/get/" + MunicipioId));
			Types.Geografico.GetInfoMunicipioResult res = new Types.Geografico.GetInfoMunicipioResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				res.Info = new Types.Geografico.InfoMunicipio
				{
					EstadoId = json.info.estadoId,
					Id = json.info.id,
					Municipio = json.info.municipio,
					PaisId = json.info.paisId,
					UniqueId = json.info.uniqueId
				};
			}
			return res;
		}
	}
}
