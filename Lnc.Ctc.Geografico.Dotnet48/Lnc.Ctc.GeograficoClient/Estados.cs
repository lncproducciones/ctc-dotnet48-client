namespace Lnc.Ctc.GeograficoClient
{
	public class Estados
	{
		public static Types.Common.ComboResult CargaComboEstados(int PaisId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("estados/list/" + PaisId));
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

		public static Types.Common.ComboResult CargaComboEstadosRegion(int PaisId, int RegionId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("estados/byregion/" + PaisId + "/" + RegionId));
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

		public static Types.Geografico.GetInfoEstadoResult GetInfoEstado(int EstadoId)
		{
			dynamic json = ApiClient.Common.GetApiResponse(ApiClient.Common.url("estados/get/" + EstadoId));
			Types.Geografico.GetInfoEstadoResult res = new Types.Geografico.GetInfoEstadoResult();
			res.Operacion = ApiClient.ToOperacion(json);
			if (res.Operacion.AffectedRows > 0)
			{
				res.Info = new Types.Geografico.InfoEstado
				{
					Estado = json.info.estado,
					PaisId = json.info.paisId,
					RegionId = json.info.regionId,
					UniqueId = json.info.uniqueId
				};
			}
			return res;
		}
	}
}
