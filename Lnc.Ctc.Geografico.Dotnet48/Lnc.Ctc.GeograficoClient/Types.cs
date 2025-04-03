using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Lnc.Ctc.GeograficoClient
{
	public class Types
	{
		public class Enums
		{
			public enum FieldStatuses
			{
				Inactivo = 0,
				Activo = 1,
				Eliminado = 2
			}

			/// <summary>
			/// Contiene los resultados posibles de la ejecución de una rutina.
			/// </summary>
			public enum OperationCodes
			{
				/// <summary>
				/// No se ha ejecutado la operación.
				/// </summary>
				NoEjecuto = -1,
				/// <summary>
				/// La operación se ejecutó exitosamente.
				/// </summary>
				Ok = 0,
				/// <summary>
				/// Ha ocurrido un error al intentar ejecutar la operación.
				/// </summary>
				Error = 1,
				/// <summary>
				/// No se ha autorizado la ejecución del proceso.
				/// </summary>
				Prohibido = 2,
				/// <summary>
				/// Función no implementada
				/// </summary>
				NoImplementado = 3
			}
		}

		public class Common
		{
			public class BooleanResult : ServiceResult
			{
				public bool Resultado { get; set; }

				public BooleanResult()
				{
					Operacion = new OperationResult();
					Resultado = false;
				}
			}

			public class ComboItem
			{
				public string Texto { get; set; }
				public string Valor { get; set; }

				public ComboItem()
				{
					Texto = string.Empty;
					Valor = string.Empty;
				}

				public ComboItem(string texto, string valor)
				{
					Texto = texto;
					Valor = valor;
				}
			}

			public class ComboItemCollection : List<ComboItem> { }

			public class ComboResult : ServiceResult
			{
				public ComboItemCollection Items { get; set; }

				public ComboResult()
				{
					Items = new ComboItemCollection();
					Operacion = new OperationResult();
				}
			}

			public class GuidResult : ServiceResult
			{
				public Guid Resultado { get; set; }

				public GuidResult()
				{
					Operacion = new OperationResult();
					Resultado = Guid.Empty;
				}
			}

			public class IntegerResult : ServiceResult
			{
				public int Resultado { get; set; }

				public IntegerResult()
				{
					Operacion = new OperationResult();
					Resultado = 0;
				}
			}

			public class OperationResult
			{
				public Enums.OperationCodes Codigo { get; set; }
				public int NewItemId { get; set; }
				public Guid NewItemGuid { get; set; }
				public int AffectedRows { get; set; }
				public string Mensaje { get; set; }
				public string Detalle { get; set; }

				public OperationResult()
				{
					Codigo = Enums.OperationCodes.NoEjecuto;
					NewItemGuid = Guid.Empty;
					NewItemId = 0;
					AffectedRows = 0;
					Mensaje = string.Empty;
					Detalle = string.Empty;
				}

				public OperationResult(Exception ex)
				{
					Codigo = Enums.OperationCodes.Error;
					NewItemGuid = Guid.Empty;
					NewItemId = 0;
					AffectedRows = 0;
					Mensaje = ex.Message;
					Detalle = ex.ToString();
				}

				public static OperationResult Prohibido
				{
					get
					{
						return new OperationResult
						{
							Codigo = Enums.OperationCodes.Prohibido,
							NewItemGuid = Guid.Empty,
							NewItemId = 0,
							AffectedRows = 0,
							Mensaje = "Operacion no permitida.",
							Detalle = "No se ha superado el proceso de validacion."
						};
					}
				}
			}

			public class ServiceResult
			{
				public OperationResult Operacion { get; set; }

				public ServiceResult()
				{
					Operacion = new OperationResult();
				}
			}

			public class StringResult : ServiceResult
			{
				public string Resultado { get; set; }

				public StringResult()
				{
					Operacion = new OperationResult();
					Resultado = string.Empty;
				}
			}
		}

		public class Geografico
		{
			public class InfoPais
			{
				#region Private members
				private int id = 0;
				private string iso = "";
				private string pais = "";
				private int monedaId = 0;
				private string monedaIso = "";
				private string moneda = "";
				private string monedaSimbolo = "";
				#endregion

				#region Public members
				public int Id
				{
					get { return id; }
					set { id = value; }
				}
				public string ISO
				{
					get { return iso; }
					set { iso = value; }
				}
				public string Pais
				{
					get { return pais; }
					set { pais = value; }
				}
				public int MonedaId
				{
					get { return monedaId; }
					set { monedaId = value; }
				}
				public string MonedaISO
				{
					get { return monedaIso; }
					set { monedaIso = value; }
				}
				public string Moneda
				{
					get { return moneda; }
					set { moneda = value; }
				}
				public string MonedaSimbolo
				{
					get { return monedaSimbolo; }
					set { monedaSimbolo = value; }
				}
				#endregion
			}

			public class GetInfoPaisResult
			{
				#region Private members
				private Common.OperationResult operacion = new Common.OperationResult();
				private InfoPais info = new InfoPais();
				#endregion

				#region Public members
				public Common.OperationResult Operacion
				{
					get { return operacion; }
					set { operacion = value; }
				}
				public InfoPais Info
				{
					get { return info; }
					set { info = value; }
				}
				#endregion
			}

			public class InfoCiudad
			{
				#region Private members
				private int uniqueId = 0;
				private string ciudad = "";
				private int codigoTelefonico = 0;
				private string zip = "";
				private int municipioId = 0;
				private int estadoId = 0;
				private int paisId = 0;
				private int id = 0;
				#endregion

				#region Public members
				public int UniqueId
				{
					get { return uniqueId; }
					set { uniqueId = value; }
				}
				public string Ciudad
				{
					get { return ciudad; }
					set { ciudad = value; }
				}
				public int CodigoTelefonico
				{
					get { return codigoTelefonico; }
					set { codigoTelefonico = value; }
				}
				public string ZIP
				{
					get { return zip; }
					set { zip = value; }
				}
				public int MunicipioId
				{
					get { return municipioId; }
					set { municipioId = value; }
				}
				public int EstadoId
				{
					get { return estadoId; }
					set { estadoId = value; }
				}
				public int PaisId
				{
					get { return paisId; }
					set { paisId = value; }
				}
				public int Id
				{
					get { return id; }
					set { id = value; }
				}
				#endregion
			}

			public class GetInfoCiudadResult
			{
				#region Private members
				private Common.OperationResult operacion = new Common.OperationResult();
				private InfoCiudad info = new InfoCiudad();
				#endregion

				#region Public members
				public Common.OperationResult Operacion
				{
					get { return operacion; }
					set { operacion = value; }
				}
				public InfoCiudad Info
				{
					get { return info; }
					set { info = value; }
				}
				#endregion
			}

			public class InfoEstado
			{
				#region Private members
				private int uniqueId = 0;
				private string estado = "";
				private int paisId = 0;
				private int regionId = 0;
				#endregion

				#region Public members
				public int UniqueId
				{
					get { return uniqueId; }
					set { uniqueId = value; }
				}
				public string Estado
				{
					get { return estado; }
					set { estado = value; }
				}
				public int PaisId
				{
					get { return paisId; }
					set { paisId = value; }
				}
				public int RegionId
				{
					get { return regionId; }
					set { regionId = value; }
				}
				#endregion
			}

			public class GetInfoEstadoResult
			{
				#region Private members
				private Common.OperationResult operacion = new Common.OperationResult();
				private InfoEstado info = new InfoEstado();
				#endregion

				#region Public members
				public Common.OperationResult Operacion
				{
					get { return operacion; }
					set { operacion = value; }
				}
				public InfoEstado Info
				{
					get { return info; }
					set { info = value; }
				}
				#endregion
			}

			public class InfoParroquia
			{
				#region Private members
				private int uniqueId = 0;
				private string parroquia = "";
				private int id = 0;
				private int municipioId = 0;
				private int estadoId = 0;
				private int paisId = 0;
				#endregion

				#region Public members
				public int UniqueId
				{
					get { return uniqueId; }
					set { uniqueId = value; }
				}
				public string Parroquia
				{
					get { return parroquia; }
					set { parroquia = value; }
				}
				public int Id
				{
					get { return id; }
					set { id = value; }
				}
				public int MunicipioId
				{
					get { return municipioId; }
					set { municipioId = value; }
				}
				public int EstadoId
				{
					get { return estadoId; }
					set { estadoId = value; }
				}
				public int PaisId
				{
					get { return paisId; }
					set { paisId = value; }
				}
				#endregion
			}

			public class GetInfoParroquiaResult
			{
				#region Private members
				private Common.OperationResult operacion = new Common.OperationResult();
				private InfoParroquia info = new InfoParroquia();
				#endregion

				#region Public members
				public Common.OperationResult Operacion
				{
					get { return operacion; }
					set { operacion = value; }
				}
				public InfoParroquia Info
				{
					get { return info; }
					set { info = value; }
				}
				#endregion
			}

			public class InfoMunicipio
			{
				#region Private members
				private int uniqueId = 0;
				private string municipio = "";
				private int id = 0;
				private int estadoId = 0;
				private int paisId = 0;
				#endregion

				#region Public members
				public int UniqueId
				{
					get { return uniqueId; }
					set { uniqueId = value; }
				}
				public string Municipio
				{
					get { return municipio; }
					set { municipio = value; }
				}
				public int Id
				{
					get { return id; }
					set { id = value; }
				}
				public int EstadoId
				{
					get { return estadoId = 0; }
					set { estadoId = value; }
				}
				public int PaisId
				{
					get { return paisId; }
					set { paisId = value; }
				}
				#endregion
			}

			public class GetInfoMunicipioResult
			{
				#region Private members
				private Common.OperationResult operacion = new Common.OperationResult();
				private InfoMunicipio info = new InfoMunicipio();
				#endregion

				#region Public members
				public Common.OperationResult Operacion
				{
					get { return operacion; }
					set { operacion = value; }
				}
				public InfoMunicipio Info
				{
					get { return info; }
					set { info = value; }
				}
				#endregion
			}

			public class InfoRegion
			{
				#region Private members
				private int uniqueId = 0;
				private string region = "";
				private int paisId = 0;
				#endregion

				#region Public members
				public int UniqueId
				{
					get { return uniqueId; }
					set { uniqueId = value; }
				}
				public string Region
				{
					get { return region; }
					set { region = value; }
				}
				public int PaisId
				{
					get { return paisId; }
					set { paisId = value; }
				}
				#endregion
			}

			public class GetInfoRegionResult
			{
				#region Private members
				private Common.OperationResult operacion = new Common.OperationResult();
				private InfoRegion info = new InfoRegion();
				#endregion

				#region Public members
				public Common.OperationResult Operacion
				{
					get { return operacion; }
					set { operacion = value; }
				}
				public InfoRegion Info
				{
					get { return info; }
					set { info = value; }
				}
				#endregion
			}
		}
	}

	public static class Conversion
	{
		public static int ToInt32(this object value)
		{
			return Convert.ToInt32(value);
		}

		public static Guid ToGuid(this object value)
		{
			return Guid.Parse(value.ToString());
		}

		public static bool ToBoolean(this object value)
		{
			return (value.ToInt32() == 1);
		}

		public static int ToTsqlBit(this bool value)
		{
			return (value) ? 1 : 0;
		}

		public static DateTime ToDateTime(this object value)
		{
			return Convert.ToDateTime(value);
		}

		public static Types.Enums.OperationCodes ToOperationCode(this object value)
		{
			switch (value.ToInt32())
			{
				case 3: return Types.Enums.OperationCodes.NoImplementado;
				case 2: return Types.Enums.OperationCodes.Prohibido;
				case 1: return Types.Enums.OperationCodes.Error;
				case 0: return Types.Enums.OperationCodes.Ok;
				default: return Types.Enums.OperationCodes.NoEjecuto;
			}
		}

		public static Types.Enums.OperationCodes ToOperationCode(this JValue value)
		{
			switch (value.ToInt32())
			{
				case 3: return Types.Enums.OperationCodes.NoImplementado;
				case 2: return Types.Enums.OperationCodes.Prohibido;
				case 1: return Types.Enums.OperationCodes.Error;
				case 0: return Types.Enums.OperationCodes.Ok;
				default: return Types.Enums.OperationCodes.NoEjecuto;
			}
		}

		public static Types.Enums.FieldStatuses ToFieldStatus(this object value)
		{
			switch (value.ToInt32())
			{
				case 2: return Types.Enums.FieldStatuses.Eliminado;
				case 1: return Types.Enums.FieldStatuses.Activo;
				default: return Types.Enums.FieldStatuses.Inactivo;
			}
		}

		public static Types.Enums.FieldStatuses ToFieldStatus(this JValue value)
		{
			switch (value.ToInt32())
			{
				case 2: return Types.Enums.FieldStatuses.Eliminado;
				case 1: return Types.Enums.FieldStatuses.Activo;
				default: return Types.Enums.FieldStatuses.Inactivo;
			}
		}
	}
}
