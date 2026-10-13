using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebEmpresa.Api.Models;

// Mapeo a la tabla existente dbo.clientes de Azure SQL.
// [JsonPropertyName] hace que el JSON use los nombres que espera Cliente.razor.
[Table("clientes", Schema = "dbo")]
public class Cliente
{
    [Key]
    [Column("id_cliente")]
    [JsonPropertyName("id_cliente")]
    public int Id { get; set; }

    [Column("cui", TypeName = "varchar(13)")]
    [StringLength(13)]
    public string? CUI { get; set; }

    [Column("nit", TypeName = "varchar(15)")]
    [Required, StringLength(15)]
    public string NIT { get; set; } = "";

    [Column("nombres", TypeName = "varchar(60)")]
    [Required, StringLength(60)]
    public string Nombres { get; set; } = "";

    [Column("apellidos", TypeName = "varchar(60)")]
    [Required, StringLength(60)]
    public string Apellidos { get; set; } = "";

    [Column("direccion", TypeName = "varchar(150)")]
    [StringLength(150)]
    public string? Direccion { get; set; }

    [Column("telefono", TypeName = "varchar(12)")]
    [StringLength(12)]
    public string? Telefono { get; set; }

    [Column("fecha_nacimiento", TypeName = "date")]
    [JsonPropertyName("fecha_nacimiento")]
    public DateTime? FechaNacimiento { get; set; }
}
