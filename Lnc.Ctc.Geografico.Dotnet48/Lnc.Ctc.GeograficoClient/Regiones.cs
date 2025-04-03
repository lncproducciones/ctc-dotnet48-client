namespace Lnc.Ctc.GeograficoClient
{
	public class Regiones
	{
		public static Types.Common.ComboResult CargaComboRegiones(int PaisId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("regiones/list/" + PaisId));
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

		public static Types.Geografico.GetInfoRegionResult GetInfoRegion(int RegionId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("regiones/get/" + RegionId));
			Types.Geografico.GetInfoRegionResult res = new Types.Geografico.GetInfoRegionResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				res.Info = new Types.Geografico.InfoRegion
				{
					PaisId = json.info.paisId,
					Region = json.info.region,
					UniqueId = json.info.uniqueId
				};
			}
			return res;
		}
	}
}
