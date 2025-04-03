namespace Lnc.Ctc.GeograficoClient
{
	public class Parroquias
	{
		public static Types.Common.ComboResult CargaComboParroquias(int PaisId, int EstadoId, int MunicipioId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("parroquias/list/" + PaisId + "/" + EstadoId + "/" + MunicipioId));
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

		public static Types.Geografico.GetInfoParroquiaResult GetInfoParroquia(int ParroquiaId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("parroquias/get/" + ParroquiaId));
			Types.Geografico.GetInfoParroquiaResult res = new Types.Geografico.GetInfoParroquiaResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				res.Info = new Types.Geografico.InfoParroquia
				{
					EstadoId = json.info.estadoId,
					Id = json.info.id,
					MunicipioId = json.info.municipioId,
					PaisId = json.info.paisId,
					Parroquia = json.info.parroquia,
					UniqueId = json.info.uniqueId
				};
			}
			return res;
		}
	}
}
